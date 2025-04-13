using System;
using System.Collections.Generic;
using System.Data;
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
                    Price = Convert.ToInt64(row["price"])
                });
            }

            return list;
        }

        public void AddRoom(RoomDTO room)
        {
            string query = $"INSERT INTO rooms (roomNo, roomType, bed, price) VALUES ('{room.RoomNo}', '{room.RoomType}', '{room.Bed}', {room.Price})";
            fn.setData(query, "Thêm phòng thành công");
        }
    }
}
