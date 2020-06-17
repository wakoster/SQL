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
    public partial class 仓库查询 : Form
    {
        AdministratorDemo administratorDemo;
        public 仓库查询(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();


            if (ConnectionState.Open == Database.conn.State)//判断数据库是否开启
                Database.conn.Close();
            Database.conn.Open();
            String userstring = "Select Wno from WAREH  " ;
            SqlDataAdapter da = new SqlDataAdapter(userstring, Database.conn);//数据适配器对象，可把数据源的数据读到内存表里，或把内存的数据写回去。
            DataTable dt = new DataTable();  //datatable对象，用来填充查询到的数据
            da.Fill(dt);  //把查询到的数据da填充给dt
            dataGridView1.DataSource = dt; //将dt对象作为dataview1的数据源
            Database.conn.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            if (this.administratorDemo.Jno == 1)
            {
                仓库管理 form2 = new 仓库管理(this.administratorDemo);
                form2.Show();
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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(ConnectionState.Open == Database.conn.State)//判断数据库是否开启
                Database.conn.Close();
            Database.conn.Open();

            if(textBox1.Text == string.Empty)
            {
                textBox1.Text = "请您输入仓库号后进行查询";
            }
            else
            {
                String userstring = "Select * from WAREH where Wno ='" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(userstring, Database.conn);//数据适配器对象，可把数据源的数据读到内存表里，或把内存的数据写回去。
                DataTable dt = new DataTable();  //datatable对象，用来填充查询到的数据
                da.Fill(dt);  //把查询到的数据da填充给dt
                dataGridView1.DataSource = dt; //将dt对象作为dataview1的数据源
            }
            Database.conn.Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ConnectionState.Open == Database.conn.State)//判断数据库是否开启
                Database.conn.Close();
            Database.conn.Open();

            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "请您输入仓库号后进行查询";
            }
            else
            {
                String userstring = "Select * from REPERTORY where Wno ='" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(userstring, Database.conn);//数据适配器对象，可把数据源的数据读到内存表里，或把内存的数据写回去。
                DataTable dt = new DataTable();  //datatable对象，用来填充查询到的数据
                da.Fill(dt);  //把查询到的数据da填充给dt
                dataGridView1.DataSource = dt; //将dt对象作为dataview1的数据源
            }
            Database.conn.Close();
        }
    }
}
