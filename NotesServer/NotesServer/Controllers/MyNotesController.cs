using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotesServer.Data;
using NotesServer.Models;

namespace NotesServer.Controllers
{
    public class MyNotesController : Controller
    {
        private readonly NotesServerContext _context;

        public MyNotesController(NotesServerContext context)
        {
            _context = context;
        }

        // GET: MyNotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyNote.ToListAsync());
        }

        // GET: MyNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myNote = await _context.MyNote
                .FirstOrDefaultAsync(m => m.MyNoteId == id);
            if (myNote == null)
            {
                return NotFound();
            }

            return View(myNote);
        }

        // GET: MyNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyNoteId,Title,Description")] MyNote myNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myNote);
        }

        // GET: MyNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myNote = await _context.MyNote.FindAsync(id);
            if (myNote == null)
            {
                return NotFound();
            }
            return View(myNote);
        }

        // POST: MyNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyNoteId,Title,Description")] MyNote myNote)
        {
            if (id != myNote.MyNoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyNoteExists(myNote.MyNoteId))
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
            return View(myNote);
        }

        // GET: MyNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myNote = await _context.MyNote
                .FirstOrDefaultAsync(m => m.MyNoteId == id);
            if (myNote == null)
            {
                return NotFound();
            }

            return View(myNote);
        }

        // POST: MyNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myNote = await _context.MyNote.FindAsync(id);
            _context.MyNote.Remove(myNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyNoteExists(int id)
        {
            return _context.MyNote.Any(e => e.MyNoteId == id);
        }
    }
}
