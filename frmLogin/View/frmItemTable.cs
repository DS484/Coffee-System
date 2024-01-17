using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using LastProjectOOP.Model;
using LastProjectOOP.Suport;

namespace LastProjectOOP
{
    public partial class frmItemTable : Form
    {
        private Manager manager = new Manager();
        List<string> listNameCoffee = new List<string>();
        private string tmpName = "";

        public frmItemTable()
        {
            InitializeComponent();
        }
        private void frmItemTable_Load(object sender, EventArgs e)
        {
            LoadDataCoffee();
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                // Kiểm tra nếu tên món chưa có trong menu
                if (row.Cells[0].Value != null && !listNameCoffee.Contains(row.Cells[0].Value.ToString()))
                {
                    listNameCoffee.Add(row.Cells[0].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Menu has " + row.Cells[0].Value.ToString() + " so it should be removed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        #region
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// Lấy dữ liệu từ database thông qua LoadCoffee trong Inventory
        /// </summary>
        private void LoadDataCoffee()
        {
            Inventory loadData = new Inventory();
            DataTable table = loadData.LoadCoffee();
            dgvItem.DataSource = table;
            dgvItem.ClearSelection();
        }



        // Hàm kiểm tra các textbox của item
        private bool CheckItem()
        {
            if (!DataInputCheck.CheckInputName(txtName.Text))
            {
                MessageBox.Show("Name of item is empty or this is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputPrice(txtPrice.Text))
            {
                MessageBox.Show("Price of item is empty or this is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputPrice(txtQuantity.Text))
            {
                MessageBox.Show("Quantity of item is empty or this is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Reset lại các textbox
        /// </summary>
        private void ResetTextbox()
        {
            txtPrice.Text = "";
            txtName.Text = "";
            txtQuantity.Text = "";
        }


        /// <summary>
        /// Nút thêm sản phẩm mới vào danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckItem())
            {
                string name = txtName.Text;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                int price = Convert.ToInt32(txtPrice.Text);

                if (!listNameCoffee.Contains(name))
                {
                    manager.AddItem(name, quantity, price);

                    // Load lại data
                    LoadDataCoffee();

                    // Thông báo thêm thành công
                    MessageBox.Show(name + " is added into list items", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset lại txt
                    ResetTextbox();
                }
                else
                {
                    MessageBox.Show("Menu has this drink!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Nút update lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            listNameCoffee.Remove(tmpName);
            if (dgvItem.SelectedRows.Count > 0)
            {
                // Kiểm tra update sản phẩm phải đầy đủ thông tin update
                if (CheckItem())
                {
                    // Thực hiện truy vấn lấy id của item cần thay đổi thông tin
                    int coffeeId = 0;
                    string query = "SELECT CoffeeId FROM Coffee WHERE Name = '" + txtName.Text + "'";

                    SqlConnection connection = new SqlConnection(Data.connect);
                    SqlCommand cmd = new SqlCommand(query, connection);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                coffeeId = Convert.ToInt32(reader["CoffeeId"]);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                    string name = txtName.Text;
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    double price = Convert.ToDouble(txtPrice.Text);

                    if (!listNameCoffee.Contains(name))
                    {
                        manager.UpdateItem(coffeeId, name, quantity, price);

                        // Cập nhật dòng được chọn trong DataGridView với các giá trị mới
                        DataGridViewRow row = dgvItem.SelectedRows[0];
                        row.Cells["Name"].Value = name;
                        row.Cells["Quantity"].Value = quantity;
                        row.Cells["Price"].Value = price;

                        // Thông báo thay đổi thành công thông tin item
                        MessageBox.Show("The item is changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listNameCoffee.Add(name);
                        // Reset lại txt
                        ResetTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Menu has this drink!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Changed information is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Nút xóa thông tin một sản phẩm
        /// Note: Chỉ xóa được các sản phẩm chưa được Order trong lịch sử quán. Hạn chế tối đa việc xóa các sản phẩm
        /// đã có trong các đơn đã Order vì đã có sự liên kết giữa các bảng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count > 0)
            {
                int coffeeId = 0;
                listNameCoffee.Remove(txtName.Text);
                string query = "SELECT CoffeeId FROM Coffee WHERE Name = '" + txtName.Text + "'";

                SqlConnection connection = new SqlConnection(Data.connect);
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            coffeeId = Convert.ToInt32(reader["CoffeeId"]);
                        }
                    }
                    // MessageBox.Show(coffeeId.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                manager.DeleteItem(coffeeId);

                // Thông báo đã xóa thành công
                //MessageBox.Show("Remove complete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dòng từ DataGridView
                // dgvItem.Rows.RemoveAt(dgvItem.SelectedCells[0].RowIndex);

                // Reset lại bảng
                LoadDataCoffee();

                // Reset lại txt
                ResetTextbox();
            }
            else
            {
                MessageBox.Show("Remove item is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvItem.Rows[e.RowIndex];
            txtName.Text = Convert.ToString(row.Cells["Name"].Value);
            txtPrice.Text = Convert.ToString(row.Cells["Price"].Value);
            txtQuantity.Text = Convert.ToString(row.Cells["Quantity"].Value);

            tmpName = txtName.Text;
        }

        private DataTable FindTypeCoffee(string s)
        {
            string query = $"SELECT Name, Quantity, Price FROM Coffee WHERE {"Name"} LIKE '%" + s + "%'";
            Inventory data = new Inventory();
            DataTable table = data.FindCoffee(query);
            return table;
        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbList.SelectedItem.ToString() == "Tea")
            {
                DataTable dt = FindTypeCoffee("Tea");
                dgvItem.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Soda")
            {
                DataTable dt = FindTypeCoffee("Soda");
                dgvItem.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Juice")
            {
                DataTable dt = FindTypeCoffee("Juice");
                dgvItem.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Smoothie")
            {
                DataTable dt = FindTypeCoffee("Smoothie");
                dgvItem.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Coffee")
            {
                DataTable dt = FindTypeCoffee("Coffee");
                dgvItem.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Cacao")
            {
                DataTable dt = FindTypeCoffee("Cacao");
                dgvItem.DataSource = dt;
            }
            dgvItem.ClearSelection();
        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            dgvItem.DataSource = null;
            dgvItem.Rows.Clear();

            LoadDataCoffee();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
