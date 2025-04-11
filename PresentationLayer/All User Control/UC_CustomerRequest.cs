using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace QuanLyKhachSan.All_User_Control
{
    public partial class UC_CustomerRequest: UserControl
    {
        CustomerServiceBL customerService = new CustomerServiceBL();
        EmployeeServiceBL employeeService = new EmployeeServiceBL();
        public UC_CustomerRequest()
        {
            InitializeComponent();
        }

        public void LoadActiveRoomNo()
        {
            // Lấy danh sách khách đang ở (chưa checkout)  
            DataTable dt = customerService.SearchCustomerRequest();

            txtRoomNo.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                txtRoomNo.Items.Add(row["roomNo"].ToString());
            }
        }

        public void LoadEmployees()
        {
            DataTable dt = employeeService.GetAllEmployees();

            txtEmployee.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                txtEmployee.Items.Add(row["ename"].ToString());
            }
        }

        public void LoadCustomerRequest()
        {
            DataTable dt = customerService.GetAllCustomerRequest();
            dgvRequest.DataSource = dt;
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRequest.Text != "" && txtEmployee.Text != "")
            {
                string roomNo = txtRoomNo.Text;        // Lấy số phòng
                string request = txtRequest.Text;      // Lấy yêu cầu
                string employee = txtEmployee.Text;    // Lấy tên nhân viên
                string status = "Đang xử lý";          // Trạng thái mặc định là "Đang xử lý"

                // Gọi BusinessLayer để thêm yêu cầu vào database
                customerService.AddCustomerRequest(roomNo, request, employee, status);

                MessageBox.Show("Yêu cầu đã được gửi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi gửi yêu cầu, ta có thể làm sạch các trường để sẵn sàng cho yêu cầu tiếp theo
                clearAllRequestFields();

                // Load lại danh sách request
                LoadCustomerRequest();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin yêu cầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAllRequestFields()
        {
            txtRoomNo.SelectedIndex = -1;
            txtRequest.SelectedIndex = -1;
            txtEmployee.SelectedIndex = -1;
        }

        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var roomInfo = customerService.GetRoomInfo(txtRoomNo.Text);
            rid = roomInfo.RoomId;  // Sử dụng RoomId từ tuple
        }

        private void UC_CustomerRequest_Load(object sender, EventArgs e)
        {
            LoadActiveRoomNo();
            LoadEmployees();
            LoadCustomerRequest();
        }
    }
}
