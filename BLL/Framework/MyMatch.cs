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
    public partial class MyMatch
    {
        public Dictionary<int, CalculateResult> list = new Dictionary<int, CalculateResult>();
        public string Condition { get; set; }
        public bool IsOnly { get; set; }
        public CalculateResult this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }
        public virtual bool Calculate(List<int> match) { return true; }
        //缴纳基数

        
    }

}
