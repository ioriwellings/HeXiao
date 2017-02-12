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
    /// 缴纳地
    /// </summary>
    public class CityController : BaseController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult GetData(DTParameters getParam)
        {
            int total = 0;
            int page = (getParam.Start != 0) ? 1 : ((getParam.Start / getParam.Length) + 1);int vertion = GetVersion();getParam.Search.Value += "^VertionDDL_Int&" + vertion.ToString();


            List<City> queryData = m_BLL.GetByParam(null, page, getParam.Length, getParam.DescOrAsc, getParam.SortOrder, getParam.Search.Value, ref total);
            DTResult<City> result = new DTResult<City>
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
            City item = m_BLL.GetById(id);
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
            City item = m_BLL.GetById(id);
            return View(item);
        }
        IBLL.ICityBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public CityController()
                    : this(new CityBLL()) { }

        public CityController(CityBLL bll)
        {
            m_BLL = bll;
        }
        
        /// <summary>
        /// 获取树形列表的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllMetadata(string id)
        {
            CityBLL m_BLL = new CityBLL();
            IQueryable<City> rows = m_BLL.GetAllMetadata(id);
            if (rows.Any())
            {//是否可以省
                return Json(new treegrid
                {
                    rows = rows.Select(s =>
                        new
                        {
                          Cit_Id = s.Cit_Id
					,Name = s.Name
					,State = s.State
					,CreateTime = s.CreateTime
					,CreatePerson = s.CreatePerson
					,UpdateTime = s.UpdateTime
					,UpdatePerson = s.UpdatePerson
					,Vertion = s.Vertion
					,Remark = s.Remark
					,Id = s.Id
					
                        }
                        ).OrderBy(o => o.Id)
                });
            }
            return Content("[]");
        }
    }
}


