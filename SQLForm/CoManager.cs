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
    public partial class CoManager : Form
    {
        AdministratorDemo administratorDemo;
        public CoManager(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            ModifyPersonalInformation form = new ModifyPersonalInformation(this.administratorDemo);
            form.Show();
        }

        private void CoManager_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form = new Form2(this.administratorDemo);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Formchanpinbaosun form = new Formchanpinbaosun(this.administratorDemo);
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

        private void InOutWareHouse_Click(object sender, EventArgs e)
        {
            this.Close();
            Formchurukucaozuo form = new Formchurukucaozuo(this.administratorDemo);
            form.Show();
        }
    }
}
