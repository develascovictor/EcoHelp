using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using EcoHelp.DataAccess.Model;

namespace EcoHelp.DataAccess.Repositories
{
    public class UserRepository : Repository
    {
        /// <summary>
        /// Method to get a specific user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(int userId)
        {
            User user = Db.Users
                .Include(u => u.Contact)
                .FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        /// <summary>
        /// Method to log in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string username, string password)
        {
            User user = Db.Users
                .Include(u => u.Contact)
                .FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }
    }
}