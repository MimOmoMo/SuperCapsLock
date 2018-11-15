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

        public void SetSelectedRowByValue(string ColumnsName, string ParamValue)
        {
            if (string.IsNullOrEmpty(ParamValue)) return;
            foreach (DataGridViewRow RowItem in this.Rows)
            {
                object ValueObj = RowItem.Cells[ColumnsName].Value;
                string StrRowValue = ValueObj.ToString();
                if (StrRowValue == ParamValue)
                {
                    RowItem.Selected = true;
                }
                else
                {
                    RowItem.Selected = false;
                }
            }
        }
        
        public void SetSelectedRowByValue(int ColumnsIndex, string ParamValue)
        {
            if (string.IsNullOrEmpty(ParamValue)) return;
            foreach (DataGridViewRow RowItem in this.Rows)
            {
                object ValueObj = RowItem.Cells[ColumnsIndex].Value;
                string StrRowValue = ValueObj.ToString();
                if (StrRowValue == ParamValue)
                {
                    RowItem.Selected = true;
                }
                else
                {
                    RowItem.Selected = false;
                }
            }
        }
    }
}
