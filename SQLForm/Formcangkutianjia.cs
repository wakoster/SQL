using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//张永轩测试上传1
namespace SQLForm
{
    public partial class Formcangkutianjia : Form
    {

        AdministratorDemo administratorDemo;
        public Formcangkutianjia(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            仓库管理 form = new 仓库管理(this.administratorDemo);
            form.Show();
        }

        private void comboBoxspbh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
