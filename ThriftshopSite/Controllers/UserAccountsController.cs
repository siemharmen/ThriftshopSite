using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThriftshopSite.Data;
using ThriftshopSite.Models;


namespace ThriftshopSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserAccountsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserAccounts
        public async Task<IActionResult> Index()
        {
              return _context.UserAccount != null ? 
                          View(await _context.UserAccount.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserAccount'  is null.");
        }
        [AllowAnonymous]
        public async Task<IActionResult> EmployeeAdd()
        {
            return _context.UserAccount != null ?
                        View(await _context.UserAccount.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.UserAccount'  is null.");
        }
        [AllowAnonymous]
        public async Task<IActionResult> AddEmployee(Guid? id, string naam)
        {
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            userAccount.role = UserAccount.Role.Admin;
            IdentityUser user = await _userManager.FindByNameAsync(userAccount.Name);
            await _userManager.AddToRoleAsync(user, "Admin");
            await _context.SaveChangesAsync();

            return RedirectToAction("EmployeeAdd");
            return View();
        }

        // GET: UserAccounts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UserAccount == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // GET: UserAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AssignAdmin1(Guid? id)
        {
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            IdentityUser user = await _userManager.FindByNameAsync(userAccount.Name);
            return View(user);
        }


        //weg
        [HttpPost]
        public async Task<IActionResult> AssignAdmin(Guid? id,string naam)
        {
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            userAccount.role = UserAccount.Role.Admin;
            IdentityUser user = await _userManager.FindByNameAsync(userAccount.Name);
            await _userManager.AddToRoleAsync(user,"Admin");
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            return View();
        }


        /// <summary>
        /// Assigns the user with the Admin role
        /// can only be done by another admin
        /// </summary>
        /// <returns></returns> 
        public async Task<IActionResult> AssignAdmin(Guid? id)
        {
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            userAccount.role = UserAccount.Role.Admin;
            IdentityUser user = await _userManager.FindByNameAsync(userAccount.Name);
            await _userManager.AddToRoleAsync(user,"Admin");
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AssignEmployee(Guid? id,string EmployeeUsername)
        {

            var employeeAccount = await _context.UserAccount.FirstOrDefaultAsync(m => m.Name == EmployeeUsername);
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            IdentityUser user = await _userManager.FindByNameAsync(userAccount.Name);
            await _userManager.AddToRoleAsync(user, "Employee");
            var EthriftShop = await _context.EmployeeThriftShops.FirstOrDefaultAsync(m => m.Account == employeeAccount);
            ThriftShop thriftShop = EthriftShop.ThriftShop;
            if (EthriftShop != null)
            {
                _context.EmployeeThriftShops.Add(new EmployeeThriftshop(userAccount, thriftShop));
            }
            await _context.SaveChangesAsync();

            
            return RedirectToAction(nameof(Index));
        }


        // POST: UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,role")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.Id = Guid.NewGuid();
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.UserAccount == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccount.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,role")] UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.Id))
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
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UserAccount == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.UserAccount == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserAccount'  is null.");
            }
            var userAccount = await _context.UserAccount.FindAsync(id);
            if (userAccount != null)
            {
                _context.UserAccount.Remove(userAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountExists(Guid id)
        {
          return (_context.UserAccount?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
