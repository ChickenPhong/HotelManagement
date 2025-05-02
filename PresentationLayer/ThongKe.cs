using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            // Xóa dữ liệu cũ trong biểu đồ
            chart2.Series["Series1"].Points.Clear();

            // Chọn loại biểu đồ: Biểu đồ tròn cho doanh thu
            chart2.Series["Series1"].ChartType = SeriesChartType.Pie;

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
                // Với báo cáo theo ngày hoặc tháng, hiển thị tổng doanh thu dưới dạng một phần trong biểu đồ tròn
                chart2.Series["Series1"].Points.AddXY("Doanh thu", totalRevenue);
            }

            // Tùy chỉnh màu sắc cho phần doanh thu
            chart2.Series["Series1"].Points[0].Color = Color.Aqua;  // Doanh thu

            // Định dạng nhãn cho biểu đồ tròn
            foreach (DataPoint point in chart2.Series["Series1"].Points)
            {
                point.Label = $"{point.AxisLabel}: {point.YValues[0]:C}";
            }

            // Bật Legend và hiển thị tên "Series"
            chart2.Legends.Clear(); // Xóa legend cũ nếu có
            chart2.Legends.Add(new Legend()); // Thêm legend mới với tên mặc định
            chart2.Legends[0].Docking = Docking.Top; // Đặt vị trí của Legend (ở trên)
            chart2.Legends[0].IsDockedInsideChartArea = false;

            // Ẩn Legend (tùy chọn)
            // chart2.Legends[0].Enabled = false;
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
