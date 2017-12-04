using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.DAL.DAC
{
    public class CategoryDAC : IDisposable
    {
        private ApplicationDbContext _context;
        public CategoryDAC()
        {

            _context = new ApplicationDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
              return  _context.Categories.ToList();

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public Category GetById(int id) =>  _context.Categories.Find(id);


        public void InsertCategory( Category category)  
        {
            try
            {

            _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;

            }

            
        
            

        }
        public void DeleteCategory(int id)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(x => x.Id == id);
                _context.Categories.Remove(category);
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
               
            }
           
        }
        public void UpdateCategory(Category category)
        {
            try
            {
            _context.Entry(category).State = EntityState.Modified;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        
    }
}
