using MyProject_AuthorizationAndAuthentification.Services;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Models.Club
{
    public partial class Club : IGetClubs
    {
        public List<Standing> Standings { get; set; }

        /// <summary>
        /// Метод для получения данных с АПИ.
        /// </summary>
        /// <returns>Возвращает объект Club</returns>
        public async Task<Club> GetClubs()
        {
            var client = new RestClient("https://api.football-data.org/v2/competitions/PL/standings");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            request.AddHeader("X-Auth-Token", "b5c5e4998357484da72349f3c3b2940a");
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = await client.ExecuteAsync(request,cancellationTokenSource.Token);
            var content = response.Content;
            var clubs = JsonConvert.DeserializeObject<Club>(content);

            return clubs;
        }
    }

}
