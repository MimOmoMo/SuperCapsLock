namespace OfficeTools.View.ShortcutKeyManage
{
    partial class frmShortcutKey_Edit_OpenType
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
            this.Program_button = new System.Windows.Forms.Button();
            this.WebSite_button = new System.Windows.Forms.Button();
            this.SysShortcutKey_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Program_button
            // 
            this.Program_button.Location = new System.Drawing.Point(20, 14);
            this.Program_button.Name = "Program_button";
            this.Program_button.Size = new System.Drawing.Size(143, 80);
            this.Program_button.TabIndex = 0;
            this.Program_button.TabStop = false;
            this.Program_button.Text = "程序或文件";
            this.Program_button.UseVisualStyleBackColor = true;
            this.Program_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // WebSite_button
            // 
            this.WebSite_button.Location = new System.Drawing.Point(198, 14);
            this.WebSite_button.Name = "WebSite_button";
            this.WebSite_button.Size = new System.Drawing.Size(143, 80);
            this.WebSite_button.TabIndex = 1;
            this.WebSite_button.TabStop = false;
            this.WebSite_button.Text = "网站";
            this.WebSite_button.UseVisualStyleBackColor = true;
            this.WebSite_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // SysShortcutKey_button
            // 
            this.SysShortcutKey_button.Location = new System.Drawing.Point(20, 114);
            this.SysShortcutKey_button.Name = "SysShortcutKey_button";
            this.SysShortcutKey_button.Size = new System.Drawing.Size(143, 80);
            this.SysShortcutKey_button.TabIndex = 2;
            this.SysShortcutKey_button.TabStop = false;
            this.SysShortcutKey_button.Text = "系统组合键";
            this.SysShortcutKey_button.UseVisualStyleBackColor = true;
            this.SysShortcutKey_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Program_button);
            this.panel1.Controls.Add(this.SysShortcutKey_button);
            this.panel1.Controls.Add(this.WebSite_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 211);
            this.panel1.TabIndex = 3;
            // 
            // frmShortcutKey_Edit_OpenType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 211);
            this.Controls.Add(this.panel1);
            this.Name = "frmShortcutKey_Edit_OpenType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShortcutKey_Edit_OpenType";            
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Program_button;
        private System.Windows.Forms.Button WebSite_button;
        private System.Windows.Forms.Button SysShortcutKey_button;
        private System.Windows.Forms.Panel panel1;
    }
}