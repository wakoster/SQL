using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLForm
{
    public partial class Administrator : Form
    {
        AdministratorDemo administratorDemo;
        public Administrator(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            if(administratorDemo.Jno == 1)
            {
                UpdateInformation1();
            }
            else if (administratorDemo.Jno == 2)
            {
                UpdateInformation2();
            }
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (this.administratorDemo.Jno == 1)
            {
                最高管理员 form = new 最高管理员(this.administratorDemo);
                form.Show();
            }
            else if (this.administratorDemo.Jno == 2)
            {
                Form1 form = new Form1(this.administratorDemo);
                form.Show();
            }
        }

        /// <summary>
        /// 更新最高管理员表格界面信息
        /// </summary>
        private void UpdateInformation1()
        {
            dataGridView1.Rows.Clear();
            Database.conn.Open();
            string sql = "SELECT * FROM Administrator";
            SqlCommand cmd = new SqlCommand(sql, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int k = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Cells[0].Value = reader[0].ToString();
                dataGridView1.Rows[k].Cells[1].Value = reader[1].ToString();
                dataGridView1.Rows[k].Cells[2].Value = reader[2].ToString();
                dataGridView1.Rows[k].Cells[3].Value = reader[3].ToString();
                dataGridView1.Rows[k].Cells[4].Value = reader[4].ToString();
                k++;
            }
            reader.Close();
            Database.conn.Close();
        }

        /// <summary>
        /// 更新高级管理员表格界面信息
        /// </summary>
        private void UpdateInformation2()
        {
            dataGridView1.Rows.Clear();
            Database.conn.Open();
            string sql = "SELECT * FROM Administrator WHERE ByAno = '" + administratorDemo.Ano + "'";
            SqlCommand cmd = new SqlCommand(sql, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int k = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Cells[0].Value = reader[0].ToString();
                dataGridView1.Rows[k].Cells[1].Value = reader[1].ToString();
                dataGridView1.Rows[k].Cells[2].Value = reader[2].ToString();
                dataGridView1.Rows[k].Cells[3].Value = reader[3].ToString();
                dataGridView1.Rows[k].Cells[4].Value = reader[4].ToString();
                k++;
            }
            reader.Close();
            Database.conn.Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                (sender as DataGridView).ClearSelection();
                (sender as DataGridView).CurrentRow.Selected = false;
                (sender as DataGridView).Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
