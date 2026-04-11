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
    public class Post1Controller : Controller
    {
        private readonly AppDbContext _context;

        public Post1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Post1
        public async Task<IActionResult> Index()
        {
              return _context.Record_1 != null ? 
                          View(await _context.Record_1.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Record_1'  is null.");
        }

        // GET: Post1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Record_1 == null)
            {
                return NotFound();
            }

            var post1 = await _context.Record_1
                .FirstOrDefaultAsync(m => m.id == id);
            if (post1 == null)
            {
                return NotFound();
            }

            return View(post1);
        }

        // GET: Post1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,artist,genre,release_date,url,uploader,description,upload_date,imagePath1,imagePath2,imagePath3,approbation")] Post1 post1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post1);
        }

        // GET: Post1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Record_1 == null)
            {
                return NotFound();
            }

            var post1 = await _context.Record_1.FindAsync(id);
            if (post1 == null)
            {
                return NotFound();
            }
            return View(post1);
        }

        // POST: Post1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,artist,genre,release_date,url,uploader,description,upload_date,imagePath1,imagePath2,imagePath3,approbation")] Post1 post1)
        {
            if (id != post1.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Post1Exists(post1.id))
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
            return View(post1);
        }

        // GET: Post1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Record_1 == null)
            {
                return NotFound();
            }

            var post1 = await _context.Record_1
                .FirstOrDefaultAsync(m => m.id == id);
            if (post1 == null)
            {
                return NotFound();
            }

            return View(post1);
        }

        // POST: Post1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Record_1 == null)
            {
                return Problem("Entity set 'AppDbContext.Record_1'  is null.");
            }
            var post1 = await _context.Record_1.FindAsync(id);
            if (post1 != null)
            {
                _context.Record_1.Remove(post1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Post1Exists(int id)
        {
          return (_context.Record_1?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
