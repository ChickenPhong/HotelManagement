using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer;
using QuanLyKhachSan.All_User_Control;

namespace QuanLyKhachSan
{
    public partial class DieuHuong : Form
    {
        public DieuHuong()
        {
            InitializeComponent();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.Show();
        }

        private void btnThonKe_Click(object sender, EventArgs e)
        {
            if (DangNhap.LoggedInRole == "Nhan vien le tan")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThongKe thongKe = new ThongKe();
            this.Hide();
            thongKe.Show();
        }

        private void DieuHuong_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.bg_hotel;
            this.BackgroundImageLayout = ImageLayout.Stretch; // hoặc .Zoom, .Center tùy ý

            // Nếu tài khoản là nhân viên lễ tân, khóa chức năng Thống Kê
            if (DangNhap.LoggedInRole == "Nhan vien le tan")
            {
                btnThonKe.Enabled = false;
                btnThonKe.Cursor = Cursors.No;
                btnThonKe.BackColor = Color.LightGray; // Tùy chọn để làm mờ nút
            }
        }
    }
}
