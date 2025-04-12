using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmployeeServiceDL
    {
        Function fn = new Function();

        //public DataSet CheckLogin(string query)
        //{
        //    return fn.getData(query);
        //}
        public DataSet CheckLogin(string username, string password)
        {
            string query = $"SELECT username, pass FROM employee " +
                           $"WHERE username IS NOT NULL AND pass IS NOT NULL " +
                           $"AND username != '' AND pass != '' " +
                           $"AND username = '{username}' AND pass = '{password}'";

            return fn.getData(query);
        }

        public DataSet GetNextEmployeeId()
        {
            string query = "SELECT MAX(eid) FROM employee";
            return fn.getData(query);
        }

        public void RegisterEmployee(string name, long mobile, string gender, string email, string username, string pass)
        {
            string query = $"INSERT INTO employee (ename, mobile, gender, emailid, username, pass) VALUES ('{name}', {mobile}, '{gender}', '{email}', '{username}', '{pass}')";
            fn.setData(query, "Đăng ký nhân viên thành công!!");
        }

        public DataTable GetAllEmployees()
        {
            string query = "SELECT * FROM employee";
            return fn.getData(query).Tables[0];
        }

        public void DeleteEmployee(int id)
        {
            string query = $"DELETE FROM employee WHERE eid = {id}";
            fn.setData(query, "Nhân viên đã được xóa!!");
        }
    }
}
