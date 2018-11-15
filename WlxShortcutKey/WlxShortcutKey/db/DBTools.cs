using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools.db
{
    /// <summary> 数据库相关工具类
    /// </summary>
    public class DBTools
    {
        private static Random DBRandom = null;


        static public Random GetDBRandom()
        {
            if (DBRandom == null) DBRandom = new Random();//全局只需要实例化一次就够了，否则在高速取随机数时会发生相同的随机数种子
            return DBRandom;
        }

        /// <summary> 发号[暂时随机发号，以后数据量多的话再制定发号规则]
        /// </summary>
        /// <returns></returns>
        static public string GetID()
        {
            string IncludeChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random RandomTemp = GetDBRandom();
            StringBuilder StringBuilderTemp = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                int CharIndex = RandomTemp.Next(IncludeChar.Length);
                StringBuilderTemp.Append(IncludeChar[CharIndex]);
            }
            return StringBuilderTemp.ToString();



        }
    }
}
