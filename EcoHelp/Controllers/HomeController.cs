using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using EcoHelp.BusinessLogic.Contexts;
using EcoHelp.BusinessLogic.ViewModels;
using EcoHelp.Utilities;

namespace EcoHelp.Controllers
{
    public class HomeController : Controller
    {
        #region Variables
        /// <summary>
        /// Current user
        /// </summary>
        private readonly CurrentUserContext _currentUserContext;

        /// <summary>
        /// List used for validations
        /// </summary>
        private List<string> _validationsList;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {
            _currentUserContext = new CurrentUserContext();
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
        /// Method to get all data for main page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageData()
        {
            JsonResponse jsonResponse;
            _currentUserContext.ValidateCurrentUser(Roles.Station, ref _validationsList);

            if (!_validationsList.Any())
            {
                CategoryContext categoryContext = new CategoryContext();
                ContactContext contactContext = new ContactContext();

                List<VMContact> supervisors = new List<VMContact>();
                List<VMContact> supportTechnicians = new List<VMContact>();
                List<VMContact> developers = contactContext.GetActiveDeveloperContacts();
                List<VMCategory> categories = categoryContext.GetActiveCategories();

                switch ((Roles)_currentUserContext.CurrentUser.Role.Id)
                {
                    case Roles.Developer:
                        {
                            break;
                        }

                    case Roles.SupportTechnician:
                    case Roles.Supervisor:
                    case Roles.Station:
                        {
                            supervisors = contactContext.GetActiveSupervisorContactsByZoneId(_currentUserContext.CurrentUser.AllowedStations[0].ZoneId);
                            supportTechnicians = contactContext.GetActiveSupportTechnicianContactsByZoneId(_currentUserContext.CurrentUser.AllowedStations[0].ZoneId);
                            break;
                        }
                }

                jsonResponse = new JsonResponse(true, new { CurrentUser = _currentUserContext.CurrentUser, Supervisors = supervisors, SupportTechnicians = supportTechnicians, Developers = developers, Categories = categories });
                JsonResult jsonResult = Json(jsonResponse, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }

            jsonResponse = new JsonResponse(false, _validationsList);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Method to get all causes from a specific issue
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCausesByIssueId(int issueId)
        {
            JsonResponse jsonResponse;
            _currentUserContext.ValidateCurrentUser(Roles.Station, ref _validationsList);

            if (!_validationsList.Any())
            {
                //TODO: Add validation for issue ID

                CauseContext causeContext = new CauseContext();
                List<VMCause> causes = causeContext.GetActiveCausesByIssueId(issueId);

                jsonResponse = new JsonResponse(true, new { Causes = causes });
                JsonResult jsonResult = Json(jsonResponse);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }

            jsonResponse = new JsonResponse(false, _validationsList);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}