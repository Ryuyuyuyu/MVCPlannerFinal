﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCPlannerFinal.Data;
using MVCPlannerFinal.Models;

namespace MVCPlannerFinal.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Visitors
        public async Task<IActionResult> Index()
        {
              return _context.Visitors != null ? 
                          View(await _context.Visitors.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Visitors'  is null.");
        }

        // GET: Visitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors
                .FirstOrDefaultAsync(m => m.VisitorID == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // GET: Visitors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitorID,FirstName,LastName,Email,PhoneNumber,DateOfBirth,PasswordHash")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitorID,FirstName,LastName,Email,PhoneNumber,DateOfBirth,PasswordHash")] Visitor visitor)
        {
            if (id != visitor.VisitorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorExists(visitor.VisitorID))
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
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors
                .FirstOrDefaultAsync(m => m.VisitorID == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Visitors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Visitors'  is null.");
            }
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor != null)
            {
                _context.Visitors.Remove(visitor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorExists(int id)
        {
          return (_context.Visitors?.Any(e => e.VisitorID == id)).GetValueOrDefault();
        }
    }
}
