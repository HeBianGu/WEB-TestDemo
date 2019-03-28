using HeBianGu.Product.Base.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeBianGu.Product.Respository.Model
{
    public class MonitorItemViewModel
    {
        public ehc_dv_monitor Monitor { get; set; }

        [Display(Name = "心率监测区间")]
        [Description("5d107bfa-3784-4e7c-8d40-5c9a38309cd6")]
        public Splite2Template HeartRange { get; set; }

        [Display(Name = "呼吸监测区间")]
        [Description("e126274b-1bc4-4724-8c84-6123a506615d")]
        public Splite2Template BreathRange { get; set; }

        [Display(Name = "监测时间一")]
        [Description("5e4d6b02-1c05-4630-bfda-9c71fc031408")]
        public TimeTemplate TimeRange1 { get; set; }

        [Display(Name = "监测时间二")]
        [Description("ee2579bd-111b-457c-8fd1-befb12bbe64e")]
        public TimeTemplate TimeRange2 { get; set; }

        [Display(Name = "监测时间三")]
        [Description("c1a239fe-5326-4bd0-8bb3-38b9e59e36e5")]
        public TimeTemplate TimeRange3 { get; set; }

        [Display(Name = "监测时间四")]
        [Description("1b77e4ae-81b9-45c0-bcfe-867746582dbf")]
        public TimeTemplate TimeRange4 { get; set; }

        [Display(Name = "监测时间五")]
        [Description("67216ec5-c33c-4965-b201-c7889e46d9ef")]
        public TimeTemplate TimeRange5 { get; set; }

    }


    public abstract class TemplateBase
    {
        /// <summary> 获取模板名称 </summary>
        public string GetTempName()
        {
            var result = this.GetType().GetCustomAttributes(false);
           

            return (result[0] as DescriptionAttribute).Description;
        }
    }

    [Description("Splite2Template")]
    public class Splite2Template : TemplateBase
    {
        //public ehc_dv_monitorextention Model { get; set; }
        [Required]
        [Display(Name = "请输入最小值")]
        public double MinValue { get; set; }

        [Required]
        [Display(Name = "请输入最大值")]
        public double MaxVlalue { get; set; }

    }

    [Description("TimeTemplate")]
    public class TimeTemplate : Splite2Template
    {
        [Required]
        [Display(Name = "离床持续时间")]
        public int LeaveBedTime { get; set; }

        [Required]
        [Display(Name = "体动持续时间")]
        public int MoveTime { get; set; }

    }
}
