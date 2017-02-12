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
    public partial class PoliceAccountNatureBLL
    {
        public List<PoliceAccountNature> GetByVertion(int vertion)
        { 
                return db.PoliceAccountNature.Where(w => w.Vertion == vertion).OrderBy(o => o.CreateTime).ToList();
             
        }
    }
}

