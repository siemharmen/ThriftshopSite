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
    public class ThriftShopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThriftShopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThriftShops
        public async Task<IActionResult> Index()
        {
              return _context.ThriftShops != null ? 
                          View(await _context.ThriftShops.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ThriftShops'  is null.");
        }

        // GET: ThriftShops/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ThriftShops == null)
            {
                return NotFound();
            }

            var thriftShop = await _context.ThriftShops
                .FirstOrDefaultAsync(m => m.Name == id);
            if (thriftShop == null)
            {
                return NotFound();
            }
            ViewData["Products"] = _context.Products.Where(m => m.Shop.Name == id);
            
            return View(thriftShop);
        }

        // GET: ThriftShops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThriftShops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location")] ThriftShop thriftShop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thriftShop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thriftShop);
        }

        // GET: ThriftShops/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ThriftShops == null)
            {
                return NotFound();
            }

            var thriftShop = await _context.ThriftShops.FindAsync(id);
            if (thriftShop == null)
            {
                return NotFound();
            }
            return View(thriftShop);
        }

        // POST: ThriftShops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Location")] ThriftShop thriftShop)
        {
            if (id != thriftShop.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thriftShop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThriftShopExists(thriftShop.Name))
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
            return View(thriftShop);
        }

        // GET: ThriftShops/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ThriftShops == null)
            {
                return NotFound();
            }

            var thriftShop = await _context.ThriftShops
                .FirstOrDefaultAsync(m => m.Name == id);
            if (thriftShop == null)
            {
                return NotFound();
            }

            return View(thriftShop);
        }

        // POST: ThriftShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ThriftShops == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ThriftShops'  is null.");
            }
            var thriftShop = await _context.ThriftShops.FindAsync(id);
            if (thriftShop != null)
            {
                _context.ThriftShops.Remove(thriftShop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThriftShopExists(string id)
        {
          return (_context.ThriftShops?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
