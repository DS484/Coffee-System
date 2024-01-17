using Guna.UI2.WinForms;
using LastProjectOOP.Suport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LastProjectOOP.Model
{
    public class Barista : Staff
    {
        public Barista()
            : base() { }

        public Barista(string name, string phone, string email, string birthDay, string address)
            : base(name, phone, email, birthDay, address)
        {

        }

        public string PrepareCoffee(Coffee coffee, int quantity)
        {
            return "Preparing...\n"
                + "Name: " + coffee.ToString() + "\n"
                + "Quantity: " + quantity + "\n\n";
        }

        public string PrepareCoffee(Coffee coffee, int quantity, string action)
        {
            return "Preparing...\n"
                + "Name: " + coffee.ToString() + "\n"
                + "Quantity: " + quantity + "\n"
                + "Action: " + action + "\n\n";
        }

        public override string PrintInfo()
        {
            return "BARISTA\n"
                + base.PrintInfo();
        }


        /// <summary>
        /// Duyệt qua datagridiew để tìm date
        /// </summary>
        private DateTime FindDay(Guna2DataGridView dgvOrder)
        {
            if (dgvOrder.Rows.Count > 0)
            {
                return Convert.ToDateTime(dgvOrder.Rows[0].Cells["CreatedDate"].Value);
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Phương thức chuẩn bị Order cho khách hàng của Barista
        /// </summary>
        /// <param name="dgvOrder"></param>: Dùng để duyệt qua các đơn chưa xác nhận
        /// <param name="baristaId"></param>: Thêm id của barista xác nhận đơn vào đơn đó
        /// <param name="customerId"></param>: Truyền vào form feedback để cho đúng khách hàng vừa đặt hàng đánh giá
        /// <param name="form"></param>: Truyền vào để đóng form hiện tại
        /// <param name="name"></param>: Hiện tên của Barista nhận đơn
        public void PrepareOrder(Guna2DataGridView dgvOrder, int baristaId, int customerId, frmBarista form, string name)
        {

            // Biến để kiểm tra xem có mặt hàng nào chưa được xác nhận không
            int check = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (!row.IsNewRow && row.Cells["BaristaId"].Value.ToString() == "")
                {
                    // Có đơn chưa xác nhận
                    check = 1; 
                    break;
                }
            }
            if (check == 1)
            {
                DateTime date = FindDay(dgvOrder);
                Data.orderFlag = 0;

                // Đẩy id của Barista nhận đơn vào các đơn hàng có BaristaId null lúc nãy
                Data.AddIdBaristaIntoOrder(baristaId);
                
                MessageBox.Show(name + " Barista has received and done this order...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Ẩn đi form barista
                form.Hide();

                frmFeedBack frmFeedBack = new frmFeedBack(customerId, date);
                frmFeedBack.ShowDialog();
            }
            else
            {
                MessageBox.Show("Don't have order to confirm!!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
