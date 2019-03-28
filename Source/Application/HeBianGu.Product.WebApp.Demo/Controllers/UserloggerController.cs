using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.IService;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{
    public class UserloggerController : ControllerBase
    {
        private readonly IUserLoggerRespository _respository;

        public UserloggerController(IUserLoggerRespository respository)
        {
            _respository = respository;
        }

        // GET: Userlogger
        public async Task<IActionResult> Index()
        {
            var result = await _respository.GetLoggers();
            return View(result.OrderByDescending(l=>l.TIME));
        }

        // GET: Userlogger/Details/5
        public async Task<IActionResult> Details(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var ehc_dv_userlogger = await _respository.GetByIDAsync(id)
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (ehc_dv_userlogger == null)
            //{
            //    return NotFound();
            //}

            return View(null);
        }

        // GET: Userlogger/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userlogger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("USERID,TYPE,MESSAGE,TIME,ID")] ehc_dv_userlogger ehc_dv_userlogger)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(ehc_dv_userlogger);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View(ehc_dv_userlogger);
        }

        // GET: Userlogger/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ehc_dv_userlogger = await _respository.GetByIDAsync(id);
            if (ehc_dv_userlogger == null)
            {
                return NotFound();
            }
            return View(ehc_dv_userlogger);
        }

        // POST: Userlogger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("USERID,TYPE,MESSAGE,TIME,ID")] ehc_dv_userlogger ehc_dv_userlogger)
        {
            if (id != ehc_dv_userlogger.ID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(ehc_dv_userlogger);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ehc_dv_userloggerExists(ehc_dv_userlogger.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(ehc_dv_userlogger);
        }

        // GET: Userlogger/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var ehc_dv_userlogger = await _context.ehc_dv_userloggers
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (ehc_dv_userlogger == null)
            //{
            //    return NotFound();
            //}

            return View(null);
        }

        // POST: Userlogger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //var ehc_dv_userlogger = await _context.ehc_dv_userloggers.FindAsync(id);
            //_context.ehc_dv_userloggers.Remove(ehc_dv_userlogger);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
         
    }
}
