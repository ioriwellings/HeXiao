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
    public partial class StandardMatch
    {
        public Dictionary<int, CalculateResult> list = new Dictionary<int, CalculateResult>();
      public  int Row { get; set; }
    
        public string Condition { get; set; }
      
        public bool IsOnly { get; set; }
        public CalculateResult this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }
        /// <summary>
        /// 这是不对的，应该是匹配项相加
        /// </summary>
        /// <returns></returns>
        public virtual bool Calculate(List<MatchDetail> matchs) { return true; }

    }

}
