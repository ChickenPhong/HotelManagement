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

namespace PresentationLayer.All_User_Control
{
    public partial class UC_CheckOut: UserControl
    {
        CustomerServiceBL customerService = new CustomerServiceBL();
        public UC_CheckOut()
        {
            InitializeComponent();
        }

        public void LoadCheckOut()
        {
            guna2DataGridView1.DataSource = customerService.GetActiveCustomerRoomInfo();
        }

        private void UC_CheckOut_Load(object sender, EventArgs e)
        {
            LoadCheckOut();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = customerService.SearchCustomerByName(txtName.Text);
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < guna2DataGridView1.Rows.Count)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells[0].Value);
                txtCName.Text = row.Cells[1].Value.ToString();
                txtRoom.Text = row.Cells["roomNo"].Value.ToString(); // roomNo

                int roomid = Convert.ToInt32(row.Cells["roomid"].Value);
                DateTime checkoutDate = txtCheckOutDate.Value; // Lấy từ DateTimePicker của bạn
                int totalDayStay = customerService.GetTotalDayStay(id, checkoutDate);
                long price = customerService.GetRoomPrice(roomid);

                long totalPrice = totalDayStay * price;

                txtTotalPrice.Text = totalPrice.ToString("N0") + " VND"; // format tiền đẹp
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCName.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string checkoutDate = txtCheckOutDate.Text;
                    int roomid = Convert.ToInt32(txtRoom.Text);
                    customerService.CheckOut(id, checkoutDate, roomid);
                    LoadCheckOut();
                    clearAll();

                    // Làm trống txtTotalPrice sau khi thanh toán
                    txtTotalPrice.Clear();
                }
            }
            else
            {
                MessageBox.Show("Không Có Khách Hàng Để Lựa Chọn", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoom.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
