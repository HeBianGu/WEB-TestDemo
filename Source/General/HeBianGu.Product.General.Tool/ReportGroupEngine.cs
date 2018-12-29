using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace HeBianGu.Product.General.Tool
{
   public class ReportGroupEngine<TModel, TResult>
    {

        public Func<IQueryable<TModel>, TResult> GroupBy { get; set; }

        public Predicate<TResult> MatchValue { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<TResult> Datas { get; set; } = new List<TResult>();

        public dynamic ToDynamic()
        {
            dynamic dynamic = new ExpandoObject();

            dynamic.name = this.Name;

            dynamic.type = this.Type;

            dynamic.data = this.Datas.ToArray();

            return dynamic;
        }
    }
}
