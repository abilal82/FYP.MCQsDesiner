using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCQsDesigner.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            HttpCookie cookie = Request.Cookies[".AspNet.ApplicationCookie"];
            if (cookie != null)
            {
                if(User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin");

                }
                if(User.IsInRole("Faculty"))
                {
                    return RedirectToAction("Index", "Faculty");
                }
                

            }

            return View();

        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}