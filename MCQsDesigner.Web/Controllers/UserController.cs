using MCQsDesigner.BOL;
using MCQsDesigner.DAL.DAC;
using MCQsDesigner.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MCQsDesigner.DAL;
using Microsoft.AspNet.Identity.Owin;
using MCQsDesigner.Web.App_Start;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MCQsDesigner.Web.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private UserDAC _user ;

        //public ApplicationDbContext DbConetxt
        //{
        //    get
        //    {
        //        return _context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
        //    }
        //    set { _context = value; }
        //}




        public ApplicationSignInManager SignInManager
        {
            get
            {

                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public UserController()
        {
            _context = new ApplicationDbContext();
           _user = new UserDAC(_context);
        }

        // GET: Student
        [HttpGet]
        public ActionResult ManageStudent()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult AddStudentInfo(StudentViewModel model)
        {
            
            var userName = "@" + model.FirstName + model.LastName;

            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser() {
                    Email = model.Email,
                    UserName = userName,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = UserManager.Create(appUser, model.Password);

               

                if (result.Succeeded)
                {
                    var roleStore = new RoleStore<IdentityRole>(_context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    if (roleManager.RoleExists("Student"))
                    {
                        UserManager.AddToRole(appUser.Id, "Student");
                        StudentProfile StdProfile = new StudentProfile()
                        {
                            UserId = appUser.Id,
                            RollNumber = model.RollNumber,
                            Session = model.Session
                        };

                        _user.CreateStudent(StdProfile);
                    }
                    else
                    {
                        roleStore.CreateAsync(new IdentityRole("Student"));
                        UserManager.AddToRole(appUser.Id, "Student");
                        StudentProfile StdProfile = new StudentProfile()
                        {
                            UserId = appUser.Id,
                            RollNumber = model.RollNumber,
                            Session = model.Session
                        };

                        _user.CreateStudent(StdProfile);
                    }


                }
                     return View("ManageStudent");

               
            }
            else
            {
               // model.ExistenceMsge = "Student Already Exist! please try another one.";

                return View("ManageStudent",model);

            }

        }

            
        [HttpGet]
        public ActionResult ManageFaculty()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult AddFacultyInfo(FacultyViewModel viewModel)
        {
            var userName = "@" + viewModel.FirstName + viewModel.LastName;

            if (ModelState.IsValid)
            {
                var appUser= new ApplicationUser()
                {
                    Email = viewModel.Email,
                    UserName = userName,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                };
                var result = UserManager.Create(appUser,viewModel.Password);

                if(result.Succeeded)
                {
                    var roleStore = new RoleStore<IdentityRole>(_context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    if(roleManager.RoleExists(viewModel.Role))
                    {
                        UserManager.AddToRole(appUser.Id,viewModel.Role);
                    }
                    else
                    {
                        roleStore.CreateAsync(new IdentityRole(viewModel.Role));
                        // Role property define in FacultyViewModel and Values are assigned in ManageFaculty.cshtml view statically  
                        UserManager.AddToRole(appUser.Id, viewModel.Role);
                    }
                }

                


            }
            else
            {
                return View("ManageFaculty",viewModel);
            }

            return RedirectToAction("ManageFaculty");
        }




        }
    }
