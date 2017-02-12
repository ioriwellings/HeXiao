using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NPOI.HPSF;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;
using Common;
using System.Reflection;
using System.Web.Script.Serialization;

namespace Models
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 获取当前登陆人的唯一数字标识
        /// </summary>
        /// <returns></returns>
        public int GetVersion()
        {
            return 36319772;


        }
        /// <summary>
        /// 获取当前登陆人的用户名
        /// </summary>
        /// <returns></returns>
        public string GetCurrentPerson()
        {
            return AccountModel.GetCurrentPerson();


        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        public Account GetCurrentAccount()
        {
            var account = AccountModel.GetCurrentAccount();

            return account;


        }
        /// <summary>
        /// 导出数据集到excle
        /// </summary>
        /// <param name="titles">第一行显示的标题名称</param>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public static string WriteExcle(string[] titles, string[] fields, dynamic[] query, string path = @"~/up/b.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
            IWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");
            string guid = Guid.NewGuid().ToString();
            string saveFileName = xlsPath.Path(guid);

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行  
            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;

            //缩小字体填充  
            //cellStyle.ShrinkToFit = true;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {
                    var Cell = dataRow.CreateCell(i);

                    Cell.SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {

                        dataRow.CreateCell(j).SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/{0}.xls", guid);
            //记录日志

        }
        public class GetDataParam
        {
            public string sort { get; set; }
            public string order { get; set; }
            public int page { get; set; }
            public int rows { get; set; }
            public string id { get; set; }
            public string search { get; set; }
        }
        public class ExportParam
        {
            public string id { get; set; }
            public string title { get; set; }
            public string field { get; set; }
            public string sortName { get; set; }
            public string sortOrder { get; set; }
            public string search { get; set; }

        }

        public static HttpResponseMessage toJson(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                str = serializer.Serialize(obj);
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, System.Text.Encoding.GetEncoding("UTF-8"), "application/json") };

            return result;
        }
    }
}
