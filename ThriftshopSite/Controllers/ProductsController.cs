using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThriftshopSite.Data;
using ThriftshopSite.Models;

namespace ThriftshopSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            List<CategoryProduct> list2 = _context.CategoryProducts.Where(a => a.ProductsId == id).ToList();
            List<Category> listCategory= new List<Category>();
            foreach (CategoryProduct categoryProduct in list2)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(m => m.Name == categoryProduct.CategoriesName);
                listCategory.Add(category);
            }
            ViewData["Categories"] = listCategory;
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = _context.Categories;
            return View();
        }

        [HttpPost]
        public ActionResult AddImageFile(Product product,FileModel fileModel)
        {
            try
            {
                product.Files.Add(fileModel);
                return PartialView("_AllTweets", product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Create
        public async Task<IActionResult> AddCategory(Guid? id)
        {
            ViewData["ProductId"] = id;
            List<Category> list1 = _context.Categories.ToList();
            List<CategoryProduct> list2 = _context.CategoryProducts.Where(a => a.ProductsId == id).ToList();
            List<Category> list3 = new List<Category>();
            foreach (CategoryProduct categoryProduct in list2)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(m => m.Name == categoryProduct.CategoriesName);
                list3.Add(category);
            }
            List<Category> list = list1.Except(list3).ToList();
            ViewData["Categories"] =  list;
            return View();

        }

        // adds a category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory([Bind("CategoriesName,ProductsId")] CategoryProduct categoryProduct)
        {
            //,Category
            //product.Id = Guid.NewGuid();
            //Replace with the thriftshop of the shop worker 
            var errors = ModelState.Values.SelectMany(v => v.Errors);


            // try catch block
            //if (product.)
            //{

            _context.Add(categoryProduct);
            //CategoryProduct productCategory = new CategoryProduct(_context.Categories.FirstOrDefault().Name, product.Id);
            //context.Add(productCategory);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
            //}
            return View(categoryProduct);
        }


        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Inventory,Price,Description,Image")] Product product)
        {
            //,Category
            //product.Id = Guid.NewGuid();
            //Replace with the thriftshop of the shop worker 
            product.Shop = _context.ThriftShops.FirstOrDefault();

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            
            // try catch block
            //if (product.)
            //{
                
                _context.Add(product);
                //CategoryProduct productCategory = new CategoryProduct(_context.Categories.FirstOrDefault().Name, product.Id);
                //context.Add(productCategory);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            //}
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Inventory,Price,Description,Image")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
