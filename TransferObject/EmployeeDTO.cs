using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public EmployeeDTO() { }

        public EmployeeDTO(int employeeId, string employeeName, string mobile, string gender, string email, string username, string password)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Mobile = mobile;
            Gender = gender;
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
