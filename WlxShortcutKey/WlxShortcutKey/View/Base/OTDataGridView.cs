using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeTools.View.Base
{
    class OTDataGridView : DataGridView
    {
        public OTDataGridView()
            : base()
        { }

        /// <summary> 获取当前选中行的某一列的值
        /// 
        /// </summary>
        /// <param name="ColumnsIndex">列的下标</param>
        /// <returns>选中行的该列的值</returns>
        public string GetSelectedRowValue(string ColumnsName)
        {
            string ResultString = "";
            DataGridViewSelectedRowCollection RowsTemp = this.SelectedRows;
            if (RowsTemp.Count != 0)
            {
                object SelectIDObj = RowsTemp[0].Cells[ColumnsName].Value;
                if (SelectIDObj != null)
                {
                    ResultString = SelectIDObj.ToString();
                }
            }
            return ResultString;
        }

        /// <summary> 获取当前选中行的某一列的值
        /// 
        /// </summary>
        /// <param name="ColumnsIndex">列的下标</param>
        /// <returns>选中行的该列的值</returns>
        public string GetSelectedRowValue(int ColumnsIndex)
        {
            string ResultString = "";
            DataGridViewSelectedRowCollection RowsTemp = this.SelectedRows;
            if (RowsTemp.Count != 0)
            {
                object SelectIDObj = RowsTemp[0].Cells[ColumnsIndex].Value;
                if (SelectIDObj != null)
                {
                    ResultString = SelectIDObj.ToString();
                }
            }
            return ResultString;
        }

        /// <summary> 选中某列的值为指定值的行，滚动条也会自动跳转至该行
        /// 
        /// </summary>
        /// <param name="ColumnsIndex">该行的列的名称</param>
        /// <param name="ParamValue">列的值</param>
        public void SetSelectedRowByValue(string ColumnsName, string ParamValue)
        {
            if (string.IsNullOrEmpty(ParamValue)) return;
            foreach (DataGridViewRow RowItem in this.Rows)
            {
                object ValueObj = RowItem.Cells[ColumnsName].Value;
                string StrRowValue = ValueObj.ToString();
                if (StrRowValue == ParamValue)
                {
                    foreach (DataGridViewCell CellItem in RowItem.Cells)
                    {
                        if (CellItem.Visible)
                        {
                            this.CurrentCell = CellItem;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary> 选中某列的值为指定值的行，滚动条也会自动跳转至该行
        /// 
        /// </summary>
        /// <param name="ColumnsIndex">该行的列的下标</param>
        /// <param name="ParamValue">列的值</param>
        public void SetSelectedRowByValue(int ColumnsIndex, string ParamValue)
        {
            if (string.IsNullOrEmpty(ParamValue)) return;
            foreach (DataGridViewRow RowItem in this.Rows)
            {
                object ValueObj = RowItem.Cells[ColumnsIndex].Value;
                string StrRowValue = ValueObj.ToString();
                if (StrRowValue == ParamValue)
                {
                    foreach (DataGridViewCell CellItem in RowItem.Cells)
                    {
                        if (CellItem.Visible)
                        {
                            this.CurrentCell = CellItem;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>选中并跳转到某一行
        /// 
        /// </summary>
        /// <param name="RowIndex">行的下标</param>
        public void SetSelecetedRowByRowIndex(int RowIndex)
        {
            if (this.Rows.Count <= RowIndex) return;
            if (this.Rows.Count == 0) return;
            DataGridViewRow RowTemp = this.Rows[RowIndex];
            foreach (DataGridViewCell CellItem in RowTemp.Cells)
            {
                if (CellItem.Visible)
                {
                    this.CurrentCell = CellItem;
                    break;
                }
            }
        }
    }
}
