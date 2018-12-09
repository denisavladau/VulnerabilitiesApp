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
    public class UtilizatoriController : Controller
    {
        private readonly VulnerabilitiesAppContext _context;

        public UtilizatoriController(VulnerabilitiesAppContext context)
        {
            _context = context;
        }

        // GET: Utilizatori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizator.ToListAsync());
        }

        // GET: Utilizatori/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizator = await _context.Utilizator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizator == null)
            {
                return NotFound();
            }

            return View(utilizator);
        }

        // GET: Utilizatori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizatori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Telefon,Email,Sters")] Utilizator utilizator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizator);
        }

        // GET: Utilizatori/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizator = await _context.Utilizator.FindAsync(id);
            if (utilizator == null)
            {
                return NotFound();
            }
            return View(utilizator);
        }

        // POST: Utilizatori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nume,Prenume,Telefon,Email,Sters")] Utilizator utilizator)
        {
            if (id != utilizator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizatorExists(utilizator.Id))
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
            return View(utilizator);
        }

        // GET: Utilizatori/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizator = await _context.Utilizator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizator == null)
            {
                return NotFound();
            }

            return View(utilizator);
        }

        // POST: Utilizatori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var utilizator = await _context.Utilizator.FindAsync(id);
            _context.Utilizator.Remove(utilizator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizatorExists(long id)
        {
            return _context.Utilizator.Any(e => e.Id == id);
        }
    }
}
