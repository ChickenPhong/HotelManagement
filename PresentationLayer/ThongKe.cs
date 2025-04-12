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
using BusinessLayer;

namespace QuanLyKhachSan
{
    public partial class ThongKe : Form
    {
        StatisticServiceBL statisticService = new StatisticServiceBL();
        public ThongKe()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
            txtTongKhachHang.Text = statisticService.GetTotalCustomer().ToString();
            txtTongDoanhThu.Text = statisticService.GetTotalRevenue().ToString();

            LoadChart();
        }

        private void LoadChart()
        {
            chart1.Series["Series1"].Points.Clear();

            chart1.Series["Series1"].Points.AddXY("Phòng", Convert.ToInt32(txtTongSoPhong.Text));
            chart1.Series["Series1"].Points.AddXY("Khách", Convert.ToInt32(txtTongKhachHang.Text));
            chart1.Series["Series1"].Points.AddXY("Doanh thu", Convert.ToInt32(txtTongDoanhThu.Text));
        }
    }
}
