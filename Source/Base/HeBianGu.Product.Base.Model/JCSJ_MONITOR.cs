using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{
    [Table("JCSJ_MONITOR")]
    public class JCSJ_MONITOR
    {
        [Display(Name = "唯一标识")]
        public string ID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "床位ID")]
        public string BEDID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "床垫ID")]
        public string MATID { get; set; }

        [Display(Name = "客户ID")]
        public string CUSTOMID { get; set; }

        [Display(Name = "监护时间ID")]
        public string TIMEPLANID { get; set; }

        [Required]
        [Display(Name = "心率监护ID")]
        public string HEARTID { get; set; }

        [Display(Name = "呼吸监护ID")]
        public string BREATHID { get; set; }

        [Display(Name = "创建时间")]
        public string CDATE { get; set; }

        [Display(Name = "修改时间")]
        public string UDATE { get; set; }
    }
}
