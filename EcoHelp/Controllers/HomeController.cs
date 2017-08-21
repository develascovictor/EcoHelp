using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoHelp.BusinessLogic.Contexts;
using EcoHelp.BusinessLogic.ViewModels;

namespace EcoHelp.Controllers
{
    public class HomeController : Controller
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {

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
        public ActionResult GetCategories()
        {
            CategoryContext categoryContext = new CategoryContext();
            List<VMCategory> categories = categoryContext.GetActiveCategories();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}