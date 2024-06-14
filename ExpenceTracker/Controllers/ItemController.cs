using ExpenceTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenceTracker.Controllers
{
    public class ItemController : Controller
    {
        private readonly ExpenceDbContext _db;
        public ItemController(ExpenceDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            IEnumerable<Items>  objlist = _db.Items;
            return View(objlist);
        }

        // Get Create
        public IActionResult Create()
        {
            return View();
        }

        // post Craeet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Items obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NoContent();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NoContent();
            }
            return View(item);
        }


        // post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Items obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // Get Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Items.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }       
             _db.Items.Remove(obj);
             _db.SaveChanges();
             return RedirectToAction("Index");
            
        }

    }
}
