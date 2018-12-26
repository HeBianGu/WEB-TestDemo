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
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_USEACCOUNT = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jCSJ_USEACCOUNT == null)
            {
                return NotFound();
            }

            return View(jCSJ_USEACCOUNT);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NAME,PASSWORD,STATE,TYPE")] JCSJ_USEACCOUNT jCSJ_USEACCOUNT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jCSJ_USEACCOUNT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jCSJ_USEACCOUNT);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_USEACCOUNT = await _context.Users.FindAsync(id);
            if (jCSJ_USEACCOUNT == null)
            {
                return NotFound();
            }
            return View(jCSJ_USEACCOUNT);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,NAME,PASSWORD,STATE,TYPE")] JCSJ_USEACCOUNT jCSJ_USEACCOUNT)
        {
            if (id != jCSJ_USEACCOUNT.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jCSJ_USEACCOUNT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JCSJ_USEACCOUNTExists(jCSJ_USEACCOUNT.ID))
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
            return View(jCSJ_USEACCOUNT);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_USEACCOUNT = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jCSJ_USEACCOUNT == null)
            {
                return NotFound();
            }

            return View(jCSJ_USEACCOUNT);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jCSJ_USEACCOUNT = await _context.Users.FindAsync(id);
            _context.Users.Remove(jCSJ_USEACCOUNT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JCSJ_USEACCOUNTExists(string id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
