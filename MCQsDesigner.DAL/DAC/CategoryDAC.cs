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

        public IEnumerable<Category> GetAll() => _context.Categories.ToList();

        public Category GetById(int id) =>  _context.Categories.Find(id);


        public void InsertCategory( Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

        }
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id ==id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        
    }
}
