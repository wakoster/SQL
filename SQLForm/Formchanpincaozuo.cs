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
    public partial class Formchanpincaozuo : Form
    {
        AdministratorDemo administratorDemo;
        public Formchanpincaozuo(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxDPNO.Text.Equals(""))
            {
                MessageBox.Show("输入产品号", "操作提示");
                return;
            }
            if (textBoxDPNAME.Text.Equals(""))
            {
                MessageBox.Show("输入产品名", "提示");
                return;
            }
            Database.conn.Open();
            String pno = this.textBoxDPNO.Text;
            String pname = this.textBoxDPNAME.Text;
            string a = "SELECT * FROM Product WHERE Pno = '" + this.textBoxDPNO.Text + "'";
            SqlCommand cmd = new SqlCommand(a, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                string sql = "insert into Product values( '" + pno + "' ,'" + pname + "')";
                SqlCommand cm = new SqlCommand(sql, Database.conn);
                SqlDataReader read = cm.ExecuteReader();
            }
            else
            {
                MessageBox.Show("以有此产品", "添加");
            }
            
            textBoxDPNO.Clear();
            textBoxDPNAME.Clear();
            
            Database.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxDPNO.Text.Equals(""))
            {
                MessageBox.Show("输入产品号", "操作提示");
                return;
            }
            if (textBoxDPNAME.Text.Equals(""))
            {
                MessageBox.Show("输入产品名", "提示");
                return;
            }
            Database.conn.Open();
            string a = "SELECT * FROM Product WHERE Pno = '" + this.textBoxDPNO.Text + "' AND Pname = '" + this.textBoxDPNAME.Text + "'";
            SqlCommand cmd = new SqlCommand(a, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("没有此产品", "删除");
            }
            else
            {
                reader.Close();
                string sql = "delete FROM Product WHERE Pno = '" + this.textBoxDPNO.Text + "' AND Pname = '" + this.textBoxDPNAME.Text + "'";
                SqlCommand cm = new SqlCommand(a, Database.conn);
                SqlDataReader read = cm.ExecuteReader();
            }
            textBoxDPNO.Clear();
            textBoxDPNAME.Clear();
            Database.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxDPNO.Text.Equals(""))
            {
                MessageBox.Show("输入产品号", "操作提示");
                return;
            }
            Database.conn.Open();
            string a = "SELECT * FROM Product WHERE Pno= '" + this.textBoxDPNO.Text + "'";
            SqlCommand cmd = new SqlCommand(a, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("没有此产品", "修改");
            }
            else
            {
                reader.Close();
                string sql = "UPDATE Product set Pname = '" + this.textBoxDPNAME.Text + "'WHERE Pno = '" + this.textBoxDPNO.Text + "' ";
                SqlCommand cm = new SqlCommand(sql, Database.conn);
                SqlDataReader read = cm.ExecuteReader();
            }
            textBoxDPNO.Clear();
            textBoxDPNAME.Clear();
            Database.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxDPNAME.Text.Equals(""))
            {
                MessageBox.Show("输入产品名", "操作提示");
                return;
            }
            Database.conn.Open();
            string a = "SELECT * FROM Product WHERE Pname = '" + this.textBoxDPNAME.Text + "'";
            SqlCommand cmd = new SqlCommand(a, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("没有此产品", "修改");
            }
            else
            {
                reader.Close();
                string sql = "UPDATE Product set Pno = '" + this.textBoxDPNO.Text + "' WHERE Pname = '" + this.textBoxDPNAME.Text + "'";
                SqlCommand cm = new SqlCommand(sql, Database.conn);
                SqlDataReader read = cm.ExecuteReader();
            }
            textBoxDPNO.Clear();
            textBoxDPNAME.Clear();
            Database.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form2 = new Form1(this.administratorDemo);
            form2.Show();
        }

        private void textBoxDPNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAPNO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
