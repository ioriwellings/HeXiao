using System.Collections.Generic;
using System.Web.Mvc;
using Langben.BLL;
using Langben.IBLL;
using Langben.DAL;

namespace Models
{
    public class SysFieldModels
    {

        /// <summary>
        /// 获取字段，首选默认
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum, string parentMyTexts)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum) || string.IsNullOrWhiteSpace(parentMyTexts))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return new SelectList(baseDDL.GetSysField(table, colum, parentMyTexts), "MyTexts", "MyTexts");

        }
        /// <summary>
        /// 获取字段，首选默认，MyTexts做为value值
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
        //    var account = AccountModel.GetCurrentAccount();
            var vertion = AccountModel.GetVersion();
            if (colum == "GoldTempId")
            {
                GoldTempBLL gold = new GoldTempBLL();

                return new SelectList(gold.GetByVertion(vertion), "Id", "Name");
            }
            else if (colum == "Style")
            {
                InsuranceBLL ins = new InsuranceBLL();

                return new SelectList(ins.GetByVertion(vertion), "Id", "Name");
            }
            else if (colum == "CityId")
            {
                CityBLL city = new CityBLL();

                return new SelectList(city.GetByVertion(vertion), "Name", "Name");
            }
            else if (colum == "PoliceAccountNatureId")
            {
                PoliceAccountNatureBLL police = new PoliceAccountNatureBLL();

                return new SelectList(police.GetByVertion(vertion), "Name", "Name");
            }
            else if (colum == "RuleId")
            {
                RuleBLL rule = new RuleBLL();

                return new SelectList(rule.GetByVertion(vertion), "Id", "Name");
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return new SelectList(baseDDL.GetSysField(table, colum), "MyTexts", "MyTexts");

        }
        /// <summary>
        /// 获取字段，首选默认，Id做为value值
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysFieldById(string table, string colum)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return new SelectList(baseDDL.GetSysField(table, colum), "Id", "MyTexts");

        }
        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public static string GetMyTextsById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return string.Empty;
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return baseDDL.GetMyTextsById(id);

        }
    }
}

