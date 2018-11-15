using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.View.Base;
using OfficeTools.Entity;
using OfficeTools.Public;
using System.Diagnostics;

namespace OfficeTools.View.Base
{
    /// <summary> 用于展示一些快捷键的分布情况
    /// </summary> 
    public partial class KeyLayoutShow : UserControl
    {
        public KeyLayoutShow()
        {
            InitializeComponent();
            SetEvent();//设置单击事件委托
            ClearContents();//清空数字键盘上的快捷键                      
        }
        private List<vShortCutKey> _DataSource = null;
        public List<vShortCutKey> DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
                ClearContents();
                if (_DataSource == null) return;
                List<vShortCutKey> KeyListTemp = _DataSource.Where(T1 => UniversalMethod.IsNumberKey(T1.ShortCutKey)).ToList();
                SetNumberKey(KeyListTemp);
                KeyListTemp = _DataSource.Where(T1 => !UniversalMethod.IsNumberKey(T1.ShortCutKey)).ToList();
                SetNotNumberKey(KeyListTemp);
            }
        }

        /// <summary> 给数字键盘委托单击事件
        /// </summary> 
        private void SetEvent()
        {
            List<ShortcutKeyItem_Box> NumberControlList = GetNumberKeyControl();
            NumberControlList.ForEach(T1 => T1.Click += new EventHandler(shortcutKeyItem_Box2_Click));
        }

        /// <summary> 清空当前页面上的所有内容
        /// </summary> 
        private void ClearContents()
        {
            NotNumberKey_flowLayoutPanel.Controls.Clear();
            List<ShortcutKeyItem_Box> ControlList = GetNumberKeyControl();
            foreach (ShortcutKeyItem_Box ControlItem in ControlList)
            {
                string KeyName = ControlItem.KeyName;
                string KeyNum = ControlItem.KeyNum;
                string StrNameText = "未设置";
                ControlItem.DataEntity = null;
                ControlItem.KeyName = KeyName;
                ControlItem.KeyNum = KeyNum;
                ControlItem.NameText = StrNameText;
            }
        }
        
        /// <summary> 设置数字键盘的快捷键
        /// </summary>
        /// <param name="KeyList">快捷键集合</param> 
        private void SetNumberKey(List<vShortCutKey> KeyList)
        {
            List<ShortcutKeyItem_Box> NumberControlList = GetNumberKeyControl();
            foreach (vShortCutKey Keyitem in KeyList)
            {
                List<ShortcutKeyItem_Box> ControlListTemp = NumberControlList.Where(T1 => T1.KeyNum == Keyitem.ShortCutKey).ToList();
                foreach (ShortcutKeyItem_Box ControlItem in ControlListTemp)
                {
                    ControlItem.DataEntity = Keyitem;
                }
            }
        }

        /// <summary> 设置其他快捷键
        /// </summary>
        /// <param name="KeyList">要设置的键[如果包含数字键也会被放在其他快捷键中]</param> 
        private void SetNotNumberKey(List<vShortCutKey> KeyList)
        {

            foreach (vShortCutKey KeyItem in KeyList)
            {
                ShortcutKeyItem_Box1 ControlTemp = new ShortcutKeyItem_Box1();
                ControlTemp.DataEntity = KeyItem;
                ControlTemp.Click += new EventHandler(shortcutKeyItem_Box2_Click);
                NotNumberKey_flowLayoutPanel.Controls.Add(ControlTemp);
            }          
        }
                
        /// <summary> 获取数字键盘的快捷键控件
        /// </summary>
        /// <returns></returns> 
        private List<ShortcutKeyItem_Box> GetNumberKeyControl()
        {
            List<Control> ControlList = GetControlList(NumberKey_tableLayoutPanel.Controls);
            ControlList = ControlList.Where(T1 => T1 is ShortcutKeyItem_Box).ToList();
            List<ShortcutKeyItem_Box> ResultList = ControlList.Select(T1 => (ShortcutKeyItem_Box)T1).ToList();
            return ResultList;

        }

        /// <summary> 递归获取某控件下的所有子控件
        /// </summary>
        /// <param name="CurrentContrl">某控件的Controls属性</param>
        /// <returns></returns> 
        private List<Control> GetControlList(ControlCollection CurrentContrl)
        {
            List<Control> ResultList = new List<Control>();
            foreach (Control ControlItem in CurrentContrl)
            {
                ResultList.Add(ControlItem);
                ResultList.AddRange(GetControlList(ControlItem.Controls));//递归
            }
            return ResultList;
        }

        /// <summary> 数字键盘和其他快捷键的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void shortcutKeyItem_Box2_Click(object sender, EventArgs e)
        {
            if (ItemClick != null) ItemClick(sender, e);            
        }
        /// <summary> 快捷键项目被单击
        /// </summary> 
        public event EventHandler ItemClick;

    }
}
