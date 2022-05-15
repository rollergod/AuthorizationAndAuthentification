using MyProject_AuthorizationAndAuthentification.Models.Club;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Services
{
    public interface IGetClubs
    {
        public Task<Club> GetClubs();
    }
}
