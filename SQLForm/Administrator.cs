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
    public partial class Administrator : Form
    {
        AdministratorDemo administratorDemo;
        public Administrator(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“administratorData.Administrator”中。您可以根据需要移动或删除它。
            this.administratorTableAdapter.Fill(this.administratorData.Administrator);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
