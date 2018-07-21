using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTE_Test_Helper.Models;

namespace PTE_Test_Helper.Controllers
{
    public class ROController : Controller
    {
        private readonly PTE_Test_HelperContext _context;

        public ROController(PTE_Test_HelperContext context)
        {
            _context = context;
        }

        // GET: RO
        public async Task<IActionResult> Index()
        {
            return View(await _context.RO.ToListAsync());
        }

        // GET: RO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rO = await _context.RO
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rO == null)
            {
                return NotFound();
            }

            return View(rO);
        }

        // GET: RO/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,IsComplete,CreateDate,UpdateDate")] RO rO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rO);
        }

        // GET: RO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rO = await _context.RO.SingleOrDefaultAsync(m => m.ID == id);
            if (rO == null)
            {
                return NotFound();
            }
            return View(rO);
        }

        // POST: RO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,IsComplete,CreateDate,UpdateDate")] RO rO)
        {
            if (id != rO.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ROExists(rO.ID))
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
            return View(rO);
        }

        // GET: RO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rO = await _context.RO
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rO == null)
            {
                return NotFound();
            }

            return View(rO);
        }

        // POST: RO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rO = await _context.RO.SingleOrDefaultAsync(m => m.ID == id);
            _context.RO.Remove(rO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ROExists(int id)
        {
            return _context.RO.Any(e => e.ID == id);
        }
    }
}
