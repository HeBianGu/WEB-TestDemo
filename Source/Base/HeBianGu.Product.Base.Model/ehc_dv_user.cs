using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeBianGu.Product.Base.Model
{
    [Table("ehc_dv_user")]
    public class ehc_dv_user : StringEntityBase
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "用户名")]
        public string NAME { get; set; }

        [Required]
        [Display(Name = "登录密码")]
        public string PASSWORD { get; set; }

        [Display(Name = "状态")]
        public string STATE { get; set; }

        [Required]
        [Display(Name = "用户类型")]
        public string ROLEID { get; set; }

        [Required]
        [Display(Name = "电话号码")]
        public string TEL { get; set; }

        [Required]
        [Display(Name = "用户姓名")]
        public string USERNAME { get; set; }

        [Display(Name = "是否可用")]
        public int ISENBLED { get; set; } = 1;
        
        [Display(Name = "注册时间")]
        public string CDATE { get; set; }
        
        [Display(Name = "修改时间")]
        public string UDATE { get; set; }
    }
}
