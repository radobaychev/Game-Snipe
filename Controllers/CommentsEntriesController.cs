using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameSnipe.Data;
using GameSnipe.Models;

namespace GameSnipe.Controllers
{
    public class CommentsEntriesController : Controller
    {
        private readonly GameSnipeContext _context;

        public CommentsEntriesController(GameSnipeContext context)
        {
            _context = context;
        }

        // GET: CommentsEntries
        public async Task<IActionResult> Index()
        {
              return View(await _context.CommentsEntry.ToListAsync());
        }

        // GET: CommentsEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CommentsEntry == null)
            {
                return NotFound();
            }

            var commentsEntry = await _context.CommentsEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentsEntry == null)
            {
                return NotFound();
            }

            return View(commentsEntry);
        }

        // GET: CommentsEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommentsEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usernameame,Message,DateAdded")] CommentsEntry commentsEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentsEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commentsEntry);
        }

        // GET: CommentsEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CommentsEntry == null)
            {
                return NotFound();
            }

            var commentsEntry = await _context.CommentsEntry.FindAsync(id);
            if (commentsEntry == null)
            {
                return NotFound();
            }
            return View(commentsEntry);
        }

        // POST: CommentsEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usernameame,Message,DateAdded")] CommentsEntry commentsEntry)
        {
            if (id != commentsEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentsEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsEntryExists(commentsEntry.Id))
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
            return View(commentsEntry);
        }

        // GET: CommentsEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CommentsEntry == null)
            {
                return NotFound();
            }

            var commentsEntry = await _context.CommentsEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentsEntry == null)
            {
                return NotFound();
            }

            return View(commentsEntry);
        }

        // POST: CommentsEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CommentsEntry == null)
            {
                return Problem("Entity set 'GameSnipeContext.CommentsEntry'  is null.");
            }
            var commentsEntry = await _context.CommentsEntry.FindAsync(id);
            if (commentsEntry != null)
            {
                _context.CommentsEntry.Remove(commentsEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentsEntryExists(int id)
        {
          return _context.CommentsEntry.Any(e => e.Id == id);
        }
    }
}
