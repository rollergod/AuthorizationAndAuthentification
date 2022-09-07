using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Domain.Club
{
    public partial class Club
    {
        public List<Standing> Standings { get; set; }
    }

}
