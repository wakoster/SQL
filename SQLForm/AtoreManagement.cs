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
    public partial class 仓库管理 : Form
    {

        AdministratorDemo administratorDemo;
        public 仓库管理(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void 仓库管理_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Formcangkutianjia form = new Formcangkutianjia(this.administratorDemo);
            form.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            最高管理员 form1 = new 最高管理员(this.administratorDemo);
            form1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            仓库查询 form3 = new 仓库查询(this.administratorDemo);
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            DeleteWarehouse form3 = new DeleteWarehouse(this.administratorDemo);
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            UpWaHouseInfor form3 = new UpWaHouseInfor(this.administratorDemo);
            form3.Show();
        }
    }
}
