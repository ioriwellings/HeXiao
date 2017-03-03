using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(PoliceInsuranceMetadata))]//使用PoliceInsuranceMetadata对PoliceInsurance进行数据验证
    public partial class PoliceInsurance
    {

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "政策主表")]
        public string InsuranceIdOld { get; set; }

        #endregion

    }
    public partial class PoliceInsuranceMetadata
    {
        [ScaffoldColumn(true)]
        [Display(Name = "名称", Order = 1)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public object Name { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "政策主表", Order = 2)]
        [StringLength(36, ErrorMessage = "长度不可超过36")]
        public object InsuranceId { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "缴纳地", Order = 3)]
        [StringLength(36, ErrorMessage = "长度不可超过36")]
        public object CityId { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "参保类型", Order = 4)]
        [StringLength(36, ErrorMessage = "长度不可超过36")]
        public object PoliceAccountNatureId { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "社保种类", Order = 5)]
        [StringLength(36, ErrorMessage = "长度不可超过36")]
        public object InsuranceKindId { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "开始时间", Order = 6)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

        public DateTime? StartTime { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "结束时间", Order = 7)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

        public DateTime? EndTime { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "允许补缴月数", Order = 8)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? MaxPayMonth { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "报增社保月", Order = 9)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? InsuranceAdd { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "缴费频率", Order = 10)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? PaymentFrequency { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "报减社保月", Order = 11)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? InsuranceReduce { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "企业比例", Order = 12)]
        public object CompanyPercent { get; set; }
        [ScaffoldColumn(true)]
        [Display(Name = "企业常量", Order = 13)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object CompanyNumber { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "个人常量", Order = 14)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object EmployeeNumber { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "企业最低基数", Order = 13)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object CompanyLowestNumber { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "个人最低基数", Order = 14)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object EmployeeLowestNumber { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "企业最高基数", Order = 15)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object CompanyHighestNumber { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "最低工资", Order = 16)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object LowWage { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "社平工资", Order = 17)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object SocialWage { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "个人最高基数", Order = 18)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Currency, ErrorMessage = "货币格式不正确")]
        public object EmployeeHighestNumber { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "个人比例", Order = 19)]
        public object EmployeePercent { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "企业承担截取规则", Order = 20)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? CompanySub { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "企业承担小数点位数", Order = 21)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? CompanyDigit { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "个人承担截取规则", Order = 22)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? EmployeeSub { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "个人承担小数点位数", Order = 23)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? EmployeeDigit { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "默认", Order = 24)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public object IsDefault { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "状态", Order = 25)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public object State { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 26)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CreateTime { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 27)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public object CreatePerson { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改时间", Order = 28)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UpdateTime { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改人", Order = 29)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public object UpdatePerson { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "Vertion", Order = 30)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? Vertion { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "备注", Order = 31)]
        [StringLength(4000, ErrorMessage = "长度不可超过4000")]
        public object Remark { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 32)]
        public object Id { get; set; }


    }
}


