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
    public class ProviderOrdersController : Controller
    {
        private readonly IC_Sur_Dbcontext _context;

        public ProviderOrdersController(IC_Sur_Dbcontext context)
        {
            _context = context;
        }

        // GET: ProviderOrders
        public async Task<IActionResult> Index()
        {
            var iC_Sur_Dbcontext = _context.ProviderOrders.Include(p => p.Product).OrderByDescending(a => a.ProviderOrderId);
            return View(await iC_Sur_Dbcontext.ToListAsync());
        }

        // GET: ProviderOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerOrder = await _context.ProviderOrders
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProviderOrderId == id);
            if (providerOrder == null)
            {
                return NotFound();
            }

            return View(providerOrder);
        }

        // GET: ProviderOrders/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            return View();
        }

        // POST: ProviderOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Amount,DateTimeOrder")] ProviderOrder providerOrder)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == providerOrder.ProductId);
                providerOrder.TotalCost = providerOrder.Amount * product.Price;
                _context.Add(providerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            return View(providerOrder);
        }

        // GET: ProviderOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerOrder = await _context.ProviderOrders.FindAsync(id);
            if (providerOrder == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            return View(providerOrder);
        }

        // POST: ProviderOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProviderOrderId,ProductId,Amount,DateTimeOrder,TotalCost")] ProviderOrder providerOrder)
        {
            if (id != providerOrder.ProviderOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(providerOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderOrderExists(providerOrder.ProviderOrderId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            return View(providerOrder);
        }

        // GET: ProviderOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerOrder = await _context.ProviderOrders
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProviderOrderId == id);
            if (providerOrder == null)
            {
                return NotFound();
            }

            return View(providerOrder);
        }

        // POST: ProviderOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var providerOrder = await _context.ProviderOrders.FindAsync(id);
            if (providerOrder != null)
            {
                _context.ProviderOrders.Remove(providerOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviderOrderExists(int id)
        {
            return _context.ProviderOrders.Any(e => e.ProviderOrderId == id);
        }
    }
}
