using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPOO2.Data;
using PPOO2.Models;

namespace PPOO2.Controllers
{
    public class Item1Controller : Controller
    {
        private readonly AppDbContext _context;

        public Item1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Item1
        public async Task<IActionResult> Index()
        {
              return _context.Items1 != null ? 
                          View(await _context.Items1.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Items1'  is null.");
        }

        // GET: Item1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items1 == null)
            {
                return NotFound();
            }

            var item1 = await _context.Items1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item1 == null)
            {
                return NotFound();
            }

            return View(item1);
        }

        // GET: Item1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,desc,n1,IsAvailable")] Item1 item1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item1);
        }

        // GET: Item1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items1 == null)
            {
                return NotFound();
            }

            var item1 = await _context.Items1.FindAsync(id);
            if (item1 == null)
            {
                return NotFound();
            }
            return View(item1);
        }

        // POST: Item1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,desc,n1,IsAvailable")] Item1 item1)
        {
            if (id != item1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item1Exists(item1.Id))
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
            return View(item1);
        }

        // GET: Item1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items1 == null)
            {
                return NotFound();
            }

            var item1 = await _context.Items1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item1 == null)
            {
                return NotFound();
            }

            return View(item1);
        }

        // POST: Item1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Items1 == null)
            {
                return Problem("Entity set 'AppDbContext.Items1'  is null.");
            }
            var item1 = await _context.Items1.FindAsync(id);
            if (item1 != null)
            {
                _context.Items1.Remove(item1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Item1Exists(int id)
        {
          return (_context.Items1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
