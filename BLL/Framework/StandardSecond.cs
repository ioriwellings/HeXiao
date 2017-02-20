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
                if (list[(int)item.MatchExcel].Value != null)
                {
                    Condition += list[(int)item.MatchExcel].Value.Trim();
                }


            }
            return true;
        }
        //缴纳基数


    }

}
