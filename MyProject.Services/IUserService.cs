using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service
{
    public interface IUserService
    {
        Task<bool> ChangePassword(int id,string newPassword);
    }
}
