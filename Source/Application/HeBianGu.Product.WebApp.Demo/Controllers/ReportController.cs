using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using System.Dynamic;
using Newtonsoft.Json;
using HeBianGu.Prodoct.Domain.DataServce;
using HeBianGu.Product.General.Tool;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq.Expressions;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{
    public class ReportController : Controller
    {
        private readonly DataContext _context;

        public ReportController(DataContext context)
        {
            _context = context;
        }

        // GET: Report
        public async Task<IActionResult> Index()
        {
            var result = _context.Datas.FromSql("select * from jw_add_data limit 0, 50");
            return View(result);

            //return View(await _context.Datas.ToListAsync());
        }

        // GET: Report
        public async Task<IActionResult> RegionDetial()
        {
            var result = _context.Datas.FromSql("select * from jw_add_data limit 0, 50");
            return View(result);

            //return View(await _context.Datas.ToListAsync());
        }


        /// <summary>

        /// 返回Echarts的option数据

        /// </summary> 

        /// <returns></returns>

        [HttpPost]
        public JsonResult RegionDetial(string Test1, string Test2)
        {

            var result = _context.Datas.FromSql("select * from jw_add_data where REGIONCODE='510703101'");

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



            var series = DataService.Instance.Create(result.ToList(), convertxAxis, matchs.Take(8).ToList());

            return Json(series);

            ////  Do：生成x坐标
            //List<string> pxAxis = new List<string>();

            //foreach (var c in result)
            //{
            //    if (!pxAxis.Contains(c.UDATE.Value.ToShortDateString()))
            //    {
            //        pxAxis.Add(convertxAxis(c));
            //    }
            //}

            ////  Do：根据属性动态生成数据
            //foreach (var x in pxAxis)
            //{
            //    //  Do：获取当前天的数据
            //    var find = result.Where(l => convertxAxis(l) == x);

            //    //  Do：根据定义规则动态加载到数据集合
            //    if (find.Count() > 0)
            //    {
            //        foreach (var item in convertToValueList)
            //        {
            //            int? c = item.Convert(find.First());

            //            if (c.HasValue)
            //            {
            //                item.Datas.Add(c.Value);
            //            }
            //        }
            //    }
            //}

            //List<string> Legend = new List<string>();//展示名称 如['成绩一','成绩二']


            //List<dynamic> pseries = convertToValueList.Select(l => l.ToDynamic()).ToList();

            //return Json(new
            //{
            //    xAxis = new { data = pxAxis.ToArray() },
            //    legend = new { data = Legend.ToArray() },
            //    series = pseries
            //});


            //foreach (var func in convertToValueList)
            //{
            //    dynamic dynamic = new ExpandoObject();

            //    dynamic.name = "ttt";

            //    dynamic.type = "line";

            //    List<int> pdata = new List<int>();

            //    //  Do：根据属性动态生成数据
            //    foreach (var x in pxAxis)
            //    {
            //        //  Do：获取当前天的数据
            //        var find = result.Where(l => convertxAxis(l) == x);

            //        //  Do：根据定义规则动态加载到数据集合
            //        if (find.Count() > 0)
            //        {
            //            int? c = func(find.First());

            //            if (c.HasValue)
            //            {
            //                pdata.Add(func(find.First()).Value);
            //            }
            //        }
            //    }

            //    dynamic.data = pdata.ToArray();

            //    pseries.Add(dynamic);
            //}



            ////  Do：分数据组

            //List<IGrouping<string, jw_add_data>> pSeries = new List<IGrouping<string, jw_add_data>>();

            //pSeries = result.GroupBy(x => x.REGIONCODE).ToList();

            //dynamic sp;//一个动态的类，省得要去定义Model，.NET4.0以上支持

            //List<dynamic> LL = new List<dynamic>();//Y轴上折现的数值列表[1,2,3,4,5]这样

            //List<int> LV = new List<int>(); ;//每个Y轴上的数值
            //List<int> LV1 = new List<int>(); ;//每个Y轴上的数值



            ////便利循环得到名称和每个名称的所有值

            //foreach (IGrouping<string, jw_add_data> s in pSeries)
            //{

            //    Legend.Add(s.Key);

            //    List<jw_add_data> CL = new List<jw_add_data>();

            //    //得到此名称下的查询到的所有信息，并取得值

            //    CL = result.Where(x => x.REGIONCODE == s.Key).OrderBy(x => x.UDATE).ToList();

            //    foreach (string day in pxAxis)
            //    {
            //        //根据天数生成X轴底部说明，并且在当前日期没有值的Y轴上的数据进行补0操作

            //        jw_add_data DayChance = new jw_add_data();

            //        DayChance = CL.Where(x => x.REGIONCODE == s.Key && x.UDATE.Value.ToShortDateString() == day).FirstOrDefault();

            //        if (DayChance == null)
            //        {
            //            LV.Add(0);
            //            LV1.Add(0);
            //        }
            //        else
            //        {
            //            LV.Add(Decimal.ToInt32((decimal)DayChance.CMPRATE));
            //            LV1.Add(Decimal.ToInt32((decimal)DayChance.CHILDRATE));
            //        }
            //    }

            //    sp = new ExpandoObject();

            //    sp.name = s.Key;

            //    sp.type = "line";

            //    sp.data = LV.ToArray();

            //    LL.Add(sp);

            //    sp = new ExpandoObject();

            //    sp.name = s.Key;

            //    sp.type = "line";

            //    sp.data = LV1.ToArray();

            //    LL.Add(sp);
            //}


            //return Json(new
            //{
            //    xAxis = new { data = pxAxis.ToArray() },
            //    legend = new { data = Legend.ToArray() },
            //    series = LL
            //});
        }


        public IActionResult RegionTotal()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegionTotalPost()
        {

            var result = _context.Datas.FromSql("select * from jw_add_data where LENGTH(REGIONCODE)=6");

            //List<ReportGroupEngine<jw_add_data, int?>> reportGroupEngines = new List<ReportGroupEngine<jw_add_data, int?>>();

            //ReportGroupEngine<jw_add_data, int?> report = new ReportGroupEngine<jw_add_data, int?>();

            //report.GroupBy = l => l.Max(k=>k.OLDTOTAL);
            //report.MatchValue = l => l.HasValue;
            //report.Name = "一";

            //reportGroupEngines.Add(report);

            //ReportGroupEngine<jw_add_data, int?> report1 = new ReportGroupEngine<jw_add_data, int?>();

            //report1.GroupBy = l => l.Max(k => k.HYTENTOTAL);
            //report1.MatchValue = l => l.HasValue;
            //report1.Name = "二";

            //reportGroupEngines.Add(report1);

            List<ReportGroupEngine<jw_add_data, double?>> allMacthType = new List<ReportGroupEngine<jw_add_data, double?>>();

            ReportGroupEngine<jw_add_data, double?> report = new ReportGroupEngine<jw_add_data, double?>();
            report.GroupBy = l => l.Max(k => k.CDTOTAL);
            //report.MatchValue = l => l.HasValue;
            report.Name = "0-6岁儿童建档总数(Max)";
            report.Type = "bar";
            allMacthType.Add(report);

            report = new ReportGroupEngine<jw_add_data, double?>();
            report.GroupBy = l => l.Min(k => k.CDTOTAL);
            //report.MatchValue = l => l.HasValue;
            report.Name = "0-6岁儿童建档总数(Min)";
            report.Type = "bar";
            allMacthType.Add(report);

            report = new ReportGroupEngine<jw_add_data, double?>();
            report.GroupBy = l => l.Average(k => k.CDTOTAL);
            //report.MatchValue = l => l.HasValue;
            report.Name = "0-6岁儿童建档总数(Average)";
            report.Type = "bar";
            allMacthType.Add(report);

            report = new ReportGroupEngine<jw_add_data, double?>();
            report.GroupBy = l => l.Count();
            //report.MatchValue = l => l.HasValue;
            report.Name = "0-6岁儿童建档总数(Count)";
            report.Type = "bar";
            allMacthType.Add(report);

            //Expression<Func<jw_add_data, int?>> ex;

            //typeof(jw_add_data).GetProperties().ToList().Find(l=>l.Name==)

            //var properties = typeof(jw_add_data).GetProperties().ToList().FindAll(l => l.PropertyType == typeof(int?));

            //foreach (var item in properties)
            //{

            //    ReportGroupEngine<jw_add_data, int?> engine = new ReportGroupEngine<jw_add_data, int?>();

            //    engine.GroupBy = l => l.Max(k => k.OLDTOTAL);

            //    DisplayAttribute display = item.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            //    engine.Name = display == null ? item.Name : display.Name;

            //    engine.Type = "line";

            //    //  Do：如果字段取值为null不添加值
            //    engine.MatchValue = l => l.HasValue;

            //    allMacthType.Add(engine);
            //}


            var json = DataService.Instance.GroupBy(result, l => l.ORGNAME, allMacthType.ToArray());

            return Json(json);

            var groups = result.GroupBy(l => l.ORGNAME);

            List<string> pxAxis = new List<string>();

            foreach (var c in groups)
            {
                string v = c.Key;

                if (!pxAxis.Contains(v))
                {
                    pxAxis.Add(v);
                }
            }


            List<dynamic> collection = new List<dynamic>();

            dynamic dynamic = new ExpandoObject();

            dynamic.name = "0-6岁儿童建档总数汇总";

            dynamic.type = "line";

            List<int> datas = new List<int>();

            collection.Add(dynamic);

            //  Do：根据属性动态生成数据
            foreach (var x in pxAxis)
            {
                //  Do：获取当前天的数据
                var find = result.Where(l => l.ORGNAME == x).Max(l => l.CDTOTAL);

                if (find.HasValue)
                {
                    datas.Add(find.Value);
                }
            }

            //pxAxis.Clear();

            //for (int i = 0; i < 30; i++)
            //{
            //    pxAxis.Add(i.ToString());

            //    //pxAxis.Add(DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));

            //}

            for (int i = 0; i < pxAxis.Count; i++)
            {
                datas.Add(i + 1);
            }

            List<string> Legend = new List<string>();

            Legend.Add(dynamic.name);



            //pxAxis = pxAxis.Skip(1).Take(20).ToList();
            //datas = datas.Skip(1).Take(20).ToList();


            dynamic.data = datas.ToArray();

            return Json(new
            {
                xAxis = new { data = pxAxis.ToArray() },
                legend = new { data = Legend.ToArray() },
                series = collection.ToArray()
            });

            //List<string> Legend = new List<string>();

            //foreach (var item in matchs)
            //{
            //    Legend.Add(item.Name);
            //}

            //List<dynamic> pseries = matchs.Select(l => l.ToDynamic()).ToList();

            //return new
            //{
            //    xAxis = new { data = pxAxis.ToArray() },
            //    legend = new { data = Legend.ToArray() },
            //    series = pseries
            //};


            ////limit 50,300

            //Func<jw_add_data, string> convertxAxis = l =>
            //{
            //    return l.UDATE.Value.ToString("yyyy-MM-dd");
            //};

            //Predicate<PropertyInfo> except = l =>
            //{
            //    return l.Name.ToUpper() == "FILETOTAL"
            //    || l.Name.ToUpper() == "OLDTOTAL"
            //    || l.Name.ToUpper() == "PERFECTTOTLE"
            //    || l.Name.ToUpper() == "COUNT"
            //    || l.Name.ToUpper() == "WOMANRATE"
            //    || l.Name.ToUpper() == "YEAR"
            //    || l.Name.ToUpper() == "TYPE";
            //};


            //List<ReportConvertEngine<jw_add_data, int?>> matchs = new List<ReportConvertEngine<jw_add_data, int?>>();

            //var vaildIntCollection = typeof(jw_add_data).GetProperties().ToList().FindAll(l => l.PropertyType == typeof(int?));

            //foreach (var item in vaildIntCollection)
            //{
            //    if (except(item)) continue;

            //    ReportConvertEngine<jw_add_data, int?> engine = new ReportConvertEngine<jw_add_data, int?>();

            //    engine.Convert = l =>
            //    {
            //        return (int?)item.GetValue(l);
            //    };

            //    engine.MatchValue = l => l.HasValue;

            //    DisplayAttribute display = item.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            //    engine.Name = display == null ? item.Name : display.Name;

            //    engine.Type = "line";

            //    matchs.Add(engine);
            //}

            ////convertToValueList.Add(l => l.CDTOTAL);
            ////convertToValueList.Add(l => l.CHILDRATE);
            ////convertToValueList.Add(l => l.COUNT);
            ////convertToValueList.Add(l => l.CYTOTAL);
            ////convertToValueList.Add(l => l.DBTOTAL);



            //var series = DataService.Instance.Create<jw_add_data, int?>(result.ToList(), convertxAxis, matchs.Take(8).ToList());

            //return Json(series);
        }

        [HttpPost]
        public JsonResult RegionTotalPostDisplay()
        {

            var result = _context.Datas.FromSql("select * from jw_add_data where LENGTH(REGIONCODE)=6"); 

            var json = DataService.Instance.GroupByExpression(result, 
                l => l.ORGNAME,
                l => l.Max(k => k.CDTOTAL), 
                l => l.Min(k => k.CDTOTAL), 
                l => l.Average(k => k.CDTOTAL), 
                l => l.Count());

            //var json = DataService.Instance.GroupByExpression(result,
            //   l => l.ORGNAME,
            //   l => l.Max(k => k.CDTOTAL),
            //   l => l.Min(k => k.CDTOTAL),
            //   l => l.Average(k => k.CDTOTAL),
            //   l => l.Min(k => k.OLDTOTAL), l => l.Count());

            return Json(json);
        }

        // GET: Report/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jw_add_data = await _context.Datas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jw_add_data == null)
            {
                return NotFound();
            }

            return View(jw_add_data);
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ORGID,ORGNAME,ORGTYPE,REGIONCODE,CDTOTAL,CYTOTAL,DBTOTAL,FILETOTAL,HYTENTOTAL,OLDTOTAL,PERFECTOLDTOTAL,PERFECTTOTLE,SPTOTAL,COUNT,WOMANRATE,TNBRATE,PKPRATE,OLDMANRATE,GXYRATE,CMPRATE,CHILDRATE,YEAR,TYPE,UDATE")] jw_add_data jw_add_data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jw_add_data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jw_add_data);
        }

        // GET: Report/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jw_add_data = await _context.Datas.FindAsync(id);
            if (jw_add_data == null)
            {
                return NotFound();
            }
            return View(jw_add_data);
        }

        // POST: Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,ORGID,ORGNAME,ORGTYPE,REGIONCODE,CDTOTAL,CYTOTAL,DBTOTAL,FILETOTAL,HYTENTOTAL,OLDTOTAL,PERFECTOLDTOTAL,PERFECTTOTLE,SPTOTAL,COUNT,WOMANRATE,TNBRATE,PKPRATE,OLDMANRATE,GXYRATE,CMPRATE,CHILDRATE,YEAR,TYPE,UDATE")] jw_add_data jw_add_data)
        {
            if (id != jw_add_data.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jw_add_data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!jw_add_dataExists(jw_add_data.ID))
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
            return View(jw_add_data);
        }

        // GET: Report/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jw_add_data = await _context.Datas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jw_add_data == null)
            {
                return NotFound();
            }

            return View(jw_add_data);
        }

        // POST: Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jw_add_data = await _context.Datas.FindAsync(id);
            _context.Datas.Remove(jw_add_data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool jw_add_dataExists(string id)
        {
            return _context.Datas.Any(e => e.ID == id);
        }
    }
}
