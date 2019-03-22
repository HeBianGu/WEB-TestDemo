using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{
    [Table("JCSJ_MAT")]
    public class JCSJ_MAT : StringEntityBase
    {

        [Required]
        [StringLength(10)]
        [Display(Name = "床垫编码")]
        public string CODE { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "床垫名称")]
        public string NAME { get; set; }

        [Display(Name = "供应商")]
        public string SUPPLIER { get; set; }

        [Display(Name = "创建时间")]
        public string CDATE { get; set; }

        [Display(Name = "修改时间")]
        public string UDATE { get; set; }
    }
}
