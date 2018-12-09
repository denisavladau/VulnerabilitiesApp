using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VulnerabilitiesApp.Models;

namespace VulnerabilitiesApp.Controllers
{
    public class AnunturiController : Controller
    {
        private readonly VulnerabilitiesAppContext _context;

        public AnunturiController(VulnerabilitiesAppContext context)
        {
            _context = context;
        }

        // GET: Anunturi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anunt.ToListAsync());
        }

        // GET: Anunturi/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anunt = await _context.Anunt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anunt == null)
            {
                return NotFound();
            }

            return View(anunt);
        }

        // GET: Anunturi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anunturi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titlu,Data,Descriere,IdCategorie,IdSubCategorie,Pret,IdValuta,Activ,Sters")] Anunt anunt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anunt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anunt);
        }

        // GET: Anunturi/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anunt = await _context.Anunt.FindAsync(id);
            if (anunt == null)
            {
                return NotFound();
            }
            return View(anunt);
        }

        // POST: Anunturi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Titlu,Data,Descriere,IdCategorie,IdSubCategorie,Pret,IdValuta,Activ,Sters")] Anunt anunt)
        {
            if (id != anunt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anunt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuntExists(anunt.Id))
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
            return View(anunt);
        }

        // GET: Anunturi/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anunt = await _context.Anunt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anunt == null)
            {
                return NotFound();
            }

            return View(anunt);
        }

        // POST: Anunturi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var anunt = await _context.Anunt.FindAsync(id);
            _context.Anunt.Remove(anunt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuntExists(long id)
        {
            return _context.Anunt.Any(e => e.Id == id);
        }
    }
}
