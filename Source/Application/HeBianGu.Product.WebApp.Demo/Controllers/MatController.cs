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
    public class MatController : Controller
    {
        private readonly DataContext _context;

        public MatController(DataContext context)
        {
            _context = context;
        }

        // GET: Mat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mats.ToListAsync());
        }

        // GET: Mat/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_MAT = await _context.Mats
                .FirstOrDefaultAsync(m => m.ID== id);
            if (jCSJ_MAT == null)
            {
                return NotFound();
            }

            return View(jCSJ_MAT);
        }

        // GET: Mat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CODE,NAME,SUPPLIER,CDATE,UDATE")] JCSJ_MAT jCSJ_MAT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jCSJ_MAT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jCSJ_MAT);
        }

        // GET: Mat/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_MAT = await _context.Mats.FindAsync(id);
            if (jCSJ_MAT == null)
            {
                return NotFound();
            }
            return View(jCSJ_MAT);
        }

        // POST: Mat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,CODE,NAME,SUPPLIER,CDATE,UDATE")] JCSJ_MAT jCSJ_MAT)
        {
            if (id != jCSJ_MAT.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jCSJ_MAT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JCSJ_MATExists(jCSJ_MAT.ID.ToString()))
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
            return View(jCSJ_MAT);
        }

        // GET: Mat/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_MAT = await _context.Mats
                .FirstOrDefaultAsync(m => m.ID== id);
            if (jCSJ_MAT == null)
            {
                return NotFound();
            }

            return View(jCSJ_MAT);
        }

        // POST: Mat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jCSJ_MAT = await _context.Mats.FindAsync(id);
            _context.Mats.Remove(jCSJ_MAT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JCSJ_MATExists(string id)
        {
            return _context.Mats.Any(e => e.ID== id);
        }
    }
}
