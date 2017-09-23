using System.Collections.Generic;
using EcoHelp.BusinessLogic.ViewModels;

namespace EcoHelp.BusinessLogic.Contexts
{
    public class CurrentUserContext
    {
        #region Variables
        /// <summary>
        /// Current user
        /// </summary>
        public readonly VMUser CurrentUser;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public CurrentUserContext()
        {
            UserContext userContext = new UserContext();
            CurrentUser = userContext.GetUserById(8);
        }
        #endregion

        #region Validations
        /// <summary>
        /// Method to validate if current user in session is valid
        /// </summary>
        /// <param name="role">Minimum role required to access</param>
        /// <param name="userRole">Only the specified role or higher ranking can pass the validation</param>
        public void ValidateCurrentUser(Roles role, ref List<string> validationList)
        {
            if (CurrentUser == null)
            {
                validationList.Add("Current User not found.");
            }

            else if (CurrentUser.Id <= 0)
            {
                validationList.Add("Invalid Current User ID.");
            }
            
            else if (!CurrentUser.IsActive)
            {
                validationList.Add("Current User is not active.");
            }

            else if ((Roles)CurrentUser.Role.Id == Roles.Undefined)
            {
                validationList.Add("Current User has an undefined role.");
            }

            else if (CurrentUser.Role.Id > (int)role)
            {
                validationList.Add("Current User is not allowed to access.");
            }
        }
        #endregion
    }
}