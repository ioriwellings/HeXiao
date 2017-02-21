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
    public partial class StandardFirst: StandardMatch
    {
      
        /// <summary>
        /// 这是不对的，应该是匹配项相加
        /// </summary>
        /// <returns></returns>
        public override bool Calculate(List<MatchDetail> matchs)
        {
            //
            foreach (var item in matchs)
            {
                if (item.ChangeMonth != null && item.ChangeMonth != 0)
                {
                    Condition += Convert.ToDateTime(list[(int)item.BaseExcel].Value.Trim()).AddMonths((int)item.ChangeMonth).ToShortDateString();
                }
                else
                {
                    Condition += list[(int)item.BaseExcel].Value.Trim();
                }

            }

            return true;
        }
        //缴纳基数


    }

}
