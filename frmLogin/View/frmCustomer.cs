using frmLogin;
using iTextSharp.text.pdf.codec;
using iTextSharp.xmp.impl;
using LastProjectOOP.Model;
using LastProjectOOP.Suport;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace LastProjectOOP
{
    public partial class frmCustomer : Form
    {
        /// <summary>
        /// Tạo để manager có thể thao tác với dữ liệu khi người dùng tiến hành đặt hành
        /// </summary>
        private Manager manager;

        /// <summary>
        /// Gán tên
        /// </summary>
        private string tmp = "";

        /// <summary>
        /// Truyền qua formSignin, sau đó từ fromSign in truyền qua Barista với mục đích là để barista biết được
        /// đơn hàng do khách hàng nào đặt
        /// </summary>
        private int customerId = 0;

        /// <summary>
        /// Cờ kiểm tra xem khách hàng đã thanh toán hay chưa, nếu chưa thì khi bấm Done thì sẽ in ra thông báo lỗi
        /// </summary>
        private bool flagPayBill = false;

        // Tạo mới một khách hàng để tương tác với form
        private Customer customer = new Customer();

        public frmCustomer()
        {
            InitializeComponent();
        }

        public frmCustomer(string name, int id)
        {
            InitializeComponent();
            tmp = name;
            customerId = id;
        }

        /// <summary>
        /// Sự kiện load form khi form được khởi chạy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            lbHi.Text = "Hi " + tmp + ", what do you want to order";
            LoadDataCoffee();
            txtTotal.Text = "0";
            txtTotalOrder.Text = "0";
        }

        private void LoadDataCoffee()
        {
            Inventory data = new Inventory();
            DataTable table = data.LoadCoffee();
            dgvMenu.DataSource = table;
            dgvMenu.ClearSelection();
        }

        /// <summary>
        /// Sự kiện click vào thông tin trong một menu thì các thông tin trên dòng đó được đẩy ra textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvMenu.Rows[e.RowIndex];
            txtName.Text = Convert.ToString(row.Cells["Name"].Value);
            txtPrice.Text = Convert.ToString(row.Cells["Price"].Value);

            // Cho name và price thành chỉ đọc khi click vào sản phẩm 
            txtName.ReadOnly = true;
            txtPrice.ReadOnly = true;
        }

        /// <summary>
        /// Trường hợp này tìm kiếm theo loại -> flag ở đây là -1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbList.SelectedItem.ToString() == "Tea")
            {
                DataTable dt = customer.FindManyCases("Tea", -1);
                dgvMenu.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Soda")
            {
                DataTable dt = customer.FindManyCases("Soda", -1);
                dgvMenu.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Juice")
            {
                DataTable dt = customer.FindManyCases("Juice", -1);
                dgvMenu.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Smoothie")
            {
                DataTable dt = customer.FindManyCases("Smoothie", -1);
                dgvMenu.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Coffee")
            {
                DataTable dt = customer.FindManyCases("Coffee", -1);
                dgvMenu.DataSource = dt;
            }
            else if (cbList.SelectedItem.ToString() == "Cacao")
            {
                DataTable dt = customer.FindManyCases("Cacao", -1);
                dgvMenu.DataSource = dt;
            }
            dgvMenu.ClearSelection();
        }


        /// <summary>
        /// Tìm kiếm theo tên (flag là 0) hoặc theo giá (flag là 1)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (DataInputCheck.CheckInputName(txtName.Text))
            {
                dt = customer.FindManyCases(txtName.Text, 0);
            }
            else if (DataInputCheck.CheckInputPrice(txtPrice.Text))
            {
                dt = customer.FindManyCases(txtPrice.Text, 1);
            }

            dgvMenu.DataSource = dt;
        }

        /// <summary>
        /// Thực hiện load lại dữ liệu món uống trong quán ở tất cả các mặt thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblReset_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = null;
            dgvMenu.Rows.Clear();

            LoadDataCoffee();
        }
        #region
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// Nút thêm món nước muốn mua vào bảng Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtpDate.Enabled = false;
            txtName.ReadOnly = false;
            txtPrice.ReadOnly = false;
            if (!DataInputCheck.CheckInputTextbox(txtName.Text))
            {
                MessageBox.Show("The name of item is not fill", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (!DataInputCheck.CheckInputTextbox(txtPrice.Text))
            {
                MessageBox.Show("The price of item is not fill", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
            }
            else if (!DataInputCheck.CheckInputTextbox(txtQuantity.Text))
            {
                MessageBox.Show("The quantity of item is not fill", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
            }
            else
            {
                int flag = 0, quantity = 0, coffeeId = 0;
                string number = txtQuantity.Text;
                for (int i = 0; i < dgvMenu.Rows.Count; i++)
                {
                    if (dgvMenu.Rows[i].Cells[0].Value != null && dgvMenu.Rows[i].Cells[1].Value != null)
                    {
                        if (txtName.Text == dgvMenu.Rows[i].Cells[0].Value.ToString())
                        {
                            Inventory data = new Inventory();
                            coffeeId = data.FindIdCoffee(txtName.Text);
                            quantity = (Convert.ToInt32(dgvMenu.Rows[i].Cells[1].Value.ToString()) - Convert.ToInt32(txtQuantity.Text));
                            if (quantity < 0)
                            {
                                MessageBox.Show(dgvMenu.Rows[i].Cells[0].Value.ToString() + "is not enough quantity!Please order another item or decrease quantity...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                flag = 1;
                            }
                        }
                    }
                }
                if (flag == 0)
                {
                    DateTime date = Convert.ToDateTime(dtpDate.Value);
                    dgvOrder.Rows.Add(txtName.Text, number.ToString(), txtPrice.Text, txtTotal.Text, dtpDate.Text, txtStatus.Text);

                    // Khi đặt thì số lượng hàng bị giảm -> Cần manager thao tác với databae
                    manager = new Manager();
                    manager.UpdateItem(coffeeId, txtName.Text, quantity, Convert.ToInt32(txtPrice.Text));


                    int orderid = Data.AddOrder(customerId, date);
                    Data.AddOrderDetail(orderid, coffeeId, Convert.ToInt32(number), txtStatus.Text);

                    // Cập nhật lại số lượng cho bảng menu 
                    DataGridViewRow row = dgvMenu.SelectedRows[0];
                    row.Cells["Quantity"].Value = quantity;

                    // Tính tổng tiền Order 
                    txtTotalOrder.Text = (Convert.ToInt32(txtTotalOrder.Text) +
                        Convert.ToInt32(txtTotal.Text)).ToString();

                }

                // Thông báo tới người dùng đơn vừa Order: Thể hiện Overloading ở class Customer
                if (DataInputCheck.CheckInputTextbox(txtStatus.Text))
                {
                    MessageBox.Show(customer.OrderCoffee(txtName.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtQuantity.Text),
                        txtStatus.Text), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(customer.OrderCoffee(txtName.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtQuantity.Text)),
                        "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Khởi động lại giá trị cho các textbox thông tin
                txtName.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";
                txtTotal.Text = "0";
                txtStatus.Text = "";
            }
        }

        /// <summary>
        /// Sự kiện tính tổng số tiền của món uống cho textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantity.Text.Length > 0)
                {
                    txtTotal.Text = (Convert.ToInt64(txtPrice.Text) *
                        Convert.ToInt64(txtQuantity.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose drink first or enter number for quantity!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Text = "";
                txtQuantity.Focus();
            }
        }

        #region
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// Nút thanh toán tiền mua nước uống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaybill_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTotalOrder.Text) > 0)
            {
                if (!DataInputCheck.CheckInputPrice(txtPayAmount.Text))
                {
                    MessageBox.Show("Invalid payment amount (other characters exist than numbers)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    flagPayBill = customer.PayyBill(txtPayAmount, txtTotalOrder, dgvOrder);
                }
            }
            else
            {
                MessageBox.Show("Please select at least one item to pay", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Xác nhận đơn hàng đã thanh toán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDone1_Click(object sender, EventArgs e)
        {
            if (!flagPayBill)
            {
                MessageBox.Show("Please order first!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Bật cờ để cho biết rằng có đơn hàng đang đợi, chưa có Barista nào nhận. Khi cờ = 1 thì 
                // đã có đơn, các khách hàng khác chưa được Order
                Data.orderFlag = 1;

                // Khi thanh toán thì txtTotalOrder sẽ về 0 
                if (txtTotalOrder.Text != "0")
                {
                    MessageBox.Show("Please pay the order first!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Ẩn form và gọi ra Barsis ta để kiêmr tra bill 
                    MessageBox.Show("Your order is preparing by Barista", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();


                    frmSignin frmSignin = new frmSignin(customerId);
                    frmSignin.ShowDialog();
                }
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            string name = "";
            string phone = "";
            string email = "";
            string address = "";
            DateTime birthday = DateTime.Now;

            string query = "SELECT * FROM Customer WHERE CustomerId = @id";
            SqlConnection connection = new SqlConnection(Data.connect);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", customerId);

            connection.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    name = reader["Name"].ToString();
                    phone = reader["Phone"].ToString();
                    email = reader["Email"].ToString();
                    birthday = Convert.ToDateTime(reader["Birthday"]);
                    address = reader["Address"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            string birthdayFormat = birthday.ToString("dd/MM/yyyy");
            Customer customer = new Customer(name, phone, email, birthdayFormat, address);
            MessageBox.Show(customer.PrintInfo(), "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtStatus.Text = "";
            txtTotal.Text = "";
            txtName.ReadOnly = false;
            txtPrice.ReadOnly = false;
        }
    }
}
