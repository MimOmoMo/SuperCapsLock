using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.db;
using OfficeTools.Entity;
using OfficeTools.Service;
using OfficeTools.View.Base;
using System.IO;
using System.Drawing.Imaging;
using OfficeTools.Public;
using IWshRuntimeLibrary;
using System.Text.RegularExpressions;
using OfficeTools.Resource.Image;
using OfficeTools.View.ShortcutKeyManage;

namespace OfficeTools
{
    public partial class frmShortcutKeyManage : Form
    {

        /// <summary> 所有快捷键的存储记录
        /// </summary> 
        private List<tShortCutKey> tShortCutKeyDataSource = null;

        /// <summary> 当前编辑的快捷键
        /// </summary> 
        private tShortCutKey EditShortCutKey = null;

        /// <summary> 是否允许关闭窗口
        /// </summary> 
        private bool CanCloseFrom = false;

        public frmShortcutKeyManage()
        {

            InitializeComponent();
            BackMission_notifyIcon.Icon = this.Icon;//右下角图标改为当前窗口图标            
            CurrentNode_dataGridView.AutoGenerateColumns = false;//取消自动生成列
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.HideTabItem();

            FormLoadTime.Enabled = true;
        }

        private void FormLoadTime_Tick(object sender, EventArgs e)
        {
            FormLoadTime.Enabled = false;
            this.Visible = false;
            InitKeyList();

            ShortcutKeyTools frm = new ShortcutKeyTools(this);
            frm.ParentForm = this;
           
        }

        #region 方法

        /// <summary> 获取所有快捷键数据
        /// </summary> 
        private void InitKeyList()
        {
            List<tShortCutKey> tShortCutKeyList = new ShortcutKeyManageService().GettShortCutKeyList();
            tShortCutKeyDataSource = tShortCutKeyList;
            RefreshTreeView();
        }

        /// <summary> 刷新列表
        /// </summary> 
        private void RefreshTreeView()
        {
            TreeNode SelectedNode = ShortcutKey_otTreeView.SelectedNode;//记录刷新之前选中的节点
            ShortcutKey_otTreeView.Nodes.Clear();
            ShortcutKey_imageList.Images.Clear();

            foreach (tShortCutKey tShortCutKeyItem in tShortCutKeyDataSource)
            {
                if (tShortCutKeyItem.ShortCutKeyImg.Length == 0) continue;
                ShortcutKey_imageList.Images.Add(tShortCutKeyItem.ShortCutKeyID, tShortCutKeyItem.ShortCutKeyImg.ToImage());
            }
            OTTreeView.TreeViewNodeStruct StructTemp = new OTTreeView.TreeViewNodeStruct() { KeyName = "ShortCutKeyID", ValueName = "ShortCutKeyName", ParentName = "ParentID" };
            ShortcutKey_otTreeView.SetDataSource<tShortCutKey>(tShortCutKeyDataSource, StructTemp);
            ShortcutKey_otTreeView.ExpandAll();
            RefreshDataGridView();            //填充右侧表格

            #region 将选中行定位到刷新之前的行
            try
            {
                Exception SetNodeEx = new Exception("NotReSettingNode");//如果无法设置当前节点就抛出这个异常来设置根节点为选中节点
                if (SelectedNode == null) throw SetNodeEx;
                if (string.IsNullOrEmpty(SelectedNode.Name)) throw SetNodeEx;
                TreeNode[] TreeNodeArray = ShortcutKey_otTreeView.Nodes.Find(SelectedNode.Name, true);
                TreeNode TreeNodeTemp = TreeNodeArray.FirstOrDefault();
                if (TreeNodeTemp == null) throw SetNodeEx;
                ShortcutKey_otTreeView.SelectedNode = TreeNodeTemp;
            }
            #region 设置根节点为选中节点
            catch (Exception ex)
            {
                if (ex.Message == "NotReSettingNode")
                    if (ShortcutKey_otTreeView.isBaseNode)
                    {
                        ShortcutKey_otTreeView.SelectedNode = ShortcutKey_otTreeView.GetBaseTreeNode();
                    }
            }
            #endregion 设置根节点为选中节点
            #endregion 将选中行定位到刷新之前的行
        }

        /// <summary> 刷新DataGridView
        /// 
        /// </summary>
        private void RefreshDataGridView()
        {
            string CurrentSelectID = CurrentNode_dataGridView.GetSelectedRowValue("ShortCutKeyID");


            TreeNode CurrentNode = ShortcutKey_otTreeView.SelectedNode;
            List<tShortCutKey> tShortCutKeyListTemp = new List<tShortCutKey>();
            if (CurrentNode == null || CurrentNode.Name == "BaseNode")
                tShortCutKeyListTemp = tShortCutKeyDataSource.Where(T1 => string.IsNullOrEmpty(T1.ParentID)).ToList();
            else tShortCutKeyListTemp = tShortCutKeyDataSource.Where(T1 => CurrentNode.Name == T1.ParentID).ToList();

            List<vShortCutKey> vShortCutKeyListTemp = new List<vShortCutKey>();//最终的数据源
            foreach (tShortCutKey tShortCutKeyItem in tShortCutKeyListTemp)
            {
                vShortCutKey vShortCutKeyTemp = UniversalMethod.ClassToClass<tShortCutKey, vShortCutKey>(tShortCutKeyItem, new vShortCutKey());
                vShortCutKeyTemp.Icon = tShortCutKeyItem.ShortCutKeyImg.ToImage();
                vShortCutKeyTemp.KeyName = UniversalMethod.GetKeyName(tShortCutKeyItem.ShortCutKey);
                vShortCutKeyTemp.ShortCutKeyTypeName = UniversalMethod.GetTypeName(tShortCutKeyItem.ShortCutKeyType);
                vShortCutKeyTemp.OwningChidrenNode = OwningChidren(vShortCutKeyTemp);
                vShortCutKeyListTemp.Add(vShortCutKeyTemp);
            }
            CurrentNode_dataGridView.DataSource = vShortCutKeyListTemp;

            #region 有子节点的话就用颜色区分出来
            foreach (DataGridViewRow Rowitem in CurrentNode_dataGridView.Rows)
            {
                if (Rowitem.Cells["IsChidren"].Value.ToString() == "True")
                {
                    DataGridViewCellStyle CellStyleTemp = Rowitem.DefaultCellStyle;
                    CellStyleTemp.BackColor = Color.Blue;
                    //CellStyleTemp.SelectionBackColor = ShortcutKeyItem_Box.ShortcutKeyItem_Box_StateColor.OwiningChidren.Click;
                }
            }
            #endregion 有子节点的话就用颜色区分出来

            CurrentNode_dataGridView.SetSelectedRowByValue("ShortCutKeyID", CurrentSelectID);
        }

        /// <summary> 检查是否拥有子节点
        /// </summary>
        private bool OwningChidren(vShortCutKey KeyEntity)
        {
            int ResultCount = tShortCutKeyDataSource.Where(T1 => T1.ParentID == KeyEntity.ShortCutKeyID).Count();
            if (ResultCount == 0) return false;
            else return true;
        }

        /// <summary> 以当前选中的快捷键为基础添加一个快捷键
        /// 
        /// </summary>
        /// <param name="IsChidren">[true:添加的快捷键是当前选中的快捷键的子节点;false:添加的选中快捷键的同级快捷键]</param> 
        private string AddtShortcutKey(bool IsChidren = true)
        {
            tShortCutKey AddData = new tShortCutKey()
            {
                ShortCutKeyName = "新增快捷键",
                ParentID = "",
                ShortCutKey = "",
                ShortCutKeyPath = "",
                ShortCutKeyType = 0,
                ShortCutKeyImg = new byte[0]
            };

            AddData.ShortCutKeyImg = OfficeTools.Resource.Image.Image.ShortcutKeyDefualtImage.ToImage().ToByteArray();
            TreeNode CurrentNode = ShortcutKey_otTreeView.SelectedNode;
            if (CurrentNode != null)
            {
                tShortCutKey CurrentEntity = tShortCutKeyDataSource.Where(T1 => T1.ShortCutKeyID == CurrentNode.Name).FirstOrDefault();
                if (CurrentEntity != null)
                {
                    AddData.ParentID = CurrentEntity.ParentID;
                    if (IsChidren)
                        AddData.ParentID = CurrentEntity.ShortCutKeyID;
                }
            }
            int KeuNum = GetDefaultKey(AddData.ParentID);
            if (KeuNum != -1) AddData.ShortCutKey = KeuNum.ToString();
            string NewID = new ShortcutKeyManageService().AddShortCutKey(AddData);
            if (!string.IsNullOrEmpty(NewID))
            {
                InitKeyList();
            }
            return NewID;
        }

        /// <summary> 获取还没有被注册的快捷键编号
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns> 
        private int GetDefaultKey(string ParentId = null)
        {
            List<tShortCutKey> tShortCutKeyList = null;

            if (string.IsNullOrEmpty(ParentId))
            {
                tShortCutKeyList = tShortCutKeyDataSource.Where(T1 => string.IsNullOrEmpty(T1.ParentID)).ToList();
            }
            else
            {
                tShortCutKeyList = tShortCutKeyDataSource.Where(T1 => T1.ParentID == ParentId).ToList();
            }
            tShortCutKeyList = tShortCutKeyList.Where(T1 => !string.IsNullOrEmpty(T1.ShortCutKey)).ToList();//去没有定义快捷键的记录
            Regex RegexTemp = new Regex(@"[^\d]");
            tShortCutKeyList = tShortCutKeyList.Where(T1 => !RegexTemp.Match(T1.ShortCutKey).Success).ToList();//去除不能转换成Int类型的记录

            List<int> KeyNumList = tShortCutKeyList.Select(T1 => Int32.Parse(T1.ShortCutKey)).ToList();//已经被定义的快捷键编号

            List<int> AutoKeyNumList = new List<int>() { 96, 97, 98, 99, 100, 101, 102, 103, 104, 105 };//允许自动填入的快捷键编号

            //KeyNumList = KeyNumList.Where(T1 => AutoKeyNumList.Contains(T1)).ToString();

            AutoKeyNumList = AutoKeyNumList.Where(T1 => !KeyNumList.Contains(T1)).ToList();//取出还没有被定义的快捷键编号

            if (AutoKeyNumList.Count == 0) return -1;

            return AutoKeyNumList.Min();
        }

        #endregion 方法

        #region 事件
        /// <summary> 添加快捷键[按钮单击]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void Add_button_Click(object sender, EventArgs e)
        {
            string StrID = "";
            if (((Button)sender).Name == "Add_button")
            {
                StrID = AddtShortcutKey(false);
            }
            else
            {
                StrID = AddtShortcutKey(true);
            }
            if (string.IsNullOrEmpty(StrID)) return;
            TreeNode TreeNodeTemp = ShortcutKey_otTreeView.Nodes.Find(StrID, true).FirstOrDefault();//将当前选中项选择为最新添加的记录
            if (TreeNodeTemp != null)
                ShortcutKey_otTreeView.SelectedNode = TreeNodeTemp;

        }

        /// <summary> 删除快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void Remove_button_Click(object sender, EventArgs e)
        {
            TreeNode CurrentNode = ShortcutKey_otTreeView.SelectedNode;
            if (CurrentNode == null) return;
            tShortCutKey RemoveData = new tShortCutKey() { ShortCutKeyID = CurrentNode.Name };
            if (new ShortcutKeyManageService().DeleteShortCutKey(RemoveData)) InitKeyList();
        }

        /// <summary> 每当选择一个快捷键就将这个快捷键的详细信息填入到右边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ShortcutKey_otTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshDataGridView();         
        }
        
        /// <summary> 按下某键时发生，主要用于快捷键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ShortcutKey_otTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            string StrID = "";
            switch (e.KeyCode)
            {
                case Keys.Enter://按下Enter添加同级节点
                    StrID = AddtShortcutKey(false);
                    ShortcutKey_otTreeView.SelectedNode.BeginEdit();
                    break;
                case Keys.Tab://按下Table添加子节点
                    StrID = AddtShortcutKey(true);
                    ShortcutKey_otTreeView.SelectedNode.BeginEdit();
                    break;
                case Keys.Delete://按下Delete删除当前节点
                    Remove_button_Click(null, null);
                    break;
            }
            if (string.IsNullOrEmpty(StrID)) return;
            TreeNode TreeNodeTemp = ShortcutKey_otTreeView.Nodes.Find(StrID, true).FirstOrDefault();//将当前选中项选择为最新添加的记录
            if (TreeNodeTemp != null)
                ShortcutKey_otTreeView.SelectedNode = TreeNodeTemp;
        }

        /// <summary> 当编辑节点名称后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ShortcutKey_otTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode CurrentNode = ShortcutKey_otTreeView.SelectedNode;
            if (CurrentNode.Text == e.Label || string.IsNullOrEmpty(e.Label)) return;//如果内容没有发生改变就返回
            tShortCutKey tShortCutKeyTemp = tShortCutKeyDataSource.Where(T1 => T1.ShortCutKeyID == CurrentNode.Name).FirstOrDefault();
            tShortCutKeyTemp.ShortCutKeyName = e.Label ?? "";
            ShortcutKey_otTreeView_AfterSelect(null, null);//发生了改变就把名称同步到右边
            new ShortcutKeyManageService().UpdateShortcutKey(tShortCutKeyTemp);//并保存这个名称
        }
        

        /// <summary> 拖入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        /// <summary> 将文件拖拽到窗口后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            System.Array ArrayTemp = ((System.Array)e.Data.GetData(DataFormats.FileDrop));
            if (ArrayTemp == null) return;//不支持的格式直接返回

            List<string> FilePathList = new List<string>();
            for (int i = 0; i < ArrayTemp.Length; i++)
            {
                FilePathList.Add(ArrayTemp.GetValue(i).ToString());
            }

            #region 获取父ID，使新添加的记录与当前选中节点处于同一级别

            string StrParentId = "";
            TreeNode CurrentNode = ShortcutKey_otTreeView.SelectedNode;
            if (CurrentNode != null)
            {
                tShortCutKey CurrentEntity = tShortCutKeyDataSource.Where(T1 => T1.ShortCutKeyID == CurrentNode.Name).FirstOrDefault();
                if (CurrentEntity != null)
                {
                    StrParentId = CurrentEntity.ShortCutKeyID;
                }
            }
            #endregion 获取父ID，使新添加的记录与当前选中节点处于同一级别

            foreach (string PathItem in FilePathList)
            {
                string StrFileName = Path.GetFileNameWithoutExtension(PathItem);//获取快捷键名称

                int KeyNum = GetDefaultKey(StrParentId);
                string StrKeyNum = "";
                if (KeyNum != -1) StrKeyNum = KeyNum.ToString();//获取默认键编号

                int FileType = 0;//设置打开类型

                byte[] ImageByteArray = UniversalMethod.GetImageByFileName(PathItem).ToByteArray();//获取文件图标

                #region 获取快捷方式真实路径
                string StrPath = PathItem;
                string StrExtension = Path.GetExtension(PathItem);
                if (!string.IsNullOrEmpty(StrExtension))//文件
                {
                    if (StrExtension == ".lnk")
                    {

                        WshShell ShellTemp = new WshShell();
                        IWshShortcut IWshShortcutTemp = (IWshShortcut)ShellTemp.CreateShortcut(PathItem);
                        StrPath = IWshShortcutTemp.TargetPath;
                        StrExtension = Path.GetExtension(StrPath);
                        if (string.IsNullOrEmpty(StrExtension)) FileType = 1;
                    }
                }
                else//文件夹
                {
                    FileType = 1;
                }
                Regex RegexTemp = new Regex(@"https{0,1}\:\/\/");
                if (RegexTemp.Match(StrPath).Success)//是否是网址
                {
                    FileType = 2;
                }
                #endregion 获取快捷方式真实路径

                #region 实例化AddData
                tShortCutKey AddData = new tShortCutKey()
                {
                    ShortCutKeyName = StrFileName,
                    ParentID = StrParentId,
                    ShortCutKey = StrKeyNum,
                    ShortCutKeyPath = StrPath,
                    ShortCutKeyType = (byte)FileType,
                    ShortCutKeyImg = ImageByteArray
                };
                #endregion 实例化AddData
                string NewID = new ShortcutKeyManageService().AddShortCutKey(AddData);
                tShortCutKeyDataSource.Add(AddData);
            }
            InitKeyList();
        }

        /// <summary> 窗口即将被关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void frmShortcutKeyManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = !CanCloseFrom;
        }

        /// <summary> 右下角图标被双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BackMission_notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        /// <summary> 退出程序菜单被选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanCloseFrom = true;
            this.Close();
        }


        /// <summary> 窗体按下ESC键退出
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShortcutKeyManage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        /// <summary> 双击某快捷键进入编辑
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentNode_dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button != MouseButtons.Left) return;
            DataGridViewSelectedRowCollection SelectedRowArrayTemp = CurrentNode_dataGridView.SelectedRows;
            if (SelectedRowArrayTemp.Count == 0) return;
            DataGridViewRow SelectedRowTemp = SelectedRowArrayTemp[0];
            string CurrentID = SelectedRowTemp.Cells["ShortCutKeyID"].Value.ToString();
            tShortCutKey CurrentEntity = tShortCutKeyDataSource.Where(T1 => T1.ShortCutKeyID == CurrentID).FirstOrDefault();
            if (CurrentEntity == null) return;
            frmShortcutKey_Edit frm = new frmShortcutKey_Edit(CurrentEntity);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                new ShortcutKeyManageService().UpdateShortcutKey(frm.CurrentEntity);
                InitKeyList();
            }
        }

        /// <summary>返回按钮被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_button_Click(object sender, EventArgs e)
        {
            if (ShortcutKey_otTreeView.SelectedNode.Name == "BaseNode") return;
            string StrID = ShortcutKey_otTreeView.SelectedNode.Name;
            ShortcutKey_otTreeView.SelectedNode = ShortcutKey_otTreeView.SelectedNode.Parent;
            CurrentNode_dataGridView.SetSelectedRowByValue("ShortCutKeyID", StrID);//设置当前选中项目
        }

        /// <summary> 进入按钮被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enter_button_Click(object sender, EventArgs e)
        {
            if (CurrentNode_dataGridView.SelectedRows.Count == 0) return;
            string StrID = CurrentNode_dataGridView.SelectedRows[0].Cells["ShortCutKeyID"].Value.ToString();
            TreeNode[] TreeNodeTempArray = ShortcutKey_otTreeView.SelectedNode.Nodes.Find(StrID, false);
            if (TreeNodeTempArray.Length == 0) return;
            ShortcutKey_otTreeView.SelectedNode = TreeNodeTempArray[0];
        }

        /// <summary> 编辑按钮被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_button_Click(object sender, EventArgs e)
        {

            CurrentNode_dataGridView_DoubleClick(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0));
        }
        /// <summary> 添加按钮被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCurrentNode_button_Click(object sender, EventArgs e)
        {
            string NewId = AddtShortcutKey(true);
            CurrentNode_dataGridView.SetSelectedRowByValue("ShortCutKeyID", NewId);//选中刚添加的那一行
        }

        /// <summary>删除按钮被单击
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCurrentNode_button_Click(object sender, EventArgs e)
        {
            String StrID = CurrentNode_dataGridView.GetSelectedRowValue("ShortCutKeyID");
            
            if (string.IsNullOrEmpty(StrID)) return;
            int IntSelectedRow = CurrentNode_dataGridView.SelectedRows[0].Index;
            tShortCutKey RemoveData = new tShortCutKey() { ShortCutKeyID = StrID };
            if (new ShortcutKeyManageService().DeleteShortCutKey(RemoveData)) InitKeyList();
            CurrentNode_dataGridView.SetSelecetedRowByRowIndex(IntSelectedRow);

        }

        /// <summary> 表格中键盘按下[用于快捷键]
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentNode_dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter://按下Enter添加同级节点
                    Enter_button_Click(null, null);
                    break;
                case Keys.Back://按下Table添加子节点
                    Back_button_Click(null, null);
                    break;
                case Keys.Delete://按下Delete删除当前节点
                    DeleteCurrentNode_button_Click(null, null);
                    break;
            }
        }

        /// <summary> DataGridView右键呼出菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentNode_dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                DataGridView_Menu.Show(Control.MousePosition);
        }

        /// <summary> 右键菜单被选择
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Control = (ToolStripMenuItem)sender;
            switch (Control.Name)
            {
                case "Enter_MenuItem":
                    Enter_button_Click(null, null);
                    break;
                case "Back_MenuItem":
                    Back_button_Click(null, null);
                    break;
                case "Edit_MenuItem":
                    Edit_button_Click(null, null);
                    break;
                case "Add_MenuItem":
                    AddCurrentNode_button_Click(null, null);
                    break;
                case "Delete_MenuItem":
                    DeleteCurrentNode_button_Click(null, null);
                    break;



            }

        }

        #endregion 事件

        /// <summary> 关闭Tab键切换焦点
        /// </summary>
        /// <param name="keydata"></param>
        /// <returns></returns> 
        protected override bool ProcessDialogKey(Keys keydata)
        {
            if (keydata == Keys.Tab)
            {
                return false;
            }
            return base.ProcessDialogKey(keydata);
        }
    }
}
