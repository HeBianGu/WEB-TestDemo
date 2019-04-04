using HeBianGu.Prodoct.Domain.DataServce;
using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.IService;
using HeBianGu.Product.Respository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.Service
{

    /// <summary> 监控配置模型 </summary>
    public class MonitorSetRespository : UserLoggerRepositoryBase<ehc_dv_monitor>, IMonitorSetRespository
    {
        public MonitorSetRespository(DataContext dbcontext, ILogger<MonitorSetRespository> logger) : base(dbcontext, logger)
        {

        }

        Random r = new Random();

        public async Task<List<MonitorViewModel>> GetMonitorListTest()
        {

            var collection = this.GetMonitorList();

            List<MonitorViewModel> result = new List<MonitorViewModel>();

            foreach (var item in collection.Result)
            {
                int v = r.Next(50, 120);

                MonitorViewModel model = item;

                model.Heart = "心率：" + v.ToString() + "次/分 历史:135/37";
                model.Breath = "呼吸：" + r.Next(80, 200).ToString() + "次/分 历史:135/37";
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

            result = result.OrderByDescending(l => l.Flag).ToList();

            return result;
        }


        static int start = 5;
        public async Task<IQueryable<jw_add_data>> GetRealLineTest()
        {
            var result = _dbContext.Datas.FromSql("select *  from jw_add_data where REGIONCODE='510703101'");

            //var result = _dbContext.Datas.FromSql("select * from jw_add_data where REGIONCODE='510703101'");

            //var find = result.Skip(r.Next(result.Count())).Take(10000);

            if (start > result.Count()) start = 5;

            var find = result.Take(start += 1).Skip(start - 20>0? start - 20:0).Take(10000);



            return find;
        }

        public async Task<List<MonitorViewModel>> GetMonitorList()
        {

            var collection = await this.GetListAsync();

            List<MonitorViewModel> result = new List<MonitorViewModel>();

            foreach (var item in collection)
            {
                MonitorViewModel model = this.GetModel(item);

                result.Add(model);
            }

            return result;
        }

        MonitorViewModel GetModel(ehc_dv_monitor monitor)
        {
            MonitorViewModel model = new MonitorViewModel();

            model.ID = monitor.ID.ToString();

            var r = _dbContext.Customers.Where(l => l.ID == monitor.CUSTOMID);

            if (r != null && r.Count() > 0)
            {
                model.Customer = r.First();
            }

            var b = _dbContext.Beds.Where(l => l.ID == monitor.BEDID);

            if (b != null && b.Count() > 0)
            {
                model.Bed = b.First();
            }

            var m = _dbContext.Mats.Where(l => l.ID == monitor.MATID);

            if (m != null && m.Count() > 0)
            {
                model.Mat = m.First();
            }


            model.MonitorDetial = this.GetMonitorDeital(monitor);

            return model;
        }

        MonitorItemViewModel GetMonitorDeital(ehc_dv_monitor monitor)
        {
            var extentions = _dbContext.ehc_dv_monitorextentions.Where(l => l.MonitorID == monitor.ID);

            MonitorItemViewModel viewModel = new MonitorItemViewModel();

            viewModel.Monitor = monitor;

            var heartDb = extentions.Where(l => l.TypeID == "5d107bfa-3784-4e7c-8d40-5c9a38309cd6");

            viewModel.HeartRange = ToolService.Instance.DeSerializeObject<Splite2Template>(heartDb.FirstOrDefault().Value);

            var breathDb = extentions.Where(l => l.TypeID == "e126274b-1bc4-4724-8c84-6123a506615d");

            viewModel.BreathRange = ToolService.Instance.DeSerializeObject<Splite2Template>(breathDb.FirstOrDefault().Value);

            var timespan1Db = extentions.Where(l => l.TypeID == "5e4d6b02-1c05-4630-bfda-9c71fc031408");

            viewModel.TimeRange1 = ToolService.Instance.DeSerializeObject<TimeTemplate>(timespan1Db.FirstOrDefault().Value);

            var timespan2Db = extentions.Where(l => l.TypeID == "ee2579bd-111b-457c-8fd1-befb12bbe64e");

            viewModel.TimeRange2 = ToolService.Instance.DeSerializeObject<TimeTemplate>(timespan2Db.FirstOrDefault().Value);

            var timespan3Db = extentions.Where(l => l.TypeID == "c1a239fe-5326-4bd0-8bb3-38b9e59e36e5");

            viewModel.TimeRange3 = ToolService.Instance.DeSerializeObject<TimeTemplate>(timespan3Db.FirstOrDefault().Value);

            var timespan4Db = extentions.Where(l => l.TypeID == "1b77e4ae-81b9-45c0-bcfe-867746582dbf");

            viewModel.TimeRange4 = ToolService.Instance.DeSerializeObject<TimeTemplate>(timespan4Db.FirstOrDefault().Value);

            var timespan5Db = extentions.Where(l => l.TypeID == "67216ec5-c33c-4965-b201-c7889e46d9ef");

            viewModel.TimeRange5 = ToolService.Instance.DeSerializeObject<TimeTemplate>(timespan5Db.FirstOrDefault().Value);


            return viewModel;
        }

        public async Task<MonitorItemViewModel> GetMonitorDeitalByID(string id)
        {
            var model = await _dbContext.Moniters.FindAsync(id);

            return this.GetMonitorDeital(model);
        }

        public async Task<int> Create(MonitorItemViewModel viewModel)
        {
            ehc_dv_monitor monitor = viewModel.Monitor;

            monitor.CDATE = DateTime.Now.ToDateTimeString();
            monitor.UDATE = DateTime.Now.ToDateTimeString();

            //  Message：保存监控
            _dbContext.Add(monitor);

            //  Message：保存监控配置
            Action<TemplateBase, string> ConvertTo = (l, k) =>
            {
                ehc_dv_monitorextention extend = new ehc_dv_monitorextention();
                extend.MonitorID = monitor.ID;
                extend.TypeID = k;
                extend.Value = ToolService.Instance.SerializeObject(l);
                extend.UDATE = DateTime.Now.ToDateTimeString();
                extend.CDATE = DateTime.Now.ToDateTimeString();
                _dbContext.Add(extend);
            };

            //  Do：转换并保存
            ConvertTo(viewModel.HeartRange, "5d107bfa-3784-4e7c-8d40-5c9a38309cd6");
            ConvertTo(viewModel.BreathRange, "e126274b-1bc4-4724-8c84-6123a506615d");
            ConvertTo(viewModel.TimeRange1, "5e4d6b02-1c05-4630-bfda-9c71fc031408");
            ConvertTo(viewModel.TimeRange2, "ee2579bd-111b-457c-8fd1-befb12bbe64e");
            ConvertTo(viewModel.TimeRange3, "c1a239fe-5326-4bd0-8bb3-38b9e59e36e5");
            ConvertTo(viewModel.TimeRange4, "1b77e4ae-81b9-45c0-bcfe-867746582dbf");
            ConvertTo(viewModel.TimeRange5, "67216ec5-c33c-4965-b201-c7889e46d9ef");

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Edit(MonitorItemViewModel viewModel)
        {

            _dbContext.Update(viewModel.Monitor);

            //  Message：保存监控配置
            Action<TemplateBase, string> ConvertTo = (l, k) =>
            {
                ehc_dv_monitorextention extend = _dbContext.ehc_dv_monitorextentions.Where(m => m.MonitorID == viewModel.Monitor.ID && m.TypeID == k).FirstOrDefault();

                extend.Value = ToolService.Instance.SerializeObject(l);
                extend.UDATE = DateTime.Now.ToDateTimeString();
                _dbContext.Update(extend);
            };

            //  Do：转换并保存
            ConvertTo(viewModel.HeartRange, "5d107bfa-3784-4e7c-8d40-5c9a38309cd6");
            ConvertTo(viewModel.BreathRange, "e126274b-1bc4-4724-8c84-6123a506615d");
            ConvertTo(viewModel.TimeRange1, "5e4d6b02-1c05-4630-bfda-9c71fc031408");
            ConvertTo(viewModel.TimeRange2, "ee2579bd-111b-457c-8fd1-befb12bbe64e");
            ConvertTo(viewModel.TimeRange3, "c1a239fe-5326-4bd0-8bb3-38b9e59e36e5");
            ConvertTo(viewModel.TimeRange4, "1b77e4ae-81b9-45c0-bcfe-867746582dbf");
            ConvertTo(viewModel.TimeRange5, "67216ec5-c33c-4965-b201-c7889e46d9ef");

            return await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> Exist(string id)
        {
            return await _dbContext.Moniters.AnyAsync(e => e.ID == id);

        }

        public async Task<int> Delete(string id)
        {

            var models = await _dbContext.Moniters.FindAsync(id);

            _dbContext.Moniters.Remove(models);

            var collection = _dbContext.ehc_dv_monitorextentions.Where(l => l.MonitorID == id);

            _dbContext.ehc_dv_monitorextentions.RemoveRange(collection);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<dynamic> GetSelectList(dynamic dynamic)
        {
            dynamic.CustomerList = new SelectList(_dbContext.Customers, "ID", "NAME");
            dynamic.MatList = new SelectList(_dbContext.Mats, "ID", "NAME");
            dynamic.BedList = new SelectList(_dbContext.Beds, "ID", "NAME");

            return dynamic;
        }

        public IEnumerable<ehc_dv_customer> GetCurstoms()
        {
            return _dbContext.Customers;
        }

        public IEnumerable<JCSJ_MAT> GetMats()
        {
            return _dbContext.Mats;
        }

        public IEnumerable<ehc_dv_bed> GetBeds()
        {
            return _dbContext.Beds;
        }

        public async Task<MonitorViewModel> GetMonitorByID(string id)
        {
            var model = await this.GetByIDAsync(id);

            MonitorViewModel result = this.GetModel(model);

            return result;
        }

    }
}
