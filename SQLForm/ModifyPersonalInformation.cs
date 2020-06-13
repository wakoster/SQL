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
    public partial class ModifyPersonalInformation : Form
    {

        AdministratorDemo administratorDemo;
        public ModifyPersonalInformation(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = administratorDemo.Ano;
            dataGridView1.Rows[0].Cells[1].Value = administratorDemo.Aname;
            dataGridView1.Rows[0].Cells[2].Value = administratorDemo.Akey;
        }

        private void button2_Click(object sender, EventArgs e)
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
            else if (this.administratorDemo.Jno == 3)
            {
                CoManager form = new CoManager(this.administratorDemo);
                form.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!dataGridView1.Rows[0].Cells[1].Value.Equals(administratorDemo.Aname) || !dataGridView1.Rows[0].Cells[2].Value.Equals(administratorDemo.Akey))
            {
                DialogResult result = MessageBox.Show("是否确认您对个人信息的修改", "提示",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    administratorDemo.Aname = (string)dataGridView1.Rows[0].Cells[1].Value;
                    administratorDemo.Akey = (string)dataGridView1.Rows[0].Cells[2].Value;
                    Database.conn.Open();
                    string sql = "UPDATE Administrator SET Akey = '" + administratorDemo.Akey + "'," + "Aname = '" + administratorDemo.Aname + "' WHERE Ano = '" + administratorDemo.Ano + "'";
                    SqlCommand cmd = new SqlCommand(sql, Database.conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    Database.conn.Close();
                }
            }
            button2_Click(sender, e);
        }
    }
}
