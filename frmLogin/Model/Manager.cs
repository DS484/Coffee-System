using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LastProjectOOP.Suport;
using Guna.UI2.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace LastProjectOOP.Model
{
    public class Manager : Person
    {
        /// <summary>
        /// Chuỗi kết nối dữ liệu
        /// </summary>
        string connect = Data.connect;

        public Manager()
            : base()
        {
        }

        public Manager(string name, string phone, string email, string birthDay, string address)
            : base(name, phone, email, birthDay, address)
        {

        }

        public override string PrintInfo()
        {
            return "MANAGER\n"
                + base.PrintInfo();
        }

        #region Các phương thức của Manager

        /// <summary>
        /// Xóa một sản phẩm
        /// </summary>
        /// <param name="coffeeId"></param>
        public void DeleteItem(int coffeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Coffee WHERE CoffeeId = @id", connection);
                    command.Parameters.AddWithValue("@id", coffeeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Remove complete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa loại hàng này vì loại hàng này đang được xử lí!!!", "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thêm một mặt hàng bất kỳ vào danh sách menu quán
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public void AddItem(string name, int quantity, double price)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "INSERT INTO Coffee(Name, Quantity, Price) VALUES(@name, @quantity, @price)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@price", price);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi truy vấn!\n" + ex.ToString(), "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Thay đổi thông tin của một món uống trên danh sách
        /// </summary>
        /// <param name="coffeeId"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public void UpdateItem(int coffeeId, string name, int quantity, double price)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "UPDATE Coffee SET Name = @name, Quantity = @quantity, Price = @price WHERE CoffeeId = @id";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@name", name);
                        // command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@id", coffeeId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi truy vấn!\n" + ex.ToString(), "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
           

        }

        /// <summary>
        /// Thêm một nhân viên vào danh sách
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="birthday"></param>
        /// <param name="pass"></param>
        /// <param name="userName"></param>
        public void AddBarista(string phone, string email, string name, string address, DateTime birthday, string pass, string userName)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "INSERT INTO Barista(Phone, Email, Name, Address, Birthday, Pass, UserName) VALUES(@phone, @email, @name, @address, @birthday, @pass, @userName)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@birthday", birthday);
                        command.Parameters.AddWithValue("@pass", pass);
                        command.Parameters.AddWithValue("@userName", userName);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi truy vấn!\n" + ex.ToString(), "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Xóa một nhân viên khỏi danh sách
        /// </summary>
        /// <param name="baristaId"></param>
        public void DeleteBarista(int baristaId)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "DELETE FROM Barista WHERE BaristaId = @baristaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue(@"baristaId", baristaId);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Remove complete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhân viên này đang làm việc không thể xóa!!!", "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin của nhân viên
        /// </summary>
        /// <param name="baristaId"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="birthday"></param>
        /// <param name="pass"></param>
        /// <param name="userName"></param>
        public void ChangeBarista(int baristaId, string phone, string email, string name, string address, DateTime birthday, string pass, string userName)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "UPDATE Barista SET Phone = @phone, Email = @email, Name = @name, Address = @address, Birthday = @birthday, Pass = @pass, UserName = @userName WHERE BaristaId = @baristaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue(@"email", email);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@birthday", birthday);
                        command.Parameters.AddWithValue("@pass", pass);
                        command.Parameters.AddWithValue("@userName", userName);

                        command.Parameters.AddWithValue("@baristaId", baristaId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi truy vấn!\n" + ex.ToString(), "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /// <summary>
        /// Sửa đổi thông tin của datagridview để in lên và trả về giá tiền tổng
        /// </summary>
        /// <param name="dtpStart"></param>
        /// <param name="dtpEnd"></param>
        /// <param name="dgvOrder"></param>
        public int ViewReport(Guna2DateTimePicker dtpStart, Guna2DateTimePicker dtpEnd, Guna2DataGridView dgvOrder)
        {
            // Xóa thông tin cũ  kkhi chọn mốc thời gian mới 
            // dgvOrder.Rows.Clear();

            List<int> listId = new List<int>();
            int total = 0;
            string startDate = dtpStart.Value.ToString("yyyy-MM-dd");
            string endDate = dtpEnd.Value.ToString("yyyy-MM-dd");
            using (SqlConnection connection = new SqlConnection(Data.connect))
            {
                string query = @"
                select f.FeedBackId ,c.Name, cf.Price, d.Quantity, f.Rating, f.Comment, o.CreatedDate from [FeedBack] f 
                join [Customer] c on f.CustomerId = c.CustomerId
                join [Order] o on c.CustomerId = o.CustomerId
                join [OrderDetail] d on o.OrderId = d.OrderId
                join [Coffee] cf on d.CoffeeId = cf.CoffeeId 
                where o.CreatedDate >= @StartDate and o.CreatedDate <= @EndDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var token = reader[1].ToString().Substring(0, 1).ToUpper();
                                string CustomerName = token.ToString() + reader[1].ToString().Substring(1);
                                DateTime date = Convert.ToDateTime(reader[6]);
                                string ViewDay = date.ToString("dd-MM-yyyy");
                                if (reader[0] != DBNull.Value)
                                {
                                    int FeedBackId = Convert.ToInt32(reader[0]);
                                    if (!listId.Contains(FeedBackId))
                                    {
                                        listId.Add(FeedBackId);
                                        dgvOrder.Rows.Add(CustomerName, reader[4], reader[5], ViewDay);
                                    }
                                }
                                if (reader[2] != DBNull.Value && reader[3] != DBNull.Value)
                                {
                                    int price = Convert.ToInt32(reader[2]);
                                    int quantity = Convert.ToInt32(reader[3]);
                                    total = total + (price * quantity);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error: +{ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return total;
            
        }

        /// <summary>
        /// Phương thức in file của manager
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dtpStart"></param>
        /// <param name="dtpEnd"></param>
        /// <param name="dgvOrder"></param>
        /// <param name="lblTotal"></param>
        public void PrintFilePdf(string filePath, Guna2DateTimePicker dtpStart, Guna2DateTimePicker dtpEnd, Guna2DataGridView dgvOrder, Guna2HtmlLabel lbTotal)
        {
            // Tạo một tài liệu PDF mới
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Tạo nội dung cho tài liệu PDF
            Paragraph header = new Paragraph("RAINY COFFEE SHOP");
            Paragraph report = new Paragraph("------------------------------REPORT------------------------------");
            doc.Add(header);
            doc.Add(report);

            doc.Add(new Paragraph("Start day: " + dtpStart.Value.ToString("dd/MM/yyyy")));
            doc.Add(new Paragraph("End day: " + dtpEnd.Value.ToString("dd/MM/yyyy")));

            // Duyệt qua từng dòng trong DataGridView và thêm thông tin vào tài liệu PDF
            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                DataGridViewRow row = dgvOrder.Rows[i];

                var name = new Paragraph("CustomerName: " + row.Cells["Column1"].Value);
                name.IndentationLeft = 70;
                var rate = new Paragraph("Rate: " + row.Cells["Column3"].Value);
                rate.IndentationLeft = 70;
                var cmt = new Paragraph("Comment: " + row.Cells["Column4"].Value);
                cmt.IndentationLeft = 70;
                var date = new Paragraph("Date: " + row.Cells["Column5"].Value);
                date.IndentationLeft = 70;
                var temp = new Paragraph("******");
                temp.IndentationLeft = 100;


                doc.Add(name);
                doc.Add(rate);
                doc.Add(cmt);
                doc.Add(date);
                doc.Add(temp);
            }

            // Thêm tổng số tiền bán được từ Label cuối cùng vào tài liệu PDF
            doc.Add(new Paragraph("Total is " + lbTotal.Text));
            doc.Add(new Paragraph("-------------------------------END-------------------------------"));

            doc.Close();
        }
        #endregion
    }
}
