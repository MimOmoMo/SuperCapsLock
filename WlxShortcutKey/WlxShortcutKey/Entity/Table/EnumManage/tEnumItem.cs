using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools.Entity
{
    /// <summary> 枚举项表
    /// 
    /// </summary>
    [Table("tEnumItem")]
    class tEnumItem
    {
        /// <summary>主键
        /// 
        /// </summary>
        [Key]
        public string EnumItemID { get; set; }
        
        /// <summary>枚举表ID
        /// 
        /// </summary>
        public string EnumProjectID { get; set; }
        
        /// <summary> 枚举项编号
        /// 
        /// </summary>
        public string EnumItemNo { get; set; }
        
        /// <summary> 枚举项的值
        /// 
        /// </summary>
        public string EnumValue { get; set; }
    }
}
