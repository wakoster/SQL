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
    public partial class DeleteWarehouse : Form
    {
        AdministratorDemo administratorDemo;
        public DeleteWarehouse(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            UpdateInformation();
        }

        private void DeleteWarehouse_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            仓库管理 form3 = new 仓库管理(this.administratorDemo);
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("是否确认删除仓库号为" + comboBox1.Text + "的仓库", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Database.conn.Open();
                    string sql = "DELETE FROM WAREH WHERE Wno = '" + comboBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, Database.conn);
                    cmd.ExecuteReader();
                    Database.conn.Close();
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    UpdateInformation();
                }
            }
        }

        /// <summary>
        /// 更新表格界面信息
        /// </summary>
        private void UpdateInformation()
        {
            comboBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            Database.conn.Open();
            string sql = "SELECT * FROM WAREH";
            SqlCommand cmd = new SqlCommand(sql, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int k = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Cells[0].Value = reader[0].ToString();
                dataGridView1.Rows[k].Cells[1].Value = reader[1].ToString();
                dataGridView1.Rows[k].Cells[2].Value = reader[2].ToString();
                if (reader[2].ToString().Equals("0"))
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }
                k++;
            }
            reader.Close();
            Database.conn.Close();
        }
    }
}
