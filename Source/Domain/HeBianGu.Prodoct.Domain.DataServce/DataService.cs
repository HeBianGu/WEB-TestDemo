using HeBianGu.Product.General.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HeBianGu.Prodoct.Domain.DataServce
{
    public class DataService
    {

        public static DataService Instance = new DataService();


        ReportAutoCreateService _reportAutoCreateService = new ReportAutoCreateService();

        public dynamic Create<TModel, RType>(List<TModel> models, Func<TModel, string> toxAxis, List<ReportConvertEngine<TModel, RType>> matchs)
        {
            return _reportAutoCreateService.Create(models, toxAxis,matchs);
        }

        public dynamic CreateWithAllProperty<TModel, RType>(List<TModel> models, Func<TModel, string> toxAxis, Predicate<PropertyInfo> except = null)
        {
            return _reportAutoCreateService.CreateWithAllProperty<TModel, RType>(models, toxAxis, except);
        }

        public dynamic GroupBy<TModel, TResult>(IQueryable<TModel> models, Func<TModel, string> groupBy, params ReportGroupEngine<TModel, TResult>[] groupFunc)
        {
            return _reportAutoCreateService.GroupBy(models, groupBy, groupFunc);
        }
    }
}
