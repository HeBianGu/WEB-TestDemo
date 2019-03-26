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
using HeBianGu.Product.Respository.Model;
using HeBianGu.Prodoct.Domain.DataServce;
using HeBianGu.Product.Respository.IService;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{

    /// <summary> 监控配置控制器 </summary>
    public class MonitorController : Controller
    {

        IMonitorSetRespository _respository;

        public MonitorController(IMonitorSetRespository respository)
        {
            _respository = respository;
        }

        /// <summary> 转到监控列表 </summary>
        public async Task<IActionResult> Index()
        {
            var collection = await _respository.GetMonitorList();

            return PartialView(collection);

        }

        /// <summary> 监控列表 </summary>
        public async Task<IActionResult> Monitor()
        {
            var collection = await _respository.GetMonitorList();

            return View(collection);
            
        }

        /// <summary> 监控图标分布视图 </summary>
        public async Task<PartialViewResult> MonitorCenter()
        {
            var collection = await _respository.GetMonitorList();

            return PartialView("_MonitorCenter", collection);
        }
        
        /// <summary>
        /// 局部刷新监控列表分布视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult RefreshMonitor()
        {
            var result = _respository.GetMonitorListTest();

            return PartialView("_MonitorCenter", result.Result);

        }

        
        public async Task<IActionResult> Details(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var jCSJ_MONITOR = await _context.Moniters .FirstOrDefaultAsync(m => m.ID == id);
            //if (jCSJ_MONITOR == null)
            //{
            //    return NotFound();
            //}

            return View(null);
        }

        /// <summary>
        /// 新建监控
        /// </summary>
        // GET: Monitor/Create
        public IActionResult Create()
        {
            this.RefreshDropList();

            return View();
        }


        /// <summary>
        /// 新建监控提交
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
         public async Task<IActionResult> Create(MonitorItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _respository.Create(viewModel);

                return RedirectToAction(nameof(Index));
            }

            this.RefreshDropList();

            return View(viewModel);
        }

        // GET: Monitor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var result = _respository.GetMonitorDeitalByID(id);

            if (result.Result == null)
            {
                return NotFound();
            }

            this.RefreshDropList();

            return View(result.Result);
        }

        /// <summary> 刷新新建下拉列表 </summary>
        void RefreshDropList()
        {
            ViewBag.CustomerList = new SelectList(_respository.GetCurstoms(), "ID", "NAME");
            ViewBag.MatList = new SelectList(_respository.GetMats(), "ID", "NAME");
            ViewBag.BedList = new SelectList(_respository.GetBeds(), "ID", "NAME");
        }

        // POST: Monitor/Edit/5 
        [HttpPost] 
        public async Task<IActionResult> Edit(string id, MonitorItemViewModel viewModel)
        {
            if (id != viewModel.Monitor.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _respository.Edit(viewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_respository.Exist(id).Result)
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
            return View(viewModel);
        }

        // GET: Monitor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _respository.Delete(id);

            return RedirectToAction(nameof(Index));
            
        }
    }
}
