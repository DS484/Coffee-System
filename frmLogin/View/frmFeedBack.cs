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
    public partial class frmFeedBack : Form
    {
        public frmFeedBack(int id, DateTime date)
        {
            InitializeComponent();
            CustomerId = id;
            dateOrder = date;
        }

        /// <summary>
        /// Feedback nhận vào Id của khách hàng và ngày đánh giá
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="orderDay"></param>
        public frmFeedBack(int customerId, string orderDay)
        {
            InitializeComponent();
            CustomerId = customerId;
            this.orderDay = orderDay;
        }

        int CustomerId = 0;
        DateTime dateOrder;
        string star = "Not rated";

        string CustomerName = "";
        private string orderDay;

        /// <summary>
        /// Tìm kiếm tên khách hàng thông qua id truyền vào
        /// </summary>
        public void FindNameById()
        {
            string query = "SELECT CustomerId, Name FROM Customer WHERE CustomerId = @id";
            SqlConnection connection = new SqlConnection(Data.connect);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", CustomerId);

            connection.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CustomerName = reader["Name"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void frmFeedBack_Load(object sender, EventArgs e)
        {
            //var token = CustomerName.ToString().Substring(0, 1).ToUpper();
            //string customerName = token.ToString() + CustomerName.ToString().Substring(1);
            string date = dateOrder.ToString("dd-MM-yyyy");
            lbDate.Text = date;
            FindNameById();
            lbThank.Text = "Thanks " + CustomerName + ", this is our feedback table";
        }

        private void rb1s_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1s.Checked)
            {
                ratingStar.Value = 1;
                star = "1 star";
            }
        }

        private void rb2s_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2s.Checked)
            {
                ratingStar.Value = 2;
                star = "2 star";
            }
        }

        private void rb3s_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3s.Checked)
            {
                ratingStar.Value = 3;
                star = "3 star";
            }
        }

        private void rb4s_CheckedChanged(object sender, EventArgs e)
        {
            if (rb4s.Checked)
            {
                ratingStar.Value = 4;
                star = "4 star";
            }
        }

        private void rb5s_CheckedChanged(object sender, EventArgs e)
        {
            if (rb5s.Checked)
            {
                ratingStar.Value = 5;
                star = "5 star";
            }
        }


        /// <summary>
        /// Lưu thông tin của Feedback lưu vào database để manager truy xuất
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Data.connect))
            {
                string query = "INSERT INTO FeedBack(Rating, Comment, Date, CustomerId) VALUES(@rating, @comment, @date, @customerid)";

                string date = dateOrder.ToString("yyyy-MM-dd");

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@rating", star);
                        command.Parameters.AddWithValue("@comment", txtCmt.Text);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@customerid", CustomerId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi truy vấn!\n" + ex.ToString(), "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (star != "Not rated" || txtCmt.Text != "")
            {
                MessageBox.Show("Your feedback has saved, Thanks you. See you again!", "Thanks You", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thanks you for visiting the cafe. See you again!", "Thanks You", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.Close();
        }
    }
}
