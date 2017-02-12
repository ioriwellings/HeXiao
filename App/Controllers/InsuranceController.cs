using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 政策主表
    /// </summary>
    public class InsuranceController : BaseController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult PostData(DTParameters getParam)
        {
            int total = 0;
            int page = (getParam.Start != 0) ? 1 : ((getParam.Start / getParam.Length) + 1);int vertion = GetVersion();getParam.Search.Value += "^VertionDDL_Int&" + vertion.ToString();


            List<Insurance> queryData = m_BLL.GetByParam(null, page, getParam.Length, getParam.DescOrAsc, getParam.SortOrder, getParam.Search.Value, ref total);
            DTResult<Insurance> result = new DTResult<Insurance>
            {
                draw = getParam.Draw,
                data = queryData.Select(s => new
                {
                    Name = s.Name
                  
                    ,
                    CreateTime = s.CreateTime
                    
                    ,
                    Remark = s.Remark
                    ,
                    Id = s.Id


                }).ToList(),

                recordsFiltered = total

            };
            return Json(result);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
        
            return View();
        }
         /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]  
        public ActionResult Details(string id)
        {
            Insurance item = m_BLL.GetById(id);
            return View(item);

        }
 
        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        { 
            
            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            Insurance item = m_BLL.GetById(id);
            return View(item);
        }
        IBLL.IInsuranceBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public InsuranceController()
                    : this(new InsuranceBLL()) { }

        public InsuranceController(InsuranceBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


