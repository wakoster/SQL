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
    public partial class Formchurukuchaxun : Form
    {
        AdministratorDemo administratorDemo;
        public Formchurukuchaxun(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Formchurukuchaxun_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             void AutoResizeColumnWidth(ListView lv)
            {
                int count = lv.Columns.Count;
                int MaxWidth = 0;
                Graphics graphics = lv.CreateGraphics();
                int width;
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                for (int i = 0; i < count; i++)
                {
                    string str = lv.Columns[i].Text;
                    MaxWidth = lv.Columns[i].Width;

                    foreach (ListViewItem item in lv.Items)
                    {
                        str = item.SubItems[i].Text;
                        width = (int)graphics.MeasureString(str, lv.Font).Width;
                        if (width > MaxWidth)
                        {
                            MaxWidth = width;
                        }
                    }
                    if (MaxWidth <= 150)
                    {
                        lv.Columns[i].Width = MaxWidth;
                    }
                    else
                    {
                        lv.Columns[i].Width = 150;
                    }
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Database.conn.Open();
            String wno = this.textBoxchurukuWNO.Text;
            String pno = this.textBoxchurukuPNO.Text;
            String pname = this.textBoxchurukuPNO.Text;
            String ono = this.textBoxchurukuONO.Text;
            listView1.Columns.Add("出入库记录"); 
            listView1.Columns.Add("单号"); 
            listView1.Columns.Add("产品号"); 
            listView1.Columns.Add("仓库号"); 
            listView1.Columns.Add("操作属性");
            listView1.Columns.Add("数量");
            listView1.Columns.Add("日期"); 
            listView1.Columns.Add("管理员号");
            listView1.Items.Clear();
            if (textBoxchurukuONO.Text.Equals(""))
            {
               
                if (textBoxchurukuWNO.Text.Equals("")&& textBoxchurukuPNO.Text!="")//仅凭产品号搜索
                {
                    
                    string a = "SELECT * FROM Opreation WHERE Pno='" + pno + "' ";
                    SqlCommand cmd = new SqlCommand(a, Database.conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("没有此产品的出入库记录", "出入");
                    }
                    else
                    {
                        reader.Close();
                        string sql = "SELECT * FROM Opreation WHERE Pno='" + pno + "' ";
                        SqlCommand cm = new SqlCommand(sql, Database.conn);
                        cmd.CommandText = "SELECT * FROM Opreation WHERE Pno='" + pno + "' ";
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {

                            ListViewItem lt = new ListViewItem();
                            lt.SubItems.Add(read[0].ToString());
                            lt.SubItems.Add(read[1].ToString());
                            lt.SubItems.Add(read[2].ToString());
                            lt.SubItems.Add(read[3].ToString());
                            lt.SubItems.Add(read[4].ToString());
                            lt.SubItems.Add(read[5].ToString());
                            lt.SubItems.Add(read[6].ToString());
                            listView1.Columns[1].Width = -1;
                            listView1.Columns[2].Width = -1;
                            listView1.Columns[3].Width = -2;
                            listView1.Columns[4].Width = -2;
                            listView1.Columns[5].Width = -1;
                            listView1.Columns[6].Width = -2;
                            listView1.Columns[7].Width = -2;
                            listView1.Columns[0].Width = -2;
                            listView1.Items.Add(lt);
                        }
                        read.Close();
                    }
                    Database.conn.Close();
                }
                else if (textBoxchurukuPNO.Text.Equals("")&& textBoxchurukuWNO.Text!="")//仅凭仓库号搜索
                {
                    string a = "SELECT * FROM Opreation WHERE Wno='" + wno + "' ";
                    SqlCommand cmd = new SqlCommand(a, Database.conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("没有此仓库的出入库记录", "出入");
                    }
                    else
                    {
                        reader.Close();
                        string sql = "SELECT * FROM Opreation WHERE Wno='" + wno + "' ";
                        SqlCommand cm = new SqlCommand(sql, Database.conn);
                        cm.CommandText = "SELECT * FROM Opreation WHERE Wno='" + wno + "' ";
                        SqlDataReader read = cm.ExecuteReader();
                        while (read.Read())
                        {
                            ListViewItem lt = new ListViewItem();
                            lt.SubItems.Add(read[0].ToString());
                            lt.SubItems.Add(read[1].ToString());
                            lt.SubItems.Add(read[2].ToString());
                            lt.SubItems.Add(read[3].ToString());
                            lt.SubItems.Add(read[4].ToString());
                            lt.SubItems.Add(read[5].ToString());
                            lt.SubItems.Add(read[6].ToString());
                            listView1.Columns[1].Width = -1;
                            listView1.Columns[2].Width = -1;
                            listView1.Columns[3].Width = -2;
                            listView1.Columns[4].Width = -2;
                            listView1.Columns[5].Width = -1;
                            listView1.Columns[6].Width = -2;
                            listView1.Columns[7].Width = -2;
                            listView1.Columns[0].Width = -2;
                            listView1.Items.Add(lt);
                        }
                        read.Close();
                    }
                    Database.conn.Close();
                }
                else if(textBoxchurukuPNO.Text!="" && textBoxchurukuWNO.Text != "")
                {
                    string a = "SELECT * FROM Opreation WHERE Wno='" + wno + "'AND Pno='" + pno + "'";
                    SqlCommand cmd = new SqlCommand(a, Database.conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("没有此仓库的出入库记录", "出入");
                    }
                    else
                    {
                        reader.Close();
                        string sql = "SELECT * FROM Opreation WHERE Wno='" + wno + "'AND Pno='" + pno + "'";
                        SqlCommand cm = new SqlCommand(sql, Database.conn);
                        cm.CommandText = "SELECT * FROM Opreation WHERE Wno='" + wno + "'AND Pno='" + pno + "'";
                        SqlDataReader read = cm.ExecuteReader();
                        while (read.Read())
                        {
                            ListViewItem lt = new ListViewItem();
                            lt.SubItems.Add(read[0].ToString());
                            lt.SubItems.Add(read[1].ToString());
                            lt.SubItems.Add(read[2].ToString());
                            lt.SubItems.Add(read[3].ToString());
                            lt.SubItems.Add(read[4].ToString());
                            lt.SubItems.Add(read[5].ToString());
                            lt.SubItems.Add(read[6].ToString());
                            listView1.Columns[1].Width = -1;
                            listView1.Columns[2].Width = -1;
                            listView1.Columns[3].Width = -2;
                            listView1.Columns[4].Width = -2;
                            listView1.Columns[5].Width = -1;
                            listView1.Columns[6].Width = -2;
                            listView1.Columns[7].Width = -2;
                            listView1.Columns[0].Width = -2;
                            listView1.Items.Add(lt);
                        }
                        read.Close();
                    }
                    Database.conn.Close();
                }
            }
            if (textBoxchurukuONO.Text!="")
            {
                string a = "SELECT * FROM Opreation WHERE Ono='" + ono + "'"; 
                SqlCommand cmd = new SqlCommand(a, Database.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    MessageBox.Show("没有此订单", "出入");
                }
                else
                {
                    reader.Close();
                    string sql = "SELECT * FROM Opreation WHERE Ono='" + ono + "'";
                    SqlCommand cm = new SqlCommand(sql, Database.conn);
                    cm.CommandText = "SELECT * FROM Opreation WHERE Ono='" + ono + "'";
                    SqlDataReader read = cm.ExecuteReader();
                    while (read.Read())
                    {
                        ListViewItem lt = new ListViewItem();
                        lt.SubItems.Add(read[0].ToString());
                        lt.SubItems.Add(read[1].ToString());
                        lt.SubItems.Add(read[2].ToString());
                        lt.SubItems.Add(read[3].ToString());
                        lt.SubItems.Add(read[4].ToString());
                        lt.SubItems.Add(read[5].ToString());
                        lt.SubItems.Add(read[6].ToString());
                        listView1.Columns[1].Width = -1;
                        listView1.Columns[2].Width = -1;
                        listView1.Columns[3].Width = -2;
                        listView1.Columns[4].Width = -2;
                        listView1.Columns[5].Width = -1;
                        listView1.Columns[6].Width = -2;
                        listView1.Columns[7].Width = -2;
                        listView1.Columns[0].Width = -2;
                        listView1.Items.Add(lt);
                    }
                    read.Close();
                }

                Database.conn.Close();
            }
            if (textBoxchurukuWNO.Text.Equals("") && textBoxchurukuPNO.Text.Equals("")&& textBoxchurukuONO.Text.Equals(""))
            {
               
                string sql = "SELECT * FROM Opreation";
                SqlCommand cmd = new SqlCommand(sql, Database.conn);
                cmd.CommandText = "SELECT * FROM Opreation";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem lt = new ListViewItem();
                    lt.SubItems.Add(reader[0].ToString());
                    lt.SubItems.Add(reader[1].ToString());
                    lt.SubItems.Add(reader[2].ToString());
                    lt.SubItems.Add(reader[3].ToString());
                    lt.SubItems.Add(reader[4].ToString());
                    lt.SubItems.Add(reader[5].ToString());
                    lt.SubItems.Add(reader[6].ToString());
                    listView1.Columns[1].Width = -1;
                    listView1.Columns[2].Width = -1;
                    listView1.Columns[3].Width = -2;
                    listView1.Columns[4].Width = -2;
                    listView1.Columns[5].Width = -1;
                    listView1.Columns[6].Width = -2;
                    listView1.Columns[7].Width = -2;
                    listView1.Columns[0].Width = -2;
                    listView1.Items.Add(lt);
                }
                reader.Close();
                Database.conn.Close();
            }
            textBoxchurukuWNO.Clear();
            textBoxchurukuPNO.Clear();
            textBoxchurukuPNO.Clear();
            textBoxchurukuONO.Clear();
        }
    }
}
