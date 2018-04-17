using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MCQsDesigner.DAL.DAC
{
    public class UserDAC
    {
        public ApplicationDbContext _context;

        public UserDAC(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddFaculty(ApplicationUser User)
        {
            using (_context)
            {
                _context.Users.Add(User);
                _context.SaveChanges();

            }

               
        }


        public void CreateStudent(StudentProfile profile)
        {
                using (_context)
                {
                    _context.StudentProfiles.Add(profile);
                    _context.SaveChanges();

                }
           
        }

        public List<StudentProfile>  GetListOfStudent()
        {
            using (_context)
            {
                var listOfStudents = _context.StudentProfiles.Include(x => x.ApplicationUser).ToList();
                return listOfStudents;
            }

        }


        public void  DeleteUser (string id)
        {
            using (_context)
            {
               var result = _context.Users.Include(x => x.StudentProfile).SingleOrDefault(u => u.Id == id);

                _context.Users.Remove(result);
                

                _context.SaveChanges();
            }
        }



    }
}
