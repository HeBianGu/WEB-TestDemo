using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{
    [Table("JCSJ_MONITOR")]
    public class JCSJ_MONITOR : StringEntityBase
    {
        [Required]
        [Display(Name = "床位设置")]
        public string BEDID { get; set; }

        [Required]
        [Display(Name = "床垫设置")]
        public string MATID { get; set; }

        [Required]
        [Display(Name = "客户设置")]
        public string CUSTOMID { get; set; }

        [Required]
        [Display(Name = "监护时间设置")]
        public string TIMEPLANID { get; set; }

        [Required]
        [Display(Name = "心率监护区间设置")]
        public string HEARTID { get; set; }

        [Required]
        [Display(Name = "呼吸监护区间设置")]
        public string BREATHID { get; set; }

        [Display(Name = "创建时间")]
        public string CDATE { get; set; }

        [Display(Name = "修改时间")]
        public string UDATE { get; set; }
    }
}
