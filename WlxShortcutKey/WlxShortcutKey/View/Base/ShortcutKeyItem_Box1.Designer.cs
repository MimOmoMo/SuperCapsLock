namespace OfficeTools.View.Base
{
    partial class ShortcutKeyItem_Box1
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

        #region 组件设计器生成的代码

        /// <summary> 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortcutKeyItem_Box1));
            this.Name_label = new System.Windows.Forms.Label();
            this.Key_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Img_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Img_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Name_label
            // 
            this.Name_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Name_label.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name_label.ForeColor = System.Drawing.Color.White;
            this.Name_label.Location = new System.Drawing.Point(0, 122);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(122, 27);
            this.Name_label.TabIndex = 1;
            this.Name_label.Text = "名称";
            this.Name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Name_label.Click += new System.EventHandler(this.ShortcutKeyItem_Box_Click);
            this.Name_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShortcutKeyItem_Box_MouseDown);
            this.Name_label.MouseEnter += new System.EventHandler(this.ShortcutKeyItem_Box_MouseEnter);
            this.Name_label.MouseLeave += new System.EventHandler(this.ShortcutKeyItem_Box_MouseLeave);
            this.Name_label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShortcutKeyItem_Box_MouseUp);
            // 
            // Key_label
            // 
            this.Key_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Key_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Key_label.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_label.ForeColor = System.Drawing.Color.White;
            this.Key_label.Location = new System.Drawing.Point(0, 150);
            this.Key_label.Name = "Key_label";
            this.Key_label.Size = new System.Drawing.Size(122, 27);
            this.Key_label.TabIndex = 2;
            this.Key_label.Text = "快捷键名称";
            this.Key_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Key_label.Click += new System.EventHandler(this.ShortcutKeyItem_Box_Click);
            this.Key_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShortcutKeyItem_Box_MouseDown);
            this.Key_label.MouseEnter += new System.EventHandler(this.ShortcutKeyItem_Box_MouseEnter);
            this.Key_label.MouseLeave += new System.EventHandler(this.ShortcutKeyItem_Box_MouseLeave);
            this.Key_label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShortcutKeyItem_Box_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 1);
            this.panel1.TabIndex = 3;
            // 
            // Img_pictureBox
            // 
            this.Img_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.Img_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Img_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Img_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Img_pictureBox.Image")));
            this.Img_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.Img_pictureBox.Name = "Img_pictureBox";
            this.Img_pictureBox.Size = new System.Drawing.Size(122, 122);
            this.Img_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img_pictureBox.TabIndex = 0;
            this.Img_pictureBox.TabStop = false;
            this.Img_pictureBox.Click += new System.EventHandler(this.ShortcutKeyItem_Box_Click);
            this.Img_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShortcutKeyItem_Box_MouseDown);
            this.Img_pictureBox.MouseEnter += new System.EventHandler(this.ShortcutKeyItem_Box_MouseEnter);
            this.Img_pictureBox.MouseLeave += new System.EventHandler(this.ShortcutKeyItem_Box_MouseLeave);
            this.Img_pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShortcutKeyItem_Box_MouseUp);
            // 
            // ShortcutKeyItem_Box1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(137)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.Img_pictureBox);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Key_label);
            this.Name = "ShortcutKeyItem_Box1";
            this.Size = new System.Drawing.Size(122, 177);
            ((System.ComponentModel.ISupportInitialize)(this.Img_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Img_pictureBox;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label Key_label;
        private System.Windows.Forms.Panel panel1;
    }
}
