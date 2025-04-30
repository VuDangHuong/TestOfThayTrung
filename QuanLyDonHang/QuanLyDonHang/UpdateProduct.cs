using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDonHang
{
    public partial class UpdateProduct : Form
    {
        private int maProduct;

        public UpdateProduct(int maProduct)
        {
            this.maProduct = maProduct;
            InitializeComponent();
            LoadCategories();
            LoadProductData();
        }


        

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtDescription = new TextBox();
            cboCategory = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên SP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 63);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 1;
            label2.Text = "Giá bán:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 103);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "Số lượng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 143);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 3;
            label4.Text = "Mô tả:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 183);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 4;
            label5.Text = "Nhóm sản phẩm:";
            // 
            // txtName
            // 
            txtName.Location = new Point(143, 18);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(265, 27);
            txtName.TabIndex = 5;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(143, 58);
            txtPrice.Margin = new Padding(4, 5, 4, 5);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(265, 27);
            txtPrice.TabIndex = 6;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(143, 98);
            txtQuantity.Margin = new Padding(4, 5, 4, 5);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(265, 27);
            txtQuantity.TabIndex = 7;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(143, 138);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(265, 27);
            txtDescription.TabIndex = 8;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(143, 178);
            cboCategory.Margin = new Padding(4, 5, 4, 5);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(265, 28);
            cboCategory.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(143, 220);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 10;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(309, 220);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // UpdateProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 274);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cboCategory);
            Controls.Add(txtDescription);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateProduct";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cập nhật sản phẩm";
            Load += UpdateProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private int maProduct1;

        private void LoadCategories()
        {
            try
            {
                string query = "SELECT MaCategory, Name FROM Category";
                DataTable dt = DatabaseConnection.Instance.ExecuteQuery(query);

                cboCategory.DataSource = dt;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "MaCategory";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            try
            {
                string query = "SELECT * FROM Product WHERE MaProduct = @MaProduct";
                SqlParameter[] parameters = {
                    new SqlParameter
                    {
                        ParameterName = "@MaProduct",
                        Value = maProduct
                    }
                };

                DataTable dt = DatabaseConnection.Instance.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["Name"].ToString();
                    txtPrice.Text = row["Price"].ToString();
                    txtQuantity.Text = row["Quantity"].ToString();
                    txtDescription.Text = row["Description"].ToString();
                    cboCategory.SelectedValue = row["MaCategory"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE Product 
                               SET Name = @Name, 
                                   Price = @Price, 
                                   Quantity = @Quantity, 
                                   Description = @Description, 
                                   MaCategory = @MaCategory 
                               WHERE MaProduct = @MaProduct";

                SqlParameter[] parameters = {
                    new SqlParameter
                    {
                        ParameterName = "@Name",
                        Value = txtName.Text
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Price",
                        Value = price
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Quantity",
                        Value = quantity
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Description",
                        Value = txtDescription.Text
                    },
                    new SqlParameter
                    {
                        ParameterName = "@MaCategory",
                        Value = cboCategory.SelectedValue
                    },
                    new SqlParameter
                    {
                        ParameterName = "@MaProduct",
                        Value = maProduct
                    }
                };

                DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {

        }
    }
} 