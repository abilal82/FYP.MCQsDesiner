using MCQsDesigner.BOL;
using MCQsDesigner.DAL.DAC;
using MCQsDesigner.Web.Models.ViewModel;
using System.Web.Mvc;

namespace MCQsDesigner.Web.Controllers
{
    [System.Web.Mvc.Authorize]
    public class CategoryController : Controller
    {
        private CategoryDAC _category;
        private DegreeProgramDAC _degree;
        public CategoryController()
        {
            _category = new CategoryDAC();
            _degree = new DegreeProgramDAC();
        }
        protected override void Dispose(bool disposing)
        {
            _category.Dispose();
            base.Dispose(disposing);
        }
        // GET: Category
        [HttpGet]
        public ActionResult ManageCategory()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel model)
        {
           
            _category.InsertCategory(model.Categories);
            return RedirectToAction("ManageCategory");
        }



        //Get : DegreeProgramm
        [HttpGet]
        public ActionResult DegreeProgram()
        {
           
            var model = new DegreeProgramsViewModel()
            {
                Categories = _category.GetAll()
            };
          
            return View(model);
        }

     
        public ActionResult AddDegreeProgram(DegreeProgramsViewModel model)
        {
            var degree = new DegreeProgram()
            {
                ProgramTitle = model.DegreePrograms.ProgramTitle,
                CategoryId = model.DegreePrograms.CategoryId
            };
            _degree.AddDegreeTitle(degree);
            return RedirectToAction("DegreeProgram");
        }

    }
}