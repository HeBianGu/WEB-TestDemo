using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{ 
    [Table("ehc_dv_monitorextention")]
    public class ehc_dv_monitorextention : StringEntityBase
    { 
        [Required]
        [Display(Name = "监控项ID")]
        public string MonitorID { get; set; }

        [Display(Name = "类别项ID")]
        public string TypeID { get; set; }

        [Display(Name = "检测参数值")]
        public string Value { get; set; }

        [Display(Name = "修改时间")]
        public string UDATE { get; set; }

        [Display(Name = "创建时间")]
        public string CDATE { get; set; }
    }
}
