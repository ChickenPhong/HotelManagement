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
            List<Room> rooms = roomService.GetAllRooms();
            DataGridView1.DataSource = rooms;

            // Ẩn cột RoomId cho dễ nhìn
            if (DataGridView1.Columns.Contains("RoomId"))
            {
                DataGridView1.Columns["RoomId"].Visible = false;
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                Room room = new Room
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
    }
}
