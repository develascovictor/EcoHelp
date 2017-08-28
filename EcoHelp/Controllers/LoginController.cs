using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoHelp.BusinessLogic.Contexts;
using EcoHelp.BusinessLogic.ViewModels;

namespace EcoHelp.Controllers
{
    public class LoginController : Controller
    {
        #region Views
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Web Methods
        /// <summary>
        /// Method to login to page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            UserContext userContext = new UserContext();
            VMUser vmUser = userContext.Login(username, password);

            if (vmUser == null || vmUser.Id <= 0)
            {
                //User not found
            }

            else if (!vmUser.IsActive)
            {
                //User not active
            }

            else
            {
                return Json(vmUser);
            }

            return Json(null);
        }
        #endregion
    }
}