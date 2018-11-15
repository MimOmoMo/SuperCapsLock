using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools.Public
{
    public class WindowsAPI
    {

        /// <summary>将窗体设置为活动窗体
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体

        /// <summary>获取当前活动窗体句柄
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>获取图标
        /// 
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="dwFileAttributes"></param>
        /// <param name="psfi"></param>
        /// <param name="cbFileInfo"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo", SetLastError = true, CharSet = CharSet.Auto)]        
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        /// <summary>模拟一个键盘的事件
        /// 
        /// </summary>
        /// <param name="KeyNum">键代码</param>
        /// <param name="KeySearch">键的OEM扫描码[填0就行]</param>
        /// <param name="param1">事件类型[0:按下;2:弹起]</param>
        /// <param name="param2">通常不用的一个值[填0就行]</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int Keybd_Event(int KeyNum, int KeySearch, int param1, int param2);

        /// <summary>取键盘状态
        /// 
        /// </summary>
        /// <param name="KeyNum"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetKeyState", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetKeyState(int KeyNum);

        /// <summary>取鼠标当前位置
        /// 
        /// </summary>
        /// <param name="KeyNum"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetCursorPos", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(int KeyNum);


    }
    #region 结构
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }
    #endregion 结构

    #region 枚举
    public enum FileInfoFlags : uint
    {
        SHGFI_ICON = 0x000000100,  //  get icon
        SHGFI_DISPLAYNAME = 0x000000200,  //  get display name
        SHGFI_TYPENAME = 0x000000400,  //  get type name
        SHGFI_ATTRIBUTES = 0x000000800,  //  get attributes
        SHGFI_ICONLOCATION = 0x000001000,  //  get icon location
        SHGFI_EXETYPE = 0x000002000,  //  return exe type
        SHGFI_SYSICONINDEX = 0x000004000,  //  get system icon index
        SHGFI_LINKOVERLAY = 0x000008000,  //  put a link overlay on icon
        SHGFI_SELECTED = 0x000010000,  //  show icon in selected state
        SHGFI_ATTR_SPECIFIED = 0x000020000,  //  get only specified attributes
        SHGFI_LARGEICON = 0x000000000,  //  get large icon
        SHGFI_SMALLICON = 0x000000001,  //  get small icon
        SHGFI_OPENICON = 0x000000002,  //  get open icon
        SHGFI_SHELLICONSIZE = 0x000000004,  //  get shell size icon
        SHGFI_PIDL = 0x000000008,  //  pszPath is a pidl
        SHGFI_USEFILEATTRIBUTES = 0x000000010,  //  use passed dwFileAttribute
        SHGFI_ADDOVERLAYS = 0x000000020,  //  apply the appropriate overlays
        SHGFI_OVERLAYINDEX = 0x000000040   //  Get the index of the overlay
    }
    public enum FileAttributeFlags : uint
    {
        FILE_ATTRIBUTE_READONLY = 0x00000001,
        FILE_ATTRIBUTE_HIDDEN = 0x00000002,
        FILE_ATTRIBUTE_SYSTEM = 0x00000004,
        FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
        FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
        FILE_ATTRIBUTE_DEVICE = 0x00000040,
        FILE_ATTRIBUTE_NORMAL = 0x00000080,
        FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
        FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
        FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
        FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
        FILE_ATTRIBUTE_OFFLINE = 0x00001000,
        FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
        FILE_ATTRIBUTE_ENCRYPTED = 0x00004000
    }
    #endregion 枚举
    
   

}
