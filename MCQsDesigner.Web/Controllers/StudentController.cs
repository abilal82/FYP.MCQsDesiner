using MCQsDesigner.DAL.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCQsDesigner.Web.Controllers
{
    public class StudentController : Controller
    {
        UserDAC _userDAC; 
        public StudentController()
        {
            _userDAC = new UserDAC();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
    }
}