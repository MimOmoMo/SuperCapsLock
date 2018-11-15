using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools.Entity
{
    /// <summary> 快捷键表
    /// </summary>
    [Table("tShortCutKey")]
    public class tShortCutKey
    {
        /// <summary> 主键ID
        /// </summary>
        [Key]
        public string ShortCutKeyID { get; set; }

        /// <summary> 父节点ID，可以为空，空表示根节点
        /// </summary>
        public string ParentID { get; set; }
        
        /// <summary> 快捷键名称
        /// </summary>
        public string ShortCutKeyName { get; set; }

        /// <summary> 准备打开的路径
        /// </summary>
        public string ShortCutKeyPath { get; set; }

        /// <summary> 快捷键代码
        /// </summary>
        public string ShortCutKey { get; set; }

        /// <summary> 图标
        /// </summary>
        public byte[] ShortCutKeyImg { get; set; }

        /// <summary> 类型
        /// 类型[0:文件;1:网址;2:系统组合键]
        /// </summary>
        public byte ShortCutKeyType { get; set; }


    }
}
