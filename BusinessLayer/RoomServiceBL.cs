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

        public List<RoomDTO> GetAllRooms()
        {
            return roomDL.GetAllRooms();
        }

        public void AddRoom(RoomDTO room)
        {
            roomDL.AddRoom(room);
        }
    }
}
