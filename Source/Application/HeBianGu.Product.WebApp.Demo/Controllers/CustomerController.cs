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
    public class CustomerController : Controller
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_CUSTOMER = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID== id);
            if (jCSJ_CUSTOMER == null)
            {
                return NotFound();
            }

            return View(jCSJ_CUSTOMER);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NAME,IMAGE,SEX,CARDID,AGE,TEL,INDATE,OUTDATE")] JCSJ_CUSTOMER jCSJ_CUSTOMER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jCSJ_CUSTOMER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jCSJ_CUSTOMER);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_CUSTOMER = await _context.Customers.FindAsync(id);
            if (jCSJ_CUSTOMER == null)
            {
                return NotFound();
            }
            return View(jCSJ_CUSTOMER);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,NAME,IMAGE,SEX,CARDID,AGE,TEL,INDATE,OUTDATE")] JCSJ_CUSTOMER jCSJ_CUSTOMER)
        {
            if (id != jCSJ_CUSTOMER.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jCSJ_CUSTOMER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JCSJ_CUSTOMERExists(jCSJ_CUSTOMER.ID.ToString()))
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
            return View(jCSJ_CUSTOMER);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_CUSTOMER = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID== id);
            if (jCSJ_CUSTOMER == null)
            {
                return NotFound();
            }

            return View(jCSJ_CUSTOMER);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jCSJ_CUSTOMER = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(jCSJ_CUSTOMER);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JCSJ_CUSTOMERExists(string id)
        {
            return _context.Customers.Any(e => e.ID== id);
        }
    }
}
