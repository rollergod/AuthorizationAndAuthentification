using Microsoft.AspNetCore.Mvc;

namespace MyProject_AuthorizationAndAuthentification.Views.Shared.Components.SearchBar
{
    public class SearchBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(SPager SearchPager)
        {
            return View("Default", SearchPager);
        }
    }
}
