using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class RoomServiceDL
    {
        Function fn = new Function();

        public List<RoomDTO> GetAllRooms()
        {
            var list = new List<RoomDTO>();
            DataSet ds = fn.getData("SELECT * FROM rooms");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new RoomDTO
                {
                    RoomId = Convert.ToInt32(row["roomid"]),
                    RoomNo = row["roomNo"].ToString(),
                    RoomType = row["roomType"].ToString(),
                    Bed = row["bed"].ToString(),
                    Price = Convert.ToInt64(row["price"]),
                    Booked = row["booked"].ToString()
                });
            }

            return list;
        }

        public void AddRoom(RoomDTO room)
        {
            string query = $"INSERT INTO rooms (roomNo, roomType, bed, price) VALUES ('{room.RoomNo}', N'{room.RoomType}', N'{room.Bed}', {room.Price})";
            fn.setData(query, "Thêm phòng thành công");
        }
        public void DeleteRoom(int roomId)
        {
            string query = $"DELETE FROM rooms WHERE roomid = {roomId}";
            fn.setData(query, "Đã xóa phòng thành công");
        }

        public DataSet GetRoomInfo(string roomNo)
        {
            string query = $"SELECT price FROM rooms WHERE roomNo = '{roomNo}'";
            return fn.getData(query);
        }

        public void UpdateRoomPrice(string roomNo, long newPrice)
        {
            string query = $"UPDATE rooms SET price = {newPrice} WHERE roomNo = '{roomNo}'";
            fn.setData(query, "Đã cập nhật giá phòng.");
        }
        public void UpdateRoomInfo(RoomDTO room)
        {
            string query = $"UPDATE rooms SET roomType = N'{room.RoomType}', bed = N'{room.Bed}', booked = N'{room.Booked}' WHERE roomNo = '{room.RoomNo}'";
            fn.setData(query, "Đã cập nhật thông tin phòng.");  // Cập nhật cơ sở dữ liệu
        }
    }
}
