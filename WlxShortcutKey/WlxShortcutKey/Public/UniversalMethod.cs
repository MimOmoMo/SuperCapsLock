using OfficeTools.View.ShortcutKeyManage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.Public
{

    public class UniversalMethod
    {

        /// <summary> 获取一个文件的图标
        /// </summary>
        /// <param name="Filepath">文件路径</param>
        /// <returns>获取到的图标</returns> 
        public static Image GetImageByFileName(string Filepath)
        {
            SHFILEINFO SHFILEINFOTemp = new SHFILEINFO();
            WindowsAPI.SHGetFileInfo(Filepath, 0, ref SHFILEINFOTemp, (uint)System.Runtime.InteropServices.Marshal.SizeOf(SHFILEINFOTemp), (uint)FileInfoFlags.SHGFI_ICON | (uint)FileInfoFlags.SHGFI_USEFILEATTRIBUTES | (uint)FileInfoFlags.SHGFI_OPENICON);
            System.Drawing.Icon IconImage = System.Drawing.Icon.FromHandle(SHFILEINFOTemp.hIcon);
            return Image.FromHbitmap(IconImage.ToBitmap().GetHbitmap());
        }
        
        /// <summary> 通过键代码获取按键名称
        /// </summary>
        /// <param name="KeyNum"></param>
        /// <returns></returns> 
        public static string GetKeyName(string KeyNum)
        {
            //if (string.IsNullOrEmpty(KeyNum)) return "";
            switch (KeyNum)
            {
                case "WheelUp":
                    return "鼠标向上滚动";
                case "WheelDown":
                    return "鼠标向下滚动";
                case "ScreenLT":
                    return "屏幕左上角";
                case "ScreenRT":
                    return "屏幕右上角";
                case "ScreenLB":
                    return "屏幕左下角";
                case "ScreenRB":
                    return "屏幕右下角";
                case "ScreenT":
                    return "屏幕上边";
                case "ScreenB":
                    return "屏幕下边";
                case "ScreenL":
                    return "屏幕左边";
                case "ScreenR":
                    return "屏幕右边";
                case "96"://0
                    return "数字键0";
                case "97"://1
                    return "数字键1";
                case "98"://2
                    return "数字键2";
                case "99"://3
                    return "数字键3";
                case "100"://4
                    return "数字键4";
                case "101"://5
                    return "数字键5";
                case "102"://6
                    return "数字键6";
                case "103"://7
                    return "数字键7";
                case "104"://8
                    return "数字键8";
                case "105"://9
                    return "数字键9";
                case "111":// /
                    return "数字键/";
                case "13"://enter
                    return "Enter";
                case "106"://*
                    return "数字键*";
                case "107"://+
                    return "数字键+";
                case "109"://-
                    return "数字键-";
                case "110"://.
                    return "数字键.";
                case "144"://.
                    return "数字键NmLk";
                default:
                    if (string.IsNullOrEmpty(KeyNum)) break;
                    if (!new Regex(@"[^\d]").Match(KeyNum).Success)
                    {
                        return Enum.GetName(typeof(Keys), Int32.Parse(KeyNum));
                    }
                    break;
            }
            return "";
        }

        /// <summary> 获取快捷键打开类型的中文含义
        /// 
        /// </summary>
        /// <param name="TypeNum">类型编号</param>
        /// <returns></returns>
        public static string GetTypeName(int TypeNum)
        {
            string StrResult = "";
            switch (TypeNum)
            {
                case 0:
                    StrResult = "程序/文件";
                    break;
                case 1:
                    StrResult = "网页";
                    break;
                case 2:
                    StrResult = "系统组合键";
                    break;
            }
            return StrResult;
        }
        
        /// <summary> 是否数字键盘上的键
        /// </summary>
        /// <param name="KeyNum">键代码</param>
        /// <returns>[是：true;不是：false]</returns> 
        public static bool IsNumberKey(string KeyNum)
        {
            string StrKeyNum = KeyNum.Trim();
            switch (StrKeyNum)
            {
                case "96"://0
                case "97"://1
                case "98"://2
                case "99"://3
                case "100"://4
                case "101"://5
                case "102"://6
                case "103"://7
                case "104"://8
                case "105"://9
                case "111":// /
                case "13"://enter
                case "106"://*
                case "107"://+
                case "109"://-
                case "110"://.
                case "144"://.
                    return true;
            }

            return false;
        }

        /// <summary> 用反射将一个类转换为另一个类
        /// [可以用于深拷贝，也可以用于两个相似的模型进行转换、并且只会转换两个类共有的属性]
        /// </summary>
        /// <typeparam name="SourceClass">将要转换的类</typeparam>
        /// <typeparam name="ResultClass">要转换到的目标类</typeparam>
        /// <param name="SourceObj">被转换的实例</param>
        /// <param name="Objed">转换前的实例[使用前请先进行一次实例化，因为本方法不会对该实例重新进行实例化]</param>
        /// <returns>返回结果[转换前的数据将会保留，只覆盖拥有相同属性名的属性]</returns> 
        public static ResultClass ClassToClass<SourceClass, ResultClass>(SourceClass SourceObj, ResultClass Objed)
        {
            PropertyInfo[] SourcePropertyInfoArray = SourceObj.GetType().GetProperties();
            PropertyInfo[] BePropertyInfoArray = Objed.GetType().GetProperties();

            foreach (PropertyInfo SourcePropertyInfoItem in SourcePropertyInfoArray)
            {
                foreach (PropertyInfo BePropertyInfoItem in BePropertyInfoArray)
                {
                    if (SourcePropertyInfoItem.Name != BePropertyInfoItem.Name) continue;//属性名不同则跳过，想在才往下走
                    string StrSourcePropertyName = SourcePropertyInfoItem.PropertyType.Name;//获取属性的数据类型名称
                    string StrBePropertyName = BePropertyInfoItem.PropertyType.Name;//获取属性的数据类型名称
                    if (StrSourcePropertyName != StrBePropertyName) break;//两个属性的数据类型必须一致才往下走，否则跳过这个属性
                    try
                    {
                        object SourcePropertyValue = SourcePropertyInfoItem.GetValue(SourceObj);
                        BePropertyInfoItem.SetValue(Objed, SourcePropertyValue);
                    }
                    catch
                    {
                        break;//能赋值就赋值，赋值失败就跳过 
                    }
                }
            }
            return Objed;
        }

        /// <summary> 使用explorer.exe启动程序
        /// 这样启动的程序启动后会激活成活动窗体，Program的Start只能在后台启动。启动后还需要点击一下任务栏才能看到页面
        /// </summary>
        /// <param name="ProgramFile"></param>
        public static void RunProgram(string ProgramFile)
        {

            //Process.Start("explorer.exe ", ProgramFile);
            Process.Start( ProgramFile);
            //frmDelayShow frm = new frmDelayShow();
            //frm.ProgramFile = ProgramFile;
            //frm.Show();
            //Process ProcessTemp = new Process();
            //ProcessTemp.StartInfo.FileName = "cmd.exe"; //命令            
            //ProcessTemp.StartInfo.UseShellExecute = false; //不启用shell启动进程
            //ProcessTemp.StartInfo.RedirectStandardInput = true; // 重定向输入
            //ProcessTemp.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            //ProcessTemp.StartInfo.RedirectStandardError = true; // 重定向错误输出 
            //ProcessTemp.StartInfo.CreateNoWindow = true; // 不创建新窗口
            //if (ProcessTemp.Start())
            //{
            //    ProcessTemp.StandardInput.WriteLine("explorer.exe " + ProgramFile); //cmd执行的语句
            //    ProcessTemp.StandardInput.WriteLine("exit"); //退出                    
            //}
        }

        /// <summary>按下键盘组合键,将指定按键同时按下
        /// 将指定按键同时按下
        /// </summary>
        /// <param name="ParamKeyNumList">同时按下的键[Keys类的值]</param>
        public static void KeyBoardDown(List<Keys> ParamKeyNumList)
        {
            
            //按下
            foreach (Keys KeyNumItem in ParamKeyNumList)
            {
                WindowsAPI.Keybd_Event((int)KeyNumItem, 0, 0, 0);
            }
            //弹起
            foreach (Keys KeyNumItem in ParamKeyNumList)
            {
                WindowsAPI.Keybd_Event((int )KeyNumItem, 0, 2, 0);
            }
        }
        
        /// <summary> 获取按键状态
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="State"></param>
        public static void SetState(Keys Key, bool State)
        {
            if (State != WindowsAPI.GetKeyState((int)Key))
            {
                Thread.Sleep(100); 
                WindowsAPI.Keybd_Event((byte)Key, 0x45, 0x1 | 0, 0);
                Thread.Sleep(100);
                WindowsAPI.Keybd_Event((byte)Key, 0x45, 0x1 | 0x2, 0);
            }
        }

    }
}
