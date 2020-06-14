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
    public partial class AdministratorUpdate : Form
    {
        AdministratorDemo administratorDemo;
        string _Ano;
        string _Aname;
        string _Akey;

        public AdministratorUpdate(AdministratorDemo administratorDemo, string Ano, string Aname, string Akey)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = Ano;
            dataGridView1.Rows[0].Cells[1].Value = Aname;
            dataGridView1.Rows[0].Cells[2].Value = Akey;
            this._Ano = Ano;
            this._Aname = Aname;
            this._Akey = Akey;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Administrator administrator = new Administrator(administratorDemo);
            administrator.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Rows[0].Cells[1].Value.Equals(_Aname) || !dataGridView1.Rows[0].Cells[2].Value.Equals(_Akey))
            {
                DialogResult result = MessageBox.Show("是否确认您对该管理员信息的修改", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string Aname = (string)dataGridView1.Rows[0].Cells[1].Value;
                    string Akey = (string)dataGridView1.Rows[0].Cells[2].Value;
                    Database.conn.Open();
                    string sql = "UPDATE Administrator SET Akey = '" + Akey + "'," + "Aname = '" + Aname + "' WHERE Ano = '" + _Ano + "'";
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
