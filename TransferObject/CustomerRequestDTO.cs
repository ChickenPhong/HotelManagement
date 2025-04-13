using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class CustomerRequestDTO
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public string Request { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }

        public CustomerRequestDTO() { }

        public CustomerRequestDTO(int id, string roomNo, string request, string employeeName, string status)
        {
            Id = id;
            RoomNo = roomNo;
            Request = request;
            EmployeeName = employeeName;
            Status = status;
        }
    }
}
