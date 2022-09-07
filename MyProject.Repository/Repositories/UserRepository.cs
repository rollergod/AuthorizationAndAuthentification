using Microsoft.EntityFrameworkCore;
using MyProject.Repotisory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        /// <summary>
        /// Смена пароля у пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns>True - смена пароля / False - ошибка</returns>
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
