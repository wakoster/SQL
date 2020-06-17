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

using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLForm
{
    public partial class Formchurukucaozuo : Form
    {
        AdministratorDemo administratorDemo;
        public Formchurukucaozuo(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            
        }

        private void textBoxspbh_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBoxspmc_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxsplx_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxspbh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxckbh_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxRPNO.Text.Equals(""))
            {
                MessageBox.Show("请输入产品号", "添加提示");
                return;
            }
            if (textBoxRWNO.Text.Equals(""))
            {
                MessageBox.Show("请输入仓库号", "添加提示");
                return;
            }
            if (textBoxRPNAME.Text.Equals(""))
            {
                MessageBox.Show("请输入管理员号", "添加提示");
                return;
            }
            if (textBoxRPNO.Text.Equals(""))
            {
                MessageBox.Show("请输入操作数量", "添加提示");
                return;
            }
            string Pno= this.textBoxRPNO.Text; 
            string Wno= this.textBoxRWNO.Text; 
            int number=0;
            try
            {
                number = int.Parse(textBoxRNUM.Text);
            }
            catch
            {
                number = 0;
            }
            string Ano= this.textBoxRFZ.Text;
            Database.conn.Open();
            string sqlsentence = "SELECT * FROM REPERTORY,Administrator WHERE  REPERTORY.Wno = '" + Wno + "'AND REPERTORY.Pno= '" + Pno + "'AND Ano='"+Ano+"'";
            SqlCommand cmd = new SqlCommand(sqlsentence, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("库存信息有误请重新输入", "出入库操作");
            }
            else
            {
reader.Close();
              SQL.ProductOutbound(Database.conn, Pno, Wno, number, Ano);
            }
            
            Database.conn.Close();
            textBoxRPNO.Clear();
            textBoxRWNO.Clear();
            textBoxRPNAME.Clear();
            textBoxRFZ.Clear();
            textBoxRNUM.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxRPNO.Text.Equals(""))
            {
                MessageBox.Show("请输入产品号", "添加提示");
                return;
            }
            if (textBoxRWNO.Text.Equals(""))
            {
                MessageBox.Show("请输入仓库号", "添加提示");
                return;
            }
            if (textBoxRFZ.Text.Equals(""))
            {
                MessageBox.Show("请输入管理员号", "添加提示");
                return;
            }
            if (textBoxRNUM.Text.Equals(""))
            {
                MessageBox.Show("请输入操作数量", "添加提示");
                return;
            }
            string Pno = this.textBoxRPNO.Text;
            string Wno = this.textBoxRWNO.Text;
            int number = 0;
            try
            {
                number = int.Parse(textBoxRNUM.Text);
            }
            catch
            {
                number = 0;
            }
            string Ano = this.textBoxRFZ.Text;
            Database.conn.Open();
            string sqlsentence = "SELECT * FROM WAREH,Product,Administrator WHERE  WAREH.Wno = '" + Wno + "' AND Product.Pno = '" + Pno + "'AND Administrator.Ano = '" + Ano + "'";
            SqlCommand cmd = new SqlCommand(sqlsentence, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("库存信息有误请重新输入", "出入库操作");
            }
            else
            {
                reader.Close();
             SQL.ProductInbound(Database.conn, Pno, Wno, number, Ano);
            }
            textBoxRPNO.Clear();
            textBoxRWNO.Clear();
            textBoxRPNAME.Clear();
            textBoxRFZ.Clear();
            textBoxRNUM.Clear();
            Database.conn.Close(); 


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            if (this.administratorDemo.Jno == 2)
            {
                Form1 form = new Form1(this.administratorDemo);
                form.Show();
            }
            else if (this.administratorDemo.Jno == 3)
            {
                CoManager form = new CoManager(this.administratorDemo);
                form.Show();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelres_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCNUM_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCWNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCFZ_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRWNO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
