using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigiTrade.Models;

namespace DigiTrade.Controllers
{
    public class Sales_InvoiceController : Controller
    {
        private readonly DigiTradeDBContext _context;

        public Sales_InvoiceController(DigiTradeDBContext context)
        {
            _context = context;
        }

        // GET: Sales_Invoice
        public async Task<IActionResult> Index()
        {
            var digiTradeDBContext = _context.Sales_Invoices.Include(s => s.Customer).Include(s => s.Product);
            return View(await digiTradeDBContext.ToListAsync());
        }

        // GET: Sales_Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales_Invoice = await _context.Sales_Invoices
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.InvoiceNumber == id);
            if (sales_Invoice == null)
            {
                return NotFound();
            }

            return View(sales_Invoice);
        }

        // GET: Sales_Invoice/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerName");
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ProductTitle");
            return View();
        }

        // POST: Sales_Invoice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceNumber,InvoiceDate,CustomerID,ProductID,Qty,Rate")] Sales_Invoice sales_Invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sales_Invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerName", sales_Invoice.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ProductTitle", sales_Invoice.ProductID);
            return View(sales_Invoice);
        }

        // GET: Sales_Invoice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales_Invoice = await _context.Sales_Invoices.FindAsync(id);
            if (sales_Invoice == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerName", sales_Invoice.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ProductTitle", sales_Invoice.ProductID);
            return View(sales_Invoice);
        }

        // POST: Sales_Invoice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceNumber,InvoiceDate,CustomerID,ProductID,Qty,Rate")] Sales_Invoice sales_Invoice)
        {
            if (id != sales_Invoice.InvoiceNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sales_Invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sales_InvoiceExists(sales_Invoice.InvoiceNumber))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CustomerName", sales_Invoice.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ProductTitle", sales_Invoice.ProductID);
            return View(sales_Invoice);
        }

        // GET: Sales_Invoice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales_Invoice = await _context.Sales_Invoices
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.InvoiceNumber == id);
            if (sales_Invoice == null)
            {
                return NotFound();
            }

            return View(sales_Invoice);
        }

        // POST: Sales_Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sales_Invoice = await _context.Sales_Invoices.FindAsync(id);
            _context.Sales_Invoices.Remove(sales_Invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sales_InvoiceExists(int id)
        {
            return _context.Sales_Invoices.Any(e => e.InvoiceNumber == id);
        }
    }
}
