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
            DateTime selectedDate = dateTimePicker1.Value;

            if (txtThongKe.SelectedItem.ToString() == "Theo ngày")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByDay(selectedDate).ToString();
                txtTongDoanhThu.Text = statisticService.GetTotalRevenueByDay(selectedDate).ToString();
            }
            else if (txtThongKe.SelectedItem.ToString() == "Theo tháng")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByMonth(selectedDate).ToString();
                txtTongDoanhThu.Text = statisticService.GetTotalRevenueByMonth(selectedDate).ToString();
            }
            else if (txtThongKe.SelectedItem.ToString() == "Theo quý")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByQuarter(selectedDate).ToString();
                txtTongDoanhThu.Text = statisticService.GetTotalRevenueByQuarter(selectedDate).ToString();
            }
            else if (txtThongKe.SelectedItem.ToString() == "Theo năm")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByYear(selectedDate).ToString();
                txtTongDoanhThu.Text = statisticService.GetTotalRevenueByYear(selectedDate).ToString();
            }

            LoadChartRoomAndCustomer();
            LoadChartRevenue();
        }

        private void LoadChartRoomAndCustomer()
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].Points.AddXY("Phòng", Convert.ToInt32(txtTongSoPhong.Text));
            chart1.Series["Series1"].Points.AddXY("Khách", Convert.ToInt32(txtTongKhachHang.Text));

            // Đổi màu từng cột
            chart1.Series["Series1"].Points[0].Color = Color.Blue;  // Phòng
            chart1.Series["Series1"].Points[1].Color = Color.Orange; // Khách

            // Tắt Legend nếu muốn
            chart1.Legends[0].Enabled = false;
        }

        private void LoadChartRevenue()
        {
            chart2.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.AddXY("Doanh thu", Convert.ToInt32(txtTongDoanhThu.Text));

            // Tắt Legend nếu muốn
            chart2.Legends[0].Enabled = false;
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            txtThongKe.Items.Add("Theo ngày");
            txtThongKe.Items.Add("Theo tháng");
            txtThongKe.Items.Add("Theo quý");
            txtThongKe.Items.Add("Theo năm");
            txtThongKe.SelectedIndex = 0; // Mặc định là Theo ngày
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            DieuHuong dieuHuong = new DieuHuong();
            this.Hide();
            dieuHuong.Show();
        }
    }
}
