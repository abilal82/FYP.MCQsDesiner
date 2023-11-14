using MCQsDesigner.BOL;
using MCQsDesigner.DAL;
using MCQsDesigner.Web.App_Start;
using MCQsDesigner.Web.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCQsDesigner.Web.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


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
        [AllowAnonymous]
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
            }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
           

            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var user = _context.Users.ToList().Find(x => x.Email == model.Email);

            if (user != null)
            {

                var result = SignInManager.PasswordSignIn(user.UserName, model.Password, model.RememberMe, shouldLockout: false);
                switch (result)
                {

                        case SignInStatus.Success:
                        if (UserManager.IsInRole(user.Id, "Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (UserManager.IsInRole(user.Id, "Faculty"))
                        {
                            return RedirectToAction("Index", "Faculty");
                        }
                        else if(UserManager.IsInRole(user.Id,"Student"))
                        {
                            return RedirectToAction("Index", "Student");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", "User is assigned role");
                        }


                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                    }

                }
                else
                {
                    ModelState.AddModelError("", " User Not Exists !.");
                    return View(model);
                }


            }

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }





        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result =  UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    
                    var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                     var roleManager = new RoleManager<IdentityRole>(roleStore);
                     roleStore.CreateAsync(new IdentityRole("Admin"));
                     UserManager.AddToRole(user.Id, "Admin");
                    
                    
                    SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("About", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }






        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

      

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }




    }
}