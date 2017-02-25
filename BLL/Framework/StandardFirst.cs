using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    /// <summary>
    /// 标准模板，基础文件
    /// </summary>
    public partial class StandardFirst: StandardMatch
    {
      
        /// <summary>
        /// 匹配项相加
        /// </summary>
        /// <returns></returns>
        public override bool Calculate(List<MatchDetail> matchs)
        {
            //
            foreach (var item in matchs)
            {
                if (list[(int)item.BaseExcel].Value != null)
                {
                    Condition += list[(int)item.BaseExcel].Value.Trim();
                }


            }

            return true;
        }
        //缴纳基数


    }

}
