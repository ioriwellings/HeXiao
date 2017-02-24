using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(MatchDetailMetadata))]//使用MatchDetailMetadata对MatchDetail进行数据验证
    public partial class MatchDetail 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "规则")]
        public string RuleIdOld { get; set; }
        
        #endregion

    }
    public partial class MatchDetailMetadata
    {
			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 1)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规则", Order = 2)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object RuleId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "日期调整月", Order = 3)]
			[Range(-230,214, ErrorMessage="数值超出范围")]
			public int? ChangeMonth { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "基础文件", Order = 4)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? BaseExcel { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "对比文件", Order = 5)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? MatchExcel { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "匹配项对比项设定", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BaseMatch { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 8)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 10)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 11)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "Vertion", Order = 12)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Vertion { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 13)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 14)]
			public object Id { get; set; }


    }
}
 

