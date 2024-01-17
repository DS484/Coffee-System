using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LastProjectOOP.Model;
using LastProjectOOP.Suport;

namespace LastProjectOOP
{
    public partial class frmStaffTable : Form
    {
        /// <summary>
        /// Manager quản lý các hoạt động thêm xóa sủa nhân viên
        /// </summary>
        private Manager manager = new Manager();
        List<string> listUserName = new List<string>();

        // Lưu tên UserName, Phone, Email trước khi update
        private string tmpUserName = "";
        private string tmpPhone = "";
        private string tmpEmail = "";

        public frmStaffTable()
        {
            InitializeComponent();
        }



        #region Phần thừa
        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        private void frmStaffTable_Load(object sender, EventArgs e)
        {
            LoadDataStaff();
            foreach (DataGridViewRow row in dgvStaff.Rows)
            {
                // Kiểm tra nếu username, phone, email chưa có
                if (row.Cells[6].Value != null && row.Cells[0].Value != null && row.Cells[1].Value != null
                    && !listUserName.Contains(row.Cells[6].Value.ToString().Trim())
                    && !listUserName.Contains(row.Cells[0].Value.ToString().Trim())
                    && !listUserName.Contains(row.Cells[1].Value.ToString().Trim()) )
                {
                    string tmp1 = row.Cells[6].Value.ToString().Trim();
                    string tmp2 = row.Cells[0].Value.ToString().Trim();
                    string tmp3 = row.Cells[1].Value.ToString().Trim();
                    listUserName.Add(tmp1);
                    listUserName.Add(tmp2);
                    listUserName.Add(tmp3);
                }
                else
                {
                    MessageBox.Show("Infomation is already exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void LoadDataStaff()
        {
            DataTable table = Data.LoadStaff();
            dgvStaff.DataSource = table;
            dgvStaff.ClearSelection();
        }

        // Hàm kiểm tra đầu vào
        private bool CheckUser()
        {
            if (!DataInputCheck.CheckInputName(txtName.Text))
            {
                MessageBox.Show("The name is empty or invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputPhoneNumber(txtPhone.Text.Trim()))
            {
                MessageBox.Show("The phone is empty or invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email is empty or invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputAdress(txtAddress.Text))
            {
                MessageBox.Show("Address is empty or invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputBirthday(txtBirthday.Text))
            {
                MessageBox.Show("Birthday is empty or invalid.\nThe format is MM/dd/yyyy", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBirthday.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Hàm reset lại thông tin trong các textbox
        /// </summary>
        private void ResetTexbox()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtBirthday.Text = "";
            txtPass.Text = "";
            txtUserName.Text = "";

        }

        /// <summary>
        /// Thêm một nhân viên vào danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckUser())
            {
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string name = txtName.Text;
                //DateTime birthday;
                //if(DateTime.TryParseExact(txtBirthday.Text, "MM/dd/yyyy",
                //    CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday)) { }
                DateTime birthday = Convert.ToDateTime(txtBirthday.Text);
                string address = txtAddress.Text;
                string userName = txtUserName.Text;
                string pass = txtPass.Text;

                manager = new Manager();
                if (!listUserName.Contains(userName.Trim()) && !listUserName.Contains(phone.Trim())
                    && !listUserName.Contains(email.Trim()))
                {
                    manager.AddBarista(phone, email, name, address, birthday, pass, userName);

                    // Cập nhật thông báo
                    MessageBox.Show(@"Staff " + name + " is added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại các ô textbox
                    ResetTexbox();

                    // Load lại data
                    LoadDataStaff();
                }
                else
                {
                    MessageBox.Show("Infomation is already exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Thay đổi thông tin nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            listUserName.Remove(tmpUserName);
            listUserName.Remove(tmpEmail);
            listUserName.Remove(tmpPhone);
            if (dgvStaff.SelectedRows.Count > 0)
            {
                if (CheckUser())
                {
                    int baristaId = 0;
                    string query = "SELECT BaristaId FROM Barista WHERE Name = '" + txtName.Text + "'";

                    SqlConnection connection = new SqlConnection(Data.connect);
                    SqlCommand cmd = new SqlCommand(query, connection);


                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                baristaId = Convert.ToInt32(reader["BaristaId"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                    string phone = txtPhone.Text;
                    string email = txtEmail.Text;
                    string name = txtName.Text;
                    string address = txtAddress.Text;
                    //DateTime birthday;
                    //if (DateTime.TryParseExact(txtBirthday.Text, "MM/dd/yyyy",
                    //    CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday)) { }
                    DateTime birthday = Convert.ToDateTime(txtBirthday.Text);
                    string pass = txtPass.Text;
                    string userName = txtUserName.Text;

                    if (!listUserName.Contains(userName.Trim()) && !listUserName.Contains(phone.Trim())
                        && !listUserName.Contains(email.Trim()))
                    {
                        manager.ChangeBarista(baristaId, phone, email, name, address, birthday, pass, userName);

                        // Cập nhật thông báo
                        MessageBox.Show("Infomation is changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listUserName.Add(userName.Trim());
                        listUserName.Add(phone.Trim());
                        listUserName.Add(email.Trim());

                        // Cập nhật lại các ô textbox
                        ResetTexbox();

                        // Cập nhật thông tin trên các dòng
                        dgvStaff.SelectedRows[0].Cells["Phone"].Value = phone;
                        dgvStaff.SelectedRows[0].Cells["Email"].Value = email;
                        dgvStaff.SelectedRows[0].Cells["Name"].Value = name;
                        dgvStaff.SelectedRows[0].Cells["Address"].Value = address;
                        dgvStaff.SelectedRows[0].Cells["Birthday"].Value = birthday;
                        dgvStaff.SelectedRows[0].Cells["Pass"].Value = pass;
                        dgvStaff.SelectedRows[0].Cells["UserName"].Value = userName;
                    }
                    else
                    {
                        listUserName.Add(tmpEmail);
                        listUserName.Add(tmpPhone);
                        listUserName.Add(tmpEmail);
                        MessageBox.Show("This UserName is already exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Changed information is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Xóa đii một nhân viên trong danh sách database
        /// Note: Chỉ xóa được các sản phẩm chưa được Order trong lịch sử quán. Hạn chế tối đa việc xóa các sản phẩm
        /// đã có trong các đơn đã Order vì đã có sự liên kết giữa các bảng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            listUserName.Remove(txtUserName.Text.Trim());
            listUserName.Remove(txtPhone.Text.Trim());
            listUserName.Remove(txtEmail.Text.Trim());
            if (dgvStaff.SelectedRows.Count > 0)
            {
                // Thực hiện truy vấn để lấy được Id và thực hiện xóa
                string query = "SELECT BaristaId FROM Barista WHERE Name = '" + txtName.Text + "'";
                int baristaId = 0;

                SqlConnection connection = new SqlConnection(Data.connect);
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            baristaId = Convert.ToInt32(reader["BaristaId"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                manager.DeleteBarista(baristaId);

                // Xóa hàng trong danh sách
                // dgvStaff.Rows.RemoveAt(dgvStaff.SelectedRows[0].Index);

                // Load lại dữ liệu
                LoadDataStaff();

                // Cập nhật lại các ô textbox
                ResetTexbox();
            }
            else
            {
                MessageBox.Show("Remove staff is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Reload lại thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblReset_Click(object sender, EventArgs e)
        {
            dgvStaff.DataSource = null;
            dgvStaff.Rows.Clear();
            LoadDataStaff();
        }

        /// <summary>
        /// Sự kiện click vào mỗi đối tượng trong nhân viên trong bảng sẽ hiện ra textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Staff_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = new DataGridViewRow();
            row = dgvStaff.Rows[e.RowIndex];
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value).Trim();
            txtName.Text = Convert.ToString(row.Cells["Name"].Value).Trim();

            string temp = Convert.ToString(row.Cells["Birthday"].Value).Trim();
            var parts = temp.Split(' ');
            txtBirthday.Text = parts[0];

            txtAddress.Text = row.Cells["Address"].Value.ToString().Trim();
            txtPhone.Text = Convert.ToString(row.Cells["Phone"].Value).Trim();

            txtPass.Text = Convert.ToString(row.Cells["Pass"].Value).Trim();
            txtUserName.Text = Convert.ToString(row.Cells["UserName"].Value).Trim();

            tmpUserName = txtUserName.Text;
            tmpEmail = txtEmail.Text;
            tmpPhone = txtPhone.Text;
            // MessageBox.Show($"{row.Cells["Email"].Value.ToString()} \n {(row.Cells["Email"].Value.ToString().Length)}");
        }

        /// <summary>
        /// Thoát form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
