using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.View.ShortcutKeyManage
{
    public partial class frmDelayShow : Form
    {
        public frmDelayShow()
        {
            InitializeComponent();
        }
        private int IntDelay = 1000;
        private void timer1_Tick(object sender, EventArgs e)
        {
            IntDelay = IntDelay - 100;
            if (IntDelay <= 0)
                this.Close();
        }
        public string ProgramFile{get;set;}
        private void frmDelayShow_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;


            Process ProcessTemp = new Process();
            ProcessTemp.StartInfo.FileName = "cmd.exe"; //命令            
            ProcessTemp.StartInfo.UseShellExecute = false; //不启用shell启动进程
            ProcessTemp.StartInfo.RedirectStandardInput = true; // 重定向输入
            ProcessTemp.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            ProcessTemp.StartInfo.RedirectStandardError = true; // 重定向错误输出 
            ProcessTemp.StartInfo.CreateNoWindow = true; // 不创建新窗口
            if (ProcessTemp.Start())
            {
                ProcessTemp.StandardInput.WriteLine("explorer.exe " + ProgramFile); //cmd执行的语句
                ProcessTemp.StandardInput.WriteLine("exit"); //退出                    
            }
        }
    }
}
