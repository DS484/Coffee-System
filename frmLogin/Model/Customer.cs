using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Security.Cryptography.X509Certificates;

namespace LastProjectOOP.Model
{
    public class Customer : Person
    {
        public Customer(string name, string phone, string email, string birthDay, string address)
            : base(name, phone, email, birthDay, address)
        {

        }

        public Customer()
            : base()
        { }

        /// <summary>
        /// Thông tin hóa đơn Order không có tham số trạng thái
        /// </summary>
        /// <param name="coffee"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public string OrderCoffee(string name, int price, int quantity)
        {
            return "Ordering...\n"
                + "Name: " + name + "\n"
                + "Quantity: " + quantity + "\n\n"
                + "Action: " + " Empty" + "\n"
                + "Total: " + price * quantity + "$\n\n";
        }

        /// <summary>
        /// Thông tin hóa đơn Order có tham số trạng thái
        /// </summary>
        /// <param name="coffee"></param>
        /// <param name="quantity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public string OrderCoffee(string name, int price, int quantity, string action)
        {
            return "Ordering...\n"
                + "Name: " + name + "\n"
                + "Quantity: " + quantity + "\n"
                + "Action: " + action + "\n"
                + "Total: " + price * quantity + "$\n\n";
        }

        public string FeedBack(string fb)
        {
            return "Thank for your feedback";
        }

        public override string PrintInfo()
        {
            return "CUSTOMER\n"
                + base.PrintInfo();
        }

        /// <summary>
        /// Phương thức tìm kiếm của khách hàng
        /// Khi cờ = -1 -> Tìm kiếm theo loại coffee trong quán
        /// Khi cờ = 0 -> Tìm kiếm theo tên coffee trong quán
        /// Khi cờ = 1 -> Tìm kiếm theo giá coffee trong quán
        /// </summary>
        /// <param name="s"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable FindManyCases(string str, int flag)
        {
            string query = string.Empty;
            if (flag == -1)
            {
                query = $"SELECT Name, Quantity, Price FROM Coffee WHERE {"Name"} LIKE '%" + str + "%'";
            }
            else if (flag == 0)
            {
                query = $"SELECT Name, Quantity, Price FROM Coffee WHERE {"Name"} LIKE '%" + str + "%'";
            }
            else if (flag == 1)
            {
                int price = Convert.ToInt32(str);
                string template = @"SELECT Name, Quantity, Price FROM Coffee WHERE [Price] = {0};";
                query = string.Format(template, price);

            }
            Inventory data = new Inventory();
            DataTable table = data.FindCoffee(query);
            return table;
        }


        /// <summary>
        /// Phương thức thanh toán đơn hàng của khách hàng
        /// </summary>
        /// <param name="payAmount"></param>
        /// <param name="totalOrder"></param>
        /// <param name="dgvOrder"></param>
        /// <param name="flagPayBill"></param>
        public bool PayyBill(Guna2TextBox payAmount, Guna2TextBox totalOrder, Guna2DataGridView dgvOrder)
        {
            string change = (Convert.ToInt64(payAmount.Text) - Convert.ToInt64(totalOrder.Text)).ToString();
            if (Convert.ToInt64(change) >= 0)
            {

                MessageBox.Show("Your change is: " + change, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                totalOrder.Text = "0";
                payAmount.Text = "";

                dgvOrder.DataSource = null;
                dgvOrder.Rows.Clear();

                // Bật cờ thanh toán thành công
                return true;
            }
            else
            {
                MessageBox.Show("The amount you gave is not enough to pay!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
