using System.Collections.Generic;
using System.Linq;
 
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Http;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 对比结果
    /// </summary>
    public class MatchResultApiController : BaseApiController
    {
      
        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public MatchResult Get(string id)
        {
            MatchResult item = m_BLL.GetById(id);
            return item;
        }
 
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]MatchResult entity)
        {           

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                entity.CreateTime = System.DateTime.Now;entity.Id = Result.GetNewId(); 
                entity.CreatePerson = currentPerson;              
                entity.Id = Result.GetNewId();

                //excel操作
                entity.Vertion = GetVersion();
                //Gold.Make(entity);
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.InsertSucceed;
                    return result; //提示创建成功
                }
                else
                { 
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，对比结果的信息，" + returnValue,"对比结果"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        
        IBLL.IMatchResultBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public MatchResultApiController()
            : this(new MatchResultBLL()) { }

        public MatchResultApiController(MatchResultBLL bll)
        {
            m_BLL = bll;
        }
    }
}


