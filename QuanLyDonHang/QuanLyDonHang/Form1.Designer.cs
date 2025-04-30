namespace QuanLyDonHang
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            panel2 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            button3 = new Button();
            panel4 = new Panel();
            comboBox1 = new ComboBox();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1063, 74);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(367, 7);
            label1.Name = "label1";
            label1.Size = new Size(352, 50);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Đơn Hàng";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(171, 49);
            button1.TabIndex = 1;
            button1.Text = "Thêm Sản Phẩm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Location = new Point(6, 138);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(294, 54);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Location = new Point(180, 3);
            button2.Name = "button2";
            button2.Size = new Size(111, 49);
            button2.TabIndex = 2;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(3, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 125);
            panel2.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(dataGridView1);
            flowLayoutPanel2.Location = new Point(3, 199);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1060, 249);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1057, 255);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Location = new Point(6, 82);
            panel3.Name = "panel3";
            panel3.Size = new Size(174, 50);
            panel3.TabIndex = 3;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(171, 47);
            button3.TabIndex = 0;
            button3.Text = "Thêm Nhóm Sản Phẩm";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBox1);
            panel4.Location = new Point(865, 82);
            panel4.Name = "panel4";
            panel4.Size = new Size(198, 35);
            panel4.TabIndex = 1;
            panel4.Paint += panel4_Paint;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 450);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "QUẢN LÝ ĐƠN HÀNG";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private DataGridView dataGridView1;
        private Panel panel3;
        private Button button3;
        private Panel panel4;
        private ComboBox comboBox1;
    }
}
