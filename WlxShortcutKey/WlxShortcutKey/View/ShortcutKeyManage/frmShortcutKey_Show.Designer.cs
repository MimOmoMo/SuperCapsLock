namespace OfficeTools
{
    partial class frmShortcutKey_Show
    {
        /// <summary> Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> Clean up any resources being used.
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

        /// <summary> Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LoadFormTimer = new System.Windows.Forms.Timer(this.components);
            this.keyLayoutShow = new OfficeTools.View.Base.KeyLayoutShow();
            this.SuspendLayout();
            // 
            // LoadFormTimer
            // 
            this.LoadFormTimer.Interval = 1;
            this.LoadFormTimer.Tick += new System.EventHandler(this.LoadFormTimer_Tick);
            // 
            // keyLayoutShow
            // 
            this.keyLayoutShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.keyLayoutShow.DataSource = null;
            this.keyLayoutShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyLayoutShow.Location = new System.Drawing.Point(0, 0);
            this.keyLayoutShow.Name = "keyLayoutShow";
            this.keyLayoutShow.Size = new System.Drawing.Size(996, 770);
            this.keyLayoutShow.TabIndex = 0;
            this.keyLayoutShow.ItemClick += new System.EventHandler(this.keyLayoutShow_ItemClick);
            // 
            // frmShortcutKey_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(996, 770);
            this.Controls.Add(this.keyLayoutShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShortcutKey_Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmShortcutKey_Show_FormClosing);
            this.Load += new System.EventHandler(this.ShortcutKey_Show_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private View.Base.KeyLayoutShow keyLayoutShow;
        private System.Windows.Forms.Timer LoadFormTimer;
    }
}