using HeBianGu.Product.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Product.WebApp.Demo.Models
{
    public class MonitorViewModel
    {
        public string  ID { get; set; }

        public JCSJ_CUSTOMER Customer { get; set; } = new JCSJ_CUSTOMER();

        public JCSJ_BED Bed { get; set; } = new JCSJ_BED();

        public JCSJ_MAT Mat { get; set; } = new JCSJ_MAT();


        public string Heart { get; set; }

        public string Breath { get; set; }

        public string Shuimian { get; set; }

        public string FanShen { get; set; }

        public string ZaiChuang { get; set; }

        public string Huli { get; set; }

    }
}
