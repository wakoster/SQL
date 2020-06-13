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
    public partial class Login : Form
    {
        AdministratorDemo administratorDemo;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入管理员编号", "登录提示");
                return;
            }
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("请输入密码", "登录提示");
                return;
            }
            Database.conn.Open();
            string sql = "SELECT Ano,Akey,Aname,Jg FROM Administrator,Jurisdiction WHERE Ano = '" + this.textBox1.Text + "' AND Administrator.Jno = Jurisdiction.Jno";
            SqlCommand cmd = new SqlCommand(sql, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool flag = false;
            while (reader.Read())
            {
                this.administratorDemo = new AdministratorDemo(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3]));
                flag = true;
            }
            reader.Close();
            if(flag)
            {
                if(administratorDemo.Jno == 1 && textBox2.Text.Equals(administratorDemo.Akey))
                {
                    Hide();
                    最高管理员 form = new 最高管理员(this.administratorDemo);
                    form.Show();
                }
                else if(administratorDemo.Jno == 2 && textBox2.Text.Equals(administratorDemo.Akey))
                {
                    Hide();
                    Form1 form = new Form1(this.administratorDemo);
                    form.Show();
                }
                else if (administratorDemo.Jno == 3 && textBox2.Text.Equals(administratorDemo.Akey))
                {
                    Hide();
                    CoManager form = new CoManager(this.administratorDemo);
                    form.Show();
                }
                else
                { 
                    textBox2.Clear();
                    MessageBox.Show("密码错误，请重新输入", "登录提示");
                }
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("管理员编号错误，请核对输入内容", "登录提示");
            }
            Database.conn.Close();
        }
    }
}
