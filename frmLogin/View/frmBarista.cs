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
using Guna.UI2.WinForms;
using LastProjectOOP.Model;
using LastProjectOOP.Suport;

namespace LastProjectOOP
{
    public partial class frmBarista : Form
    {
        Barista barista = new Barista();

        public frmBarista(string user, int baristaId, int customerId)
        {
            InitializeComponent();
            name = user;
            this.baristaId = baristaId;
            this.customerId = customerId;
        }

        /// <summary>
        /// name để hiện trên form lời chào
        /// </summary>
        string name = "";

        /// <summary>
        /// BaristaId dùng để truyền qua phương thức thêm Id của barista nhận đơn vào đơn đó
        /// </summary>
        int baristaId = 0;

        /// <summary>
        /// CustomerId dùng để khởi tạo feedback cho chinh customer đó
        /// </summary>
        int customerId = 0;


        /// <summary>
        //  Khi được Order thì thông tin của đơn hàng sẽ được đẩy lên bảng Order.
        //  Tại đó, các đơn nếu chưa có Baris ta nào nhận pha chế thì BarisatId của đơn đó là null 
        //  Khi đó, các đơn này sẽ được đưa vào formBarista tại datagridview. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBarista_Load(object sender, EventArgs e)
        {
            lbname.Text = name;


            string query = @"
            SELECT [Coffee].Name, [OrderDetail].Quantity, [Coffee].Price, [Order].CreatedDate, [Order].BaristaId, [OrderDetail].Status 
            FROM [Order]
            JOIN [OrderDetail] ON [Order].OrderId = [OrderDetail].OrderId
            JOIN [Coffee] ON [OrderDetail].CoffeeId = [Coffee].CoffeeId
            LEFT JOIN [Barista] ON [Order].BaristaId = [Barista].BaristaId
            WHERE [Order].BaristaId IS NULL
            OR [Order].BaristaId = @baristaId";

            SqlConnection connection = new SqlConnection(Data.connect);
            SqlCommand cmd = new SqlCommand(query, connection);
            DataTable dataTable = new DataTable();

            cmd.Parameters.AddWithValue("@baristaId", baristaId);

            connection.Open();
            try
            {
                // Đọc thông tin từ bảng lấy về từ câu lệnh truy vấn 
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);
                        dgvOrder.DataSource = dataTable;
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
        }

        /// <summary>
        /// Nút xác nhận đơn hàng Order của khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(customerId.ToString());
            barista.PrepareOrder(dgvOrder, baristaId, customerId, this, name);
        }

        /// <summary>
        /// 2 nút logout và thoát form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbLogout_Click(object sender, EventArgs e)
        {
            this.Close();
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

            string query = "SELECT * FROM Barista WHERE BaristaId = @id";
            SqlConnection connection = new SqlConnection(Data.connect);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", baristaId);

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
            Barista customer = new Barista(name, phone, email, birthdayFormat, address);
            MessageBox.Show(customer.PrintInfo(), "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
