using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.View.Base
{
    /// <summary> 与TableContrl相比提供了隐藏选择项的方法，使一个窗体拥有多个页面
    /// 
    /// </summary>
    class OTTabControl : TabControl
    {
        public OTTabControl()
            : base()
        {
            this.TabStop = false;

        }
        private int HideWidth = 0;
        private int HideHeight = 0;
        /// <summary>隐藏表头
        /// 
        /// </summary>
        public void HideTabItem()
        {
            if (this.TabPages.Count == 0) return;
            HideWidth = this.Width - this.TabPages[0].Width;
            HideHeight = this.Height - this.TabPages[0].Height;
            this.Region = new System.Drawing.Region(new System.Drawing.Rectangle(this.TabPages[0].Left, this.TabPages[0].Top, this.Width - HideWidth, this.Height - HideHeight));
            this.Resize += new EventHandler(ReSizeEvent);
        }
        private void ReSizeEvent(object Sender, EventArgs e)
        {
            this.Region = new System.Drawing.Region(new System.Drawing.Rectangle(this.TabPages[0].Left, this.TabPages[0].Top, this.Width - HideWidth, this.Height - HideHeight));
        }
    }
}
