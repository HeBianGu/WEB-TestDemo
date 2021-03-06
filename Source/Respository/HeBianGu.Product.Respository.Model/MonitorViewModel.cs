﻿using HeBianGu.Product.Base.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.Model
{
    public class MonitorViewModel
    {
        public string  ID { get; set; }

        public MonitorItemViewModel MonitorDetial { get; set; } = new MonitorItemViewModel();

        public ehc_dv_customer Customer { get; set; } = new ehc_dv_customer();

        public ehc_dv_bed Bed { get; set; } = new ehc_dv_bed();

        public JCSJ_MAT Mat { get; set; } = new JCSJ_MAT();

        public string Heart { get; set; }

        public string Breath { get; set; }

        public string Shuimian { get; set; }

        public string FanShen { get; set; }

        public string ZaiChuang { get; set; }

        public string Huli { get; set; }

        public string ForeColor{ get; set; }

        public string BackColor { get; set; }

        public int Flag { get; set; } = 0;

    }
}
