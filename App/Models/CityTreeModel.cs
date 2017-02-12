using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Text;
using Models;
namespace Langben.App.Models
{
    /// <summary>
    /// 缴纳地
    /// </summary>
    public class CityTreeNodeCollection
    {
        IEnumerable<City> listTree;
        public bool Bind(IEnumerable<City> entitys, string myCit_Id, ref List<SystemTree> myChildren)
        {
            if (null != myCit_Id)
                listTree = from o in entitys
                           where o.Cit_Id == myCit_Id
                           select o;//叶子节点            
            else
                listTree = from o in entitys
                           where o.Cit_Id == null
                           select o;//根目录

            if (listTree != null && listTree.Any())
            {//填充数据
                foreach (var item in listTree)
                {
                    SystemTree myTree = new SystemTree() { id = item.Id.GetString(), text = item.Name.GetString() };
                    //if (string.IsNullOrWhiteSpace(item.Status))
                    //    myTree.@checked = false;
                    //else
                    //    myTree.@checked = true;
                        //if (!string.IsNullOrWhiteSpace(item.Iconic))
                    //    myTree.iconCls = item.Iconic;//开启图标
                    myChildren.Add(myTree);
                    if (Bind(entitys, item.Id, ref myTree.children))//递归调用
                    {
                        if (null != item.Cit_Id)
                        {//根目录
                           // myTree.iconCls = "icon-ok";//如果包含此字符串，则点击查看全部
                            myTree.state = "open";//默认是打开还是关闭
                        }
                        else
                        {
                            myTree.state = "closed";
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }               
        }
    
    
    }
}


