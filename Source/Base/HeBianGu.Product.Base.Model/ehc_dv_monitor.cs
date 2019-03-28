using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{
    [Table("ehc_dv_monitor")]
    public class ehc_dv_monitor : StringEntityBase
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
 
        [Display(Name = "创建时间")]
        public string CDATE { get; set; }

        [Display(Name = "修改时间")]
        public string UDATE { get; set; }

        [Display(Name = "是否可用")]
        public int IsEnbled { get; set; } = 1;
    }
}
