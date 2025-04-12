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

namespace PresentationLayer.All_User_Control
{
    public partial class UC_CustomerRes: UserControl
    {
        CustomerServiceBL customerService = new CustomerServiceBL();

        public UC_CustomerRes()
        {
            InitializeComponent();
        }

        private void UC_CustomerRes_Load(object sender, EventArgs e)
        {
            txtDob.Format = DateTimePickerFormat.Custom;
            txtDob.CustomFormat = "dd/MM/yyyy";
            txtDob.ShowUpDown = false; // muốn chọn nhanh có thể true

            txtCheckin.Format = DateTimePickerFormat.Custom;
            txtCheckin.CustomFormat = "dd/MM/yyyy";
            txtCheckin.ShowUpDown = false; // muốn chọn nhanh có thể true
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

        private void txtDob_Leave(object sender, EventArgs e)
        {
            DateTime tempDate;
            if (!DateTime.TryParseExact(txtDob.Text, "dd/MM/yyyy",
                                        System.Globalization.CultureInfo.InvariantCulture,
                                        System.Globalization.DateTimeStyles.None, out tempDate))
            {
                MessageBox.Show("Ngày sinh không hợp lệ, vui lòng nhập đúng định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDob.Focus();
            }
        }

        private void txtCheckin_Leave(object sender, EventArgs e)
        {
            DateTime tempDate;
            if (!DateTime.TryParseExact(txtCheckin.Text, "dd/MM/yyyy",
                                        System.Globalization.CultureInfo.InvariantCulture,
                                        System.Globalization.DateTimeStyles.None, out tempDate))
            {
                MessageBox.Show("Ngày đăng ký không hợp lệ, vui lòng nhập đúng định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCheckin.Focus();
            }
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
            txtNationality.Clear();
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
    }
}
