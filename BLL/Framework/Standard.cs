using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    /// <summary>
    /// 标准模板
    /// </summary>
    public partial class Standard
    {
        public Dictionary<int, CalculateResult> list = new Dictionary<int, CalculateResult>();

        public CalculateResult this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }
        public virtual bool Calculate(DAL.MYResult entity) { return true; }
        //缴纳基数

        /// <summary>
        /// 基数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool Between(PoliceInsurance data, string com, string num)
        {
            if (string.IsNullOrWhiteSpace(num))
            {
                return false;
            }
            if (com == "企业")
            {
                return !(Convert.ToDecimal(num) >= data.CompanyLowestNumber && Convert.ToDecimal(num) <= data.CompanyHighestNumber);
            }
            else
            {
                return !(Convert.ToDecimal(num) >= data.EmployeeLowestNumber && Convert.ToDecimal(num) <= data.EmployeeHighestNumber);
            }

        }
        /// <summary>
        /// 比例
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Scale(PoliceInsurance data, string com, string num)
        {
            if (string.IsNullOrWhiteSpace(num))
            {
                return string.Empty;
            }
            if (com == "企业")
            {    /*  四舍五入 = 1,      
        直接舍去 = 2,      
        直接进位 =3,
        四舍六入五取偶=4*/
                switch ((int)(data.CompanySub))
                {

                    case 1:
                        return decimal.Round(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100, (int)data.CompanyDigit, MidpointRounding.AwayFromZero).ToString();
                    case 2:

                        var pow = (int)((Math.Pow(10, ((double)data.CompanyDigit))));
                        return (decimal.Floor(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100 * pow) / pow).ToString();
                    case 3:
                        var pow3 = (int)((Math.Pow(10, ((double)data.CompanyDigit))));
                        return (decimal.Ceiling(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100 * pow3) / pow3).ToString();

                    case 4:
                        return decimal.Round(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100, (int)data.CompanyDigit).ToString();
                    default:
                        break;
                }
            }
            else
            {
                switch ((int)(data.EmployeeSub))
                {
                    case 1:
                        return decimal.Round(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100, (int)data.EmployeeDigit, MidpointRounding.AwayFromZero).ToString();
                    case 2:

                        var pow = (int)((Math.Pow(10, ((double)data.EmployeeDigit))));
                        return (decimal.Floor(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100 * pow) / pow).ToString();
                    case 3:
                        var pow3 = (int)((Math.Pow(10, ((double)data.EmployeeDigit))));
                        return (decimal.Ceiling(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100 * pow3) / pow3).ToString();

                    case 4:
                        return decimal.Round(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100, (int)data.EmployeeDigit).ToString();
                    default:
                        break;
                }
            }
            return string.Empty;
        }
        public static string Scale(PoliceInsurance data, string com, string num, string addition)
        {
            if (string.IsNullOrWhiteSpace(num))
            {
                return string.Empty;
            }
            if (com == "企业")
            {    /*  四舍五入 = 1,      
        直接舍去 = 2,      
        直接进位 =3,
        四舍六入五取偶=4*/
                switch ((int)(data.CompanySub))
                {

                    case 1:
                        return (decimal.Parse(addition) + decimal.Round(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100, (int)data.CompanyDigit, MidpointRounding.AwayFromZero))
                            .ToString();
                    case 2:

                        var pow = (int)((Math.Pow(10, ((double)data.CompanyDigit))));
                        return (decimal.Parse(addition) + (decimal.Floor(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100 * pow) / pow))
                        .ToString();
                    case 3:
                        var pow3 = (int)((Math.Pow(10, ((double)data.CompanyDigit))));
                        return (decimal.Parse(addition) + (decimal.Ceiling(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100 * pow3) / pow3))
                            .ToString();

                    case 4:
                        return (decimal.Parse(addition) + decimal.Round(decimal.Parse(num) * ((decimal)data.CompanyPercent) / 100, (int)data.CompanyDigit))
                            .ToString();
                    default:
                        break;
                }
            }
            else
            {
                switch ((int)(data.EmployeeSub))
                {
                    case 1:
                        return (decimal.Parse(addition) + decimal.Round(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100, (int)data.EmployeeDigit, MidpointRounding.AwayFromZero))
                            .ToString();
                    case 2:

                        var pow = (int)((Math.Pow(10, ((double)data.EmployeeDigit))));
                        return (decimal.Parse(addition) + (decimal.Floor(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100 * pow) / pow))
                            .ToString();
                    case 3:
                        var pow3 = (int)((Math.Pow(10, ((double)data.EmployeeDigit))));
                        return (decimal.Parse(addition) + (decimal.Ceiling(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100 * pow3) / pow3))
                            .ToString();

                    case 4:
                        return (decimal.Parse(addition) + decimal.Round(decimal.Parse(num) * ((decimal)data.EmployeePercent) / 100, (int)data.EmployeeDigit))
                            .ToString();
                    default:
                        break;
                }
            }
            return string.Empty;

        }
        public static bool Different(PoliceInsurance data, string com, string num)
        {
            return true;//decimal.Round(decimal.Parse(num) * decimal.Parse("1"), 2).ToString();
        }
    }

}
