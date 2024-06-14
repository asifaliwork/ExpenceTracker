using ExpenceTracker.Models;
using ExpenceTracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenceTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenceDbContext _db;
        public ExpenseController(ExpenceDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objlist = _db.Expenses;

            foreach(var obj in objlist)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(e => e.Id == obj.ExpenseTypeId);
            }

            return View(objlist);
        }
        // Get Create
        public IActionResult Create()
        {

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };


            return View(expenseVM);
        }
        // Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {
            if (ModelState.IsValid) 
            {  
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(obj);

        }
        // Get Update
        public IActionResult Update(int? Id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };


            if (Id == null)
            {
                return NoContent();
            }
            expenseVM.Expense = _db.Expenses.Find(Id);
            if (expenseVM.Expense == null)
            {
                return NoContent();
            }
            return View(expenseVM);
        }


        // post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Get Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
