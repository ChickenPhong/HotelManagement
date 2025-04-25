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

        public string GetRoleByUsername(string username)
        {
            return employeeServiceDL.GetRoleByUsername(username);
        }

        public int GetNextEmployeeId()
        {
            DataSet ds = employeeServiceDL.GetNextEmployeeId();

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
            }

            return 1;
        }

        //public void RegisterEmployee(string name, long mobile, string gender, string email, string username, string pass)
        //{
        //    string query = $"INSERT INTO employee (ename, mobile, gender, emailid, username, pass) VALUES ('{name}', {mobile}, '{gender}', '{email}', '{username}', '{pass}')";
        //    fn.setData(query, "Đăng ký nhân viên thành công!!");
        //}
        public void RegisterEmployee(string name, long mobile, string gender, string email, string username, string pass, string role)
        {
            //employeeServiceDL.RegisterEmployee(name, mobile, gender, email, username, pass, role);
            string hashedPass = HashPassword(pass); // Băm mật khẩu
            employeeServiceDL.RegisterEmployee(name, mobile, gender, email, username, hashedPass, role);
        }

        //public DataTable GetAllEmployees()
        //{
        //    string query = "SELECT * FROM employee";
        //    return fn.getData(query).Tables[0];
        //}
        public DataTable GetAllEmployees()
        {
            return employeeServiceDL.GetAllEmployees();
        }

        //public void DeleteEmployee(int id)
        //{
        //    string query = $"DELETE FROM employee WHERE eid = {id}";
        //    fn.setData(query, "Nhân viên đã được xóa!!");
        //}

        
        public void DeleteEmployeeByName(string name)
        {
            employeeServiceDL.DeleteEmployeeByName(name);
        }

    }
}
