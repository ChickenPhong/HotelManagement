using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; // thư viện dùng cho băm mật khẩu
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class EmployeeServiceBL
    {
        //Function fn = new Function();

        EmployeeServiceDL employeeServiceDL = new EmployeeServiceDL();

        public bool CheckLogin(string username, string password)
        {
            //DataSet ds = employeeServiceDL.CheckLogin(username, password);
            string hashedPassword = HashPassword(password); // Băm mật khẩu nhập vào
            DataSet ds = employeeServiceDL.CheckLogin(username, hashedPassword);
            return ds.Tables[0].Rows.Count > 0;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        //Form DangNhap
        public string GetRoleByUsername(string username)
        {
            return employeeServiceDL.GetRoleByUsername(username);
        }

        //Form DangNhap
        public EmployeeDTO GetEmployeeByUsername(string username)
        {
            return employeeServiceDL.GetEmployeeByUsername(username);
        }

        //UC_Employee
        public int GetNextEmployeeId()
        {
            DataSet ds = employeeServiceDL.GetNextEmployeeId();

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
            }

            return 1;
        }

        //UC_Employee
        public void RegisterEmployee(string name, long mobile, string gender, string email, string username, string pass, string role)
        {
            //employeeServiceDL.RegisterEmployee(name, mobile, gender, email, username, pass, role);
            string hashedPass = HashPassword(pass); // Băm mật khẩu
            employeeServiceDL.RegisterEmployee(name, mobile, gender, email, username, hashedPass, role);
        }

        //UC_CustomerRequest
        //UC_Employee
        public DataTable GetAllEmployees()
        {
            return employeeServiceDL.GetAllEmployees();
        }


        //UC_Employee
        public void DeleteEmployeeByName(string name)
        {
            employeeServiceDL.DeleteEmployeeByName(name);
        }

        //Form ThayMatKhau
        public bool CheckPassword(string username, string password)
        {
            string hashed = HashPassword(password); // Băm mật khẩu cũ
            return employeeServiceDL.CheckPassword(username, hashed);
        }

        //Form ThayMatKhau
        public bool UpdatePassword(string username, string newPassword)
        {
            string hashedNewPass = HashPassword(newPassword); // Băm mật khẩu mới
            return employeeServiceDL.UpdatePassword(username, hashedNewPass);
        }
    }
}
