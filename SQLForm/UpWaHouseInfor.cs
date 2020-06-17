using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLForm
{
    public partial class UpWaHouseInfor : Form
    {
        AdministratorDemo administratorDemo;
        public UpWaHouseInfor(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            仓库管理 form = new 仓库管理(this.administratorDemo);
            form.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.conn.Open();
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入仓库号", "修改提示");
                Database.conn.Close();
                return;
            }
            else if(textBox1.Text !="" && (textBox2.Text.Equals("") || textBox3.Text.Equals("")))
                {
                MessageBox.Show("请输入完整的修改信息", "修改提示");
                Database.conn.Close();
                return;
            }
            else if (textBox1.Text != "" && textBox2.Text !="" && textBox3.Text !="")
            {
                string s = textBox1.Text;
                string s1 = SQL.SelectFromWarhouse(Database.conn, s)[0];
                if (s1 == "false")
                {
                    textBox1.Clear();
                    MessageBox.Show("您输入的仓库号不存在", "修改提示");
                    Database.conn.Close();
                    return;
                }
                else
                {
                   
                    string d1 = textBox1.Text;
                    string d2 = textBox2.Text;
                    string d3 = textBox3.Text;
                        String Adm;
                        Adm = "UPDATE WAREH SET Wsize = '" + d2 + "'," + "Wnow = '" + d3 + "'WHERE Wno = '" + d1 + "';";
                         SqlCommand cmd = new SqlCommand(Adm,Database.conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("修改完成", "修改提示");

                    Database.conn.Close();

                    return;
                }
            }
            Database.conn.Close();
        }
    }
}
