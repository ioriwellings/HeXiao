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
    public partial class CityBLL  
    {
        public List<City> GetByVertion(int vertion)
        {
        
                return db.City.Where(w => w.Vertion == vertion).OrderBy(o => o.CreateTime).ToList();
           

        }
    }
}

