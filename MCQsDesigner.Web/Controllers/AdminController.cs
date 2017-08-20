using MCQsDesigner.DAL;
using MCQsDesigner.DAL.DAC;
using MCQsDesigner.Web.Models.ViewModel;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace MCQsDesigner.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
      
       

        private CategoryDAC _category = new CategoryDAC();
      
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
       
       

    }
}