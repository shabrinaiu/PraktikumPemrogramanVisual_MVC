using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbumRent_MVC.Models;

namespace AlbumRent_MVC.Controllers
{
    public class RentTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentTransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentTransactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        // GET: RentTransactions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentTransaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentTransaction == null)
            {
                return NotFound();
            }

            return View(rentTransaction);
        }

        // GET: RentTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Date,AlbumId,StatusRent")] RentTransaction rentTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentTransaction);
        }

        // GET: RentTransactions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentTransaction = await _context.Transactions.FindAsync(id);
            if (rentTransaction == null)
            {
                return NotFound();
            }
            return View(rentTransaction);
        }

        // POST: RentTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Date,AlbumId,StatusRent")] RentTransaction rentTransaction)
        {
            if (id != rentTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentTransactionExists(rentTransaction.Id))
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
            return View(rentTransaction);
        }

        // GET: RentTransactions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentTransaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentTransaction == null)
            {
                return NotFound();
            }

            return View(rentTransaction);
        }

        // POST: RentTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rentTransaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(rentTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentTransactionExists(string id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
