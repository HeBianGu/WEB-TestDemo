using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{
    [Table("ehc_dv_customer")]
    public class ehc_dv_customer : StringEntityBase
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

        [Required] 
        [Display(Name = "紧急联系人")]
        public string CONTACT { get; set; }

        [Required]
        [Display(Name = "入院诊断")]
        public string DIAGNOSIS { get; set; }

        [Required]
        [Display(Name = "病史")]
        public string HISTORY { get; set; }

        [Required]
        [Display(Name = "护理等级")]
        public string NURSE { get; set; }

        [Required]
        [Display(Name = "翻身护理")]
        public string TURN { get; set; }

        [Display(Name = "是否可用")]
        public int ISENBLED { get; set; } 

        [Display(Name = "入院时间")]
        public string INDATE { get; set; }

        [Display(Name = "出院时间")]
        public string OUTDATE { get; set; }


    }
}
