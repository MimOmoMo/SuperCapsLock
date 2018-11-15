using OfficeTools.View.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.View.ShortcutKeyManage
{
    /// <summary>选择启动类型的窗体，窗体关闭后tShortCutKeyType表示选择结果
    /// 
    /// </summary>
    public partial class frmShortcutKey_Edit_OpenType : frmShowFormBase
    {
        public frmShortcutKey_Edit_OpenType()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }
        private byte _tShortCutKeyType = 0;
        public byte tShortCutKeyType
        {
            get { return _tShortCutKeyType; }
            set { _tShortCutKeyType = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            switch (((Button)sender).Name)
            {
                case "Program_button":
                    _tShortCutKeyType = 0;
                    break;
                case "WebSite_button":
                    _tShortCutKeyType = 1;
                    break;
                case "SysShortcutKey_button":
                    _tShortCutKeyType = 2;
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }     
    }
}
