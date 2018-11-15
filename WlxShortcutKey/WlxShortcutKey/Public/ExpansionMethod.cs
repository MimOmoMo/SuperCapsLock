using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.Public
{
    /// <summary> 扩展方法
    /// </summary>
    public static class ExpansionMethod
    {
        /// <summary> 将Image以png的格式转换为Byte数组
        /// [便于存储数据]
        /// </summary>
        /// <param name="SourceImage"></param>
        /// <returns>转换后的结果</returns> 
        public static byte[] ToByteArray(this Image SourceImage)
        {
            MemoryStream StmTemp = new MemoryStream();
            SourceImage.Save(StmTemp, ImageFormat.Png);
            return StmTemp.ToArray();
        }

        /// <summary> 将Byte数组转为为Image对象
        /// </summary>
        /// <param name="SourceByteArray"></param>
        /// <returns></returns> 
        public static Image ToImage(this byte[] SourceByteArray)
        {
            MemoryStream Stm = new MemoryStream(SourceByteArray);
            return Image.FromStream(Stm);
        }

        /// <summary> 将Icon对象转换为Image对象
        /// </summary>
        /// <param name="SourceIcon"></param>
        /// <returns></returns> 
        public static Image ToImage(this Icon SourceIcon)
        {
            Bitmap BitmapTemp = SourceIcon.ToBitmap();
            IntPtr Handle = BitmapTemp.GetHbitmap();
            Image ReturnImage = Image.FromHbitmap(Handle);
            return ReturnImage;
        }

    }
}
