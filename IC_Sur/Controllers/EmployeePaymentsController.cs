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
    public class EmployeePaymentsController : Controller
    {
        private readonly IC_Sur_Dbcontext _context;

        public EmployeePaymentsController(IC_Sur_Dbcontext context)
        {
            _context = context;
        }

        // GET: EmployeePayments
        public async Task<IActionResult> Index()
        {
            var iC_Sur_Dbcontext = _context.EmployeePayments
                                  .Include(e => e.Employee)
                                  .ThenInclude(emp => emp.Role)
                                  .OrderByDescending(e => e.EmployeePaymentId);
            return View(await iC_Sur_Dbcontext.ToListAsync());
        }

        // GET: EmployeePayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePayment = await _context.EmployeePayments
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeePaymentId == id);
            if (employeePayment == null)
            {
                return NotFound();
            }

            return View(employeePayment);
        }

        // GET: EmployeePayments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName");
            return View();
        }

        // POST: EmployeePayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Amount,DateTimePayment,Detail,Discount")] EmployeePayment employeePayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", employeePayment.EmployeeId);
            return View(employeePayment);
        }

        public async Task<IActionResult> CreatePayments()
        {
            ViewData["Employees"] = await _context.Employees
                                .Include(e => e.Role)
                                .ToListAsync();
            return View();
        }


        [HttpPost, ActionName("CreatePayments")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePayments()
        {
            var employees = await _context.Employees
                                .Include(e => e.Role)
                                .ToListAsync();
            foreach (var e in employees)
            {
                string detail = Request.Form["detail[" + @e.EmployeeId + "]"].ToString();
                if (detail == "")
                {
                    //ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", assistance.EmployeeId);
                    ViewData["Employees"] = await _context.Employees
                                .Include(e => e.Role)
                                .ToListAsync();
                    ViewData["Error"] = "Es necesario que llene todos los campos";
                    return View();
                    //return RedirectToAction(nameof(CreatePayments));
                }
            }

            foreach (var employee in employees)
            {
                string employeeId = Request.Form["employeeId[" + @employee.EmployeeId + "]"].ToString();
                string amount = Request.Form["amount[" + @employee.EmployeeId + "]"].ToString();
                string date = Request.Form["dateTimePayment[" + @employee.EmployeeId + "]"].ToString();
                string detail = Request.Form["detail[" + @employee.EmployeeId + "]"].ToString();
                string discount = Request.Form["discount[" + @employee.EmployeeId + "]"].ToString();

                double discountedAmount = double.Parse(amount) - double.Parse(discount);

                EmployeePayment ep = new EmployeePayment
                {
                    Amount = discountedAmount,
                    DateTimePayment = DateTime.Parse(date),
                    Detail = detail,
                    Discount = double.Parse(discount),
                    EmployeeId = int.Parse(employeeId)
                };
                _context.Add(ep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: EmployeePayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePayment = await _context.EmployeePayments.FindAsync(id);
            if (employeePayment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", employeePayment.EmployeeId);
            return View(employeePayment);
        }

        // POST: EmployeePayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeePaymentId,EmployeeId,Amount,DateTimePayment,Detail,Discount")] EmployeePayment employeePayment)
        {
            if (id != employeePayment.EmployeePaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePaymentExists(employeePayment.EmployeePaymentId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "LastName", employeePayment.EmployeeId);
            return View(employeePayment);
        }

        // GET: EmployeePayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePayment = await _context.EmployeePayments
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeePaymentId == id);
            if (employeePayment == null)
            {
                return NotFound();
            }

            return View(employeePayment);
        }

        // POST: EmployeePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeePayment = await _context.EmployeePayments.FindAsync(id);
            if (employeePayment != null)
            {
                _context.EmployeePayments.Remove(employeePayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePaymentExists(int id)
        {
            return _context.EmployeePayments.Any(e => e.EmployeePaymentId == id);
        }
    }
}
