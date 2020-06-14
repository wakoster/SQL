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
    public partial class AdministratorInsert : Form
    {
        AdministratorDemo administratorDemo;

        public AdministratorInsert(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            dataGridView1.Rows.Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Administrator administrator = new Administrator(administratorDemo);
            administrator.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ano = (string)dataGridView1.Rows[0].Cells[0].Value;
            string Aname = (string)dataGridView1.Rows[0].Cells[1].Value;
            if(Ano == null || Aname == null)
            {
                MessageBox.Show("请输入完整管理员信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (Ano.Length != 4)
            {
                MessageBox.Show("应该输入四位管理员编号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Aname.Length > 10)
            {
                MessageBox.Show("管理员姓名超出长度", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("是否确认添加该管理员信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Database.conn.Open();
                string getJno = "SELECT Jno FROM Jurisdiction WHERE Jg = " + (administratorDemo.Jno + 1);
                SqlCommand _cmd = new SqlCommand(getJno, Database.conn);
                SqlDataReader _reader = _cmd.ExecuteReader();
                _reader.Read();
                string Jno = _reader[0].ToString();
                _reader.Close();
                {
                    string s = "SELECT Ano,Aname FROM Administrator WHERE Ano = '" + Ano + "' OR Aname = '" + Aname + "'";
                    SqlCommand c = new SqlCommand(s, Database.conn);
                    SqlDataReader r = c.ExecuteReader();
                    while (r.Read())
                    {
                        if (Ano.Equals(r[0].ToString()))
                        {
                            MessageBox.Show("管理员编号存在重复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            r.Close();
                            Database.conn.Close();
                            return;
                        }
                        if (Aname.Equals(r[1].ToString()))
                        {
                            MessageBox.Show("管理员姓名存在重复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            r.Close();
                            Database.conn.Close();
                            return;
                        }
                    }
                    r.Close();
                }
                string sql = "INSERT INTO Administrator VALUES('" + Ano + "','123456','" + Jno + "','" + Aname + "','" + administratorDemo.Ano + "')";
                SqlCommand cmd = new SqlCommand(sql, Database.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                Database.conn.Close();
            }
            button2_Click(sender, e);
        }
    }
}
