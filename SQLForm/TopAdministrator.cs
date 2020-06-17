using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLForm
{
    public partial class 最高管理员 : Form
    {
        AdministratorDemo administratorDemo;
        public 最高管理员(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            label1.Text = "最高管理员：" + administratorDemo.Aname;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Administrator from = new Administrator(this.administratorDemo);
            from.Show();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            //this.Dispose();
            this.Close();
            仓库管理 form2 = new 仓库管理(this.administratorDemo);
            form2.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form = new Form2(this.administratorDemo);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login form = new Login();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Formchurukuchaxun form = new Formchurukuchaxun(this.administratorDemo);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            ModifyPersonalInformation form = new ModifyPersonalInformation(this.administratorDemo);
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
