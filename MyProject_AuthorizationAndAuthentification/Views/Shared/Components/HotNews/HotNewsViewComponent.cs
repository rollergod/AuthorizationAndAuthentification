using Microsoft.AspNetCore.Mvc;
using MyProject_AuthorizationAndAuthentification.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyProject_AuthorizationAndAuthentification.Views.Shared.Components.HotNews
{
    public class HotNewsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Article> articles)
        {
            articles = articles.Skip(articles.Count() - 5).Take(5).ToList();
            
            return View("Default", articles);
        }
    }
}
