using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Showsatron.Data;
using Showsatron.Models;

namespace Showsatron.Controllers
{
    public class AccountInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AccountInfos.Include(a => a.Platform);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AccountInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInfo = await _context.AccountInfos
                .Include(a => a.Platform)
                .FirstOrDefaultAsync(m => m.AccountInfoId == id);
            if (accountInfo == null)
            {
                return NotFound();
            }

            return View(accountInfo);
        }

        // GET: AccountInfoes/Create
        public IActionResult Create()
        {
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "Name");
            return View();
        }

        // POST: AccountInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountInfoId,SubscriptionPrice,PlatformId")] AccountInfo accountInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "Name", accountInfo.PlatformId);
            return View(accountInfo);
        }

        // GET: AccountInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInfo = await _context.AccountInfos.FindAsync(id);
            if (accountInfo == null)
            {
                return NotFound();
            }
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "Name", accountInfo.PlatformId);
            return View(accountInfo);
        }

        // POST: AccountInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountInfoId,SubscriptionPrice,PlatformId")] AccountInfo accountInfo)
        {
            if (id != accountInfo.AccountInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountInfoExists(accountInfo.AccountInfoId))
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
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "Name", accountInfo.PlatformId);
            return View(accountInfo);
        }

        // GET: AccountInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInfo = await _context.AccountInfos
                .Include(a => a.Platform)
                .FirstOrDefaultAsync(m => m.AccountInfoId == id);
            if (accountInfo == null)
            {
                return NotFound();
            }

            return View(accountInfo);
        }

        // POST: AccountInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountInfo = await _context.AccountInfos.FindAsync(id);
            _context.AccountInfos.Remove(accountInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountInfoExists(int id)
        {
            return _context.AccountInfos.Any(e => e.AccountInfoId == id);
        }
    }
}
