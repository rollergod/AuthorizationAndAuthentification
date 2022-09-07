using System.Collections.Generic;

namespace MyProject.Domain
{
    public class Role
    {
        /// <summary>
        /// Ид роли
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
