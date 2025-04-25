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
            ThongKe thongKe = new ThongKe();
            this.Hide();
            thongKe.Show();
        }

    }
}
