using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{
    [Table("JCSJ_BED")]
    public class JCSJ_BED: StringEntityBase
    { 

        [Required]
        [StringLength(10)]
        [Display(Name = "床位编码")]
        public string CODE { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "床位名称")]
        public string NAME { get; set; }

        [Display(Name = "创建时间")]
        public string CDATE { get; set; }

        [Display(Name = "修改时间")]
        public string UDATE { get; set; }
    }
}
