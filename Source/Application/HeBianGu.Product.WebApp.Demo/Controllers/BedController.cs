using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{
    public class BedController : Controller
    {
        private readonly DataContext _context;

        public BedController(DataContext context)
        {
            _context = context;
        }

        // GET: Bed
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beds.ToListAsync());
        }

        // GET: Bed/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_BED = await _context.Beds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jCSJ_BED == null)
            {
                return NotFound();
            }

            return View(jCSJ_BED);
        }

        // GET: Bed/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CODE,NAME,CDATE,UDATE")] JCSJ_BED jCSJ_BED)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jCSJ_BED);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jCSJ_BED);
        }

        // GET: Bed/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_BED = await _context.Beds.FindAsync(id);
            if (jCSJ_BED == null)
            {
                return NotFound();
            }
            return View(jCSJ_BED);
        }

        // POST: Bed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,CODE,NAME,CDATE,UDATE")] JCSJ_BED jCSJ_BED)
        {
            if (id != jCSJ_BED.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jCSJ_BED);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JCSJ_BEDExists(jCSJ_BED.ID))
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
            return View(jCSJ_BED);
        }

        // GET: Bed/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_BED = await _context.Beds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jCSJ_BED == null)
            {
                return NotFound();
            }

            return View(jCSJ_BED);
        }

        // POST: Bed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jCSJ_BED = await _context.Beds.FindAsync(id);
            _context.Beds.Remove(jCSJ_BED);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JCSJ_BEDExists(string id)
        {
            return _context.Beds.Any(e => e.ID == id);
        }
    }
}
