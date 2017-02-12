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
    public partial class PoliceInsuranceBLL
    {
        public List<PoliceInsurance> GetByVertion(int? vertion, string InsuranceId,string CityId, string PoliceAccountNatureId)
        {
            var data= db.PoliceInsurance.Where(w => w.Vertion == vertion
              && w.CityId == CityId
             && w.PoliceAccountNatureId == PoliceAccountNatureId
             && w.InsuranceId == InsuranceId
            );

            return data.ToList();


        }
    }
}

