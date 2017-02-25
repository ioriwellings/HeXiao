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
        public ActionResult Create(MatchResult entity)//文档上传
        {
            string msg = string.Empty;
            if (Request.Files.Count == 2)//前端获取文件选择控件值
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    System.Web.HttpPostedFileBase postedFile = Request.Files[i];//获取页面选择的文件                   
                    UploadFiles upFiles = new UploadFiles();
                    msg = upFiles.fileSaveAsResult(postedFile);//上传文件
                    if (i == 0)
                    {
                        entity.BasePath = postedFile.FileName;
                        entity.BaseFullPath = msg;

                    }
                    else
                    {
                        entity.GoldTempPath = postedFile.FileName;
                        entity.GoldTempFullPath = msg;

                    }
                }
            }
            else
            {

                return View();
            }
            string currentPerson = GetCurrentPerson();
            entity.CreateTime = System.DateTime.Now;
            entity.CreatePerson = currentPerson;
            entity.Id = Result.GetNewId();

            //excel操作
            entity.Vertion = GetVersion();
            entity.Result= GoldMatch.Make(entity);
            string returnValue = string.Empty;
            if (m_BLL.Create(ref validationErrors, entity))
            {

                return Redirect("/home/index");//提示创建成功
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
                LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，对比结果的信息，" + returnValue, "对比结果"
                    );//写入日志                      
              
                return View(); //提示插入失败
            }

           
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

        public ActionResult PostData(DTParameters getParam)
        {
            int total = 0;
            int page = (getParam.Start != 0) ? 1 : ((getParam.Start / getParam.Length) + 1);
            int vertion = GetVersion();
            getParam.Search.Value += "^VertionDDL_Int&" + vertion.ToString();


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


