using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;

namespace SQLForm
{
    public partial class DamagedProductInformation : Form
    {
        List<REPERTORYInformation> newList = new List<REPERTORYInformation>();
        public DamagedProductInformation(REPERTORYInformation A)
        {
            InitializeComponent();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = A.Pno;
            dataGridView1.Rows[0].Cells[1].Value = A.Wno;
            dataGridView1.Rows[0].Cells[2].Value = A.number;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string a = "D:" + "\\KKHMD.xls";
            //ExportExcels(a, dataGridView1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="myDGV">控件DataGridView</param>
        private void ExportExcels(string fileName, DataGridView myDGV)
        {
            //string saveFileName = "";
            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.DefaultExt = "xls";
            //saveDialog.Filter = "Excel文件|*.xls";
            //saveDialog.FileName = fileName;
            //saveDialog.ShowDialog();
            //saveFileName = saveDialog.FileName;
            //if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //if (xlApp == null)
            //{
            //    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
            //    return;
            //}
            //Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            //Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
            //                                                                                                                      //写入标题
            //for (int i = 0; i < myDGV.ColumnCount; i++)
            //{
            //    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            //}
            ////写入数值
            //for (int r = 0; r < myDGV.Rows.Count; r++)
            //{
            //    for (int i = 0; i < myDGV.ColumnCount; i++)
            //    {
            //        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
            //    }
            //    System.Windows.Forms.Application.DoEvents();
            //}
            //worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            //if (saveFileName != "")
            //{
            //    try
            //    {
            //        workbook.Saved = true;
            //        workbook.SaveCopyAs(saveFileName);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
            //    }
            //}
            //xlApp.Quit();
            //GC.Collect();//强行销毁
            //MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
