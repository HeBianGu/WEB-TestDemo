using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.IService
{
    /// <summary> 监控配置模型接口 </summary>
    public interface IMonitorSetRespository: IUserLoggerRepositoryBase<ehc_dv_monitor>
    {

        Task<IQueryable<jw_add_data>> GetRealLineTest();

        /// <summary> 获取监控列表 </summary>
        Task<List<MonitorViewModel>> GetMonitorList();

        /// <summary> 获取监控列表测试用 </summary>
        Task<List<MonitorViewModel>> GetMonitorListTest();

        /// <summary> 根据ID获取监控新增编辑项绑定模型 </summary>
        Task<MonitorViewModel> GetMonitorByID(string id);

        /// <summary> 根据ID获取监控新增编辑项绑定模型 </summary>
        Task<MonitorItemViewModel> GetMonitorDeitalByID(string id);

        /// <summary> 根据绑定模型创建监控项 </summary>
        Task<int> Create(MonitorItemViewModel viewModel);

        /// <summary> 根据绑定模型编辑监控项 </summary>
        Task<int> Edit(MonitorItemViewModel viewModel);

        /// <summary> 指定监控ID是否存在 </summary>
        Task<bool> Exist(string id);

        /// <summary> 删除指定监控项 </summary>
        Task<int> Delete(string id);

        /// <summary> 获取所有客户列表 </summary>
        IEnumerable<ehc_dv_customer> GetCurstoms();

        /// <summary> 获取所有床垫列表 </summary>
        IEnumerable<JCSJ_MAT> GetMats();

        /// <summary> 获取所有床列表 </summary>
        IEnumerable<ehc_dv_bed> GetBeds();
    }
}
