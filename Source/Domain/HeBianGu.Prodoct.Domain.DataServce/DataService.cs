using HeBianGu.Product.General.Tool;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public dynamic GroupByExpression<TModel, TResult>(IQueryable<TModel> collection, Expression<Func<TModel, String>> groupby, params Expression<Func<IQueryable<TModel>, TResult>>[] expressions)
        {
            return _reportAutoCreateService.GroupByExpression(collection, groupby, expressions);
        }


        /// <summary>
        /// 序列化实体
        /// </summary>
        /// <param name="obj">string</param>
        /// <returns>实体</returns>
        public string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

    }
}
