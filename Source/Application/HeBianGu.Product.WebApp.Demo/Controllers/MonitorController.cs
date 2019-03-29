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
using HeBianGu.Product.General.Tool;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{

    /// <summary> 监控配置控制器 </summary>
    public class MonitorController : ControllerBase
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

        /// <summary>
        /// 局部刷新监控人员信息分布视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public  PartialViewResult ShowCustomer(string id)
        {
            if (!this.CHeckSession())
            {
                _respository.LogInfo("CHeckSession登录超时");
                return null;
            }

            var result = _respository.GetCurstoms();

            var find = result.Where(l => l.ID == id).FirstOrDefault();

            return PartialView("_CustomerView", find);
        }

        /// <summary>
        /// 局部刷新监控人员信息分布视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult ShowRealLine(string id)
        {
            if (!this.CHeckSession())
            {
                _respository.LogInfo("CHeckSession登录超时");
                return null;
            }

           var reult=   this._respository.GetMonitorByID(id);

            return PartialView("_RealLineView", reult.Result);
        }

        [HttpPost]
        public JsonResult RefreshRealLine(string Test1, string Test2)
        {

            var result = _respository.GetRealLineTest().Result;
            //_context.Datas.FromSql("select * from jw_add_data where REGIONCODE='510703101'");

            //limit 50,300

            Func<jw_add_data, string> convertxAxis = l =>
            {
                return l.UDATE.Value.ToString("yyyy-MM-dd");
            };

            Predicate<PropertyInfo> except = l =>
            {
                return l.Name.ToUpper() == "FILETOTAL"
                || l.Name.ToUpper() == "OLDTOTAL"
                || l.Name.ToUpper() == "PERFECTTOTLE"
                || l.Name.ToUpper() == "COUNT"
                || l.Name.ToUpper() == "WOMANRATE"
                || l.Name.ToUpper() == "YEAR"
                || l.Name.ToUpper() == "TYPE";
            };


            List<ReportConvertEngine<jw_add_data, int?>> matchs = new List<ReportConvertEngine<jw_add_data, int?>>();

            var vaildIntCollection = typeof(jw_add_data).GetProperties().ToList().FindAll(l => l.PropertyType == typeof(int?));

            foreach (var item in vaildIntCollection)
            {
                if (except(item)) continue;

                ReportConvertEngine<jw_add_data, int?> engine = new ReportConvertEngine<jw_add_data, int?>();

                engine.Convert = l =>
                {
                    return (int?)item.GetValue(l);
                };

                engine.MatchValue = l => l.HasValue;

                DisplayAttribute display = item.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

                engine.Name = display == null ? item.Name : display.Name;

                engine.Type = "line";

                matchs.Add(engine);
            }

            //convertToValueList.Add(l => l.CDTOTAL);
            //convertToValueList.Add(l => l.CHILDRATE);
            //convertToValueList.Add(l => l.COUNT);
            //convertToValueList.Add(l => l.CYTOTAL);
            //convertToValueList.Add(l => l.DBTOTAL);

            var series = ToolService.Instance.Create(result.ToList(), convertxAxis, matchs.Take(8).ToList());

            return Json(series);
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

                await _respository.WriteUserLogger(this.GetUserID(), "添加监控", viewModel.Monitor.CUSTOMID);

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

                    await _respository.WriteUserLogger(this.GetUserID(), "编辑监控", viewModel.Monitor.CUSTOMID);
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

        // POST: Monitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _respository.Delete(id);

            await _respository.WriteUserLogger(this.GetUserID(), "删除监控", id);

            return RedirectToAction(nameof(Index));
            
        }
    }
}
