using MyProject_AuthorizationAndAuthentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Services
{
    public interface IUserService
    {
        Task<bool> ChangePassword(int id,string newPassword);
    }
}
