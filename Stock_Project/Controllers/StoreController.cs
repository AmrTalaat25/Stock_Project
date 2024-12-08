using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stock_Project.Dtos;
using Stock_Project.Models;

namespace Stock_Project.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            return View(_context.Stores.ToList());
        }
        #region Create New Store
        // GET: 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                var newStore = new Store();
                newStore.Name = store.Name;
                newStore.Location = store.Location;
                newStore.CreatedDate = DateTime.Now;

                _context.Stores.Add(newStore);
                _context.SaveChanges();

                return RedirectToAction("Get");
            }
            else
                return View(store);
        }
        #endregion

        #region Delete Store
        public IActionResult Delete(int id)
        {
            var store = _context.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            _context.SaveChanges();
             
            return RedirectToAction("Get");

        }
        #endregion

        
        #region Update Store
        // GET Store/Update
        public IActionResult Update(int id)
        {
            var store = _context.Stores.Find(id);
            return View(store);
        }

        [HttpPost]
        public IActionResult Update(int id, Store store)
        {
            var newStore = _context.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }
            newStore.Name = store.Name;
            newStore.Location = store.Location;
            newStore.CreatedDate = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("Get");
        }
        #endregion



        public IActionResult UpdateStock()
        {
            var stores = _context.Stores.ToList();
            var viewModel = new UpdateStockViewModel
            {
                Stores = _context.Stores.Select(s => new storelookup
                {
                    Id = s.StoreId,
                    Name = s.Name,
                    StoreBalanse = s.Balance
                }).ToList(),

                Items = _context.Items.Select(i => new Itemlookup
                {
                    Id = i.ItemId,
                    Name = i.Name,
                    ItemQuantity=i.Quantity
                }).ToList(),
                
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateStock(UpdateStockViewModel model)
        {

            var storeItem = _context.ItemStores
                .FirstOrDefault(si => si.StoreId == model.StoreId && si.ItemId == model.ItemId);

            if (storeItem == null)
            {
                // If no existing stock entry, create a new one
                storeItem = new ItemStore
                {
                    StoreId = model.StoreId,
                    ItemId = model.ItemId,
                    Stock = model.Quantity

                };
                _context.ItemStores.Add(storeItem);
            }
            else
            {
                // Update existing stock
                storeItem.Stock += model.Quantity;
            }
            var store = _context.Stores.FirstOrDefault(s => s.StoreId == model.StoreId);
            if (store != null)
            {
                store.Balance = model.Balance;
            }


            _context.SaveChanges();

            return RedirectToAction("Get"); // Redirect to a stock list page
        }





    }
}
