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
    /// 对比结果
    /// </summary>
    public class MatchResultController : BaseController
    {
        [HttpPost]
        public ActionResult BaoGaoShangChuan()//文档上传
        {
            
            

            string msg = string.Empty;
            if (Request.Files.Count > 0)//前端获取文件选择控件值
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    System.Web.HttpPostedFileBase pstFile = Request.Files[i];//获取页面选择的文件
                    string upfile = pstFile.FileName;//文件名
                    UploadFiles upFiles = new UploadFiles();
                    //msg += upFiles.ReportToUpload(pstFile, upfile, i);//上传文件

                }
            }
             
            msg = msg.Substring(1, msg.Length - 1).TrimEnd('}');//去掉头尾｛｝
            string[] mg = msg.Split(',');
            for (int i = 0; i < mg.Length; i++)//解析上传文件方法返回的字符串
            {
                string[] m = mg[i].Split('*');
                switch (m[0].ToString())
                {
                   
                    default:
                        break;
                }
            }
            
            return View();
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
            MatchResult item = m_BLL.GetById(id);
            return View(item);

        }
        public ActionResult PostData(DTParameters getParam)
        {
            int total = 0;
            int page = (getParam.Start != 0) ? 1 : ((getParam.Start / getParam.Length) + 1);int vertion = GetVersion();getParam.Search.Value += "^VertionDDL_Int&" + vertion.ToString();

          
            List<MatchResult> queryData = m_BLL.GetByParam(null, page, getParam.Length, getParam.DescOrAsc, getParam.SortOrder, getParam.Search.Value, ref total);
            DTResult<MatchResult> result = new DTResult<MatchResult>
            {
                draw = getParam.Draw,
                data = queryData,

                recordsFiltered = total

            };
            return Json(result);


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
            MatchResult item = m_BLL.GetById(id);
            return View(item);
        }
        IBLL.IMatchResultBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public MatchResultController()
                    : this(new MatchResultBLL()) { }

        public MatchResultController(MatchResultBLL bll)
        {
            m_BLL = bll;
        }

    }
}


