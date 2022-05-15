using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject_AuthorizationAndAuthentification.Models;
using MyProject_AuthorizationAndAuthentification.Models.Club;
using MyProject_AuthorizationAndAuthentification.Services;
using MyProject_AuthorizationAndAuthentification.Services.Repositories;

namespace MyProject_AuthorizationAndAuthentification
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserRepository>();
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IGetClubs, Club>();
            services.AddSingleton<Image>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Home/Index";
                });
           
            services.AddControllersWithViews();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(name: "Blog",
                    pattern: "Blog/Article/Create",
                    defaults: new { area = "Admin",controller = "Article", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "GetArticle",
                    pattern: "Blog/Article/{id?}",
                    defaults: new { area = "Admin", controller = "Article", action = "GetArticleById" });

                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "StartPage",
                    pattern: "/",
                    defaults: new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
