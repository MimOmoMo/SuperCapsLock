using OfficeTools.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.View.Base
{
    [ToolboxItem(true)]
    class OTTreeView : TreeView
    {
        public OTTreeView() : base() { ; }

        /// <summary>是否存在根节点
        /// 
        /// </summary>
        private bool _isBaseNode = true;

        /// <summary>是否存在根节点
        /// 
        /// </summary>
        public bool isBaseNode
        {
            get { return _isBaseNode; }
            set { _isBaseNode = value; }
        }


        /// <summary> 用递归的方式将List数据按树状图添加到指定节点下
        /// </summary>
        /// <typeparam name="T">要添加的数据的模型类</typeparam>
        /// <param name="DataSource">要添加的List数据</param>
        /// <param name="NodeStruct">List的结构</param>
        /// <param name="ParenNode">父节点[为空则添加到根节点]</param>
        public void SetDataSource<T>(List<T> DataSource, TreeViewNodeStruct NodeStruct, TreeNode ParenNode = null)
        {
            PropertyInfo KeyProperty = typeof(T).GetProperty(NodeStruct.KeyName);
            PropertyInfo ValueProperty = typeof(T).GetProperty(NodeStruct.ValueName);
            PropertyInfo ParentProperty = typeof(T).GetProperty(NodeStruct.ParentName);
            List<T> CurrentAddList = null;
            if (ParenNode == null) CurrentAddList = DataSource.Where(T1 => string.IsNullOrEmpty(ParentProperty.GetValue(T1).ToString())).ToList();//没有父节点就取父节点为空的记录
            else CurrentAddList = DataSource.Where(T1 => ParentProperty.GetValue(T1).ToString() == ParenNode.Name).ToList();//有父节点就取ParentID为父节点的记录
            foreach (T item in CurrentAddList)//遍历取出的记录
            {
                string StrKey = KeyProperty.GetValue(item).ToString();
                string StrValue = ValueProperty.GetValue(item).ToString();
                string StrParentValue = ParentProperty.GetValue(item).ToString();
                TreeNode NodeTemp = new TreeNode() { Name = StrKey, Text = StrValue, ImageKey = StrKey, SelectedImageKey =StrKey};
                SetDataSource<T>(DataSource, NodeStruct, NodeTemp);
                (ParenNode == null ? GetBaseNodes() : ParenNode.Nodes).Add(NodeTemp);//将取出的记录添加到父节点下，没有父节点就添加到控件的Nodes下
            }
        }

        /// <summary>获取根节点的对象
        /// 
        /// </summary>
        /// <returns></returns>
        private TreeNodeCollection GetBaseNodes()
        {
            if (!_isBaseNode) return this.Nodes;
            return GetBaseTreeNode().Nodes;
        }

        /// <summary>获取根节点的对象
        /// 
        /// </summary>
        /// <returns></returns>
        public TreeNode GetBaseTreeNode()
        {
            if (!_isBaseNode) return null;
            while (true)
            {
                TreeNode[] ResultArray = this.Nodes.Find("BaseNode", false);
                if (ResultArray.Length == 0)
                {
                    TreeNode TreeNodeTemp = new TreeNode() { Name = "BaseNode", Text = "根节点" };
                    this.Nodes.Add(TreeNodeTemp);
                }
                else
                {
                    return ResultArray[0];
                }
            }        
        }

        /// <summary> 递归获取某节点下所有节点
        /// </summary>
        /// <param name="ParentNodes">留空则表示包括根节点的所有节点</param>
        /// <returns>所有节点</returns>
        public List<TreeNode> GetAllTreeNode(TreeNodeCollection ParentNodes = null)
        {
            if (ParentNodes == null) ParentNodes = this.Nodes;
            List<TreeNode> ResultList = new List<TreeNode>();
            foreach (TreeNode TreeNodeItem in ParentNodes)
            {
                ResultList.Add(TreeNodeItem);
                ResultList.AddRange(GetAllTreeNode(TreeNodeItem.Nodes));
            }
            return ResultList;
        }

        /// <summary> 通过节点名称查找该节点的实体
        /// </summary>
        /// <param name="NodeName">TreeNode.Name属性</param>
        /// <returns>查找到的第一个结果</returns>
        public TreeNode FindNodes(string NodeName)
        {
            List<TreeNode> AllNodeList = GetAllTreeNode();
            return AllNodeList.Where(T1 => T1.Name == NodeName).FirstOrDefault();
        }

        #region 内部类
        /// <summary> 用于指明SetDataSource的泛型类的结构
        /// [指明传入的哪个属性是ID，哪个属性是父ID，哪个属性是展示在前台的文本]
        /// </summary>
        public class TreeViewNodeStruct
        {
            /// <summary> 用于添加到TreeNode.Name中的属性名称
            /// 一般用于存ID值
            /// </summary>
            public string KeyName { get; set; }
            /// <summary> 用于展示到前台的属性名称
            /// [添加到TreeNode.Text中的值]
            /// </summary>
            public string ValueName { get; set; }
            /// <summary> 父ID的属性名称
            /// </summary>
            public string ParentName { get; set; }

        }
        #endregion 内部类
        //123
    }

}
