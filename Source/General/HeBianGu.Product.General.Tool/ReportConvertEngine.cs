using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace HeBianGu.Product.General.Tool
{

   public class ReportConvertEngine<TModel,RType>
    {
        public Func<TModel, RType> Convert { get; set; }

        public Predicate<RType> MatchValue { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<RType> Datas { get; set; } = new List<RType>();

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
