using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string IdProof { get; set; }
        public string Address { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; } // có thể cho phép giá trị null
        public string CheckOutStatus { get; set; } // YES / NO
        public int RoomId { get; set; }

        public CustomerDTO() { }

        public CustomerDTO(int customerId, string customerName, string mobile, string nationality, string gender, DateTime dob, string idProof, string address, DateTime checkIn, DateTime? checkOut, string checkOutStatus, int roomId)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Mobile = mobile;
            Nationality = nationality;
            Gender = gender;
            Dob = dob;
            IdProof = idProof;
            Address = address;
            CheckIn = checkIn;
            CheckOut = checkOut;
            CheckOutStatus = checkOutStatus;
            RoomId = roomId;
        }
    }
}
