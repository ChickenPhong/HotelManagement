using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class RoomServiceBL
    {
        Function fn = new Function();

        public List<Room> GetAllRooms()
        {
            var list = new List<Room>();
            DataSet ds = fn.getData("SELECT * FROM rooms");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Room
                {
                    RoomId = Convert.ToInt32(row["roomid"]),
                    RoomNo = row["roomNo"].ToString(),
                    RoomType = row["roomType"].ToString(),
                    Bed = row["bed"].ToString(),
                    Price = Convert.ToInt64(row["price"])
                });
            }

            return list;
        }

        public void AddRoom(Room room)
        {
            string query = $"INSERT INTO rooms (roomNo, roomType, bed, price) VALUES ('{room.RoomNo}', '{room.RoomType}', '{room.Bed}', {room.Price})";
            fn.setData(query, "Thêm phòng thành công");
        }
    }
}
