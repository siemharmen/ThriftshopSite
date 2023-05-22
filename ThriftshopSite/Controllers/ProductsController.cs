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

            List<FileModel> files = _context.Files.Where(a => a.Product.Id == id).ToList();

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

        // GET: Products/Details/5
        public async Task<IActionResult> Add(Guid? id)
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

            List<FileModel> files = _context.Files.Where(a => a.Product.Id == id).ToList();

            List<CategoryProduct> list2 = _context.CategoryProducts.Where(a => a.ProductsId == id).ToList();
            List<Category> listCategory = new List<Category>();
            foreach (CategoryProduct categoryProduct in list2)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(m => m.Name == categoryProduct.CategoriesName);
                listCategory.Add(category);
            }
            ViewData["Categories"] = listCategory;
            return View(product);
        }

        // GET: Products/Create
        /// <summary>
        /// Sends the user to Create products with a guid for the id of product
        /// its also gives a list of thriftshops to the user based on what shops he's a member of
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            UserAccount user = await _context.UserAccount.FirstAsync(m => m.Name == User.Identity.Name);

            IEnumerable<ThriftShop> thriftShops = _context.EmployeeThriftShops.Include(x => x.ThriftShop).Where(entry => entry.Account == user).Select(entry => entry.ThriftShop).AsEnumerable<ThriftShop>();
            ViewData["Categories"] = _context.Categories;
            var Fileid = TempData["ProductsId"];
            ViewData["Thrifshop"] = thriftShops;
            //alles ophalen op basis van ditdan toeveogen aanproduct
            // dan updaten zodat je ze kloppen met de goede productid
            // ViewData["ProductsId"] = productslist;

            ViewData["FileList"] = new List<FileModel>();
            Product product = new Product();
            product.Id = Guid.NewGuid();
            ViewData["Product"] = product;
            return View(); 
        }


        /// <summary>
        /// Creates a new product with a thriftshop
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="inventory"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="image"></param>
        /// <param name="thriftShop"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createshop(Guid id, string name, int inventory, double price, string description, string image, string thriftShop)
        {
            //maak van thriftshop een guid dan zelfde doen dan klaar
            if (ModelState.IsValid)
            {
                var thriftShopfull = await _context.ThriftShops.FirstOrDefaultAsync(m => m.Name == thriftShop);
                Product product = new Product(id, name, inventory, price, description, image, thriftShopfull);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

        /// <summary>
        /// send the player to a view where he can add a category with a list of categories that can be added based on what categories the product already possses.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        public async Task<IActionResult> AddImage(Guid? id)
        {
            ViewData["ProductId"] = id;
            return View();

        }
        
        
        /// <summary>
        /// Adds a category to a product based on a existing category chosen from a list and the id of the product.
        /// </summary>
        /// <param name="categoryProduct"></param>
        /// <returns></returns>
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

            return RedirectToAction("Add", "Products", new { id = categoryProduct.ProductsId });
        }


       

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Inventory,Price,Description,Image,Shop")] Product product)
        {
            //,Category
            //product.Id = Guid.NewGuid();
            //Replace with the thriftshop of the shop worker 

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            
            // try catch block
            //if (product.)
            //{
                
                _context.Add(product);
                //CategoryProduct productCategory = new CategoryProduct(_context.Categories.FirstOrDefault().Name, product.Id);
                //context.Add(productCategory);
                await _context.SaveChangesAsync();

            return RedirectToAction("Add", "Products", new { id = product.Id });
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
