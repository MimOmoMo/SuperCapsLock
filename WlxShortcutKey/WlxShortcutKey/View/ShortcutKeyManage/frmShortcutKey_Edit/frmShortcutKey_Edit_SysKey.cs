using OfficeTools.Public;
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
    /// <summary>用于启动类型为[2：系统快捷键]时选择快捷键使用的窗体，窗体关闭后KeyName属性表示返回结果
    /// 
    /// </summary>
    public partial class frmShortcutKey_Edit_SysKey : frmShowFormBase
    {
        /// <summary>所有控制键
        /// 
        /// </summary>
        private List<Keys> ControlKeysList = new List<Keys>() { Keys.ControlKey, Keys.Menu, Keys.ShiftKey, Keys.LWin };

        public frmShortcutKey_Edit_SysKey()
        {
            InitializeComponent();
        }
        public frmShortcutKey_Edit_SysKey(string StrKey)
            : this()
        {
            if (string.IsNullOrEmpty(StrKey)) return;
            
            List<Keys> ResultList = new List<Keys>();
            List<string> KeyNameList = StrKey.Split('+').ToList();
            foreach (string KeyName in KeyNameList)
            {
                Keys ResultKey = new Keys();
                if (!Enum.TryParse<Keys>(KeyName, out ResultKey)) continue;
                if (ControlKeysList.Contains(ResultKey))
                {
                    ResultList.Add(ResultKey);
                    switch (ResultKey)
                    {
                        case Keys.ControlKey:
                            Control_checkBox.Checked = true;
                            break;
                        case Keys.Menu:
                            Alt_checkBox.Checked = true;
                            break;
                        case Keys.ShiftKey:
                            Shift_checkBox.Checked = true;
                            break;
                        case Keys.LWin:
                            Win_checkBox.Checked = true;
                            break;
                    }
                }
                else
                {
                    Key = ResultKey;
                }
            }
            ShowSysKey();
        }
        /// <summary>按下的控制键
        /// 
        /// </summary>
        private List<Keys> KeysList = new List<Keys>();

        /// <summary>键代码
        /// 
        /// </summary>
        private Keys? Key = null;

        public string KeyName { get { return Result_textBox.Text; } }

        /// <summary> 将按下的按键转换为键盘上的按键名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void KeyName_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox CurrentControl = (TextBox)sender;
            Key = e.KeyCode;
            ShowSysKey();
        }

        /// <summary> 键盘按下时，禁止输入东西
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void KeyName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CheckBoxTemp = ((CheckBox)sender);
            switch (CheckBoxTemp.Text)
            {
                case "Control":
                    KeysList = KeysList.Where(T1 => T1 != Keys.ControlKey).ToList();
                    if (CheckBoxTemp.Checked) KeysList.Add(Keys.ControlKey);
                    break;
                case "Alt":
                    KeysList = KeysList.Where(T1 => T1 != Keys.Menu).ToList();
                    if (CheckBoxTemp.Checked) KeysList.Add(Keys.Menu);
                    break;
                case "Shift":
                    KeysList = KeysList.Where(T1 => T1 != Keys.ShiftKey).ToList();
                    if (CheckBoxTemp.Checked) KeysList.Add(Keys.ShiftKey);
                    break;
                case "Win":
                    KeysList = KeysList.Where(T1 => T1 != Keys.LWin).ToList();
                    if (CheckBoxTemp.Checked) KeysList.Add(Keys.LWin);
                    break;
            }
            ShowSysKey();
        }
        private void ShowSysKey()
        {
            List<string> StrKeyList = KeysList.Select(T1 => Enum.GetName(typeof(Keys), T1)).ToList();
            if (Key != null) StrKeyList.Add(Enum.GetName(typeof(Keys), Key));
            Result_textBox.Text = string.Join("+", StrKeyList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
