using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject_AuthorizationAndAuthentification.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        UserContext _db;
        public HomeController(UserContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = await _db.Users.Include(u => u.Role).ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is not null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }
    }
}
