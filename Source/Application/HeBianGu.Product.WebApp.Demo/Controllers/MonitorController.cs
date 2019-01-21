using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.WebApp.Demo.Models;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{
    public class MonitorController : Controller
    {
        private readonly DataContext _context;

        public MonitorController(DataContext context)
        {
            _context = context;
        }

        // GET: Monitor
        public async Task<IActionResult> Index()
        {
            var collection = await _context.Moniters.ToListAsync();

            if (collection == null)
            {
                return View(null);
            }
            else
            {
                List<MonitorViewModel> result = new List<MonitorViewModel>();

                foreach (var item in collection)
                {
                    MonitorViewModel model = this.GetModel(item);

                    result.Add(model);
                }
                return View(result);
            }
        }

        // GET: Monitor
        public async Task<IActionResult> Monitor()
        {
            var collection = await _context.Moniters.ToListAsync();

            if (collection == null)
            {
                return View(null);
            }
            else
            {
                List<MonitorViewModel> result = new List<MonitorViewModel>();

                foreach (var item in collection)
                {
                    MonitorViewModel model = this.GetModel(item);

                    result.Add(model);
                }
                return View(result);
            }
        }

        MonitorViewModel GetModel(JCSJ_MONITOR monitor)
        {
            MonitorViewModel model = new MonitorViewModel();
            model.ID = monitor.ID;
            var r = _context.Customers.Where(l => l.ID == monitor.CUSTOMID);

            if (r != null && r.Count() > 0)
            {
                model.Customer = r.First();
            }

            var b = _context.Beds.Where(l => l.ID == monitor.BEDID);

            if (b != null && b.Count() > 0)
            {
                model.Bed = b.First();
            }

            var m = _context.Mats.Where(l => l.ID == monitor.MATID);

            if (m != null && m.Count() > 0)
            {
                model.Mat = m.First();
            }

            return model;
        }

        // GET: Monitor/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_MONITOR = await _context.Moniters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jCSJ_MONITOR == null)
            {
                return NotFound();
            }

            return View(jCSJ_MONITOR);
        }

        // GET: Monitor/Create
        public IActionResult Create()
        {
            this.RefreshDropList();

            return View();
        }

        // POST: Monitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,BEDID,MATID,CUSTOMID,TIMEPLANID,HEARTID,BREATHID,CDATE,UDATE")] JCSJ_MONITOR jCSJ_MONITOR)
        public async Task<IActionResult> Create([Bind("ID,BEDID,MATID,CUSTOMID,TIMEPLANID,HEARTID,BREATHID,CDATE,UDATE")] JCSJ_MONITOR jCSJ_MONITOR)
        {
            //JCSJ_MONITOR jcsj_monitor = new JCSJ_MONITOR();
            //jcsj_monitor.ID = Guid.NewGuid().ToString();
            //jcsj_monitor.CUSTOMID = monitor.Customer?.ID;

            //if (string.IsNullOrEmpty(monitor.Customer?.ID))
            //{
            //    return this.Create();
            //}
            //else
            //{
            //    _context.Add(jcsj_monitor);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            if (ModelState.IsValid)
            {
                _context.Add(jCSJ_MONITOR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            this.RefreshDropList();

            return View(jCSJ_MONITOR);
        }



        // GET: Monitor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_MONITOR = await _context.Moniters.FindAsync(id);

            if (jCSJ_MONITOR == null)
            {
                return NotFound();
            }

            this.RefreshDropList();

            return View(jCSJ_MONITOR);
        }

        void RefreshDropList()
        {
            ViewBag.CustomerList = new SelectList(_context.Customers, "ID", "NAME");
            ViewBag.MatList = new SelectList(_context.Mats, "ID", "NAME");
            ViewBag.BedList = new SelectList(_context.Beds, "ID", "NAME");
        }

        // POST: Monitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,BEDID,MATID,CUSTOMID,TIMEPLANID,HEARTID,BREATHID,CDATE,UDATE")] JCSJ_MONITOR jCSJ_MONITOR)
        {
            if (id != jCSJ_MONITOR.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jCSJ_MONITOR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JCSJ_MONITORExists(jCSJ_MONITOR.ID))
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
            return View(jCSJ_MONITOR);
        }

        // GET: Monitor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jCSJ_MONITOR = await _context.Moniters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jCSJ_MONITOR == null)
            {
                return NotFound();
            }

            return View(jCSJ_MONITOR);
        }

        // POST: Monitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jCSJ_MONITOR = await _context.Moniters.FindAsync(id);
            _context.Moniters.Remove(jCSJ_MONITOR);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JCSJ_MONITORExists(string id)
        {
            return _context.Moniters.Any(e => e.ID == id);
        }
    }
}
