using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools.Entity
{

    /// <summary> 枚举表
    /// 
    /// </summary>
    [Table("tEnumProject")]
    class tEnumProject
    {
        /// <summary> 枚举表ID
        /// 
        /// </summary>
                [Key]
        public string EnumProjectID { get; set; }
        /// <summary> 枚举名称
        /// 
        /// </summary>
        public string EnumName { get; set; }
    }
}
