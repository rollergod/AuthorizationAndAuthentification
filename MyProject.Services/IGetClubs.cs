using MyProject.Domain.Club;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public interface IGetClubs
    {
        public Task<Club> GetClubsFromApi();
    }
}
