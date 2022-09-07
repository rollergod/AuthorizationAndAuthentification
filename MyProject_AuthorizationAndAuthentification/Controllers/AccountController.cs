using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain;
using MyProject.Domain.ViewModels;
using MyProject.Repotisory;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserContext _userContext;
        public AccountController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userContext.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

                if (user is not null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login);

                if (user is null)
                {
                    user = new User { Login = model.Login, Password = model.Password };
                    Role userRole = await _userContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole is not null)
                    {
                        user.Role = userRole;
                    }

                    _userContext.Users.Add(user);
                    await _userContext.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            return View(model);
        }

        public async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role?.Name)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
