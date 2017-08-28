using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using EcoHelp.BusinessLogic.Contexts;
using EcoHelp.BusinessLogic.ViewModels;

namespace EcoHelp.Controllers
{
    public class HomeController : Controller
    {
        #region Variables
        /// <summary>
        /// Current user
        /// </summary>
        private readonly VMUser _currentUser;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {
            UserContext userContext = new UserContext();
            _currentUser = userContext.GetUserById(8);
        }
        #endregion

        #region Views
        public ActionResult Index()
        {
            if (HttpContext.Request.Url != null)
            {
                // Generate the correct path for services to call
                string url = HttpContext.Request.Url.AbsolutePath;

                if (url.Last() != '/')
                {
                    url += "/";
                }

                //If URL contains path, redirect to same action again to remove path on URL
                if (url.ToLower().EndsWith("home/index/", StringComparison.Ordinal))
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Url = url;
            }

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
            return Json(null);
        }

        /// <summary>
        /// Method to get all data for main page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageData()
        {
            CategoryContext categoryContext = new CategoryContext();
            ContactContext contactContext = new ContactContext();

            List<VMCategory> categories = categoryContext.GetActiveCategories();


            List<VMContact> supervisors = new List<VMContact>();

            if (_currentUser == null || _currentUser.Id <= 0)
            {
                //User not found
            }

            else if (!_currentUser.IsActive)
            {
                //User not active
            }

            else
            {

                switch ((Roles)_currentUser.Role.Id)
                {
                    case Roles.Developer:
                        {
                            break;
                        }

                    case Roles.SupportTechnician:
                        {
                            break;
                        }

                    case Roles.Supervisor:
                        {
                            break;
                        }

                    case Roles.Station:
                        {
                            supervisors = contactContext.GetSupervisorContactsByZoneId(_currentUser.AllowedStations[0].ZoneId);
                            break;
                        }
                }
            }

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Method to get all causes from a specific issue
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCausesByIssueId(int issueId)
        {
            CauseContext causeContext = new CauseContext();
            List<VMCause> causes = causeContext.GetActiveCausesByIssueId(issueId);

            return Json(causes);
        }
        #endregion
    }
}