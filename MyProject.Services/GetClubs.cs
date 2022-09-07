using MyProject.Domain.Club;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public class GetClubs : IGetClubs
    {
      
        /// <summary>
        /// Метод для получения данных с АПИ.
        /// </summary>
        /// <returns>Возвращает объект Club</returns>
        public async Task<Club> GetClubsFromApi()
        {
            var client = new RestClient("https://api.football-data.org/v2/competitions/PL/standings");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            request.AddHeader("X-Auth-Token", "b5c5e4998357484da72349f3c3b2940a");
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            var content = response.Content;
            var clubs = JsonConvert.DeserializeObject<Club>(content);

            return clubs;
        }
        
    }
}
