using EcoHelp.BusinessLogic.ViewModels;
using EcoHelp.DataAccess.Model;
using EcoHelp.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace EcoHelp.BusinessLogic.Contexts
{
    public class UserContext
    {
        #region Private Variables
        private readonly UserRepository _userRepository;
        #endregion

        #region Constructors
        public UserContext()
        {
            _userRepository = new UserRepository();
        }
        #endregion

        #region Repository Calls
        /// <summary>
        /// Method to get a specific user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public VMUser GetUserById(int userId)
        {
            User entityObject = _userRepository.GetUserById(userId);
            VMUser viewModelObject = new VMUser(entityObject);

            return viewModelObject;
        }

        /// <summary>
        /// Method to log in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public VMUser Login(string username, string password)
        {
            User entityObject = _userRepository.Login(username, password);
            VMUser viewModelObject = new VMUser(entityObject);

            return viewModelObject;
        }
        #endregion
    }
}
