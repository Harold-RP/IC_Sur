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
                // Verificar si el producto ya existe para el proveedor especificado
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductId == storageEntry.ProductId && p.ProviderId == storageEntry.ProviderId);

                if (product != null)
                {
                    // Actualizar el stock sumando la cantidad de la entrada de almacén
                    product.Stock += storageEntry.ProductAmount;

                    // Guardar la actualización del stock del producto
                    _context.Products.Update(product);
                }
                else
                {
                    // Si el producto no existe, aquí puedes manejar el caso o lanzar una advertencia
                    return NotFound("El producto o proveedor no son válidos.");
                }

                // Agregar la entrada de almacén al contexto
                _context.StorageEntries.Add(storageEntry);

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Si el modelo no es válido, volver a la vista con los datos actuales
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
                    // Obtener la entrada de almacén original para calcular la diferencia
                    var originalEntry = await _context.StorageEntries
                        .AsNoTracking()
                        .FirstOrDefaultAsync(se => se.StorageEntryId == id);

                    if (originalEntry == null)
                    {
                        return NotFound();
                    }

                    // Verificar si el producto y proveedor existen
                    var newProduct = await _context.Products
                        .FirstOrDefaultAsync(p => p.ProductId == storageEntry.ProductId && p.ProviderId == storageEntry.ProviderId);

                    if (newProduct == null)
                    {
                        return NotFound("El producto o proveedor no son válidos.");
                    }

                    // Obtener el producto original y su proveedor
                    var originalProduct = await _context.Products
                        .FirstOrDefaultAsync(p => p.ProductId == originalEntry.ProductId && p.ProviderId == originalEntry.ProviderId);

                    if (originalProduct == null)
                    {
                        return NotFound("El producto o proveedor original no son válidos.");
                    }

                    // Calcular la diferencia de cantidad para el producto original
                    var originalQuantityDifference = originalEntry.ProductAmount;

                    // Actualizar el stock del producto original basado en la cantidad eliminada
                    originalProduct.Stock -= originalQuantityDifference;

                    // Si el producto ha cambiado, actualizar el stock del producto nuevo
                    if (originalEntry.ProductId != storageEntry.ProductId || originalEntry.ProviderId != storageEntry.ProviderId)
                    {
                        // Restar la cantidad de stock del producto original
                        _context.Products.Update(originalProduct);

                        // Obtener el producto nuevo para actualizar el stock
                        newProduct.Stock += storageEntry.ProductAmount;

                        // Actualizar el producto nuevo en el contexto
                        _context.Products.Update(newProduct);
                    }
                    else
                    {
                        // Si el producto no ha cambiado, ajustar el stock del producto actual
                        var quantityDifference = storageEntry.ProductAmount - originalEntry.ProductAmount;
                        newProduct.Stock += quantityDifference;
                    }

                    // Actualizar la entrada de almacén con los nuevos datos
                    _context.Entry(originalEntry).CurrentValues.SetValues(storageEntry);
                    _context.StorageEntries.Update(storageEntry);

                    // Guardar los cambios en la base de datos
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
            var storageEntry = await _context.StorageEntries
                .Include(se => se.Product)
                .FirstOrDefaultAsync(se => se.StorageEntryId == id);

            if (storageEntry != null)
            {
                // Obtener el producto y proveedor relacionados con la entrada
                var product = storageEntry.Product;

                // Restar la cantidad del stock del producto
                product.Stock -= storageEntry.ProductAmount;

                // Eliminar la entrada de almacén
                _context.StorageEntries.Remove(storageEntry);
                _context.Products.Update(product);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool StorageEntryExists(int id)
        {
            return _context.StorageEntries.Any(e => e.StorageEntryId == id);
        }
    }
}
