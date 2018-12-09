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
    public class AnunturiUtilizatoriController : Controller
    {
        private readonly VulnerabilitiesAppContext _context;

        public AnunturiUtilizatoriController(VulnerabilitiesAppContext context)
        {
            _context = context;
        }

        // GET: AnunturiUtilizatori
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnuntUtilizator.ToListAsync());
        }

        // GET: AnunturiUtilizatori/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuntUtilizator = await _context.AnuntUtilizator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anuntUtilizator == null)
            {
                return NotFound();
            }

            return View(anuntUtilizator);
        }

        // GET: AnunturiUtilizatori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnunturiUtilizatori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUtilizator,IdAnunt,Sters")] AnuntUtilizator anuntUtilizator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anuntUtilizator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anuntUtilizator);
        }

        // GET: AnunturiUtilizatori/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuntUtilizator = await _context.AnuntUtilizator.FindAsync(id);
            if (anuntUtilizator == null)
            {
                return NotFound();
            }
            return View(anuntUtilizator);
        }

        // POST: AnunturiUtilizatori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,IdUtilizator,IdAnunt,Sters")] AnuntUtilizator anuntUtilizator)
        {
            if (id != anuntUtilizator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anuntUtilizator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuntUtilizatorExists(anuntUtilizator.Id))
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
            return View(anuntUtilizator);
        }

        // GET: AnunturiUtilizatori/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuntUtilizator = await _context.AnuntUtilizator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anuntUtilizator == null)
            {
                return NotFound();
            }

            return View(anuntUtilizator);
        }

        // POST: AnunturiUtilizatori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var anuntUtilizator = await _context.AnuntUtilizator.FindAsync(id);
            _context.AnuntUtilizator.Remove(anuntUtilizator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuntUtilizatorExists(long id)
        {
            return _context.AnuntUtilizator.Any(e => e.Id == id);
        }
    }
}
