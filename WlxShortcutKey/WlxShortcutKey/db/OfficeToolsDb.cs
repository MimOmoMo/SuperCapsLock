using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.Entity;
using System.IO;


namespace OfficeTools.db
{
    class OfficeToolsDb : DbContext
    {
        public OfficeToolsDb()
            : base(new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\db\Database.sqlite;Version=3;"), false)
        {
            if (!File.Exists(Application.StartupPath + @"\db\Database.sqlite"))
            {
                File.Copy(Application.StartupPath + @"\db\DbBack\Database.sqlite", Application.StartupPath + @"\db\Database.sqlite");
            }            
        }

        /// <summary> 快捷键表
        /// 
        /// </summary>
        public DbSet<tShortCutKey> tShortCutKey { get; set; }

        /// <summary> 枚举表
        /// 
        /// </summary>
        public DbSet<tEnumProject> tEnumProject { get; set; }
        /// <summary> 枚举项表
        /// 
        /// </summary>
        public DbSet<tEnumItem> tEnumItem { get; set; }




    }
}
