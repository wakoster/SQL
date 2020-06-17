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
    public partial class Formchanpinbaosun : Form
    {
        AdministratorDemo administratorDemo;
        public Formchanpinbaosun(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void Formchanpinbaosun_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxBSWNO.Text.Equals(""))
            {
                MessageBox.Show("请输入要报损的仓库号", "添加提示");
                return;
            }
            if (textBoxBSPNO.Text.Equals(""))
            {
                MessageBox.Show("请输入要报损的产品号", "添加提示");
                return;
            }
            if (textBoxBSNUMBER.Text.Equals(""))
            {
                MessageBox.Show("请输入要报损的产品数量", "添加提示");
                return;
            }
            Database.conn.Open();
            String wno = this.comboBoxBSWNO.Text;
            String pno = this.textBoxBSPNO.Text;
            String num = this.textBoxBSNUMBER.Text;
           
            string a = "SELECT * FROM REPERTORY WHERE Wno = '" + wno + "' AND Pno='" + pno + "' AND Pnum>'"+num+"'";
            SqlCommand cmd = new SqlCommand(a, Database.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
               MessageBox.Show("库存信息有误请重新输入", "报损");
                Database.conn.Close();
            }
            else
            {
                reader.Close();
                SQL.AddDAMAGE(Database.conn, pno, wno, num);
                Database.conn.Close();
            }
            textBoxBSPNO.Clear();
            textBoxBSNUMBER.Clear();

        }

        private void textBoxdwmc_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxlxdh_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxdwdz_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxfzrxm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxdwbh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void labelres_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelopestyle_Click(object sender, EventArgs e)
        {

        }
    }
}
