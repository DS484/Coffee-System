using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LastProjectOOP.Suport;

namespace LastProjectOOP
{
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
        }

        List<string> listInfomation = new List<string>();

        private void frmSignUp_Load(object sender, EventArgs e)
        {

        }

        private void SaveInfo()
        {
            using (SqlConnection connection = new SqlConnection(Data.connect))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string phone = reader["Phone"].ToString().Trim();
                        string email = reader["Email"].ToString().Trim();
                        listInfomation.Add(phone);
                        listInfomation.Add(email);
                        listInfomation.Add(reader["Name"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Infomation is already exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        /// <summary>
        /// Kiểm tra thông tin đăng ký tài khoản
        /// </summary>
        private bool CheckInfo()
        {
            SaveInfo();
            if (!DataInputCheck.CheckInputName(txtName.Text))
            {
                MessageBox.Show("The name is empty or invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputPhoneNumber(txtPhone.Text))
            {
                MessageBox.Show("The phone is empty or invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            else if (!DataInputCheck.CheckInputEmail(txtEmail.Text))
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
            else if (!DataInputCheck.CheckInputBirthdayInSignUp(dtpkBirthday))
            {
                MessageBox.Show("Birthday is invalid. You are not yet 12 years old to sign up", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(listInfomation.Contains(txtName.Text) || listInfomation.Contains(txtEmail.Text)
                || listInfomation.Contains(txtPhone.Text))
            {
                MessageBox.Show("Infomation is already exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lưu thông tin đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInfo())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Data.connect))
                    {
                        string query = "INSERT INTO Customer(Phone, Email, Name, Address, Birthday) VALUES(@phone, @email, @name, @address, @birthday)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            DateTime dateTime = Convert.ToDateTime(dtpkBirthday.Value);
                            command.Parameters.AddWithValue("@phone", txtPhone.Text);
                            command.Parameters.AddWithValue("@email", txtEmail.Text);
                            command.Parameters.AddWithValue("@name", txtName.Text);
                            command.Parameters.AddWithValue("@address", txtAddress.Text);
                            command.Parameters.AddWithValue("@birthday", dateTime);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Sign up success! Now, you can sign in to order", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errol!\n" + ex.ToString(), "Errol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
