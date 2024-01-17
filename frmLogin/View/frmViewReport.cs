using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LastProjectOOP.Suport;
using System.Linq.Expressions;
using LastProjectOOP.Model;





namespace LastProjectOOP
{
    public partial class frmViewReport : Form
    {
        private Manager manager = new Manager();

        private void frmViewReport_Load(object sender, EventArgs e)
        {

        }

        public frmViewReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Check tính hợp lý của 2 khoảng thời gian
        /// </summary>
        /// <returns></returns>
        private bool CheckDate()
        {
            return dtpStart.Value < dtpEnd.Value && dtpEnd.Value <= DateTime.Now;
        }


        /// <summary>
        /// Nút xem thông tin các đơn order và doanh thu trong quán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                // Xóa thông tin cũ  kkhi chọn mốc thời gian mới 
                dgvOrder.Rows.Clear();

                int total = manager.ViewReport(dtpStart, dtpEnd, dgvOrder);

                lbTotal.Text = total.ToString() + " VND";
            }
            else
            {
                MessageBox.Show("Start time or End time are invalid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        /// <summary>
        /// In thông tin trên bảng ra file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // SaveFileDialog giúp ta xác định đường dẫn và vị trí lưu file trong ổ đĩa
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Document|*.pdf";
            saveFileDialog.Title = "Save report as PDF";

            // Tên file mặc định (người dùng có thể đổi)
            saveFileDialog.FileName = "report";

            // Hiển thị SaveFileDialog và kiểm tra xem người dùng đã nhấn Save hay chưa
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // PrintFilePdf(filePath);
                manager.PrintFilePdf(filePath, dtpStart, dtpEnd, dgvOrder, lbTotal);

                MessageBox.Show("Print completed, you can see it at " + filePath, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
