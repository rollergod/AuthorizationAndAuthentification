using Microsoft.EntityFrameworkCore;
using MyProject_AuthorizationAndAuthentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Services.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<bool> ChangePassword(int id,string newPassword)
        {

            if(id != 0 || !string.IsNullOrWhiteSpace(newPassword))
            {
                var user = await _userContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                if(user != null)
                {
                    user.Password = newPassword;
                    await _userContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
        
    }
}
