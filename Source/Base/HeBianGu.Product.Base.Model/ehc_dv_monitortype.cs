using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HeBianGu.Product.Base.Model
{

    [Table("ehc_dv_monitortype")]
    public class ehc_dv_monitortype : StringEntityBase
    {
        [Display(Name = "类型名称")]
        public string Name { get; set; }

        [Display(Name = "参数值")]
        public string Value { get; set; }

        [Display(Name = "启用")]
        public string IsEnbled { get; set; }

        [Display(Name = "修改时间")]
        public string UDATE { get; set; }

        [Display(Name = "创建时间")]
        public string CDATE { get; set; }

        [Display(Name = "模板类型")]
        public string Template { get; set; }

        [Display(Name = "排序字段")]
        public int OrderBy { get; set; }

    }
}
