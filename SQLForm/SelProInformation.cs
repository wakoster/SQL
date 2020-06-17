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
using SQLForm;

namespace SQLForm
{
    public partial class Form2 : Form
    {
        AdministratorDemo administratorDemo;
        public Form2(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.conn.Open();
            if (textBox1.Text.Equals("")&&(textBox2.Text.Equals("")))
            {
                MessageBox.Show("请输入产品编号或产品名称", "查询提示");
                Database.conn.Close();
                return;
            }
            else if(textBox1.Text != "" && (textBox2.Text.Equals("")))
            {
                string s = textBox1.Text;
                string s1 = SQL.SelectFromProductWherePno(Database.conn,s)[0];
                    if (s1 == "false")
                    {
                        textBox1.Clear();
                        MessageBox.Show("您输入的产品号不存在", "查询提示");
                        Database.conn.Close();
                        return;
                    }
                    else
                    {
                        textBox1.Clear();
                        Form3 form3 = new Form3(SQL.SelectFromProductWherePno(Database.conn, s));
                        form3.ShowDialog();
                        Database.conn.Close();

                        return;
                    }
            }
            else if (textBox1.Text.Equals("") && (textBox2.Text != ""))
            {
                
                string s = textBox2.Text;
                string s1 = SQL.SelectFromProductWherePname(Database.conn, s)[0];
                    if (s1 == "false")
                    {
                        textBox2.Clear();
                        MessageBox.Show("您输入的产品名不存在", "查询提示");
                        Database.conn.Close();

                        return;
                    }
                    else
                    {
                        textBox2.Clear();
                        Form3 form3 = new Form3(SQL.SelectFromProductWherePname(Database.conn, s));
                        form3.ShowDialog();
                        Database.conn.Close();
                        return;
                    }

            }
            Database.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.conn.Open();
            if (textBox1.Text.Equals("") && (textBox2.Text.Equals("")))
            {
                MessageBox.Show("请输入产品编号或产品名称", "查询提示");
                Database.conn.Close();
                return;
            }
            else if (textBox1.Text != "" && (textBox2.Text.Equals("")))
            {
                string s = textBox1.Text;
                string s1 = SQL.SelsctDAMAGEByPno(Database.conn, s)[0].Pno;
                if (s1 == "false")
                {
                    textBox1.Clear();
                    MessageBox.Show("您输入的产品号不存在", "查询提示");
                    Database.conn.Close();
                    return;
                }
                else
                {
                    textBox1.Clear();
                    DamagedProductInformation damagedProductInformation = new DamagedProductInformation(SQL.SelsctDAMAGEByPno(Database.conn, s)[0]);
                    damagedProductInformation.ShowDialog();
                    Database.conn.Close();

                    return;
                }
            }
            else if (textBox1.Text.Equals("") && (textBox2.Text != ""))
            {

                string s = textBox2.Text;
                string s1 = SQL.SelsctDAMAGEByPno(Database.conn, s)[0].Pno;
                if (s1 == "false")
                {
                    textBox2.Clear();
                    MessageBox.Show("请输入产品号以查询产品信息", "查询提示");
                    Database.conn.Close();

                    return;
                }
                else
                {
                    textBox2.Clear();
                    DamagedProductInformation damagedProductInformation = new DamagedProductInformation(SQL.SelsctDAMAGEByPno(Database.conn, s)[0]);
                    damagedProductInformation.ShowDialog();
                    Database.conn.Close();
                    return;
                }

            }
            Database.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.conn.Open();
            if (textBox1.Text.Equals("") && (textBox2.Text.Equals("")))
            {
                MessageBox.Show("请输入产品编号或产品名称", "查询提示");
                Database.conn.Close();
                return;
            }
            else if (textBox1.Text != "" && (textBox2.Text.Equals("")))
            {
                string s = textBox1.Text;
                string s1 = SQL.SelsctREPERTORYByPno(Database.conn, s)[0].Pno;
                if (s1 == "false")
                {
                    textBox1.Clear();
                    MessageBox.Show("您输入的产品号不存在", "查询提示");
                    Database.conn.Close();
                    return;
                }
                else
                {
                    textBox1.Clear();
                    ProductInventoryInformation productInventoryInformation = new ProductInventoryInformation(SQL.SelsctREPERTORYByPno(Database.conn, s)[0]);
                    productInventoryInformation.ShowDialog();
                    Database.conn.Close();

                    return;
                }
            }
            else if (textBox1.Text.Equals("") && (textBox2.Text != ""))
            {

                string s = textBox2.Text;
                string s1 = SQL.SelsctREPERTORYByPno(Database.conn, s)[0].Pno;
                if (s1 == "false")
                {
                    textBox2.Clear();
                    MessageBox.Show("请输入产品号以查询产品库存信息", "查询提示");
                    Database.conn.Close();

                    return;
                }
                else
                {
                    textBox2.Clear();
                    ProductInventoryInformation productInventoryInformation = new ProductInventoryInformation(SQL.SelsctREPERTORYByPno(Database.conn, s)[0]);
                    productInventoryInformation.ShowDialog();
                    Database.conn.Close();
                    return;
                }

            }
            Database.conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            if(this.administratorDemo.Jno == 1)
            {
                最高管理员 form = new 最高管理员(this.administratorDemo);
                form.Show();
            }
            else if(this.administratorDemo.Jno == 2)
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
    }
}
