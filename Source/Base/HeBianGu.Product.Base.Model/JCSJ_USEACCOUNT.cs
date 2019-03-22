using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeBianGu.Product.Base.Model
{
    [Table("JCSJ_USEACCOUNT")]
    public class JCSJ_USEACCOUNT : StringEntityBase
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "用户名")]
        public string NAME { get; set; }

        [Required]
        [Display(Name = "密码")]
        public string PASSWORD { get; set; }

        [Required]
        [Display(Name = "状态")]
        public string STATE { get; set; }

        [Required]
        [Display(Name = "用户类型")]
        public string TYPE { get; set; }
    }
}
