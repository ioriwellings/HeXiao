using System;
using System.Collections.Generic;
using Langben.App.Models;
using Langben.DAL;

namespace Langben.App.Models
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class SysMenuTree
    {
        public SysMenuTree()
        {
            ChildMenus = new List<SysMenu>();
        }
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 提示数字
        /// </summary>
        public Nullable<Int32> ShowNumber { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<Int32> Sort { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 菜单标识
        /// </summary>
        public string MenuFlg { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public string IsParent { get; set; }
        /// <summary>
        /// 父节点标识
        /// </summary>
        public string ParentFlg { get; set; }
        /// <summary>
        /// 菜单样式
        /// </summary>
        public string MenuClass { get; set; }
        /// <summary>
        /// 首页展示
        /// </summary>
        public Nullable<Int32> FrontPageShow { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<SysMenu> ChildMenus { get; set; }

    }

}



