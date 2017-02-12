using System.Collections.Generic;
using System.Linq;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 目标模板 
    /// </summary>
    public partial class GoldTempBLL 
    {
        public List<GoldTemp> GetByVertion(int vertion)
        {
            
                return db.GoldTemp.Where(w=>w.Vertion== vertion).OrderBy(o=>o.State).ToList();
            
        }
    }
}

