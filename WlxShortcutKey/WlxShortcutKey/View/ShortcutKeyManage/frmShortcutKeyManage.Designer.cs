using OfficeTools.View.Base;
namespace OfficeTools
{
    partial class frmShortcutKeyManage
    {
        /// <summary> 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary> 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShortcutKeyManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShortcutKey_otTreeView = new OfficeTools.View.Base.OTTreeView();
            this.ShortcutKey_imageList = new System.Windows.Forms.ImageList(this.components);
            this.Opration_panel = new System.Windows.Forms.Panel();
            this.Remove_button = new System.Windows.Forms.Button();
            this.AddChidren_button = new System.Windows.Forms.Button();
            this.Add_button = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Back_button = new System.Windows.Forms.Button();
            this.Enter_button = new System.Windows.Forms.Button();
            this.AddCurrentNode_button = new System.Windows.Forms.Button();
            this.DeleteCurrentNode_button = new System.Windows.Forms.Button();
            this.Edit_button = new System.Windows.Forms.Button();
            this.SelectFile = new System.Windows.Forms.OpenFileDialog();
            this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.BackMission_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightKeyMission_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormLoadTime = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new OfficeTools.View.Base.OTTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CurrentNode_dataGridView = new OfficeTools.View.Base.OTDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ShortCutKeyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsChidren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataGridView_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Enter_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Back_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Add_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.Opration_panel.SuspendLayout();
            this.RightKeyMission_contextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentNode_dataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.DataGridView_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShortcutKey_otTreeView);
            this.panel1.Controls.Add(this.Opration_panel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 466);
            this.panel1.TabIndex = 1;
            // 
            // ShortcutKey_otTreeView
            // 
            this.ShortcutKey_otTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShortcutKey_otTreeView.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShortcutKey_otTreeView.HideSelection = false;
            this.ShortcutKey_otTreeView.HotTracking = true;
            this.ShortcutKey_otTreeView.ImageIndex = 0;
            this.ShortcutKey_otTreeView.ImageList = this.ShortcutKey_imageList;
            this.ShortcutKey_otTreeView.isBaseNode = true;
            this.ShortcutKey_otTreeView.LabelEdit = true;
            this.ShortcutKey_otTreeView.Location = new System.Drawing.Point(0, 34);
            this.ShortcutKey_otTreeView.Name = "ShortcutKey_otTreeView";
            this.ShortcutKey_otTreeView.SelectedImageIndex = 0;
            this.ShortcutKey_otTreeView.Size = new System.Drawing.Size(237, 432);
            this.ShortcutKey_otTreeView.TabIndex = 2;
            this.ShortcutKey_otTreeView.TabStop = false;
            this.ShortcutKey_otTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ShortcutKey_otTreeView_AfterLabelEdit);
            this.ShortcutKey_otTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ShortcutKey_otTreeView_AfterSelect);
            this.ShortcutKey_otTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShortcutKey_otTreeView_KeyDown);
            // 
            // ShortcutKey_imageList
            // 
            this.ShortcutKey_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ShortcutKey_imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.ShortcutKey_imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Opration_panel
            // 
            this.Opration_panel.Controls.Add(this.Remove_button);
            this.Opration_panel.Controls.Add(this.AddChidren_button);
            this.Opration_panel.Controls.Add(this.Add_button);
            this.Opration_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Opration_panel.Location = new System.Drawing.Point(0, 0);
            this.Opration_panel.Name = "Opration_panel";
            this.Opration_panel.Size = new System.Drawing.Size(237, 34);
            this.Opration_panel.TabIndex = 2;
            // 
            // Remove_button
            // 
            this.Remove_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.Remove_button.Location = new System.Drawing.Point(156, 0);
            this.Remove_button.Margin = new System.Windows.Forms.Padding(0);
            this.Remove_button.Name = "Remove_button";
            this.Remove_button.Size = new System.Drawing.Size(78, 34);
            this.Remove_button.TabIndex = 1;
            this.Remove_button.TabStop = false;
            this.Remove_button.Text = "-";
            this.Remove_button.UseVisualStyleBackColor = true;
            this.Remove_button.Click += new System.EventHandler(this.Remove_button_Click);
            // 
            // AddChidren_button
            // 
            this.AddChidren_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddChidren_button.Location = new System.Drawing.Point(78, 0);
            this.AddChidren_button.Margin = new System.Windows.Forms.Padding(0);
            this.AddChidren_button.Name = "AddChidren_button";
            this.AddChidren_button.Size = new System.Drawing.Size(78, 34);
            this.AddChidren_button.TabIndex = 0;
            this.AddChidren_button.TabStop = false;
            this.AddChidren_button.Text = "+";
            this.toolTip.SetToolTip(this.AddChidren_button, "添加子节点");
            this.AddChidren_button.UseVisualStyleBackColor = true;
            this.AddChidren_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Add_button
            // 
            this.Add_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.Add_button.Location = new System.Drawing.Point(0, 0);
            this.Add_button.Margin = new System.Windows.Forms.Padding(0);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(78, 34);
            this.Add_button.TabIndex = 2;
            this.Add_button.TabStop = false;
            this.Add_button.Text = "+";
            this.toolTip.SetToolTip(this.Add_button, "添加同级节点");
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 1;
            this.toolTip.ReshowDelay = 1;
            this.toolTip.Tag = " ";
            // 
            // Back_button
            // 
            this.Back_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.Back_button.Location = new System.Drawing.Point(0, 0);
            this.Back_button.Margin = new System.Windows.Forms.Padding(0);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(107, 28);
            this.Back_button.TabIndex = 3;
            this.Back_button.TabStop = false;
            this.Back_button.Text = "<- 返回";
            this.toolTip.SetToolTip(this.Back_button, "添加同级节点");
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // Enter_button
            // 
            this.Enter_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.Enter_button.Location = new System.Drawing.Point(107, 0);
            this.Enter_button.Margin = new System.Windows.Forms.Padding(0);
            this.Enter_button.Name = "Enter_button";
            this.Enter_button.Size = new System.Drawing.Size(107, 28);
            this.Enter_button.TabIndex = 4;
            this.Enter_button.TabStop = false;
            this.Enter_button.Text = "进入 ->";
            this.toolTip.SetToolTip(this.Enter_button, "添加同级节点");
            this.Enter_button.UseVisualStyleBackColor = true;
            this.Enter_button.Click += new System.EventHandler(this.Enter_button_Click);
            // 
            // AddCurrentNode_button
            // 
            this.AddCurrentNode_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddCurrentNode_button.Location = new System.Drawing.Point(321, 0);
            this.AddCurrentNode_button.Margin = new System.Windows.Forms.Padding(0);
            this.AddCurrentNode_button.Name = "AddCurrentNode_button";
            this.AddCurrentNode_button.Size = new System.Drawing.Size(107, 28);
            this.AddCurrentNode_button.TabIndex = 5;
            this.AddCurrentNode_button.TabStop = false;
            this.AddCurrentNode_button.Text = "添加";
            this.toolTip.SetToolTip(this.AddCurrentNode_button, "添加同级节点");
            this.AddCurrentNode_button.UseVisualStyleBackColor = true;
            this.AddCurrentNode_button.Click += new System.EventHandler(this.AddCurrentNode_button_Click);
            // 
            // DeleteCurrentNode_button
            // 
            this.DeleteCurrentNode_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeleteCurrentNode_button.Location = new System.Drawing.Point(428, 0);
            this.DeleteCurrentNode_button.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteCurrentNode_button.Name = "DeleteCurrentNode_button";
            this.DeleteCurrentNode_button.Size = new System.Drawing.Size(107, 28);
            this.DeleteCurrentNode_button.TabIndex = 6;
            this.DeleteCurrentNode_button.TabStop = false;
            this.DeleteCurrentNode_button.Text = "删除";
            this.toolTip.SetToolTip(this.DeleteCurrentNode_button, "添加同级节点");
            this.DeleteCurrentNode_button.UseVisualStyleBackColor = true;
            this.DeleteCurrentNode_button.Click += new System.EventHandler(this.DeleteCurrentNode_button_Click);
            // 
            // Edit_button
            // 
            this.Edit_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.Edit_button.Location = new System.Drawing.Point(214, 0);
            this.Edit_button.Margin = new System.Windows.Forms.Padding(0);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(107, 28);
            this.Edit_button.TabIndex = 7;
            this.Edit_button.TabStop = false;
            this.Edit_button.Text = "编辑";
            this.toolTip.SetToolTip(this.Edit_button, "添加同级节点");
            this.Edit_button.UseVisualStyleBackColor = true;
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // SelectFile
            // 
            this.SelectFile.FileName = "file";
            // 
            // BackMission_notifyIcon
            // 
            this.BackMission_notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.BackMission_notifyIcon.BalloonTipText = "文本";
            this.BackMission_notifyIcon.BalloonTipTitle = "标题";
            this.BackMission_notifyIcon.ContextMenuStrip = this.RightKeyMission_contextMenuStrip;
            this.BackMission_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("BackMission_notifyIcon.Icon")));
            this.BackMission_notifyIcon.Text = "快捷键管理";
            this.BackMission_notifyIcon.Visible = true;
            this.BackMission_notifyIcon.DoubleClick += new System.EventHandler(this.BackMission_notifyIcon_DoubleClick);
            // 
            // RightKeyMission_contextMenuStrip
            // 
            this.RightKeyMission_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主窗体ToolStripMenuItem,
            this.退出程序ToolStripMenuItem});
            this.RightKeyMission_contextMenuStrip.Name = "RightKeyMission_contextMenuStrip";
            this.RightKeyMission_contextMenuStrip.Size = new System.Drawing.Size(137, 48);
            // 
            // 显示主窗体ToolStripMenuItem
            // 
            this.显示主窗体ToolStripMenuItem.Name = "显示主窗体ToolStripMenuItem";
            this.显示主窗体ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示主窗体ToolStripMenuItem.Text = "显示主窗体";
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.退出程序ToolStripMenuItem_Click);
            // 
            // FormLoadTime
            // 
            this.FormLoadTime.Interval = 1;
            this.FormLoadTime.Tick += new System.EventHandler(this.FormLoadTime_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(237, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 466);
            this.tabControl1.TabIndex = 14;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CurrentNode_dataGridView);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 434);
            this.panel2.TabIndex = 2;
            // 
            // CurrentNode_dataGridView
            // 
            this.CurrentNode_dataGridView.AllowUserToAddRows = false;
            this.CurrentNode_dataGridView.AllowUserToDeleteRows = false;
            this.CurrentNode_dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CurrentNode_dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.CurrentNode_dataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.CurrentNode_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentNode_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ShortCutKeyID,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.IsChidren});
            this.CurrentNode_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentNode_dataGridView.Location = new System.Drawing.Point(0, 28);
            this.CurrentNode_dataGridView.Name = "CurrentNode_dataGridView";
            this.CurrentNode_dataGridView.ReadOnly = true;
            this.CurrentNode_dataGridView.RowHeadersVisible = false;
            this.CurrentNode_dataGridView.RowTemplate.Height = 33;
            this.CurrentNode_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CurrentNode_dataGridView.Size = new System.Drawing.Size(543, 406);
            this.CurrentNode_dataGridView.TabIndex = 0;
            this.CurrentNode_dataGridView.DoubleClick += new System.EventHandler(this.CurrentNode_dataGridView_DoubleClick);
            this.CurrentNode_dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentNode_dataGridView_KeyDown);
            this.CurrentNode_dataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CurrentNode_dataGridView_MouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Icon";
            this.Column1.HeaderText = "图标";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 33;
            // 
            // ShortCutKeyID
            // 
            this.ShortCutKeyID.DataPropertyName = "ShortCutKeyID";
            this.ShortCutKeyID.HeaderText = "ID";
            this.ShortCutKeyID.Name = "ShortCutKeyID";
            this.ShortCutKeyID.ReadOnly = true;
            this.ShortCutKeyID.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ShortCutKeyName";
            this.Column2.HeaderText = "名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "KeyName";
            this.Column3.HeaderText = "键名称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ShortCutKeyTypeName";
            this.Column4.HeaderText = "类型";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "ShortCutKeyPath";
            this.Column5.HeaderText = "打开内容";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // IsChidren
            // 
            this.IsChidren.DataPropertyName = "OwningChidrenNode";
            this.IsChidren.HeaderText = "是否有下级";
            this.IsChidren.Name = "IsChidren";
            this.IsChidren.ReadOnly = true;
            this.IsChidren.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DeleteCurrentNode_button);
            this.panel3.Controls.Add(this.AddCurrentNode_button);
            this.panel3.Controls.Add(this.Edit_button);
            this.panel3.Controls.Add(this.Enter_button);
            this.panel3.Controls.Add(this.Back_button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 28);
            this.panel3.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(549, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // DataGridView_Menu
            // 
            this.DataGridView_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Enter_MenuItem,
            this.Back_MenuItem,
            this.EditMenuItem,
            this.Add_MenuItem,
            this.Delete_MenuItem});
            this.DataGridView_Menu.Name = "DataGridView_Menu";
            this.DataGridView_Menu.Size = new System.Drawing.Size(93, 114);
            // 
            // Enter_MenuItem
            // 
            this.Enter_MenuItem.Name = "Enter_MenuItem";
            this.Enter_MenuItem.ShortcutKeyDisplayString = "";
            this.Enter_MenuItem.ShowShortcutKeys = false;
            this.Enter_MenuItem.Size = new System.Drawing.Size(92, 22);
            this.Enter_MenuItem.Text = "进入";
            this.Enter_MenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Back_MenuItem
            // 
            this.Back_MenuItem.Name = "Back_MenuItem";
            this.Back_MenuItem.ShortcutKeyDisplayString = "";
            this.Back_MenuItem.ShowShortcutKeys = false;
            this.Back_MenuItem.Size = new System.Drawing.Size(92, 22);
            this.Back_MenuItem.Text = "返回";
            this.Back_MenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.ShortcutKeyDisplayString = "";
            this.EditMenuItem.ShowShortcutKeys = false;
            this.EditMenuItem.Size = new System.Drawing.Size(92, 22);
            this.EditMenuItem.Text = "编辑";
            this.EditMenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Add_MenuItem
            // 
            this.Add_MenuItem.Name = "Add_MenuItem";
            this.Add_MenuItem.ShortcutKeyDisplayString = "";
            this.Add_MenuItem.ShowShortcutKeys = false;
            this.Add_MenuItem.Size = new System.Drawing.Size(92, 22);
            this.Add_MenuItem.Text = "添加";
            this.Add_MenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Delete_MenuItem
            // 
            this.Delete_MenuItem.Name = "Delete_MenuItem";
            this.Delete_MenuItem.ShortcutKeyDisplayString = "";
            this.Delete_MenuItem.ShowShortcutKeys = false;
            this.Delete_MenuItem.Size = new System.Drawing.Size(92, 22);
            this.Delete_MenuItem.Text = "删除";
            this.Delete_MenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // frmShortcutKeyManage
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 466);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmShortcutKeyManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperCapsLock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmShortcutKeyManage_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShortcutKeyManage_KeyDown);
            this.panel1.ResumeLayout(false);
            this.Opration_panel.ResumeLayout(false);
            this.RightKeyMission_contextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentNode_dataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.DataGridView_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Opration_panel;
        private System.Windows.Forms.Button Remove_button;
        private System.Windows.Forms.Button AddChidren_button;
        private View.Base.OTTreeView ShortcutKey_otTreeView;
        private System.Windows.Forms.ImageList ShortcutKey_imageList;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog SelectFile;
        private System.Windows.Forms.FolderBrowserDialog SelectFolder;
        private System.Windows.Forms.ContextMenuStrip RightKeyMission_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示主窗体ToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon BackMission_notifyIcon;
        private System.Windows.Forms.Timer FormLoadTime;
        private OTTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Back_button;
        private OfficeTools.View.Base.OTDataGridView CurrentNode_dataGridView;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortCutKeyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsChidren;
        private System.Windows.Forms.Button DeleteCurrentNode_button;
        private System.Windows.Forms.Button AddCurrentNode_button;
        private System.Windows.Forms.Button Edit_button;
        private System.Windows.Forms.Button Enter_button;
        private System.Windows.Forms.ContextMenuStrip DataGridView_Menu;
        private System.Windows.Forms.ToolStripMenuItem Enter_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Back_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Add_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Delete_MenuItem;
    }
}

