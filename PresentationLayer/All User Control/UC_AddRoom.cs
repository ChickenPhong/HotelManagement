using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer.All_User_Control
{
    public partial class UC_AddRoom: UserControl
    {
        RoomServiceBL roomService = new RoomServiceBL();

        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            LoadRoom();
        }

        // Load danh sách phòng lên DataGridView
        private void LoadRoom()
        {
            List<RoomDTO> rooms = roomService.GetAllRooms();
            DataGridView1.DataSource = rooms;

            // Ẩn cột RoomId cho dễ nhìn
            if (DataGridView1.Columns.Contains("RoomId"))
            {
                DataGridView1.Columns["RoomId"].Visible = false;
            }
            LoadRoomNumbersToComboBox();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                RoomDTO room = new RoomDTO
                {
                    RoomNo = txtRoomNo.Text,
                    RoomType = txtRoomType.Text,
                    Bed = txtBed.Text,
                    Price = long.Parse(txtPrice.Text)
                };

                roomService.AddRoom(room);
                MessageBox.Show("Đã thêm phòng", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRoom();
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtRoomNo.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            LoadRoom();
        }

        private void LoadRoomNumbersToComboBox()
        {
            txtRoomHave.Items.Clear();
            txtRoomHave.Items.Add("");
            txtRoomHave2.Items.Clear();
            txtRoomHave2.Items.Add("");
            List<RoomDTO> rooms = roomService.GetAllRooms();
            foreach (var room in rooms)
            {
                txtRoomHave.Items.Add(room.RoomNo);  // <-- CHỈ THÊM RoomNo (vd: 101, 102)
                txtRoomHave2.Items.Add(room.RoomNo);
            }
            txtRoomHave.SelectedIndex = 0;
            txtRoomHave2.SelectedIndex = 0;
        }
        private void txtRoomHave2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtRoomHave2.SelectedItem != null)
            {
                string selectedRoomNo = txtRoomHave2.SelectedItem.ToString();
                var ds = roomService.GetRoomInfo(selectedRoomNo);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPricePresent.Text = ds.Tables[0].Rows[0]["price"].ToString();
                }
                else
                {
                    txtPricePresent.Text = "Không tìm thấy";
                }
            }
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            if (txtRoomHave.SelectedItem != null)
            {
                string selectedRoomNo = txtRoomHave.SelectedItem.ToString();
                var ds = roomService.GetRoomInfo(selectedRoomNo);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPricePresent.Text = ds.Tables[0].Rows[0]["price"].ToString();
                }
                else
                {
                    txtPricePresent.Text = "Không tìm thấy";
                }
            }
            LoadRoom();
        }

        private void txtRoomHave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtRoomHave.SelectedItem != null)
            {
                // Lấy số phòng đã chọn từ ComboBox
                string selectedRoomNo = txtRoomHave.SelectedItem.ToString();

                // Gọi đến BusinessLayer để lấy thông tin phòng
                var ds = roomService.GetRoomInfo(selectedRoomNo);

            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            // Lấy số phòng đã chọn từ ComboBox
            string selectedRoomNo = txtRoomHave.SelectedItem.ToString();

            // Lấy các giá trị từ các TextBox
            string roomType = txtRoomType1.Text;
            string bedType = txtBedType1.Text;
            string bookedStatus = txtBooked.Text;

            // Tạo đối tượng RoomDTO để chứa các thông tin đã thay đổi
            RoomDTO room = new RoomDTO
            {
                RoomNo = selectedRoomNo,
                RoomType = roomType,
                Bed = bedType,
                Booked = bookedStatus
            };

            // Gọi đến BusinessLayer để cập nhật thông tin phòng
            RoomServiceBL roomService = new RoomServiceBL();
            roomService.UpdateRoomInfo(room); // Cập nhật thông tin phòng

            MessageBox.Show("Thông tin phòng đã được cập nhật!");
            LoadRoom();
        }
    }
}
