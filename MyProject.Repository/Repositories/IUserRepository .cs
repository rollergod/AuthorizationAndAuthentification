using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ChangePassword(int id,string newPassword);
    }
}
