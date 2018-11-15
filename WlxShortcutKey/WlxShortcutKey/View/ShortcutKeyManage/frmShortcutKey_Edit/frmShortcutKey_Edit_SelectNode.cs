using OfficeTools.Entity;
using OfficeTools.Service;
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
using OfficeTools.View.Base;

namespace OfficeTools.View.ShortcutKeyManage
{
    /// <summary>用于选择父节点的窗体，窗体关闭后SelectedEntity属性表示返回结果
    /// 
    /// </summary>
    public partial class frmShortcutKey_Edit_SelectNode : frmShowFormBase
    {
        public frmShortcutKey_Edit_SelectNode()
        {
            InitializeComponent();
        }

        /// <summary>用于设置默认选择节点或获取最终选择结果
        /// 
        /// </summary>
        public tShortCutKey SelectedEntity{ get; set; }

        private List<tShortCutKey> EntityList = null;


        /// <summary> 窗体创建时加载树节点
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShortcutKey_Edit_SelectNode_Load(object sender, EventArgs e)
        {
            otTreeView1.AfterSelect -= new TreeViewEventHandler(otTreeView1_AfterSelect);
            List<tShortCutKey> tShortCutKeyList = new ShortcutKeyManageService().GettShortCutKeyList();
            EntityList = tShortCutKeyList;
            foreach (tShortCutKey tShortCutKeyItem in tShortCutKeyList)
            {
                imageList1.Images.Add(tShortCutKeyItem.ShortCutKeyID, tShortCutKeyItem.ShortCutKeyImg.ToImage());
            }
            OTTreeView.TreeViewNodeStruct StructTemp = new OTTreeView.TreeViewNodeStruct() { KeyName = "ShortCutKeyID", ValueName = "ShortCutKeyName", ParentName = "ParentID" };
            otTreeView1.SetDataSource<tShortCutKey>(tShortCutKeyList, StructTemp);
            otTreeView1.ExpandAll();
            if (SelectedEntity != null && !string.IsNullOrEmpty(SelectedEntity.ShortCutKeyID))
            {
                List<TreeNode> TreeNodeList = otTreeView1.GetAllTreeNode();
                TreeNode TreeNodeTemp = TreeNodeList.Where(T1 => T1.Name == SelectedEntity.ShortCutKeyID).FirstOrDefault();
                if (TreeNodeTemp != null) otTreeView1.SelectedNode = TreeNodeTemp;
            }
            Application.DoEvents();
            

            timer1.Enabled = true;
        }

        /// <summary> 用户选择一个节点后
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (otTreeView1.SelectedNode == null) return;
            if (otTreeView1.SelectedNode.Name == "BaseNode")
            {
                SelectedEntity = new tShortCutKey() { ShortCutKeyID = "", ShortCutKeyName = "根节点" };
            }
            else
            {
                tShortCutKey tShortCutKeyTemp = EntityList.Where(T1 => T1.ShortCutKeyID == otTreeView1.SelectedNode.Name).FirstOrDefault();
                if (tShortCutKeyTemp == null) return;

                SelectedEntity = tShortCutKeyTemp;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>用于给TreeList赋值被选择事件的时钟
        /// 因为它总是会在初始化数据后触发选择事件。即使在Application.DoEvents后面赋值委托，也无法阻止其触发这个事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            otTreeView1.AfterSelect += new TreeViewEventHandler(otTreeView1_AfterSelect);
        }

        private void otTreeView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.DialogResult = DialogResult.Cancel;
            //    this.Close();            
            //}
            base.OnKeyDown(e);
            
        }
    }
}
