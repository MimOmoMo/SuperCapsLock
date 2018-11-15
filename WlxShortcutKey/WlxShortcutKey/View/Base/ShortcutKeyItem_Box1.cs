using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.Entity;
using OfficeTools.Public;


namespace OfficeTools.View.Base
{
    /// <summary> 用于展示一个快捷按键的内容[纵向展示]
    /// </summary> 
    public partial class ShortcutKeyItem_Box1 : UserControl,IShortcutKeyItem_Box
    {
        public ShortcutKeyItem_Box1()
        {
            InitializeComponent();
            this.BackColor = CurrentColorStruct.Normaly;
        }

        /// <summary> 当前状态的颜色
        /// </summary> 
        private OfficeTools.View.Base.ShortcutKeyItem_Box.ColorStruct CurrentColorStruct = OfficeTools.View.Base.ShortcutKeyItem_Box._ShortcutKeyItem_Box_StateColor.NotSet;

        #region 公开属性

        /// <summary> 用于设置内容的对象
        /// </summary> 
        public vShortCutKey DataEntity
        {
            get
            {
                return _DataEntity;
            }
            set
            {
                if (value == null) return;
                Img_pictureBox.Image = value.ShortCutKeyImg.ToImage();
                Name_label.Text = value.ShortCutKeyName;
                Key_label.Text = UniversalMethod.GetKeyName(value.ShortCutKey);
                _DataEntity = value;
                if (value.OwningChidrenNode) CurrentColorStruct = OfficeTools.View.Base.ShortcutKeyItem_Box._ShortcutKeyItem_Box_StateColor.OwiningChidren;
                else CurrentColorStruct =
                OfficeTools.View.Base.ShortcutKeyItem_Box._ShortcutKeyItem_Box_StateColor.NotChirdren;
                this.BackColor = CurrentColorStruct.Normaly;

            }
        }
        private vShortCutKey _DataEntity = null;

        /// <summary> 快捷键名称
        /// </summary> 
        public string NameText
        {
            get { return Name_label.Text; }
            set
            {
                Name_label.Text = value;
            }
        }

        /// <summary> 键名称
        /// </summary> 
        public string KeyName
        {
            get { return Key_label.Text; }
            set
            {
                Key_label.Text = value;
            }
        }
        #endregion 公开属性


        #region 鼠标变色事件
        private void ShortcutKeyItem_Box_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = CurrentColorStruct.Normaly;
        }
        private void ShortcutKeyItem_Box_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = CurrentColorStruct.Enter;
        }
        private void ShortcutKeyItem_Box_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = CurrentColorStruct.Click;
        }
        private void ShortcutKeyItem_Box_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = CurrentColorStruct.Enter;
        }
        #endregion 鼠标变色事件

        private void ShortcutKeyItem_Box_Click(object sender, EventArgs e)
        {
            if (Click != null) Click(this, e);
        }
        public new event EventHandler Click;//继承事件
    }
}
