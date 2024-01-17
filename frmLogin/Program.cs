using LastProjectOOP;

namespace frmLogin
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        ///  2
        /// Xong DataInputCheck, xong class Customer, Inventory, Data
        /// Xong frmCustomer, frmItemTable, frmStaffTable, Chuyển đổi qua lại giữa các form, frmSignUp, frmViewRport
        /// 
        /// Đang làm Barista và frmBarista
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSignin());
        }
    }
}