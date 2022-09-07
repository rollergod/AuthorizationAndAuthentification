using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Repotisory;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Search(string articleSearch)
        {
            var articles = await _context.Articles.ToListAsync();
            if (!string.IsNullOrEmpty(articleSearch))
            {
                articles = articles.Where(a => a.Title.Contains(articleSearch)).ToList();
            }
            return View(articles);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            //Получаем статьи, также получаем пользователя, который создал статью
            //сортируем по самым новым
            var articles = await _context.Articles.Include(a => a.User).Include(a => a.User.Role)
                .OrderByDescending(article => article.CreateDate).ToListAsync();

            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);

            ViewBag.CurrentRole = currentUser.Role.Name;

            //HotNews
            ViewBag.Articles = articles;
            return View(articles);
        }



    }
}
