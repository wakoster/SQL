namespace SQLForm
{
    partial class DamagedProductInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pno,
            this.Wno,
            this.Bnum});
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(656, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Pno
            // 
            this.Pno.HeaderText = "Pno";
            this.Pno.MinimumWidth = 6;
            this.Pno.Name = "Pno";
            this.Pno.ReadOnly = true;
            // 
            // Wno
            // 
            this.Wno.HeaderText = "Wno";
            this.Wno.MinimumWidth = 6;
            this.Wno.Name = "Wno";
            this.Wno.ReadOnly = true;
            // 
            // Bnum
            // 
            this.Bnum.HeaderText = "Bnum";
            this.Bnum.MinimumWidth = 6;
            this.Bnum.Name = "Bnum";
            this.Bnum.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "导出为EXECEL表格";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DamagedProductInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 142);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DamagedProductInformation";
            this.Text = "损坏产品信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bnum;
        private System.Windows.Forms.Button button1;
    }
}