﻿namespace SQLForm
{
    partial class ProductInventoryInformation
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
            this.Pnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Pnum});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(656, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // Pnum
            // 
            this.Pnum.HeaderText = "Pnum";
            this.Pnum.MinimumWidth = 6;
            this.Pnum.Name = "Pnum";
            this.Pnum.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "导出为EXECEL表格";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ProductInventoryInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 153);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductInventoryInformation";
            this.Text = "产品库存信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pnum;
    }
}