namespace OfficeTools.View.ShortcutKeyManage
{
    partial class frmShortcutKey_Edit_SelectNode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.otTreeView1 = new OfficeTools.View.Base.OTTreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // otTreeView1
            // 
            this.otTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otTreeView1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.otTreeView1.ImageIndex = 0;
            this.otTreeView1.ImageList = this.imageList1;
            this.otTreeView1.isBaseNode = true;
            this.otTreeView1.Location = new System.Drawing.Point(0, 0);
            this.otTreeView1.Name = "otTreeView1";
            this.otTreeView1.SelectedImageIndex = 0;
            this.otTreeView1.Size = new System.Drawing.Size(525, 552);
            this.otTreeView1.TabIndex = 0;
            this.otTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.otTreeView1_AfterSelect);
            this.otTreeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.otTreeView1_KeyDown);
            // 
            // frmShortcutKey_Edit_SelectNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 552);
            this.Controls.Add(this.otTreeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShortcutKey_Edit_SelectNode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShortcutKey_Edit_SelectNode";
            this.Load += new System.EventHandler(this.frmShortcutKey_Edit_SelectNode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Base.OTTreeView otTreeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
    }
}