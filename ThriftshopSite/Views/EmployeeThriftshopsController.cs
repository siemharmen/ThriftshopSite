﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThriftshopSite.Data;
using ThriftshopSite.Models;

namespace ThriftshopSite.Views
{
    public class EmployeeThriftshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeThriftshopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeThriftshops
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeThriftShops != null ? 
                          View(await _context.EmployeeThriftShops.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EmployeeThriftShops'  is null.");
        }

        // GET: EmployeeThriftshops/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EmployeeThriftShops == null)
            {
                return NotFound();
            }

            var employeeThriftshop = await _context.EmployeeThriftShops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeThriftshop == null)
            {
                return NotFound();
            }

            return View(employeeThriftshop);
        }

        // GET: EmployeeThriftshops/Create
        public IActionResult Create(Guid? id)
        {
            List<ThriftShop> shoplist = _context.ThriftShops.ToList();
            ViewData["UserAccount"] = id;
            ViewData["ShopList"] = shoplist;
            return View();
        }

        // POST: EmployeeThriftshops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("Id,Account,ThriftShop")] EmployeeThriftshop employeeThriftshop)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(employeeThriftshop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeThriftshop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid userGuid,string thriftShop)
        {
            //maak van thriftshop een guid dan zelfde doen dan klaar
            if (ModelState.IsValid)
            {
                EmployeeThriftshop employeeThriftshop = new EmployeeThriftshop();
                employeeThriftshop.Id = Guid.NewGuid();
                employeeThriftshop.Account = await _context.UserAccount.FirstOrDefaultAsync(m => m.Id == userGuid);
                employeeThriftshop.ThriftShop = await _context.ThriftShops.FirstOrDefaultAsync(m => m.Name == thriftShop); ;
                _context.Add(employeeThriftshop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: EmployeeThriftshops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeThriftShops == null)
            {
                return NotFound();
            }

            var employeeThriftshop = await _context.EmployeeThriftShops.FindAsync(id);
            if (employeeThriftshop == null)
            {
                return NotFound();
            }
            return View(employeeThriftshop);
        }

        // POST: EmployeeThriftshops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] EmployeeThriftshop employeeThriftshop)
        {
            if (id != employeeThriftshop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeThriftshop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeThriftshopExists(employeeThriftshop.Id))
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
            return View(employeeThriftshop);
        }

        // GET: EmployeeThriftshops/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EmployeeThriftShops == null)
            {
                return NotFound();
            }

            var employeeThriftshop = await _context.EmployeeThriftShops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeThriftshop == null)
            {
                return NotFound();
            }

            return View(employeeThriftshop);
        }

        // POST: EmployeeThriftshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.EmployeeThriftShops == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployeeThriftShops'  is null.");
            }
            var employeeThriftshop = await _context.EmployeeThriftShops.FindAsync(id);
            if (employeeThriftshop != null)
            {
                _context.EmployeeThriftShops.Remove(employeeThriftshop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeThriftshopExists(Guid id)
        {
          return (_context.EmployeeThriftShops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
