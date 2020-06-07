namespace SQLForm
{
    partial class CoManager
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.InOutWareHouse = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 25);
            this.textBox1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "普通管理员：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 30F);
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 50);
            this.label1.TabIndex = 16;
            this.label1.Text = "仓库管理系统";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(452, 293);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(295, 52);
            this.button6.TabIndex = 15;
            this.button6.Text = "个人信息";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(452, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(295, 52);
            this.button5.TabIndex = 14;
            this.button5.Text = "进出库记录查询";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // InOutWareHouse
            // 
            this.InOutWareHouse.Location = new System.Drawing.Point(59, 293);
            this.InOutWareHouse.Name = "InOutWareHouse";
            this.InOutWareHouse.Size = new System.Drawing.Size(295, 52);
            this.InOutWareHouse.TabIndex = 12;
            this.InOutWareHouse.Text = "出入库操作";
            this.InOutWareHouse.UseVisualStyleBackColor = true;
            this.InOutWareHouse.Click += new System.EventHandler(this.InOutWareHouse_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(295, 52);
            this.button2.TabIndex = 11;
            this.button2.Text = "查看仓库信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 52);
            this.button1.TabIndex = 10;
            this.button1.Text = "产品查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(452, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(295, 52);
            this.button3.TabIndex = 19;
            this.button3.Text = "产品报损";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CoManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 371);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.InOutWareHouse);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "CoManager";
            this.Text = "普通管理员";
            this.Load += new System.EventHandler(this.CoManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button InOutWareHouse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}