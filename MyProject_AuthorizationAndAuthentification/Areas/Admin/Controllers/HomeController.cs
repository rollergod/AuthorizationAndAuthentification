using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain;
using MyProject.Repotisory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly UserContext _userContext;
        public HomeController(UserContext context)
        {
            _userContext = context;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = await _userContext.Users.Include(u => u.Role).ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            User user = await _userContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is not null)
            {
                _userContext.Users.Remove(user);
                await _userContext.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }
    }
}
