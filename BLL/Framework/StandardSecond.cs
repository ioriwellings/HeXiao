using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    /// <summary>
    /// 标准模板，对比文件
    /// </summary>
    public partial class StandardSecond : StandardMatch
    {

        /// <summary>
        /// 这是不对的，应该是匹配项相加
        /// </summary>
        /// <returns></returns>
        public override bool Calculate(List<MatchDetail> matchs)
        {
           
            foreach (var item in matchs)
            {
                if (item.ChangeMonth != null && item.ChangeMonth != 0)
                {
                    if (list[(int)item.MatchExcel].Value != null)
                    {
                        DateTime dt = new DateTime();
                        if (DateTime.TryParse(list[(int)item.MatchExcel].Value.Trim(), out dt))
                        {

                            Condition += Convert.ToDateTime(dt).AddMonths((int)item.ChangeMonth).ToShortDateString();
                        }
                        else
                        {
                            if (list[(int)item.MatchExcel].Value.Trim().Length == 6)
                            {
                                DateTime dtime = DateTime.ParseExact(list[(int)item.MatchExcel].Value.Trim(), "yyyyMM", null);

                                Condition += Convert.ToDateTime(dtime).AddMonths((int)item.ChangeMonth).ToString("yyyyMM");
                            }
                        }
                    }


                }
                else
                {
                    Condition += list[(int)item.MatchExcel].Value.Trim();
                }

            }
            return true;
        }
        //缴纳基数


    }

}
