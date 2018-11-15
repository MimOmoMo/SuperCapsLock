using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.db;

namespace OfficeTools
{
    static class Program
    {
        /// <summary> 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Database.SetInitializer<OfficeToolsDb>(null);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmShortcutKeyManage());
            //Application.Run(new frmShortcutKey_Show());
        }
    }
}
