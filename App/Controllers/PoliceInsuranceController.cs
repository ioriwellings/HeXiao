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
    /// 社保政策
    /// </summary>
    public class PoliceInsuranceController : BaseController
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
            int page = (getParam.Start != 0) ? 1 : ((getParam.Start / getParam.Length) + 1);
            int vertion = GetVersion();
        
            var queryData = m_BLL.GetByParam(getParam.Search.Value.Trim(), page, getParam.Length, getParam.DescOrAsc, getParam.SortOrder, "^VertionDDL_Int&" + vertion.ToString(), ref total)
                 .Select(s => new
                 {
                     Name=s.Name,
                     CityId = s.CityId
                     ,
                     PoliceAccountNatureId = s.PoliceAccountNatureId
                     ,
                     InsuranceKindId = s.InsuranceKindId
                     ,
                     StartTime = s.StartTime
                     ,
                     EndTime = s.EndTime

                     ,
                     CreateTime = s.CreateTime


                     ,
                     Id = s.Id


                 });
            DTResult<PoliceInsurance> result = new DTResult<PoliceInsurance>
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
        public ActionResult Index(string id)
        {
            var s = id.Split('-');
            ViewBag.InsuranceId = s[0];
            ViewBag.InsuranceName = s[1];
            ViewBag.Id = id;
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
            PoliceInsurance item = m_BLL.GetById(id);
            return View(item);

        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        {
            var s = id.Split('-');
            ViewBag.InsuranceId = s[0];
            ViewBag.InsuranceName = s[1];
            ViewBag.Id = id;
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

            PoliceInsurance item = m_BLL.GetById(id);
            ViewBag.Id = item.Insurance.Id + "-" + item.Insurance.Name;
            ViewBag.InsuranceName = item.Insurance.Name;
            return View(item);
        }
        IBLL.IPoliceInsuranceBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public PoliceInsuranceController()
                    : this(new PoliceInsuranceBLL()) { }

        public PoliceInsuranceController(PoliceInsuranceBLL bll)
        {
            m_BLL = bll;
        }

    }
}


