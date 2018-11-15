namespace OfficeTools.View.ShortcutKeyManage
{
    partial class frmShortcutKey_Edit_SysKey
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Result_textBox = new System.Windows.Forms.TextBox();
            this.Control_checkBox = new System.Windows.Forms.CheckBox();
            this.Alt_checkBox = new System.Windows.Forms.CheckBox();
            this.Shift_checkBox = new System.Windows.Forms.CheckBox();
            this.Win_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 43);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 43);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Result_textBox
            // 
            this.Result_textBox.Location = new System.Drawing.Point(12, 146);
            this.Result_textBox.Name = "Result_textBox";
            this.Result_textBox.Size = new System.Drawing.Size(276, 21);
            this.Result_textBox.TabIndex = 1;
            this.Result_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyName_textBox_KeyDown);
            this.Result_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyName_textBox_KeyPress);
            // 
            // Control_checkBox
            // 
            this.Control_checkBox.AutoSize = true;
            this.Control_checkBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Control_checkBox.Location = new System.Drawing.Point(35, 51);
            this.Control_checkBox.Name = "Control_checkBox";
            this.Control_checkBox.Size = new System.Drawing.Size(106, 25);
            this.Control_checkBox.TabIndex = 2;
            this.Control_checkBox.Text = "Control";
            this.Control_checkBox.UseVisualStyleBackColor = true;
            this.Control_checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Alt_checkBox
            // 
            this.Alt_checkBox.AutoSize = true;
            this.Alt_checkBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Alt_checkBox.Location = new System.Drawing.Point(189, 51);
            this.Alt_checkBox.Name = "Alt_checkBox";
            this.Alt_checkBox.Size = new System.Drawing.Size(62, 25);
            this.Alt_checkBox.TabIndex = 2;
            this.Alt_checkBox.Text = "Alt";
            this.Alt_checkBox.UseVisualStyleBackColor = true;
            this.Alt_checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Shift_checkBox
            // 
            this.Shift_checkBox.AutoSize = true;
            this.Shift_checkBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Shift_checkBox.Location = new System.Drawing.Point(35, 95);
            this.Shift_checkBox.Name = "Shift_checkBox";
            this.Shift_checkBox.Size = new System.Drawing.Size(84, 25);
            this.Shift_checkBox.TabIndex = 2;
            this.Shift_checkBox.Text = "Shift";
            this.Shift_checkBox.UseVisualStyleBackColor = true;
            this.Shift_checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Win_checkBox
            // 
            this.Win_checkBox.AutoSize = true;
            this.Win_checkBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Win_checkBox.Location = new System.Drawing.Point(189, 95);
            this.Win_checkBox.Name = "Win_checkBox";
            this.Win_checkBox.Size = new System.Drawing.Size(62, 25);
            this.Win_checkBox.TabIndex = 2;
            this.Win_checkBox.Text = "Win";
            this.Win_checkBox.UseVisualStyleBackColor = true;
            this.Win_checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmShortcutKey_Edit_SysKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.Win_checkBox);
            this.Controls.Add(this.Shift_checkBox);
            this.Controls.Add(this.Alt_checkBox);
            this.Controls.Add(this.Control_checkBox);
            this.Controls.Add(this.Result_textBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmShortcutKey_Edit_SysKey";
            this.Text = "frmShortcutKey_Edit_SysKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Result_textBox;
        private System.Windows.Forms.CheckBox Control_checkBox;
        private System.Windows.Forms.CheckBox Alt_checkBox;
        private System.Windows.Forms.CheckBox Shift_checkBox;
        private System.Windows.Forms.CheckBox Win_checkBox;
    }
}