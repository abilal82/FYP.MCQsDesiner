using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.DAL.DAC
{
    public class UserDAC
    {
        public ApplicationDbContext _context;

        public UserDAC()
        {
            _context = new ApplicationDbContext();
        }

        public void CreateUser(StudentProfile profile)
        {
            try
            {
                using (_context)
                {
                    _context.StudentProfiles.Add(profile);
                    _context.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



    }
}
