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
using System.Timers;
using System.Drawing;

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
                return PartialView(null);
            }
            else
            {
                List<MonitorViewModel> result = new List<MonitorViewModel>();

                foreach (var item in collection)
                {
                    MonitorViewModel model = this.GetModel(item);

                    result.Add(model);
                }
                return PartialView(result);
            }

        }

        Timer timer = new Timer() { Interval = 2000 };
        // GET: Monitor
        public async Task<IActionResult> Monitor()
        {

            //timer.Elapsed += (l, k) =>
            //  {
            //      this.MonitorCenter();
            //  };


            //timer.Start();

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

        public PartialViewResult MonitorCenter()
        {
            var collection = _context.Moniters.ToList();

            List<MonitorViewModel> result = new List<MonitorViewModel>();

            foreach (var item in collection)
            {
                MonitorViewModel model = this.GetModel(item);

                result.Add(model);
            }

            return PartialView("_MonitorCenter", result);
        }

        Random r = new Random();
        [HttpPost]
        public PartialViewResult RefreshMonitor()
        {
            var collection = _context.Moniters.ToList();

            List<MonitorViewModel> result = new List<MonitorViewModel>();

            foreach (var item in collection)
            {
                int v = r.Next(50, 120);

                MonitorViewModel model = this.GetModel(item);

                model.Heart = "心率：" + r.Next(50, 120).ToString() + "次/分";
                model.Breath = "呼吸：" + r.Next(80, 200).ToString() + "次/分";
                model.FanShen = "体动：" + r.Next(6).ToString() + "分 累计：" + r.Next(12).ToString() + "时/天";
                model.Shuimian = r.Next(3) == 1 ? "睡眠中/睡眠：" + r.Next(8).ToString() + "时" + r.Next(60).ToString() + "分" : "未睡眠";
                model.ZaiChuang = r.Next(3) == 1 ? "离床：" + r.Next(8).ToString() + "时" + r.Next(60).ToString() + "分" : "在床：" + r.Next(8).ToString() + "时" + r.Next(60).ToString() + "分";
                model.Huli = r.Next(3) == 1 ? "中度护理 计划翻身" : "中度护理 间隔翻身";

                if (v > 60 && v < 110)
                {
                    //model.ForeColor = "#252525";
                }
                else if (v < 60)
                {
                    model.ForeColor = "#FFFF00";
                    model.BackColor = "#3300FF";

                    model.Flag = -1;
                }
                else
                {
                    model.ForeColor = "#FFFF00";
                    model.BackColor = "#CC0000";

                    model.Flag = 1;
                }

                result.Add(model);
            }

            //  Message：随机打乱数组
            //Item<MonitorViewModel> models = new Item<MonitorViewModel>(result.ToArray());

            //return PartialView("_MonitorCenter", models.GetDisruptedItems());

            result = result.OrderByDescending(l => l.Flag).ToList(); ;

            return PartialView("_MonitorCenter", result);

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

    //泛型类
    class Item<T>
    {
        T[] item;
        //构造函数
        public Item(T[] obj)
        {
            item = new T[obj.Length];
            for (int i = 0; i < obj.Length; i++)
            {
                item[i] = obj[i];
            }
        }
        public Type ShowType() { return typeof(T); } //返回类型
        public T[] GetItems() { return item; } //返回原数组
                                               //返回打乱顺序后的数组
        public T[] GetDisruptedItems()
        {
            //生成一个新数组：用于在之上计算和返回
            T[] temp;
            temp = new T[item.Length];
            for (int i = 0; i < temp.Length; i++) { temp[i] = item[i]; }
            //打乱数组中元素顺序
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < temp.Length; i++)
            {
                int x, y; T t;
                x = rand.Next(0, temp.Length);
                do
                {
                    y = rand.Next(0, temp.Length);
                } while (y == x);
                t = temp[x];
                temp[x] = temp[y];
                temp[y] = t;
            }
            return temp;
        }
    }
}
