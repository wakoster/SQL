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
    public partial class ProductInventoryInformation : Form
    {
        List<REPERTORYInformation> newList = new List<REPERTORYInformation>();
        public ProductInventoryInformation(REPERTORYInformation A)
        {
            InitializeComponent();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = A.Pno;
            dataGridView1.Rows[0].Cells[1].Value = A.Wno;
            dataGridView1.Rows[0].Cells[2].Value = A.number;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
