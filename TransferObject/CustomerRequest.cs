using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    class CustomerRequest
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public string Request { get; set; }
        public string Employee { get; set; }
        //public string Status { get; set; }
    }
}
