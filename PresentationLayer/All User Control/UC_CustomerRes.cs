using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;
using Guna.UI2.WinForms;

namespace PresentationLayer.All_User_Control
{
    public partial class UC_CustomerRes: UserControl
    {
        CustomerServiceBL customerService = new CustomerServiceBL();

        public UC_CustomerRes()
        {
            InitializeComponent();
        }

        private void txtBedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();

            DataTable rooms = customerService.GetAvailableRooms(txtBed.Text, txtRoom.Text);
            foreach (DataRow row in rooms.Rows)
            {
                txtRoomNo.Items.Add(row["roomNo"].ToString());
            }
        }

        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var (price, roomId) = customerService.GetRoomInfo(txtRoomNo.Text);
            txtPrice.Text = price.ToString();
            rid = roomId;
        }

        private void btnAllotCustomer_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text != "" && txtContact.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDob.Text != "" && txtIDProof.Text != "" && txtAddress.Text != "" && txtCheckin.Text != "" && txtPrice.Text != "")
            {
                String name = txtFullName.Text;
                long mobile = long.Parse(txtContact.Text);
                String national = txtNationality.Text;
                String gender = txtGender.Text;
                String dob = txtDob.Text;
                String idproof = txtIDProof.Text;
                String address = txtAddress.Text;
                String checkin = txtCheckin.Text;

                customerService.AllotCustomer(name, mobile, national, gender, dob, idproof, address, checkin, rid, txtRoomNo.Text);
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại đầy đủ thông tin.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtFullName.Clear();
            txtContact.Clear();
            txtNationality.SelectedIndex = -1;
            txtGender.SelectedIndex = -1;
            txtDob.ResetText();
            txtIDProof.Clear();
            txtAddress.Clear();
            txtCheckin.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }

        private void btnAllotCustomer_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        public void LoadCustomerList()
        {
            DataTable dt = customerService.GetAllCustomers(); // phải có hàm này ở BusinessLayer
            dgvCustomerList.DataSource = dt;
        }

        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomerList.SelectedRows.Count > 0)
            {
                string roomId = dgvCustomerList.SelectedRows[0].Cells["roomid"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc muốn hủy khách hàng và trả phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    customerService.CancelCustomerByRoomId(roomId); // viết theo roomid
                    MessageBox.Show("Đã hủy khách hàng và cập nhật trạng thái phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerList();
                }
            }
            else
            {
                MessageBox.Show("❗ Vui lòng chọn khách hàng để hủy", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UC_CustomerRes_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvCustomerList.DataSource = customerService.SearchCustomerByName(txtName.Text);
        }

        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomerList.Rows[e.RowIndex].Cells["cname"].Value != null)
            {
                string customerName = dgvCustomerList.Rows[e.RowIndex].Cells["cname"].Value.ToString();
                txtCName.Text = customerName;
            }
        }
    }
}
