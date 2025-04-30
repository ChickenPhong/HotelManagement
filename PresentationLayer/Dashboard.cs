using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan;

namespace PresentationLayer
{
    public partial class Dashboard: Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát tài khoản không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Ẩn form hiện tại
                this.Hide();

                // Hiển thị lại Form1 (màn hình đăng nhập)
                DangNhap form1 = new DangNhap();
                form1.Show();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRes1.Visible = false;
            uC_CheckOut1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Employee1.Visible = false;
            uC_CustomerRequest1.Visible = false;
            btnCustomerRes.PerformClick();

            string role = DangNhap.LoggedInRole;

            if (role == "Nhân viên lễ tân")
            {
                // Disable 2 nút chức năng
                btnAddRoom.Enabled = false;
                btnAddRoom.BackColor = Color.Gray;

                btnEmployee.Enabled = false;
                btnEmployee.BackColor = Color.Gray;
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnAddRoom.Left + 50;
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();

            if (DangNhap.LoggedInRole == "Nhân viên lễ tân")
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCustomerRes_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerRes.Left + 60;
            uC_CustomerRes1.Visible = true;
            uC_CustomerRes1.BringToFront();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCheckOut.Left + 60;
            uC_CheckOut1.Visible = true;
            // Load lại data mới nhất
            uC_CheckOut1.LoadCheckOut();
            
            uC_CheckOut1.BringToFront();
        }

        private void btnCustomerDetail_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerDetail.Left + 60;
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnEmployee.Left + 60;
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();

            if (DangNhap.LoggedInRole == "Nhân viên lễ tân")
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCustomerRequest_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerRequest.Left + 60;
            uC_CustomerRequest1.Visible = true;
            // Load lại Room và Request mới nhất
            uC_CustomerRequest1.LoadActiveRoomNo();
            uC_CustomerRequest1.LoadCustomerRequest();

            uC_CustomerRequest1.BringToFront();
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            DieuHuong dieuHuong = new DieuHuong();
            this.Hide();
            dieuHuong.Show();
        }
    }
}
