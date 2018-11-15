using OfficeTools.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.Public;
using OfficeTools.Service;
using System.IO;
using OfficeTools.View.Base;


namespace OfficeTools.View.ShortcutKeyManage
{
    public partial class frmShortcutKey_Edit : Form
    {
        public frmShortcutKey_Edit()
        {
            InitializeComponent();
        }

        public frmShortcutKey_Edit(tShortCutKey entity)
            : this()
        {
            CurrentEntity = entity;
        }


        private tShortCutKey _CurrentEntity = new tShortCutKey();
        public tShortCutKey CurrentEntity
        {
            get { return _CurrentEntity; }
            set { _CurrentEntity = value; }
        }
        private void FillContent()
        {
            if (CurrentEntity == null) return;
            Img_pictureBox.Image = CurrentEntity.ShortCutKeyImg.ToImage();
            Name_textBox.Text = CurrentEntity.ShortCutKeyName;
            KeyName_textBox.Text = UniversalMethod.GetKeyName(CurrentEntity.ShortCutKey);
            TypeName_textBox.Text = UniversalMethod.GetTypeName(CurrentEntity.ShortCutKeyType);


            if (CurrentEntity.ShortCutKeyType == 2)
            {
                Path_panel.Visible = false;
                SysShortcutKey_textBox.Text = CurrentEntity.ShortCutKeyPath;
            }
            else
            {
                Path_panel.Visible = true;
                Path_textBox.Text = CurrentEntity.ShortCutKeyPath;
            }                                              

            string ParentName = "根目录";
            if (!string.IsNullOrEmpty(CurrentEntity.ParentID))
            {
                tShortCutKey tShortCutKeyTemp = new ShortcutKeyManageService().GettShortCutKeyList(new tShortCutKey() { ShortCutKeyID = CurrentEntity.ParentID }).FirstOrDefault();
                if (tShortCutKeyTemp != null) ParentName = tShortCutKeyTemp.ShortCutKeyName;
            }
            ParentNode_textBox.Text = ParentName;
        }
                
        
        private void frmShortcutKey_Edit_Load(object sender, EventArgs e)
        {
            FillContent();
        }

        /// <summary> 打开类型被选择
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectType_button_Click(object sender, EventArgs e)
        {
            frmShortcutKey_Edit_OpenType frm = new frmShortcutKey_Edit_OpenType();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                byte TypeNum = frm.tShortCutKeyType;
                CurrentEntity.ShortCutKeyType = TypeNum;
                TypeName_textBox.Text = UniversalMethod.GetTypeName(CurrentEntity.ShortCutKeyType);
                if (TypeNum == 2)
                {
                    Path_panel.Visible = false;
                }
                else 
                {
                    Path_panel.Visible = true;                
                }

            }
        }

        /// <summary> 特殊按钮被点击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecialKey_button_Click(object sender, EventArgs e)
        {
            frmShortcutKey_Edit_SpecialKey frm = new frmShortcutKey_Edit_SpecialKey();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string KeyNum = frm.KeyNum;
                CurrentEntity.ShortCutKey = KeyNum;
                KeyName_textBox.Text = UniversalMethod.GetKeyName(CurrentEntity.ShortCutKey);                
            }

        }

        /// <summary> 将按下的按键转换为键盘上的按键名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void SysShortcutKey_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            List<string> KeyList = new List<string>();
            if (e.Control) KeyList.Add("Control");
            if (e.Alt) KeyList.Add("Alt");
            if (e.Shift) KeyList.Add("Shift");

            List<Keys> KeysEnumList = new List<Keys>();
            KeysEnumList.Add(Keys.Control);
            KeysEnumList.Add(Keys.ControlKey);
            KeysEnumList.Add(Keys.LControlKey);
            KeysEnumList.Add(Keys.RControlKey);
            KeysEnumList.Add(Keys.Shift);
            KeysEnumList.Add(Keys.ShiftKey);
            KeysEnumList.Add(Keys.LShiftKey);
            KeysEnumList.Add(Keys.RShiftKey);
            KeysEnumList.Add(Keys.Alt);
            KeysEnumList.Add(Keys.Menu);
            KeysEnumList.Add(Keys.LMenu);
            KeysEnumList.Add(Keys.RMenu);

            if (!KeysEnumList.Contains(e.KeyCode)) KeyList.Add(UniversalMethod.GetKeyName(e.KeyValue.ToString()));
            SysShortcutKey_textBox.Text = string.Join("+", KeyList);
        }

        /// <summary> 键盘按下时，禁止输入东西
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void SysShortcutKey_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        /// <summary> 将按下的按键转换为键盘上的按键名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void KeyName_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox CurrentControl = (TextBox)sender;
            CurrentEntity.ShortCutKey = e.KeyValue.ToString();
            CurrentControl.Text = UniversalMethod.GetKeyName(CurrentEntity.ShortCutKey);
        }

        /// <summary> 键盘按下时，禁止输入东西
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void KeyName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary> 选择文件路径时
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectPath_button_Click(object sender, EventArgs e)
        {
            if (CurrentEntity == null) return;
            switch (CurrentEntity.ShortCutKeyType)
            {
                case 0://文件/程序
                    SelectFilePath.Filter = "所有文件|*.*";                    
                    if (SelectFilePath.ShowDialog() == DialogResult.Cancel) return;
                    Path_textBox.Text = SelectFilePath.FileName;
                    Img_pictureBox.Image = UniversalMethod.GetImageByFileName(Path_textBox.Text);
                    if (string.IsNullOrEmpty(Name_textBox.Text)) Name_textBox.Text = Path.GetFileNameWithoutExtension(Path_textBox.Text);
                    break;
            }
        }

        /// <summary> 选择父节点被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectParent_button_Click(object sender, EventArgs e)
        {
            frmShortcutKey_Edit_SelectNode frm = new frmShortcutKey_Edit_SelectNode();
            frm.SelectedEntity = new tShortCutKey() { ShortCutKeyID=CurrentEntity.ParentID};

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity.ParentID = frm.SelectedEntity.ShortCutKeyID;
                ParentNode_textBox.Text = frm.SelectedEntity.ShortCutKeyName;

            }

        }

        /// <summary>图片框被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Img_pictureBox_Click(object sender, EventArgs e)
        {
            SelectFilePath.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp;*.ico";
            if (SelectFilePath.ShowDialog() != DialogResult.OK) return;
            string FilePath = SelectFilePath.FileName;
            byte[] ByteArray = System.IO.File.ReadAllBytes(FilePath);
            Img_pictureBox.Image = ByteArray.ToImage();
        }

        /// <summary>取消按钮被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary> 确定键单机
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_button_Click(object sender, EventArgs e)
        {
            CurrentEntity.ShortCutKeyImg = Img_pictureBox.Image.ToByteArray();
            CurrentEntity.ShortCutKeyName = Name_textBox.Text;
            if(CurrentEntity.ShortCutKeyType==2)
            {
                CurrentEntity.ShortCutKeyPath = SysShortcutKey_textBox.Text;
            }
            else
            {
                CurrentEntity.ShortCutKeyPath = Path_textBox.Text;
            }            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>选择系统快捷键
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysShortcutKey_button_Click(object sender, EventArgs e)
        {
            frmShortcutKey_Edit_SysKey frm = new frmShortcutKey_Edit_SysKey(SysShortcutKey_textBox.Text);
            if(frm.ShowDialog()==DialogResult.OK)
            {
                SysShortcutKey_textBox.Text = frm.KeyName;                
            }
        }
    }
}
