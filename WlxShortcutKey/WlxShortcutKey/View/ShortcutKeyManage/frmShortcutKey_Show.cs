using OfficeTools.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeTools.Entity;
using OfficeTools.Public;
using System.Diagnostics;
using OfficeTools.View.Base;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using OfficeTools.View.ShortcutKeyManage;

namespace OfficeTools
{
    public partial class frmShortcutKey_Show : Form
    {

        #region 内部类

        #region 滚轮冷却类
        /// <summary> 用于冷却鼠标滚轮的类，防止使用滚轮序触发多次，导致一瞬间打开很多歌相同的程序
        /// 用于冷却鼠标滚轮的类，防止使用滚轮序触发多次，导致一瞬间打开很多歌相同的程序
        /// </summary> 
        public class WheelCooling
        {
            #region 变量
            /// <summary> 冷却时间
            /// 冷却时间
            /// </summary> 
            private int CoolingTime = 1000;

            /// <summary> 冷却完成时间
            /// 冷却完成时间
            /// </summary> 
            private DateTime OverTime = DateTime.Now;
            #endregion 变量

            #region 构造方法
            /// <summary> 默认冷却时间为1000毫秒
            /// 默认冷却时间为1000毫秒
            /// </summary> 
            public WheelCooling() : this(1000) { }

            /// <summary> 实例化,并指定冷却时间
            /// 实例化,并指定冷却时间
            /// </summary>
            /// <param name="ParameCoolingTime">冷却时间[单位:ms]</param> 
            public WheelCooling(int ParameCoolingTime)
            {
                CoolingTime = ParameCoolingTime;
            }

            #endregion 构造方法

            #region 方法

            /// <summary> 是否已经冷却完成了
            /// 是否已经冷却完成了
            /// </summary>
            /// <returns>完成:true;未完成:false</returns> 
            public bool IsOver
            {
                get
                {
                    if (OverTime < DateTime.Now) return true;
                    return false;
                }
            }

            /// <summary> 重新开始冷却
            /// 重新开始冷却
            /// </summary> 
            public void StartCooling()
            {
                OverTime = DateTime.Now.AddMilliseconds(CoolingTime);
            }
            #endregion 方法
        }
        #endregion 滚轮冷却类

        #region 包含向上滚动和向上滚动的冷却时间类
        /// <summary> 包含向上滚动和向上滚动的冷却时间
        /// 包含向上滚动和向上滚动的冷却时间
        /// </summary> 
        public class WheelCoolingGroup
        {
            #region 构造方法
            /// <summary> 实例化对象，默认冷却时间为1000毫秒
            /// 实例化对象，默认冷却时间为1000毫秒
            /// </summary> 
            public WheelCoolingGroup() : this(1000) { }

            /// <summary> 实例化对象
            /// 实例化对象
            /// </summary>
            /// <param name="CollingTime">冷却时间[ms]</param> 
            public WheelCoolingGroup(int CollingTime)
            {
                WhellUp = new WheelCooling(CollingTime);
                WhellDown = new WheelCooling(CollingTime);
            }
            #endregion 构造方法

            #region 向上和向下滚动的属性

            /// <summary> 向上滚动的冷却
            /// 向上滚动的冷却
            /// </summary> 
            public WheelCooling WhellUp { get; set; }
            /// <summary> 向下滚动的冷却
            /// 向下滚动的冷却
            /// </summary> 
            public WheelCooling WhellDown { get; set; }
            #endregion 向上和向下滚动的属性
        }
        #endregion 包含向上滚动和向上滚动的冷却时间类

        #region 呼出界面的按键类
        /// <summary> 呼出界面的按键        
        /// </summary>         
        public class KeyBoardControlButton
        {
            public KeyBoardControlButton()
            {
                Control = false;
                Alt = false;
                CapsLock = false;
                IsRunProgram = false;
            }

            #region 属性
            /// <summary> 左边Control是否已按下
            /// 左边Control是否已按下
            /// </summary> 
            public bool Control { get; set; }

            /// <summary> 左边Alt是否已按下
            /// 左边Alt是否已按下
            /// </summary> 
            public bool Alt { get; set; }

            /// <summary>用于记录按住的时长
            /// 如果按住的时间没有超过这个时长则不对还原大小写状态
            /// </summary>
            private WheelCooling CapsLock_Cooling = new WheelCooling(200);

            /// <summary>当前的大小写状态
            /// 
            /// </summary>
            private bool KeyBoradState = false;

            /// <summary>大小写键是否已经按下
            /// 
            /// </summary>
            private bool _CapsLock = false;

            /// <summary>大小写键是否已经按下
            /// 
            /// </summary>
            public bool CapsLock
            {
                get
                {
                    return _CapsLock;
                }
                set
                {
                    if (value == _CapsLock) return;
                    if (value)
                    {
                        //按下大小写键时记录大小写键的状态
                        CapsLock_Cooling.StartCooling();
                        KeyBoradState = WindowsAPI.GetKeyState(20);
                    }
                    else
                    {
                        //放开大小写键时判断是否需要还原
                        if (IsNeedResetState())
                        {
                            this.IsRunProgram = false;
                            Thread thread = new Thread(() =>
                            {
                                Thread.Sleep(50);
                                UniversalMethod.SetState(Keys.CapsLock, KeyBoradState);
                            });
                            thread.Start();
                        }

                    }
                    _CapsLock = value;
                }
            }

            /// <summary>是否按下过快捷键
            /// 如果按下过快捷键则会还原大小写状态
            /// </summary>
            public bool IsRunProgram { get; set; }

            /// <summary>是否需要还原键盘状态
            /// 如果按住时间超过冷却时间，或者使用过组合键，就需要还原成按下之前的状态，否则不需要还原
            /// </summary>
            /// <returns></returns>
            private bool IsNeedResetState()
            {
                if (IsRunProgram || CapsLock_Cooling.IsOver) return true;
                return false;
            }


            /// <summary> 所有控制键是否全部按下了
            /// 所有控制键是否全部按下了
            /// </summary> 
            public bool IsAllPressDown
            {
                get
                {
                    //if (Control && Alt) return true;
                    if (CapsLock) return true;
                    return false;

                }
            }
            #endregion 属性

            /// <summary> 键代码是否是控制键之一
            /// 键代码是否是控制键之一
            /// </summary>
            /// <param name="KeyNum">键代码</param>
            /// <returns></returns> 
            public bool IsControlButton(int KeyNum)
            {
                switch (KeyNum)
                {
                    case (int)Keys.LControlKey:
                    case (int)Keys.LMenu:
                    case (int)Keys.CapsLock:
                        return true;
                }
                return false;
            }
        }
        #endregion 呼出界面的按键类

        #region 外设钩子类
        /// <summary> 外设钩子，用于鼠标和键盘的动作
        /// 外设钩子，用于鼠标和键盘的动作
        /// </summary> 
        public class DeviceHook
        {
            public DeviceHook()
            {
                KeyboardHook = new KeyboardHookLib();
                MouseHook = new MouseHook();
            }

            #region 属性
            /// <summary> 键盘钩子对象
            /// 键盘钩子对象
            /// </summary> 
            public KeyboardHookLib KeyboardHook { get; set; }

            /// <summary> 鼠标钩子对象
            /// 鼠标钩子对象
            /// </summary> 
            public MouseHook MouseHook { get; set; }

            /// <summary> 设置键盘发生动作时的事件委托
            /// 设置键盘发生动作时的事件委托
            /// </summary> 
            public KeyboardHookLib.ProcessKeyHandle KeyboardEvent
            {
                set { KeyboardHook.InstallHook(value); }
            }

            /// <summary> 设置鼠标发生动作时的事件委托
            /// 设置鼠标发生动作时的事件委托
            /// </summary> 
            public MouseHook.MouseHookEventDeleget MouseEvent
            {
                set { MouseHook.Start(value); }
            }
            #endregion 属性

            /// <summary> 卸载所有钩子
            /// 卸载所有钩子
            /// </summary> 
            public void CloseHook()
            {
                KeyboardHook.UninstallHook();
                MouseHook.Stop();
            }
        }
        #endregion 外设钩子类

        #region 延时启动程序类
        /// <summary> 延时启动程序类
        /// 最终会调用窗体的InvokeDelayRun方法来执行启动代码
        /// 本类只用于延时，延时的时间到了则将启动代码交给UI线程来执行
        /// </summary>
        class DelayRun
        {
            /// <summary> 实例化
            /// 
            /// </summary>
            /// <param name="ParamRunForm">最终启动程序的窗体,该窗体必须有InvokeDelayRun的公开方法来执行最终运行的代码[本类只用于延时，延时的时间到了则将启动代码交给UI线程来执行]</param>
            /// <param name="ParamKeyNum">最终运行的快捷键代码</param>
            /// <param name="ParamDelayTime">延迟时间[单位:ms]</param>
            public DelayRun(frmShortcutKey_Show ParamRunForm, string ParamKeyNum, int ParamDelayTime)
            {
                InvokeForm = ParamRunForm;
                KeyNum = ParamKeyNum;
                DelayTime = ParamDelayTime;


            }

            /// <summary> 运行程序时的UI窗体
            /// 如果延时的时间到了，线程会将启动程序的代码提交到UI线程的消息队列，由UI线程来执行最终的启动代码
            /// </summary>
            private frmShortcutKey_Show InvokeForm = null;

            /// <summary> 延时时间ms
            /// 
            /// </summary>
            private int DelayTime = 0;

            /// <summary> 启动时间
            /// 
            /// </summary>
            private DateTime RunTime = DateTime.Now;

            /// <summary> 用于监视当前时间是否可以启动程序的线程实例
            /// 
            /// </summary>            
            private Thread DelayRunThread = null;

            /// <summary> 是否终止延时启动
            /// 
            /// </summary>
            private bool ThreadStop = false;

            /// <summary> 延时启动的快捷键代码
            /// 
            /// </summary>
            public string KeyNum { get; set; }

            #region 方法
            /// <summary> 停止延时启动
            /// 如果之前已经开始计时，调用该方法则会立即中断监视线程。本次延时启动将取消
            /// </summary>
            public void StopDlayRun()
            {
                ThreadStop = true;
            }

            /// <summary> 开始计时或重置计时器
            /// 如果之前已经开始计时再次调用则会覆盖
            /// </summary>
            public void ReSetRunTime()
            {
                ThreadStop = false;
                RunTime = DateTime.Now.AddMilliseconds(DelayTime);

                ThreadDelayRun();
            }

            /// <summary> 创建一条线程来监视当前是否允许允许程序
            ///  线程只用来监视，最终的启动代码将由UI线程来执行
            /// </summary>
            private void ThreadDelayRun()
            {

                if (DelayRunThread == null)//对象对空标识之前的线程运行结束
                {
                    DelayRunThread = new Thread(() =>
                    {
                        while (true)
                        {
                            if (ThreadStop)
                            {
                                DelayRunThread = null;
                                return;
                            }
                            if (RunTime < DateTime.Now)
                            {
                                object[] ParameArray = new object[1];
                                ParameArray[0] = KeyNum;
                                InvokeForm.BeginInvoke(new Action<string>(InvokeForm.InvokeDelayRun), ParameArray);
                                DelayRunThread = null;
                                return;
                            }
                            Thread.Sleep(10);
                        }

                    });


                    DelayRunThread.Start();
                }


            }
            #endregion 方法

        }
        #endregion 延时启动程序类

        #endregion 内部类

        #region 属性

        private List<tShortCutKey> tShortCutKeyDataSource = null;
        private List<vShortCutKey> CurrentNodetShortCutKey = null;

        private KeyBoardControlButton ControlButton = new KeyBoardControlButton();

        private DeviceHook HookObj = new DeviceHook();


        private WheelCoolingGroup WhellColingObj = new WheelCoolingGroup(100);


        /// <summary> 是否已经运行过程序了
        /// 
        /// </summary>
        private bool IsRun = false;

        /// <summary> 用于屏幕延时的实例
        /// 
        /// </summary>
        private DelayRun DelayRunObj = null;

        public Form ParentForm = null;

        #endregion 属性

        #region 启动、初始化
        public frmShortcutKey_Show()
        {

            InitializeComponent();
            ShowForm = (Form)(this.Parent);
            if (ShowForm == null) ShowForm = this;
        }

        private void ShortcutKey_Show_Load(object sender, EventArgs e)
        {
            LoadFormTimer.Enabled = true;
        }

        private void LoadFormTimer_Tick(object sender, EventArgs e)
        {
            LoadFormTimer.Enabled = false;
            this.Visible = false;
            tShortCutKeyDataSource = new ShortcutKeyManageService().GettShortCutKeyList();
            ShowKey();

            HookObj = new DeviceHook();
            HookObj.KeyboardEvent = KeyboardDown;
            HookObj.MouseEvent = MouseEvent;
        }
        #endregion 启动、初始化

        #region 方法
        /// <summary> 显示某个节点下的所有快捷键
        /// 显示某个节点下的所有快捷键
        /// </summary>
        /// <param name="Parent">父节点ID，为空则为根节点</param> 
        private void ShowKey(string ParentID = null)
        {
            List<tShortCutKey> tShortCutKeyTempList = null;

            if (string.IsNullOrEmpty(ParentID))
                tShortCutKeyTempList = tShortCutKeyDataSource.Where(T1 => string.IsNullOrEmpty(T1.ParentID)).ToList();
            else
                tShortCutKeyTempList = tShortCutKeyDataSource.Where(T1 => T1.ParentID == ParentID).ToList();

            //将tShortCutKey转换成vShortCutKey
            CurrentNodetShortCutKey = tShortCutKeyTempList.Select(T1 => UniversalMethod.ClassToClass<tShortCutKey, vShortCutKey>(T1, new vShortCutKey())).ToList();
            CurrentNodetShortCutKey.ForEach(T1 => T1.OwningChidrenNode = OwningChidren(T1));//加入是否有下级节点     
            keyLayoutShow.DataSource = CurrentNodetShortCutKey;
        }

        /// <summary> 检查某快捷键是否有子节点
        /// 检查某快捷键是否有子节点
        /// </summary>
        /// <param name="KeyEntity">被检查的快捷键</param>
        /// <returns></returns>         
        private bool OwningChidren(vShortCutKey KeyEntity)
        {
            int ResultCount = tShortCutKeyDataSource.Where(T1 => T1.ParentID == KeyEntity.ShortCutKeyID).Count();
            if (ResultCount == 0) return false;
            else return true;
        }

        private Form ShowForm = null;

        /// <summary> 设置窗口的现实和隐藏
        /// 设置窗口的现实和隐藏
        /// </summary>
        /// <returns>成功改变Visible的值返回True，否则返回False</returns>         
        private bool SetFormVisible()
        {
            bool SourceVisible = ShowForm.Visible;
            if (ControlButton.IsAllPressDown)
            {
                ShowForm.Visible = true;
                ShowForm.TopMost = true;
            }
            else
            {
                ShowForm.Visible = false;
            }
            bool VisibleChange = SourceVisible != ShowForm.Visible;//是否有变化
            if (VisibleChange && ShowForm.Visible)
            //if (true)
            {
                ShowKey();//当前节点置入到根节点
                tShortCutKeyDataSource = new ShortcutKeyManageService().GettShortCutKeyList(); //当前结束时获取最新记录
            }
            return VisibleChange;
        }

        /// <summary> 全系统的：键盘按下事件
        /// 全系统的：键盘按下事件
        /// </summary>
        /// <param name="param">按下的按键消息</param>
        /// <param name="handle">是否拦截这个按钮</param> 
        private void KeyboardDown(KeyboardHookLib.HookStruct param, out bool handle)
        {
            handle = false;
            //this.Text = string.Format(@"vkCode:{0};flags{1}", param.vkCode.ToString(), param.flags.ToString());

            #region 控制键弹起或按下
            if (param.flags == 128 || param.flags == 160)//是否弹起
            {
                switch (param.vkCode)
                {
                    case (int)Keys.LControlKey:
                        ControlButton.Control = false;
                        break;
                    case (int)Keys.LMenu:
                        ControlButton.Alt = false;
                        break;
                    case (int)Keys.CapsLock:
                        ControlButton.CapsLock = false;
                        ControlButtonDown = true;
                        break;
                }
            }
            else if (param.flags == 0 || param.flags == 32)
            {
                switch (param.vkCode)
                {
                    case (int)Keys.LControlKey:
                        ControlButton.Control = true;
                        break;
                    case (int)Keys.LMenu:
                        ControlButton.Alt = true;
                        break;
                    case (int)Keys.CapsLock:
                        ControlButton.CapsLock = true;
                        break;
                }
            }
            //SetFormVisible();//隐藏或关闭窗口     
            if (ControlButton.IsControlButton(param.vkCode))
            {
                if (ControlButtonDown)
                {
                    tShortCutKeyDataSource = new ShortcutKeyManageService().GettShortCutKeyList(); //当前结束时获取最新记录
                    ShowKey();//当前节点置入到根节点
                    ControlButtonDown = false;
                }
                return;//是控制键就不用往下走了
            }
            #endregion 控制键弹起或按下

            if (ControlButton.IsAllPressDown)
            {
                bool IsKeyDown = param.flags == 0 || param.flags == 32;//是否键盘按下
                if (!IsKeyDown) return;//不是按下就直接返回

                handle = RunShortcutKeyContens(param.vkCode.ToString()); //阻止按键
            }
        }
        private bool ControlButtonDown = false;

        /// <summary>延时后启动程序的方法
        /// 主要用来在UI线程执行启动代码，
        /// </summary>
        /// <param name="ParamKeyNum"></param>
        public void InvokeDelayRun(string ParamKeyNum)
        {
            if (IsRun) return;
            RunShortcutKeyContens(ParamKeyNum);//启动程序
            IsRun = true;
        }

        /// <summary> 全系统的：鼠标动作捕捉
        /// 全系统的：鼠标动作捕捉
        /// </summary>
        /// <param name="param"></param>
        /// <param name="wParam">动作代码</param>
        /// <param name="lParam">句柄</param>
        /// <param name="handle">是否阻止动作</param>
        private void MouseEvent(MouseHook.MouseHookStruct param, int wParam, Int64 lParam, out bool handle)
        {

            handle = false;
            switch (wParam)
            {
                case 512://鼠标移动
                    if (!ControlButton.IsAllPressDown) return;//是否按下了控制键
                    string StrKeyNum = GetScreenKeyNum();//获取鼠标触发的屏幕键代码
                    if (string.IsNullOrEmpty(StrKeyNum)) //鼠标是否已经离开的屏幕的边角地区
                    {
                        IsRun = false;
                        return;
                    }
                    if (IsRun) return;//如果已经运行过程序避免重复运行这里直接返回
                    #region 注释说明
                    //用户如果想要触发角快捷键，一般情况下总会先触发边的快捷键再触发角
                    //所以如果触发了边则不立即运行快捷键，而进行延时100毫秒在运行，
                    //如果延时期间一担触发了角快捷键则立即启动并终止边快捷键的延迟启动，
                    //所以角快捷键的优先权总是高于边快捷键的，一旦触发角则立即舍弃边 
                    #endregion 注释说明
                    if (IsScreenAngle(StrKeyNum))//是否触发的是屏幕的四个角
                    {
                        if (DelayRunObj != null) DelayRunObj.StopDlayRun();//如果之前触发了边快捷键则立即终止它的延时启动
                        RunShortcutKeyContens(StrKeyNum); //如果触发了角则直接启动程序
                        IsRun = true;
                    }
                    else
                    {
                        if (DelayRunObj == null) DelayRunObj = new DelayRun(this, StrKeyNum, 100);
                        DelayRunObj.KeyNum = StrKeyNum;
                        DelayRunObj.ReSetRunTime();//如果触发了边则延时启动，看后面还会不会触发角
                    }
                    break;
                case 513://鼠标左键按下
                    break;
                case 514://鼠标左键弹起
                    break;
                case 516://鼠标右键按下
                    break;
                case 517://鼠标右键弹起
                    break;
                case 519://鼠标中键按下
                    break;
                case 520://鼠标中键弹起
                    break;
                case 522://鼠标滚轮滚动
                    if (!ControlButton.IsAllPressDown) return;
                    if (0 < param.hWnd)   //向上滑动                                               
                    {
                        if (WhellColingObj.WhellUp.IsOver)//冷却完成
                        {
                            RunShortcutKeyContens("WheelUp");//启动程序                                
                        }
                        WhellColingObj.WhellUp.StartCooling();//重新开始冷却
                    }
                    else
                    {
                        if (WhellColingObj.WhellDown.IsOver)//冷却完成
                        {
                            RunShortcutKeyContens("WheelDown");//启动程序
                        }
                        WhellColingObj.WhellDown.StartCooling();//重新开始冷却
                    }
                    handle = true;
                    break;
            }


        }

        /// <summary> 运行当前节点的某个快捷键
        /// 运行当前节点的某个快捷键
        /// </summary>
        /// <param name="KeyNum">当前节点的键代码</param> 
        private bool RunShortcutKeyContens(string KeyNum)
        {
            vShortCutKey CurrentEntity = CurrentNodetShortCutKey.Where(T1 => T1.ShortCutKey == KeyNum).FirstOrDefault();
            if (CurrentEntity == null) return false;
            if (CurrentEntity.OwningChidrenNode)
            {
                ShowKey(CurrentEntity.ShortCutKeyID);
                return true;
            }
            if (string.IsNullOrEmpty(CurrentEntity.ShortCutKeyPath)) return false;
            try
            {
                ControlButton.IsRunProgram = true;
                switch (CurrentEntity.ShortCutKeyType)
                {
                    case 0://程序                        
                    case 1://网址
                        UniversalMethod.RunProgram(CurrentEntity.ShortCutKeyPath);
                        break;
                    case 2://系统组合键
                        UniversalMethod.KeyBoardDown(GetSysShortcutKey(CurrentEntity.ShortCutKeyPath));
                        break;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary> 打开类为[2:系统组合键]的快捷键的打开内容转换为Keys的键代码集合
        /// 
        /// </summary>
        /// <param name="StrKey"></param>
        /// <returns></returns>
        private List<Keys> GetSysShortcutKey(string StrKey)
        {
            List<Keys> ResultList = new List<Keys>();
            List<string> KeyNameList = StrKey.Split('+').ToList();
            foreach (string KeyName in KeyNameList)
            {
                Keys ResultKey = new Keys();
                if (!Enum.TryParse<Keys>(KeyName, out ResultKey)) continue;
                ResultList.Add(ResultKey);
            }
            return ResultList;
        }

        /// <summary> 获取屏幕键代码
        /// 
        /// </summary>
        /// <returns>返回键代码，如果没有触及到屏幕边缘则返回空</returns>
        private string GetScreenKeyNum()
        {
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;

            if (Control.MousePosition.X <= 1 && Control.MousePosition.Y <= 1) return "ScreenLT";
            if (Control.MousePosition.X <= 1 && Control.MousePosition.Y >= ScreenHeight - 1) return "ScreenLB";
            if (Control.MousePosition.X >= ScreenWidth - 1 && Control.MousePosition.Y <= 1) return "ScreenRT";
            if (Control.MousePosition.X >= ScreenWidth - 1 && Control.MousePosition.Y >= ScreenHeight - 1) return "ScreenRB";
            if (Control.MousePosition.Y <= 1) return "ScreenT";
            if (Control.MousePosition.X <= 1) return "ScreenL";
            if (Control.MousePosition.X >= ScreenWidth - 1) return "ScreenR";
            if (Control.MousePosition.Y >= ScreenHeight - 1) return "ScreenB";
            return null;
        }

        /// <summary> 键代码是否是屏幕的角
        /// 
        /// </summary>
        /// <param name="KeyNum"></param>
        /// <returns></returns>
        private bool IsScreenAngle(string KeyNum)
        {
            switch (KeyNum)
            {
                case "ScreenLT":
                case "ScreenLB":
                case "ScreenRT":
                case "ScreenRB":
                    return true;
            }
            return false;
        }
        #endregion 方法

        #region 事件
        /// <summary> 快捷键项目被单击
        /// 快捷键项目被单击
        /// </summary>
        /// <param name="sender">被单击的自定义控件[以继承自IShortcutKeyItem_Box接口，横向和竖向都可以被强转为IShortcutKeyItem_Box]</param>
        /// <param name="e"></param>         
        private void keyLayoutShow_ItemClick(object sender, EventArgs e)
        {
            vShortCutKey EntityTemp = ((IShortcutKeyItem_Box)sender).DataEntity;
            if (EntityTemp == null) return;
            RunShortcutKeyContens(EntityTemp.ShortCutKey);
        }

        /// <summary> 窗口即将被关闭时卸载键盘钩子
        /// 窗口即将被关闭时卸载键盘钩子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void frmShortcutKey_Show_FormClosing(object sender, FormClosingEventArgs e)
        {
            HookObj.CloseHook();
        }
        #endregion 事件

    }
}
