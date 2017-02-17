using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 政策主表 
    /// </summary>
    public partial class RuleBLL
    {
        public List<Rule> GetByVertion(int vertion)
        {
         
                return db.Rule.Where(w => w.Vertion == vertion).ToList();
           
        }
    }
}

