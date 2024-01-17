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
using frmLogin;
using LastProjectOOP.Model;
using LastProjectOOP.Suport;

namespace LastProjectOOP
{
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
        }

        public frmManager(string name)
        {
            InitializeComponent();
            tmp = name;
        }

        private string tmp = "";

        private void frmManager_Load(object sender, EventArgs e)
        {
            label2.Text = "Hi " + tmp + " Manager, have good day!";
            LoadDataCoffee();
            LoadDataStaff();
        }

        // Đẩy dữ liệu từ database lên bảng item
        private void LoadDataCoffee()
        {
            Inventory data = new Inventory();
            DataTable table = data.LoadCoffee();
            dgvItem.DataSource = table;
            dgvItem.ClearSelection();
        }

        // Đẩy dữ liệu từ database lên bảng staff
        private void LoadDataStaff()
        {
            DataTable table = Data.LoadStaff();
            dgvStaff.DataSource = table;
            dgvStaff.ClearSelection();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmItemTable itemTable = new frmItemTable();
            itemTable.ShowDialog();

            this.Visible = true;
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmStaffTable staffTable = new frmStaffTable();
            staffTable.ShowDialog();

            this.Visible = true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmViewReport frmViewReport = new frmViewReport();
            frmViewReport.ShowDialog();

            this.Visible = true;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblResetItem_Click(object sender, EventArgs e)
        {
            LoadDataCoffee();
        }

        private void lblResetStaff_Click(object sender, EventArgs e)
        {
            LoadDataStaff();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            string name = "";
            string phone = "";
            string email = "";
            string address = "";
            DateTime birthday = DateTime.Now;

            string query = "SELECT * FROM Manager WHERE Name = @name";
            SqlConnection connection = new SqlConnection(Data.connect);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", tmp);

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
            Manager customer = new Manager(name, phone, email, birthdayFormat, address);
            MessageBox.Show(customer.PrintInfo(), "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
