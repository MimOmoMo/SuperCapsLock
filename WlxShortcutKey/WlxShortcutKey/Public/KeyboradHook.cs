using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;


namespace OfficeTools.Public
{

    /// <summary> 键盘Hook管理类
    /// </summary>
    public class KeyboardHookLib
    {
        private const int WH_KEYBOARD_LL = 13; //键盘

        //键盘处理事件委托.
        private delegate int HookHandle(int nCode, int wParam, IntPtr lParam);

        //客户端键盘处理事件
        public delegate void ProcessKeyHandle(HookStruct param, out bool handle);

        //接收SetWindowsHookEx返回值
        private static int _hHookValue = 0;

        //勾子程序处理事件
        private HookHandle _KeyBoardHookProcedure;

        //Hook结构
        [StructLayout(LayoutKind.Sequential)]
        public class HookStruct
        {
            /// <summary> 键代码
            /// </summary>
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        //设置钩子
        [DllImport("user32.dll")]
        private static extern int SetWindowsHookEx(int idHook, HookHandle lpfn, IntPtr hInstance, int threadId);

        //取消钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        //调用下一个钩子
        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        //获取当前线程ID
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        //Gets the main module for the associated process.
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string name);

        private IntPtr _hookWindowPtr = IntPtr.Zero;

        //构造器
        public KeyboardHookLib() { }

        //外部调用的键盘处理事件
        private static ProcessKeyHandle _clientMethod = null;

        /// <summary> 安装勾子
        /// </summary>
        /// <param name="hookProcess">外部调用的键盘处理事件</param>
        public void InstallHook(ProcessKeyHandle clientMethod)
        {
            _clientMethod = clientMethod;

            // 安装键盘钩子
            if (_hHookValue == 0)
            {
                _KeyBoardHookProcedure = new HookHandle(GetHookProc);

                _hookWindowPtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);

                _hHookValue = SetWindowsHookEx(
                    WH_KEYBOARD_LL,
                    _KeyBoardHookProcedure,
                    _hookWindowPtr,
                    0);

                //如果设置钩子失败.
                if (_hHookValue == 0)

                    UninstallHook();
            }
        }

        //取消钩子事件
        public void UninstallHook()
        {
            if (_hHookValue != 0)
            {
                bool ret = UnhookWindowsHookEx(_hHookValue);
                if (ret) _hHookValue = 0;
            }
        }

        //钩子事件内部调用,调用_clientMethod方法转发到客户端应用。
        private static int GetHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                //转换结构
                HookStruct hookStruct = (HookStruct)Marshal.PtrToStructure(lParam, typeof(HookStruct));

                if (_clientMethod != null)
                {
                    bool handle = false;
                    //调用客户提供的事件处理程序。
                    _clientMethod(hookStruct, out handle);
                    if (handle) return 1; //1:表示拦截键盘,return 退出
                }
            }
            return CallNextHookEx(_hHookValue, nCode, wParam, lParam);
        }

    }



    /// <summary> 鼠标全局钩子
    /// </summary>
    public class MouseHook
    {
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;

        /// <summary> 点
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        /// <summary> 钩子结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        public const int WH_MOUSE_LL = 14; // mouse hook constant

        // 装置钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        // 卸下钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        // 下一个钩挂的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        public delegate void MouseHookEventDeleget(MouseHookStruct Struct, int wParam, Int64 lParam, out bool handle);

        // 全局的鼠标事件
        public event MouseHookEventDeleget OnMouseActivity;

        // 钩子回调函数
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        // 声明鼠标钩子事件类型
        private HookProc _mouseHookProcedure;
        private static int _hMouseHook = 0; // 鼠标钩子句柄

        /// <summary> 构造函数
        /// </summary>
        public MouseHook()
        {

        }


        /// <summary> 启动全局钩子
        /// </summary>
        public void Start(MouseHookEventDeleget EventParame)
        {
            OnMouseActivity = EventParame;

            // 安装鼠标钩子
            if (_hMouseHook == 0)
            {
                // 生成一个HookProc的实例.
                _mouseHookProcedure = new HookProc(MouseHookProc);

                _hMouseHook = SetWindowsHookEx(
                    WH_MOUSE_LL,
                    _mouseHookProcedure,
                    Process.GetCurrentProcess().MainModule.BaseAddress,
                    0);

                //如果装置失败停止钩子
                if (_hMouseHook == 0)
                {
                    Stop();
                    
                }
            }
        }

        /// <summary> 停止全局钩子
        /// </summary>
        public void Stop()
        {
            bool retMouse = true;

            if (_hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(_hMouseHook);
                _hMouseHook = 0;
            }

            // 如果卸下钩子失败
            if (!(retMouse))
                throw new Exception("UnhookWindowsHookEx failed.");
        }

        /// <summary> 鼠标钩子回调函数
        /// </summary>
        private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 如果正常运行并且用户要监听鼠标的消息
            if ((nCode >= 0) && (OnMouseActivity != null))
            {
                MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                bool ResultHandle = false;
                OnMouseActivity(MyMouseHookStruct,wParam,lParam.ToInt64(),out ResultHandle);
                if (ResultHandle) return 1; //1:表示拦截键盘,return 退出
            }

            // 启动下一次钩子
            return CallNextHookEx(_hMouseHook, nCode, wParam, lParam);
        }
    }
}