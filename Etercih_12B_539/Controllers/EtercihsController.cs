using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Etercih_12B_539.Models;

namespace Etercih_12B_539.Controllers
{
    public class EtercihsController : Controller
    {
        private readonly EtercihVtContext _context;

        public EtercihsController(EtercihVtContext context)
        {
            _context = context;
        }

        // GET: Etercihs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etercihs.ToListAsync());
        }

        // GET: Etercihs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etercih = await _context.Etercihs
                .FirstOrDefaultAsync(m => m.EtercihId == id);
            if (etercih == null)
            {
                return NotFound();
            }

            return View(etercih);
        }

        // GET: Etercihs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etercihs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtercihId,KullaniciId,SecenekId,Zaman,Aciklama")] Etercih etercih)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etercih);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etercih);
        }

        // GET: Etercihs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etercih = await _context.Etercihs.FindAsync(id);
            if (etercih == null)
            {
                return NotFound();
            }
            return View(etercih);
        }

        // POST: Etercihs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtercihId,KullaniciId,SecenekId,Zaman,Aciklama")] Etercih etercih)
        {
            if (id != etercih.EtercihId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etercih);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtercihExists(etercih.EtercihId))
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
            return View(etercih);
        }

        // GET: Etercihs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etercih = await _context.Etercihs
                .FirstOrDefaultAsync(m => m.EtercihId == id);
            if (etercih == null)
            {
                return NotFound();
            }

            return View(etercih);
        }

        // POST: Etercihs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etercih = await _context.Etercihs.FindAsync(id);
            if (etercih != null)
            {
                _context.Etercihs.Remove(etercih);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtercihExists(int id)
        {
            return _context.Etercihs.Any(e => e.EtercihId == id);
        }
    }
}
