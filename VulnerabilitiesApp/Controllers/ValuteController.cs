﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VulnerabilitiesApp.Models;

namespace VulnerabilitiesApp.Controllers
{
    public class ValuteController : Controller
    {
        private readonly VulnerabilitiesAppContext _context;

        public ValuteController(VulnerabilitiesAppContext context)
        {
            _context = context;
        }

        // GET: Valute
        public async Task<IActionResult> Index()
        {
            return View(await _context.Valuta.ToListAsync());
        }

        // GET: Valute/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valuta = await _context.Valuta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valuta == null)
            {
                return NotFound();
            }

            return View(valuta);
        }

        // GET: Valute/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Valute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume")] Valuta valuta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valuta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(valuta);
        }

        // GET: Valute/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valuta = await _context.Valuta.FindAsync(id);
            if (valuta == null)
            {
                return NotFound();
            }
            return View(valuta);
        }

        // POST: Valute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nume")] Valuta valuta)
        {
            if (id != valuta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valuta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValutaExists(valuta.Id))
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
            return View(valuta);
        }

        // GET: Valute/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valuta = await _context.Valuta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valuta == null)
            {
                return NotFound();
            }

            return View(valuta);
        }

        // POST: Valute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var valuta = await _context.Valuta.FindAsync(id);
            _context.Valuta.Remove(valuta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValutaExists(long id)
        {
            return _context.Valuta.Any(e => e.Id == id);
        }
    }
}
