using OfficeTools.db;
using OfficeTools.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools.Service
{
    public class ShortcutKeyManageService
    {
        public List<tShortCutKey> GettShortCutKeyList(tShortCutKey WhereEntity = null)
        {

            List<tShortCutKey> ResultList = new List<tShortCutKey>();
            using (OfficeToolsDb db = new OfficeToolsDb())
            {
                IQueryable<tShortCutKey> tShortCutKeyIQ = db.tShortCutKey;
                if (WhereEntity == null)
                {
                    ResultList = tShortCutKeyIQ.ToList();
                    return ResultList;
                }
                if (WhereEntity.ShortCutKeyID != null)
                {
                    tShortCutKeyIQ = tShortCutKeyIQ.Where(T1 => T1.ShortCutKeyID == WhereEntity.ShortCutKeyID);
                }
                ResultList = tShortCutKeyIQ.ToList();
            }
            return ResultList;
        }

        /// <summary> 在某个节点下添加一个快捷键,成功返回它的ID，失败返回空
        /// </summary>
        /// <param name="AddData">节点</param>
        /// <returns>新的快捷键的ID</returns>
        public string AddShortCutKey(tShortCutKey AddData)
        {
            int ChangeCount = 0;
            using (OfficeToolsDb db = new OfficeToolsDb())
            {
                if (AddData.ShortCutKeyID == null) AddData.ShortCutKeyID = DBTools.GetID();
                db.tShortCutKey.Add(AddData);
                ChangeCount = db.SaveChanges();
            }
            if (ChangeCount <= 0) return null;
            return AddData.ShortCutKeyID;
        }

        /// <summary> 删除快捷键以及他的子节点
        /// </summary>
        /// <param name="DeleteData"></param>
        /// <returns></returns>
        public bool DeleteShortCutKey(tShortCutKey DeleteData)
        {
            if (string.IsNullOrEmpty(DeleteData.ShortCutKeyID)) return false;
            using (OfficeToolsDb db = new OfficeToolsDb())
            {
                var tShortCutKeyIdList = db.tShortCutKey.Select(T1 => new { ID = T1.ShortCutKeyID, ParentID = T1.ParentID }).ToList();//取出该表的所有ID和父ID
                List<dynamic> tIdList = tShortCutKeyIdList.Select(T1 => (dynamic)T1).ToList();//将匿名对象转换成Dynamic方便后面传递给递归方法
                List<string> DeliteIdList = GetChidrenId(tIdList, DeleteData.ShortCutKeyID);//递归无限向下取所有子节点ID
                DeliteIdList.Add(DeleteData.ShortCutKeyID);//自己本身也要被删除
                List<tShortCutKey> DeleteEntityList = DeliteIdList.Select(T1 => new tShortCutKey() { ShortCutKeyID = T1 }).ToList();//将Dynamic集合转换为tShortCutKey方便EF删除
                #region 开始删除
                foreach (tShortCutKey Deleteitem in DeleteEntityList)
                {
                    DbEntityEntry Status = db.Entry(Deleteitem);
                    Status.State = EntityState.Deleted;
                }
                db.SaveChanges();
                #endregion 开始删除
            }
            return true;
        }

        /// <summary> 递归无限向下取所有子节点ID
        /// [孙节点;曾孙节点都能取到]
        /// </summary>
        /// <param name="ListData">所有记录</param>
        /// <param name="ParentID">父ID</param>
        /// <returns>取到的ID</returns>
        private List<string> GetChidrenId(List<dynamic> ListData, string ParentID)
        {
            List<dynamic> ListTemp = ListData.Where(T1 => T1.ParentID == ParentID).ToList();
            List<string> ResultStringList = new List<string>();
            foreach (dynamic item in ListTemp)
            {
                ResultStringList.Add(item.ID);
                ResultStringList.AddRange(GetChidrenId(ListData, item.ID));
            }
            return ResultStringList;
        }

        public bool UpdateShortcutKey(tShortCutKey UpdateEntity)
        {

            int ChangeLineCount = 0;

            using (OfficeToolsDb db = new OfficeToolsDb())
            {
                db.Entry<tShortCutKey>(UpdateEntity).State = EntityState.Modified;
                ChangeLineCount = db.SaveChanges();
            }
            return 0 < ChangeLineCount;

        }



    }
}
