namespace OfficeTools.View.ShortcutKeyManage
{
    partial class frmShortcutKey_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShortcutKey_Edit));
            this.label1 = new System.Windows.Forms.Label();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.KeyName_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Path_textBox = new System.Windows.Forms.TextBox();
            this.SelectParent_button = new System.Windows.Forms.Button();
            this.ParentNode_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Img_pictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SpecialKey_button = new System.Windows.Forms.Button();
            this.TypeName_textBox = new System.Windows.Forms.TextBox();
            this.SelectType_button = new System.Windows.Forms.Button();
            this.SelectPath_button = new System.Windows.Forms.Button();
            this.Path_panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SysShortcutKey_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SysShortcutKey_button = new System.Windows.Forms.Button();
            this.SelectFilePath = new System.Windows.Forms.OpenFileDialog();
            this.OK_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Img_pictureBox)).BeginInit();
            this.Path_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(92, 77);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(223, 21);
            this.Name_textBox.TabIndex = 1;
            this.Name_textBox.TabStop = false;
            // 
            // KeyName_textBox
            // 
            this.KeyName_textBox.Location = new System.Drawing.Point(92, 121);
            this.KeyName_textBox.Name = "KeyName_textBox";
            this.KeyName_textBox.Size = new System.Drawing.Size(92, 21);
            this.KeyName_textBox.TabIndex = 3;
            this.KeyName_textBox.TabStop = false;
            this.KeyName_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyName_textBox_KeyDown);
            this.KeyName_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyName_textBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "键名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "打开路径：";
            // 
            // Path_textBox
            // 
            this.Path_textBox.Location = new System.Drawing.Point(91, 5);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(158, 21);
            this.Path_textBox.TabIndex = 3;
            this.Path_textBox.TabStop = false;
            // 
            // SelectParent_button
            // 
            this.SelectParent_button.Location = new System.Drawing.Point(254, 247);
            this.SelectParent_button.Margin = new System.Windows.Forms.Padding(0);
            this.SelectParent_button.Name = "SelectParent_button";
            this.SelectParent_button.Size = new System.Drawing.Size(62, 21);
            this.SelectParent_button.TabIndex = 4;
            this.SelectParent_button.TabStop = false;
            this.SelectParent_button.Text = "选择";
            this.SelectParent_button.UseVisualStyleBackColor = true;
            this.SelectParent_button.Click += new System.EventHandler(this.SelectParent_button_Click);
            // 
            // ParentNode_textBox
            // 
            this.ParentNode_textBox.Enabled = false;
            this.ParentNode_textBox.Location = new System.Drawing.Point(92, 248);
            this.ParentNode_textBox.Name = "ParentNode_textBox";
            this.ParentNode_textBox.Size = new System.Drawing.Size(158, 21);
            this.ParentNode_textBox.TabIndex = 6;
            this.ParentNode_textBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "父节点：";
            // 
            // Img_pictureBox
            // 
            this.Img_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Img_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Img_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Img_pictureBox.Image")));
            this.Img_pictureBox.Location = new System.Drawing.Point(92, 14);
            this.Img_pictureBox.Name = "Img_pictureBox";
            this.Img_pictureBox.Size = new System.Drawing.Size(50, 50);
            this.Img_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img_pictureBox.TabIndex = 1;
            this.Img_pictureBox.TabStop = false;
            this.Img_pictureBox.Click += new System.EventHandler(this.Img_pictureBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "图标：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "打开类型：";
            // 
            // SpecialKey_button
            // 
            this.SpecialKey_button.Location = new System.Drawing.Point(191, 115);
            this.SpecialKey_button.Margin = new System.Windows.Forms.Padding(0);
            this.SpecialKey_button.Name = "SpecialKey_button";
            this.SpecialKey_button.Size = new System.Drawing.Size(124, 31);
            this.SpecialKey_button.TabIndex = 4;
            this.SpecialKey_button.TabStop = false;
            this.SpecialKey_button.Text = "特殊按键";
            this.SpecialKey_button.UseVisualStyleBackColor = true;
            this.SpecialKey_button.Click += new System.EventHandler(this.SpecialKey_button_Click);
            // 
            // TypeName_textBox
            // 
            this.TypeName_textBox.Enabled = false;
            this.TypeName_textBox.Location = new System.Drawing.Point(92, 166);
            this.TypeName_textBox.Name = "TypeName_textBox";
            this.TypeName_textBox.Size = new System.Drawing.Size(92, 21);
            this.TypeName_textBox.TabIndex = 7;
            this.TypeName_textBox.TabStop = false;
            // 
            // SelectType_button
            // 
            this.SelectType_button.Location = new System.Drawing.Point(191, 161);
            this.SelectType_button.Margin = new System.Windows.Forms.Padding(0);
            this.SelectType_button.Name = "SelectType_button";
            this.SelectType_button.Size = new System.Drawing.Size(124, 31);
            this.SelectType_button.TabIndex = 4;
            this.SelectType_button.TabStop = false;
            this.SelectType_button.Text = "选择";
            this.SelectType_button.UseVisualStyleBackColor = true;
            this.SelectType_button.Click += new System.EventHandler(this.SelectType_button_Click);
            // 
            // SelectPath_button
            // 
            this.SelectPath_button.Location = new System.Drawing.Point(251, 5);
            this.SelectPath_button.Margin = new System.Windows.Forms.Padding(0);
            this.SelectPath_button.Name = "SelectPath_button";
            this.SelectPath_button.Size = new System.Drawing.Size(62, 21);
            this.SelectPath_button.TabIndex = 4;
            this.SelectPath_button.TabStop = false;
            this.SelectPath_button.Text = "选择";
            this.SelectPath_button.UseVisualStyleBackColor = true;
            this.SelectPath_button.Click += new System.EventHandler(this.SelectPath_button_Click);
            // 
            // Path_panel
            // 
            this.Path_panel.Controls.Add(this.Path_textBox);
            this.Path_panel.Controls.Add(this.label3);
            this.Path_panel.Controls.Add(this.SelectPath_button);
            this.Path_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Path_panel.Location = new System.Drawing.Point(0, 0);
            this.Path_panel.Name = "Path_panel";
            this.Path_panel.Size = new System.Drawing.Size(334, 34);
            this.Path_panel.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.Path_panel);
            this.panel2.Location = new System.Drawing.Point(1, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 37);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SysShortcutKey_textBox);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.SysShortcutKey_button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(334, 32);
            this.panel3.TabIndex = 9;
            // 
            // SysShortcutKey_textBox
            // 
            this.SysShortcutKey_textBox.Enabled = false;
            this.SysShortcutKey_textBox.Location = new System.Drawing.Point(91, 5);
            this.SysShortcutKey_textBox.Name = "SysShortcutKey_textBox";
            this.SysShortcutKey_textBox.Size = new System.Drawing.Size(158, 21);
            this.SysShortcutKey_textBox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "组合键：";
            // 
            // SysShortcutKey_button
            // 
            this.SysShortcutKey_button.Location = new System.Drawing.Point(251, 6);
            this.SysShortcutKey_button.Margin = new System.Windows.Forms.Padding(0);
            this.SysShortcutKey_button.Name = "SysShortcutKey_button";
            this.SysShortcutKey_button.Size = new System.Drawing.Size(62, 21);
            this.SysShortcutKey_button.TabIndex = 4;
            this.SysShortcutKey_button.TabStop = false;
            this.SysShortcutKey_button.Text = "选择";
            this.SysShortcutKey_button.UseVisualStyleBackColor = true;
            this.SysShortcutKey_button.Click += new System.EventHandler(this.SysShortcutKey_button_Click);
            // 
            // SelectFilePath
            // 
            this.SelectFilePath.Filter = "所有文件|*.*";
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(10, 282);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(162, 43);
            this.OK_button.TabIndex = 10;
            this.OK_button.TabStop = false;
            this.OK_button.Text = "确定";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(180, 282);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(162, 43);
            this.Cancel_button.TabIndex = 11;
            this.Cancel_button.TabStop = false;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // frmShortcutKey_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 342);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TypeName_textBox);
            this.Controls.Add(this.Img_pictureBox);
            this.Controls.Add(this.ParentNode_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SelectType_button);
            this.Controls.Add(this.SpecialKey_button);
            this.Controls.Add(this.SelectParent_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.KeyName_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "frmShortcutKey_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加";
            this.Load += new System.EventHandler(this.frmShortcutKey_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Img_pictureBox)).EndInit();
            this.Path_panel.ResumeLayout(false);
            this.Path_panel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.TextBox KeyName_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Path_textBox;
        private System.Windows.Forms.Button SelectParent_button;
        private System.Windows.Forms.TextBox ParentNode_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox Img_pictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SpecialKey_button;
        private System.Windows.Forms.TextBox TypeName_textBox;
        private System.Windows.Forms.Button SelectType_button;
        private System.Windows.Forms.Button SelectPath_button;
        private System.Windows.Forms.Panel Path_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox SysShortcutKey_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog SelectFilePath;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button SysShortcutKey_button;
    }
}