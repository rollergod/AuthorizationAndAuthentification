using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.ViewModels;
using MyProject.Repotisory;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _userContext;
        private readonly IUserService _userService;

        public UserController(UserContext userContext, IUserService userService)
        {
            _userContext = userContext;
            _userService = userService;
        }

       
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool changedPassword = await _userService.ChangePassword(model.Id,model.NewPassword);
                if (changedPassword)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
           
            return View();
        }
    }
}
