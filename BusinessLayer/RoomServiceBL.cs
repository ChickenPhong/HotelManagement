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
        RoomServiceDL roomDL = new RoomServiceDL();

        //UC_AddRoom
        public List<RoomDTO> GetAllRooms()
        {
            return roomDL.GetAllRooms();
        }

        //UC_AddRoom
        public void AddRoom(RoomDTO room)
        {
            roomDL.AddRoom(room);
        }

        //UC_AddRoom
        public DataSet GetRoomInfo(string roomNo)
        {
            return roomDL.GetRoomInfo(roomNo);
        }

        //UC_AddRoom
        public void UpdateRoomPrice(string roomNo, long newPrice)
        {
            roomDL.UpdateRoomPrice(roomNo, newPrice);
        }
        public void UpdateRoomInfo(RoomDTO room)
        {
            roomDL.UpdateRoomInfo(room);  // Gọi DataLayer để cập nhật thông tin phòng
        }

        //UC_AddRoom
        public void UpdateRoomNo(string oldRoomNo, string newRoomNo)
        {
            roomDL.UpdateRoomNo(oldRoomNo, newRoomNo);
        }

        //UC_AddRoom
        public void UpdateRoomBedType(string roomNo, string newBedType)
        {
            roomDL.UpdateRoomBedType(roomNo, newBedType);
        }

        //UC_AddRoom
        public void UpdateRoomType(string roomNo, string newRoomType)
        {
            roomDL.UpdateRoomType(roomNo, newRoomType);
        }

    }
}
