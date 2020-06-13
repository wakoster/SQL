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
    public partial class DeleteWarehouse : Form
    {
        AdministratorDemo administratorDemo;
        public DeleteWarehouse(AdministratorDemo administratorDemo)
        {
            this.administratorDemo = administratorDemo;
            InitializeComponent();
        }

        private void DeleteWarehouse_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“deleteWarehouseData.WAREH”中。您可以根据需要移动或删除它。
            this.wAREHTableAdapter.Fill(this.deleteWarehouseData.WAREH);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            仓库管理 form3 = new 仓库管理(this.administratorDemo);
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
