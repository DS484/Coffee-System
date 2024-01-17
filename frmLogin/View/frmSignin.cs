using LastProjectOOP;
using LastProjectOOP.Suport;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace frmLogin
{
    public partial class frmSignin : Form
    {
        /// <summary>
        /// Id của khách được truyền qua formSignin, từ đây khi thực hiện đăng nhập dưới tư cách Barista (hàm được định
        /// nghĩa trong Class Data) thì sẽ được truyền cho hàm.
        /// </summary>
        int idCustomer = 0;

        public frmSignin()
        {
            InitializeComponent();

        }

        public frmSignin(int id)
        {
            InitializeComponent();
            idCustomer = id;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sự kiện click vào nút Signup để đăng ký tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSignUp frmSignUp = new frmSignUp();
            frmSignUp.ShowDialog();

            this.Visible = true;
            //frmSignin frm = new frmSignin();
            //frm.ShowDialog();
        }

        /// <summary>
        /// Thực hiện đăng nhập: Khi nhập tài khoản sẽ kiểm tra xem đó là tk của manager hay baris ta.
        /// Ưu tiên kiểm tra của manager 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignIn_Click(object sender, EventArgs e)
        {

            int checkManager = LoginManager(txtUserName.Text, txtPassword.Text);
            

            if (checkManager == 0)
            {
                int checkBarista = LoginBarista(txtUserName.Text, txtPassword.Text, idCustomer);

                if (checkBarista == 0)
                {
                    MessageBox.Show("Wrong user or password! Enter again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Đăng nhập với tư cách khách hàng: Sẽ không cần nhập mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblGuest_Click(object sender, EventArgs e)
        {
            if (Data.orderFlag == 1)
            {
                MessageBox.Show("The previous order has not been processed, please comeback later...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int check = 0, id = -1;
            string name = "";
            string query = "SELECT * FROM Customer";
            SqlConnection connection = new SqlConnection(Data.connect);
            SqlCommand cmd = new SqlCommand(query, connection);
            
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string user = reader.GetString(3).Trim();
                        if (user == txtUserName.Text)
                        {
                            // Lấy id, tên từ bảng Customer nếu tên trùng nhau
                            id = reader.GetInt32(0);
                            name = reader.GetString(3).Trim();
                            check = 1;
                            break;
                        }
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
            
            if (check == 1)
            {
                string s1 = name.Substring(0, 1);
                string s2 = name.Substring(1);
                s1 = s1.ToUpper();
                string name1 = s1 + s2;


                // Thực hiện ẩn đi, sau đó hiện lại form
                this.Hide();

                frmCustomer customerTable = new frmCustomer(name1, id);
                customerTable.ShowDialog();

                // this.Visible = true;
            }
            else
            {
                MessageBox.Show("Your password is incorrect or this account doesn't " +
                    "exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Đăng nhập với tư cách manager
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public int LoginManager(string user, string pass)
        {
            int check = 0;
            string name = "";
            string query = "SELECT * FROM Manager";
            SqlConnection connection = new SqlConnection(Data.connect);
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string user1 = reader.GetString(6).Trim();
                        string pass1 = reader.GetString(7).Trim();
                        if (user1 == user && pass1 == pass)
                        {
                            name = reader.GetString(3).Trim();
                            check = 1;
                            break;
                        }
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

            if (check == 1)
            {
                this.Hide();

                frmManager managerTable = new frmManager(name);
                managerTable.ShowDialog();

                this.Visible = true;
            }
            return check;
        }

        /// <summary>
        /// Đăng nhập với tư cách Barista, đem theo id của khách hàng đã đặt hàng (quy định trong from manager)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public int LoginBarista(string user, string pass, int CustomerId)
        {
            int check = 0;
            string name = "";
            string query = "SELECT * FROM Barista";

            SqlConnection connection = new SqlConnection(Data.connect);
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string user1 = reader.GetString(7).Trim();
                        string pass1 = reader.GetString(6).Trim();
                        if (user1 == user && pass1 == pass)
                        {
                            name = reader.GetString(3).Trim();
                            check = reader.GetInt32(0);
                            break;
                        }
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

            if (check != 0)
            {
                this.Hide();

                frmBarista baristaTable = new frmBarista(name, check, CustomerId);
                baristaTable.ShowDialog();

                this.Visible = true;
            }
            return check;
        }

        /// <summary>
        /// Rời khỏi chương trình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblExit_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do you want to exit the store?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}