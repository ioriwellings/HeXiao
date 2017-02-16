using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(MatchResultMetadata))]//使用MatchResultMetadata对MatchResult进行数据验证
    public partial class MatchResult 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class MatchResultMetadata
    {
			[ScaffoldColumn(true)]
			[Display(Name = "结果", Order = 1)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Result { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "基础文件", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object BasePath { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "基础模板全路径", Order = 3)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object BaseFullPath { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "对比文件", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object GoldTempPath { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "目标模板全路径", Order = 5)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object GoldTempFullPath { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规则主键", Order = 6)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object RuleId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规则名称", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object RuleName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 10)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 11)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 12)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "Vertion", Order = 13)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Vertion { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 14)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 15)]
			public object Id { get; set; }


    }
}
 

