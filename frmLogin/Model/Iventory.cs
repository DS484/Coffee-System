using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LastProjectOOP.Suport;

namespace LastProjectOOP.Model
{
    public class Inventory
    {
        private Coffee coffee;

        private int quantity;

        public Inventory(Coffee coffee, int quantity)
        {
            Coffee = coffee;
            Quantity = quantity;
        }

        public Inventory()
        {

        }

        public Coffee Coffee { get => coffee; set => coffee = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        /// <summary>
        /// Tìm kiếm id tương ứng dựa vào tên
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FindIdCoffee(string s)
        {
            int coffeeId = 0;
            string query = "SELECT CoffeeId FROM Coffee WHERE Name = '" + s + "'";

            SqlConnection connection = new SqlConnection(Data.connect);
            SqlCommand cmd = new SqlCommand(query, connection);
            
            // Cấu trúc try-catch-finaly để kiểm soát dữ liệu
            connection.Open();
            try
            {
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
            return coffeeId;
        }

        /// <summary>
        /// Hàm load dữ liệu lại từ database lên form
        /// </summary>
        /// <returns></returns>
        public DataTable LoadCoffee()
        {
            DataTable table = new DataTable();

            // Từ khóa using giúp cho dữ liệu được tự động giải phóng sau khi dùng
            try
            {
                using (SqlConnection connection = new SqlConnection(Data.connect))
                {
                    string query = "SELECT Name, Quantity, Price FROM Coffee";
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        table.Clear();
                        adapter.Fill(table);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show("Query error" + sql.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Application.Exit();
            }
            return table;
        }


        /// <summary>
        /// Dùng cho hàm tìm kiếm coffee, trả về bảng thông tin cần tìm tương ứng với câu lệnh
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable FindCoffee(string query)
        {
            SqlConnection connection = new SqlConnection(Data.connect);
            DataTable table = new DataTable();
            connection.Open();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    table.Clear();
                    adapter.Fill(table);
                }
            }
            catch(SqlException sql)
            {
                MessageBox.Show("Query error" + sql.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
    }
}
