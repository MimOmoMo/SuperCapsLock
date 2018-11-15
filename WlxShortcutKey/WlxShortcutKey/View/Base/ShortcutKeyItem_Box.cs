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
using System.Diagnostics;


namespace OfficeTools.View.Base
{


    [ToolboxItem(true)]
    /// <summary> 用于展示一个快捷按键的内容[横向展示]
    /// </summary> 
    public partial class ShortcutKeyItem_Box : UserControl,IShortcutKeyItem_Box
    {
        #region 内部类
        /// <summary> 控件的几组颜色表示控件的状态，其中包含：未设置快捷键时、正常时、拥有下级节点时的颜色
        /// </summary> 
        public class StateColor
        {
            /// <summary> 有子节点时的颜色组
            /// </summary> 
            public ColorStruct OwiningChidren { get; set; }
            /// <summary> 没有子节点时的颜色组
            /// </summary> 
            public ColorStruct NotChirdren { get; set; }
            /// <summary> 还未对控件进行设置时的颜色组
            /// </summary> 
            public ColorStruct NotSet { get; set; }

        }

        /// <summary> 控件的一组颜色，其中包含控件正常时、按下时、鼠标悬停时的颜色
        /// </summary> 
        public class ColorStruct
        {
            /// <summary> 控件正常时的颜色
            /// </summary> 
            public Color Normaly { get; set; }

            /// <summary> 鼠标悬停时的颜色[一般比正常时稍暗]
            /// </summary> 
            public Color Enter { get; set; }

            /// <summary> 鼠标按下时的颜色[一般比正常时稍亮]
            /// </summary> 
            public Color Click { get; set; }
        }
        #endregion 内部类

        #region 静态属性
        public static StateColor _ShortcutKeyItem_Box_StateColor = new StateColor()
     {
         NotChirdren = new ColorStruct() { Normaly = Color.FromArgb(74, 137, 220), Enter = Color.FromArgb(100, 154, 225), Click = Color.FromArgb(48, 120, 215) },
         OwiningChidren = new ColorStruct() { Normaly = Color.FromArgb(59, 175, 218), Enter = Color.FromArgb(85, 186, 223), Click = Color.FromArgb(39, 162, 207) },
         NotSet = new ColorStruct() { Normaly = Color.FromArgb(246, 187, 66), Enter = Color.FromArgb(247, 198, 95), Click = Color.FromArgb(245, 176, 37) }
     };
        /// <summary> 获取ShortcutKeyItem_Box控件的三种状态的颜色
        /// </summary> 
        public static StateColor ShortcutKeyItem_Box_StateColor { get { return _ShortcutKeyItem_Box_StateColor; } }
        #endregion

        public ShortcutKeyItem_Box()
        {           
            InitializeComponent();            
            this.BackColor = CurrentColorStruct.Normaly;
        }

        private ColorStruct CurrentColorStruct = _ShortcutKeyItem_Box_StateColor.NotSet;

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

                _DataEntity = value;
                if (value == null)
                {
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortcutKeyItem_Box));
                    this.Img_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Img_pictureBox.Image")));
                    Name_label.Text = "未设置";
                    Key_label.Text = "未设置";
                    CurrentColorStruct = _ShortcutKeyItem_Box_StateColor.NotSet;
                }
                else
                {
                    Img_pictureBox.Image = value.ShortCutKeyImg.ToImage();
                    Name_label.Text = value.ShortCutKeyName;
                    Key_label.Text = UniversalMethod.GetKeyName(value.ShortCutKey);
                    if (value.OwningChidrenNode)
                    {
                        CurrentColorStruct = _ShortcutKeyItem_Box_StateColor.OwiningChidren;
                    }
                    else
                    {
                        CurrentColorStruct = _ShortcutKeyItem_Box_StateColor.NotChirdren;
                    }
                }
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

        /// <summary> 键代码
        /// 标识这个控件准备给那个键使用、只有标记意义，没有实际意义
        /// </summary> 
        public string KeyNum { get; set; }
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


        /// <summary> 单击控件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ShortcutKeyItem_Box_Click(object sender, EventArgs e)
        {
            if (Click != null) Click(this, e);
        }
        public new event EventHandler Click;//继承事件


    }
}
