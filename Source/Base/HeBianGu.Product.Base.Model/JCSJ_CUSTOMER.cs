using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{
    [Table("JCSJ_CUSTOMER")]
    public class JCSJ_CUSTOMER : StringEntityBase
    {

        [Required]
        [StringLength(10)]
        [Display(Name = "客户姓名")]
        public string NAME { get; set; }

        [Display(Name = "照片")]
        public string IMAGE { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "性别")]
        public string SEX { get; set; }

        [Required]
        [Display(Name = "身份证号")]
        public string CARDID { get; set; }

        [Required]
        [Display(Name = "年龄")]
        public string AGE { get; set; }

        [Required]
        [Phone]
        [Display(Name = "电话")]
        public string TEL { get; set; }

        [Display(Name = "入院时间")]
        public string INDATE { get; set; }

        [Display(Name = "出院时间")]
        public string OUTDATE { get; set; }


    }
}
