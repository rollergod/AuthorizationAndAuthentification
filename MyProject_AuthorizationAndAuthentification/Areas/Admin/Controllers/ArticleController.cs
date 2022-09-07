﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain;
using MyProject.Repotisory;
using MyProject.Service;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly Image _image;
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ArticleController(UserContext context,
                                 IWebHostEnvironment hostEnvironment,
                                 Image image)
        {
            _image = image;
            _hostEnvironment = hostEnvironment;
            _context = context;
        }
        public async Task<IActionResult> Articles()
        {
            return View(await _context.Articles.Include(user => user.User).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article model)
        {
            if (model is not null)
            {
                model.UserId = _context.Users.FirstOrDefault(u => u.Login == User.Identity.Name).Id;

                if (ModelState.IsValid)
                {
                    await _image.CreateImage(model, ImageTypes.Create);

                    await _context.Articles.AddAsync(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Articles));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(article => article.Id == id);
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Article model)
        {
            var files = HttpContext.Request.Form.Files; //получаем файлы из формы

            if (ModelState.IsValid)
            {
                var oldModel = await _context.Articles.FirstOrDefaultAsync(article => article.Id == model.Id);

                oldModel.Title = model.Title;
                oldModel.Description = model.Description;

                if (files.Count > 0)
                {
                    await _image.CreateImage(model, ImageTypes.Update, oldModel);
                }


                _context.Articles.Update(oldModel);
                await _context.SaveChangesAsync();
                return RedirectToRoute("StartPage"); // Home/Index
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(article => article.Id == id);

            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return RedirectToRoute("StartPage");
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _context.Articles.Include(article => article.User)
                .FirstOrDefaultAsync(article => article.Id == id);

            return View("Article", article);
        }
    }
}
