using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastProjectOOP.Suport
{
    public static class Data
    {
        /// <summary>
        /// Chuỗi kết nối database
        /// </summary> 
        public static string connect = @"Data Source = MSI\SQLEXPRESS;Initial Catalog=CoffeeStore;Integrated Security=True";
        public static int orderFlag = 0;

        /// <summary>
        /// Load dữ liệu bảng nhân viên vào
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadStaff()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection connection = new SqlConnection(connect);
                string querry = "SELECT Phone, Email, Name, Address, Birthday, Pass, UserName FROM Barista";
                using (SqlCommand sqlCommand = new SqlCommand(querry, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    table.Clear();
                    adapter.Fill(table);

                    connection.Close();
                }

            }
            catch (SqlException sql)
            {
                MessageBox.Show("Query error!\n" + sql.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return table;
        }

        /// <summary>
        /// Thêm một Order khi khách hàng thực hiện Order
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int AddOrder(int CustomerId, DateTime date)
        {
            int orderId = 0;
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "INSERT INTO [Order](CustomerId, CreatedDate) OUTPUT INSERTED.OrderId VALUES(@customerid, @date)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@customerid", CustomerId);
                        command.Parameters.AddWithValue("@date", date);

                        connection.Open();
                        orderId = (int)command.ExecuteScalar();
                        //command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Query error!\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return orderId;
        }

        /// <summary>
        /// Thêm OrderDetail
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="CoffeeId"></param>
        /// <param name="Quantity"></param>
        /// <param name="Status"></param>
        public static void AddOrderDetail(int OrderId, int CoffeeId, int Quantity, string Status)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "INSERT INTO [OrderDetail](OrderId, CoffeeId, Quantity, Status) VALUES(@orderid, @coffeeid, @quantity, @status)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@orderid", OrderId);
                        command.Parameters.AddWithValue("@coffeeid", CoffeeId);
                        command.Parameters.AddWithValue("@quantity", Quantity);
                        command.Parameters.AddWithValue("@status", Status);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Query error!\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Khi được Order, nếu chưa có barista nào nhận thì đơn order đó sẽ có BaristaId rỗng. Khi đã có Barista nhận đơn, đây sẽ là
        /// phương thức thêm Id của Barista đó vào đơn Order (chứng tỏ đã có người làm)
        /// </summary>
        /// <param name="baristaId"></param>
        public static void AddIdBaristaIntoOrder(int baristaId)
        {
            string updateQuery = "UPDATE [Order] SET BaristaId = @baristaId WHERE BaristaId IS NULL";

            using (SqlConnection updateConnection = new SqlConnection(Data.connect))
            {
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, updateConnection))
                {
                    updateCommand.Parameters.AddWithValue("@baristaId", baristaId);

                    updateConnection.Open();
                    try
                    {
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating BaristaId: " + ex.Message);
                    }
                }
            }
        }
    }
}
