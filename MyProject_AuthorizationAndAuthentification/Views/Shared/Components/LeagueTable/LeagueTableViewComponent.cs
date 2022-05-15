using Microsoft.AspNetCore.Mvc;
using MyProject_AuthorizationAndAuthentification.Services;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Views.Shared.Components.LeagueTable
{
    public class LeagueTableViewComponent : ViewComponent
    {
        private readonly IGetClubs _clubs;

        public LeagueTableViewComponent(IGetClubs clubs)
        {
            _clubs = clubs;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = new RestClient("https://api.football-data.org/v2/competitions/PL/standings");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("X-Auth-Token", "b5c5e4998357484da72349f3c3b2940a");
            //request.AddHeader("Accept", "application/json");
            //request.RequestFormat = DataFormat.Json;
            //IRestResponse response = client.Execute(request);
            //var content = response.Content;
            //var clubs = JsonConvert.DeserializeObject<Club>(content);
            //return View("Default", clubs);

            return View("Default", await _clubs.GetClubs());
        }
    }
}
