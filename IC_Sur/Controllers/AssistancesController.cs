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
    public class AssistancesController : Controller
    {
        private readonly IC_Sur_Dbcontext _context;

        public AssistancesController(IC_Sur_Dbcontext context)
        {
            _context = context;
        }

        // GET: Assistances
        public async Task<IActionResult> Index()
        {
            var iC_Sur_Dbcontext = _context.Assistances.Include(a => a.Employee).OrderByDescending(a => a.AssistanceId);
            return View(await iC_Sur_Dbcontext.ToListAsync());
        }

        // GET: Assistances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistance = await _context.Assistances
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssistanceId == id);
            if (assistance == null)
            {
                return NotFound();
            }

            return View(assistance);
        }

        // GET: Assistances/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName");
            return View();
        }

        // POST: Assistances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssistanceId,EmployeeId,ArrivalDatetime,ExitDateTime,AssistanceMark")] Assistance assistance)
        {
            if (ModelState.IsValid)
            {
                var assistanceMark = Request.Form["assistanceMark"];
                if (Request.Form["assistanceMark"].ToString() == "")
                {
                    ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", assistance.EmployeeId);
                    return View(assistance);
                }
                _context.Add(assistance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", assistance.EmployeeId);
            return View(assistance);
        }

        // GET: Assistances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistance = await _context.Assistances.FindAsync(id);
            if (assistance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", assistance.EmployeeId);
            return View(assistance);
        }

        // POST: Assistances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssistanceId,EmployeeId,ArrivalDatetime,ExitDateTime,AssistanceMark")] Assistance assistance)
        {
            if (id != assistance.AssistanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssistanceExists(assistance.AssistanceId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", assistance.EmployeeId);
            return View(assistance);
        }

        // GET: Assistances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistance = await _context.Assistances
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssistanceId == id);
            if (assistance == null)
            {
                return NotFound();
            }

            return View(assistance);
        }

        // POST: Assistances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assistance = await _context.Assistances.FindAsync(id);
            if (assistance != null)
            {
                _context.Assistances.Remove(assistance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssistanceExists(int id)
        {
            return _context.Assistances.Any(e => e.AssistanceId == id);
        }
    }
}
