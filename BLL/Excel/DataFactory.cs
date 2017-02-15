using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Langben.BLL
{
    /// <summary>
    /// 数据工厂
    /// </summary>
    public static class DataFactory
    {

        public static Standard CreateStandard(int? vertion)
        {
            switch (vertion)
            {
                case 36319772://用户的唯一表示

                    return new Standard36319772();

                default:
                    return new Standard36319772();
            }
        }
        public static IDictionary<int, int> CreateRelation(string goldTempId)
        {
            switch (goldTempId)
            {
                case "36319772001"://源模板（供应商模板）的唯一标识

                    return Relation36319772001.relation;
                case "36319772002"://源模板（供应商模板）的唯一标识
                    return Relation36319772002.relation;
                default:
                    return Relation36319772002.relation;
            }
        }
    }
}
