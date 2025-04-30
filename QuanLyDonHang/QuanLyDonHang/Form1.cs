using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDonHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            SetupDataGridView();
            
            LoadCategories();
            LoadProducts();
        }

        private void dataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maProduct = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaProduct"].Value);


                using (var updateForm = new UpdateProduct(maProduct))
                {
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
        }

        

        private void SetupDataGridView()
        {
            // Cấu hình DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            var deleteCheckBoxColumn = new DataGridViewCheckBoxColumn();
            deleteCheckBoxColumn.Name = "deleteGroup";
            deleteCheckBoxColumn.HeaderText = "Xoa nhieu hang";
            dataGridView1.Columns.Add(deleteCheckBoxColumn);

            // Thêm các cột
            dataGridView1.Columns.Add("MaProduct", "Mã SP");
            dataGridView1.Columns.Add("Name", "Tên SP");
            dataGridView1.Columns.Add("Price", "Giá");
            dataGridView1.Columns.Add("Quantity", "Số lượng");
            dataGridView1.Columns.Add("Description", "Mô tả");
            dataGridView1.Columns.Add("CategoryName", "Danh mục");
            
            // Cấu hình thuộc tính cho các cột
            dataGridView1.Columns["MaProduct"].DataPropertyName = "MaProduct";
            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Price"].DataPropertyName = "Price";
            dataGridView1.Columns["Quantity"].DataPropertyName = "Quantity";
            dataGridView1.Columns["Description"].DataPropertyName = "Description";
            dataGridView1.Columns["CategoryName"].DataPropertyName = "CategoryName";

            // Định dạng cột giá
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "N0";
            //Theem nut sua vao cot action
            var editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Action";
            editButtonColumn.HeaderText = "Hành động";
            editButtonColumn.Text = "Sửa";         
            editButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editButtonColumn);
            //Them nut checkBox 


        }

        private void LoadCategories()
        {
            try
            {
                string query = "SELECT MaCategory, Name FROM Category";
                DataTable dt = DatabaseConnection.Instance.ExecuteQuery(query);

                // Thêm một item "Tất cả" vào đầu danh sách
                DataRow allRow = dt.NewRow();
                allRow["MaCategory"] = DBNull.Value;
                allRow["Name"] = "Tất cả";
                dt.Rows.InsertAt(allRow, 0);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "MaCategory";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts(string categoryId = null)
        {
            try
            {
                string query;
                SqlParameter[] parameters;

                if (!string.IsNullOrEmpty(categoryId))
                {
                    query = @"SELECT p.*, c.Name as CategoryName 
                             FROM Product p 
                             LEFT JOIN Category c ON p.MaCategory = c.MaCategory 
                             WHERE p.MaCategory = @CategoryId";
                    parameters = new[] {
                        new SqlParameter
                        {
                            ParameterName = "@CategoryId",
                            Value = categoryId
                        }
                    };
                }
                else
                {
                    query = @"SELECT p.*, c.Name as CategoryName 
                             FROM Product p 
                             LEFT JOIN Category c ON p.MaCategory = c.MaCategory";
                    parameters = null;
                }

                DataTable dt = parameters != null
                    ? DatabaseConnection.Instance.ExecuteQuery(query, parameters)
                    : DatabaseConnection.Instance.ExecuteQuery(query);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedValue;
            if (selected == DBNull.Value || selected == null)
            {
                LoadProducts();
            }
            else
            {
                // Nếu là DataRowView thì lấy đúng giá trị MaCategory
                string categoryId = selected is System.Data.DataRowView drv ? drv["MaCategory"].ToString() : selected.ToString();
                LoadProducts(categoryId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Thêm sản phẩm mới
            using (var addForm = new AddProduct())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Tìm các dòng có CheckBox được chọn
            var selectedProductIds = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var isChecked = row.Cells["deleteGroup"].Value != null && (bool)row.Cells["deleteGroup"].Value;
                if (isChecked)
                {
                    int maProduct = Convert.ToInt32(row.Cells["MaProduct"].Value);
                    selectedProductIds.Add(maProduct);
                }
            }

            if (selectedProductIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Bạn có chắc muốn xóa {selectedProductIds.Count} sản phẩm?", "Xác nhận xóa",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (var maProduct in selectedProductIds)
                    {
                        string query = "DELETE FROM Product WHERE MaProduct = @MaProduct";
                        SqlParameter[] parameters = {
                    new SqlParameter
                    {
                        ParameterName = "@MaProduct",
                        Value = maProduct
                    }
                };
                        DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
                    }

                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Thêm danh mục mới
            using (var addCategoryForm = new AddCategory())
            {
                if (addCategoryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
        }

        

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
