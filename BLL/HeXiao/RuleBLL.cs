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
         
                return db.Rule.Where(w => w.State != "删除" && w.Vertion == vertion).ToList();
           
        }
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<Rule> GetByParam(int id, int page, int rows, string order, string sort, string search, ref int total)
        {

            IQueryable<Rule> queryData = db.Rule.Where(w => w.State != "删除" && w.Vertion == id);
            total = queryData.Count();
            if (total > 0)
            {
                if (page <= 1)
                {
                    queryData = queryData.Take(rows);
                }
                else
                {
                    queryData = queryData.Skip((page - 1) * rows).Take(rows);
                }

            }
            return queryData.ToList();
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
                    //var details = rule.MatchDetail.ToList();
                    //if (rule != null)
                    //{
                    //    foreach (var item in details)
                    //    {
                    //        db.MatchDetail.Remove(item);
                    //    }
                    //    db.Rule.Remove(rule);

                    //}
                    rule.State = "删除";
                    entity.Id = Common.Result.GetNewId();
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

