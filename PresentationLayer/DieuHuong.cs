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
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form1.targetPage = "Dashboard"; // set target là Dashboard
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1.targetPage = "ThongKe"; // set target là Thống Kê
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
