using MCQsDesigner.DAL;
using MCQsDesigner.DAL.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MCQsDesigner.Web.Controllers.API
{
    public class UserServiceController : ApiController
    {

        private UserDAC _userDAC;
        private ApplicationDbContext _context;
        public UserServiceController()
        {
            _context = new ApplicationDbContext();
            _userDAC = new UserDAC(_context);
        }

        [HttpGet]
        public IHttpActionResult GetStudentList()
        {

            var model = _userDAC.GetListOfStudent()
                               .Select(user => new {
                                   user.ApplicationUser.Id,
                                   user.ApplicationUser.Email,
                                   user.ApplicationUser.FirstName,
                                   user.ApplicationUser.UserName,
                                   user.RollNumber,
                                   user.Session
                               });


            return Ok(model);
        }

        public  IHttpActionResult DeleteUser(string id)
        {
            if(id !=null)
            {
                _userDAC.DeleteUser(id);
                return Ok("Deleted Successfully ");
            }
            else
            {
                return BadRequest();
            }
           
        }
    }
}
