using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IC_Sur.Data;
using IC_Sur.Models;

namespace IC_Sur.Controllers
{
    public class StorageEntriesController : Controller
    {
        private readonly IC_Sur_Dbcontext _context;

        public StorageEntriesController(IC_Sur_Dbcontext context)
        {
            _context = context;
        }

        // GET: StorageEntries
        public async Task<IActionResult> Index()
        {
            var iC_Sur_Dbcontext = _context.StorageEntries.Include(s => s.Product).Include(s => s.Provider);
            return View(await iC_Sur_Dbcontext.ToListAsync());
        }

        // GET: StorageEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageEntry = await _context.StorageEntries
                .Include(s => s.Product)
                .Include(s => s.Provider)
                .FirstOrDefaultAsync(m => m.StorageEntryId == id);
            if (storageEntry == null)
            {
                return NotFound();
            }

            return View(storageEntry);
        }

        // GET: StorageEntries/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            ViewData["ProviderId"] = new SelectList(_context.Providers, "ProviderId", "Name");
            return View();
        }

        // POST: StorageEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StorageEntryId,EntryDateTime,ProductId,ProviderId,ProductAmount")] StorageEntry storageEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storageEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", storageEntry.ProductId);
            ViewData["ProviderId"] = new SelectList(_context.Providers, "ProviderId", "Name", storageEntry.ProviderId);
            return View(storageEntry);
        }

        // GET: StorageEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageEntry = await _context.StorageEntries.FindAsync(id);
            if (storageEntry == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", storageEntry.ProductId);
            ViewData["ProviderId"] = new SelectList(_context.Providers, "ProviderId", "Name", storageEntry.ProviderId);
            return View(storageEntry);
        }

        // POST: StorageEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StorageEntryId,EntryDateTime,ProductId,ProviderId,ProductAmount")] StorageEntry storageEntry)
        {
            if (id != storageEntry.StorageEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storageEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageEntryExists(storageEntry.StorageEntryId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", storageEntry.ProductId);
            ViewData["ProviderId"] = new SelectList(_context.Providers, "ProviderId", "Name", storageEntry.ProviderId);
            return View(storageEntry);
        }

        // GET: StorageEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageEntry = await _context.StorageEntries
                .Include(s => s.Product)
                .Include(s => s.Provider)
                .FirstOrDefaultAsync(m => m.StorageEntryId == id);
            if (storageEntry == null)
            {
                return NotFound();
            }

            return View(storageEntry);
        }

        // POST: StorageEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storageEntry = await _context.StorageEntries.FindAsync(id);
            if (storageEntry != null)
            {
                _context.StorageEntries.Remove(storageEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageEntryExists(int id)
        {
            return _context.StorageEntries.Any(e => e.StorageEntryId == id);
        }
    }
}
