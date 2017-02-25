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
        /// <summary>
        /// 编辑一个规则
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个规则</param>
        /// <returns></returns>
        public bool Edit(ref ValidationErrors validationErrors, Rule entity)
        {
            try
            {
                using (SysEntities db = new SysEntities())
                {
                    var rule = db.Rule.SingleOrDefault(s => s.Id == entity.Id);
                    var details = rule.MatchDetail.ToList();
                    if (rule != null)
                    {
                        foreach (var item in details)
                        {
                            db.MatchDetail.Remove(item);
                        }
                        db.Rule.Remove(rule);

                    }

                    db.Rule.Add(entity);
                    db.SaveChanges();

                }

                return true;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }

    }
}

