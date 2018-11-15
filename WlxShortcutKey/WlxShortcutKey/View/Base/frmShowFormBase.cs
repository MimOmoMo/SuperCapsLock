using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.View.Base
{
    /// <summary> 临时呼出的窗体的基类
    /// 统一提供了按下ESC键退出的功能
    /// </summary>
    public class frmShowFormBase : Form
    {
        public frmShowFormBase()
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDlogBase_KeyDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void frmShowDlogBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
