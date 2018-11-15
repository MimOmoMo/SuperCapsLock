using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeTools.Entity;

namespace OfficeTools.View.Base
{
    /// <summary> 用于展示一个快捷按键的内容的接口[横向或纵向都可以使用此接口]
    /// </summary> 
    public interface IShortcutKeyItem_Box
    {
        /// <summary> 用于设置内容的对象
        /// </summary> 
        vShortCutKey DataEntity { get; set; }
        /// <summary> 快捷键名称
        /// </summary> 
        string NameText { get; set; }
        /// <summary> 键名称
        /// </summary> 
        string KeyName { get; set; }
    }
}
