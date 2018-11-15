using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.View.Base;

namespace OfficeTools.View.ShortcutKeyManage
{
    /// <summary>用于选择特殊快捷键的窗体
    /// 
    /// </summary>
    public partial class frmShortcutKey_Edit_SpecialKey : frmShowFormBase
    {


        public frmShortcutKey_Edit_SpecialKey()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }

        private string _KeyNum = "";
        public string KeyNum
        {
            get { return _KeyNum; }
            set { _KeyNum = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            switch (((Button)sender).Name)
            {
                case "LeftTop_button":
                    _KeyNum = "ScreenLT";
                    break;
                case "RightTop_button":
                    _KeyNum = "ScreenRT";
                    break;
                case "LeftBottom_button":
                    _KeyNum = "ScreenLB";
                    break;
                case "RightBottom_button":
                    _KeyNum = "ScreenRB";
                    break;
                case "Top_button":
                    _KeyNum = "ScreenT";
                    break;
                case "Bottom_button":
                    _KeyNum = "ScreenB";
                    break;
                case "Left_button":
                    _KeyNum = "ScreenL";
                    break;
                case "Right_button":
                    _KeyNum = "ScreenR";
                    break;
                case "MouseWheelTop_button":
                    _KeyNum = "WheelUp";
                    break;
                case "MouseWheelDown_button":
                    _KeyNum = "WheelDown";
                    break;
            }
            this.DialogResult = DialogResult.OK;

            this.Close();
        }



    }
}
