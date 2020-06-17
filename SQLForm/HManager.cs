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
    public partial class Form1 : Form
    {

        AdministratorDemo administratorDemo;
        public Form1(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
            textBox1.Text = administratorDemo.Aname;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this.administratorDemo);
            this.Hide();
            if (form2.ShowDialog() == DialogResult.OK)
            { 
                this.Show(); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Formchurukucaozuo form = new Formchurukucaozuo(this.administratorDemo);
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            ModifyPersonalInformation form = new ModifyPersonalInformation(this.administratorDemo);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Administrator form = new Administrator(this.administratorDemo);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            仓库查询 form2 = new 仓库查询(this.administratorDemo);
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Formchurukuchaxun form2 = new Formchurukuchaxun(this.administratorDemo);
            form2.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Formchanpincaozuo form2 = new Formchanpincaozuo(this.administratorDemo);
            form2.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Formchanpinbaosun form2 = new Formchanpinbaosun(this.administratorDemo);
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = administratorDemo.Ano;
        }
    }
}
