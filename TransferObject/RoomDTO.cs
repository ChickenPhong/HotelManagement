using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public string Bed { get; set; }
        public long Price { get; set; }
        public string Booked { get; set; } // YES / NO

        public RoomDTO() { }

        public RoomDTO(int roomId, string roomNo, string roomType, string bed, long price, string booked)
        {
            RoomId = roomId;
            RoomNo = roomNo;
            RoomType = roomType;
            Bed = bed;
            Price = price;
            Booked = booked;
        }
    }
}
