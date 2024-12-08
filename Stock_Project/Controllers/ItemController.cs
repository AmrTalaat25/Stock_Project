using Microsoft.AspNetCore.Mvc;
using Stock_Project.Models;

namespace Stock_Project.Controllers
{
    public class ItemController : Controller
    {

        private ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            return View(_context.Items.ToList());
        }

        #region Create New Item
        // GET: 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                var newItem = new Item();
                newItem.Name = item.Name;
                newItem.Price = item.Price;
                newItem.Quantity = item.Quantity;


                _context.Items.Add(newItem);
                _context.SaveChanges();

                return RedirectToAction("Get");
            }
            else
                return View(item);
        }
        #endregion

        #region Delete Item
        public IActionResult Delete(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Get");

        }
        #endregion

        #region Update Item
        // GET Store/Update
        public IActionResult Update(int id)
        {
            var item = _context.Items.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(int id, Item item)
        {
            var newItem = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            newItem.Name = item.Name;
            newItem.Price=item.Price;
            newItem.Quantity = item.Quantity;


            _context.SaveChanges();
            return RedirectToAction("Get");
        }
        #endregion
    }
}
