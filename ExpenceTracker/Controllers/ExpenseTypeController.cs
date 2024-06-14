using ExpenceTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenceTracker.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ExpenceDbContext _db;
        public ExpenseTypeController(ExpenceDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objlist = _db.ExpenseTypes;

            return View(objlist);
        }
        // Get Create
        public IActionResult Create()
        {
            return View();
        }
        // Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        // Get Update
        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NoContent();
            }
            var item = _db.ExpenseTypes.Find(Id);
            if (item == null)
            {
                return NoContent();
            }
            return View(item);
        }


        // post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
           
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }


        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Get Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.ExpenseTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
