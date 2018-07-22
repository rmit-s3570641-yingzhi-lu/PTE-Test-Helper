using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTE_Test_Helper.Models;

namespace PTE_Test_Helper.Controllers
{
    public class ParagraphsController : Controller
    {
        private readonly PTE_Test_HelperContext _context;

        public ParagraphsController(PTE_Test_HelperContext context)
        {
            _context = context;
        }

        // GET: Paragraphs
        public async Task<IActionResult> Index(int? pid)
        {
            var currentArticle = _context.Paragraphs.Select(x => x);
            var roContent = await _context.RO.Select(x => x).ToListAsync();
            if (pid > roContent.Last().ArticleId)
            {
                pid = roContent.First().ArticleId;
                currentArticle = currentArticle.Where(x => x.ParentId == pid);
            }
            else
            {
                currentArticle = currentArticle.Where(x => x.ParentId == pid);
            }

            return View(await currentArticle.ToListAsync());
        }

        // GET: Paragraphs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragraph = await _context.Paragraphs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (paragraph == null)
            {
                return NotFound();
            }

            return View(paragraph);
        }

        // GET: Paragraphs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paragraphs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ParentId,Content,Location")] Paragraph paragraph)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paragraph);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paragraph);
        }

        // GET: Paragraphs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragraph = await _context.Paragraphs.SingleOrDefaultAsync(m => m.ID == id);
            if (paragraph == null)
            {
                return NotFound();
            }
            return View(paragraph);
        }

        // POST: Paragraphs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ParentId,Content,Location")] Paragraph paragraph)
        {
            if (id != paragraph.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paragraph);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParagraphExists(paragraph.ID))
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
            return View(paragraph);
        }

        // GET: Paragraphs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragraph = await _context.Paragraphs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (paragraph == null)
            {
                return NotFound();
            }

            return View(paragraph);
        }

        // POST: Paragraphs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paragraph = await _context.Paragraphs.SingleOrDefaultAsync(m => m.ID == id);
            _context.Paragraphs.Remove(paragraph);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParagraphExists(int id)
        {
            return _context.Paragraphs.Any(e => e.ID == id);
        }
    }
}
