using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TheListController : Controller
    {
        private readonly ListContext _context;

        public TheListController(ListContext context)
        {
            _context = context;
        }

        // GET: TheList
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetItDone.ToListAsync());
        }

        // GET: TheList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theList = await _context.GetItDone
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theList == null)
            {
                return NotFound();
            }

            return View(theList);
        }

        // GET: TheList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,CreatedDate")] TheList theList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theList);
        }

        // GET: TheList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theList = await _context.GetItDone.FindAsync(id);
            if (theList == null)
            {
                return NotFound();
            }
            return View(theList);
        }

        // POST: TheList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,CreatedDate")] TheList theList)
        {
            if (id != theList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheListExists(theList.ID))
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
            return View(theList);
        }

        // GET: TheList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theList = await _context.GetItDone
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theList == null)
            {
                return NotFound();
            }

            return View(theList);
        }

        // POST: TheList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theList = await _context.GetItDone.FindAsync(id);
            _context.GetItDone.Remove(theList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheListExists(int id)
        {
            return _context.GetItDone.Any(e => e.ID == id);
        }
    }
}
