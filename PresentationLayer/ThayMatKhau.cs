using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace QuanLyKhachSan
{
    public partial class ThayMatKhau: Form
    {
        public EmployeeDTO NhanVienDangNhap { get; set; }
        private EmployeeServiceBL nhanVienBL;

        public ThayMatKhau()
        {
            InitializeComponent();
            nhanVienBL = new EmployeeServiceBL();
        }

        private void btnXacNhanMatKhau_Click(object sender, EventArgs e)
        {
            string passCu = txtMatKhauHienTai.Text.Trim();
            string passMoi = txtMatKhauMoi.Text.Trim();
            string passXacNhan = txtXacNhanMatKhauMoi.Text.Trim();

            if (string.IsNullOrEmpty(passCu) || string.IsNullOrEmpty(passMoi) || string.IsNullOrEmpty(passXacNhan))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu cũ (sử dụng phương thức có băm)
            if (!nhanVienBL.CheckPassword(NhanVienDangNhap.Username, passCu))
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passMoi != passXacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật mật khẩu đã băm
            bool success = nhanVienBL.UpdatePassword(NhanVienDangNhap.Username, passMoi);
            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thay đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyThayMatKhau_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
