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
    public partial class Formcangkutianjia : Form
    {

        AdministratorDemo administratorDemo;
        public Formcangkutianjia(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            仓库管理 form = new 仓库管理(this.administratorDemo);
            form.Show();
        }

        private void comboBoxspbh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttoncangkutianjia_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入新增仓库号", "添加提示");
                return;
            }
            if (textBoxcangkutianjiaWSIZE.Text.Equals(""))
            {
                MessageBox.Show("请输入仓库规格", "添加提示");
                return;
            }
            String wno = this.textBox1.Text;
            String wsize = this.textBoxcangkutianjiaWSIZE.Text;
            Database.conn.Open();
            string sqlsentence = "SELECT * FROM WAREH WHERE Wno = '" + wno + "' ";
            SqlCommand cmd = new SqlCommand(sqlsentence, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                string sql = "INSERT INTO WAREH VALUES('" + wno + "'," + wsize + ", '" + wsize + "')";
                SqlCommand cd = new SqlCommand(sql, Database.conn);
                SqlDataReader read = cd.ExecuteReader();
            }
            else
            {
                MessageBox.Show("已有该仓库", "仓库操作");
            }
            textBoxcangkutianjiaWSIZE.Clear();
            Database.conn.Close();
        }
    }
}
