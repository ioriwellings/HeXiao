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
    /// 户口性质
    /// </summary>
    public class PoliceAccountNatureController : BaseController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostData( DTParameters getParam)
        {
            int total = 0;
            int page = (getParam.Start != 0) ? 1 : ((getParam.Start / getParam.Length) + 1);int vertion = GetVersion();getParam.Search.Value += "^VertionDDL_Int&" + vertion.ToString();


            List<PoliceAccountNature> queryData = m_BLL.GetByParam(null, page, getParam.Length, getParam.DescOrAsc, getParam.SortOrder, getParam.Search.Value, ref total);
            DTResult<PoliceAccountNature> result = new DTResult<PoliceAccountNature>
            {
                draw = getParam.Draw,
                data = queryData,

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
            PoliceAccountNature item = m_BLL.GetById(id);
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
            PoliceAccountNature item = m_BLL.GetById(id);
            return View(item);
        }
        IBLL.IPoliceAccountNatureBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public PoliceAccountNatureController()
                    : this(new PoliceAccountNatureBLL()) { }

        public PoliceAccountNatureController(PoliceAccountNatureBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


