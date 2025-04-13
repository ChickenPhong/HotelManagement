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

        public string FormatRevenue(int revenue)
        {
            if (revenue >= 1000000)
            {
                double trieu = (double)revenue / 1000000;
                return trieu.ToString("0.#") + " triệu VND";
            }
            else if (revenue >= 1000)
            {
                return revenue.ToString("N0") + " VND"; // Ví dụ: 120,000 VND
            }
            else
            {
                return revenue.ToString() + " VND";
            }
        }
        int totalRevenue;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            if (txtThongKe.SelectedItem.ToString() == "Theo ngày")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByDay(selectedDate).ToString();

                totalRevenue = statisticService.GetTotalRevenueByDay(selectedDate);
                txtTongDoanhThu.Text = FormatRevenue(totalRevenue);
            }
            else if (txtThongKe.SelectedItem.ToString() == "Theo tháng")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByMonth(selectedDate).ToString();

                totalRevenue = statisticService.GetTotalRevenueByMonth(selectedDate);
                txtTongDoanhThu.Text = FormatRevenue(totalRevenue);
            }
            else if (txtThongKe.SelectedItem.ToString() == "Theo quý")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByQuarter(selectedDate).ToString();

                totalRevenue = statisticService.GetTotalRevenueByQuarter(selectedDate);
                txtTongDoanhThu.Text = FormatRevenue(totalRevenue);
            }
            else if (txtThongKe.SelectedItem.ToString() == "Theo năm")
            {
                txtTongSoPhong.Text = statisticService.GetTotalRoom().ToString();
                txtTongKhachHang.Text = statisticService.GetTotalCustomerByYear(selectedDate).ToString();


                totalRevenue = statisticService.GetTotalRevenueByYear(selectedDate);
                txtTongDoanhThu.Text = FormatRevenue(totalRevenue);
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
            //chart1.Series["Series1"].Points[0].Color = Color.Blue;  // Phòng
            chart1.Series["Series1"].Points[1].Color = Color.Orange; // Khách

            // Tắt Legend nếu muốn
            chart1.Legends[0].Enabled = false;
        }

        private void LoadChartRevenue()
        {
            chart2.Series["Series1"].Points.Clear();
            if (txtThongKe.SelectedItem.ToString() == "Theo năm")
            {
                List<int> revenueList = statisticService.GetRevenueByYear(dateTimePicker1.Value);

                for (int i = 1; i <= 12; i++)
                {
                    chart2.Series["Series1"].Points.AddXY("Tháng " + i, revenueList[i - 1]);
                }
            }
            else if (txtThongKe.SelectedItem.ToString() == "Theo quý")
            {
                List<int> revenueList = statisticService.GetRevenueByQuarter(dateTimePicker1.Value);
                int quy = (dateTimePicker1.Value.Month - 1) / 3 + 1;
                int startMonth = (quy - 1) * 3 + 1;
                for (int i = 0; i < 3; i++)
                {
                    chart2.Series["Series1"].Points.AddXY("Tháng " + (startMonth + i), revenueList[i]);
                }
            }
            else
            {
                chart2.Series["Series1"].Points.AddXY("Doanh thu", totalRevenue);
            }
            //chart2.Series["Series1"].Points.AddXY("Doanh thu",totalRevenue);

            chart2.Series["Series1"].Points[0].Color = Color.Blue;  // Doanh thu

            // Hiển thị trục Y đẹp
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            chart2.ChartAreas[0].AxisX.Interval = 1; // Hiện đủ Tháng 1 đến Tháng 12
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

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
