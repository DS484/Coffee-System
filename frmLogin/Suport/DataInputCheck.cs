using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Guna.UI2.WinForms;

namespace LastProjectOOP.Suport
{
    public static class DataInputCheck
    {
        /// <summary>
        /// Tên không được tồn tại ký tự đặc biệt hoặc các số và không phân biệt hoa thường
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckInputName(string name)
            => Regex.IsMatch(name, @"^[a-zA-Z ]+$") && !string.IsNullOrEmpty(name);

        /// <summary>
        /// Số điện thoại chỉ bao gồm số hoặc dấu + ở đầu và không được trống
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool CheckInputPhoneNumber(string phone)
            => Regex.IsMatch(phone, @"^\+[0-9]+$") && !string.IsNullOrEmpty(phone);

        /// <summary>
        /// Giá chỉ bao gồm các số, không có các ký tự đặc biệt khác
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static bool CheckInputPrice(string price)
            => Regex.IsMatch(price, @"^\d+$") && !string.IsNullOrEmpty(price);

        /// <summary>
        /// Địa chỉ không được phép chứa các ký tự đặc biệt
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool CheckInputAdress(string address)
            => Regex.IsMatch(address, @"^[a-zA-Z0-9-/\s]+$");

        /// <summary>
        /// Kiểm tra ngày tháng năm sinh có đúng không: Có dạng MM/dd/yyyy
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static bool CheckInputBirthday(string birthday)
            //  @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"
            => Regex.IsMatch(birthday, @"^((0?[1-9]|1[0-2])/(0?[1-9]|[12][0-9]|3[01])/(\d{4}))$");
        

        /// <summary>
        /// Phải đúng định dạng của một emali
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckInputEmail(string email)
            
            => Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") && !string.IsNullOrEmpty(email);

        /// <summary>
        /// Khi nhập bất kỳ thông tin nào vào thì textbox đó không được rỗng
        /// </summary>
        /// <param name="txtExp"></param>
        /// <returns></returns>
        public static bool CheckInputTextbox(string txtExp)
            => txtExp != string.Empty;

        /// <summary>
        /// Khách hàng chỉ được phép đăng ký tài khoản với điều kiện từ đủ 12 tuôi tính tới hiện tại
        /// </summary>
        /// <param name="birthdayInSignUp"></param>
        /// <returns></returns>
        public static bool CheckInputBirthdayInSignUp(Guna2DateTimePicker birthdayInSignUp)
        {
            DateTime birthday = birthdayInSignUp.Value;

            // Tính toán tuổi dựa trên ngày sinh và ngày hiện tại
            TimeSpan ageDiff = DateTime.Now - birthday;
            int age = Convert.ToInt32(ageDiff.Days / 365.25);

            return age > 12;
        }

        public static bool FindItemInMenu(string item, Guna2DataGridView dgvMenu)
        {
            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                // Lấy giá trị cột chứa tên sản phẩm
                string productName = row.Cells["Name"].Value.ToString();

                // So sánh tên sản phẩm với sản phẩm cần tìm không phân biệt hoa thường
                if (productName.Equals(item, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
