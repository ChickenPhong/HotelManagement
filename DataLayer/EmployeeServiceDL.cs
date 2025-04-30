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
                           $"AND username = '{username}' AND pass = '{password}'" +
                           $"AND role IN (N'Quản lý', N'Nhân viên lễ tân')";

            return fn.getData(query);
        }

        public string GetRoleByUsername(string username)
        {
            string query = $"SELECT role FROM employee WHERE username = '{username}'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["role"].ToString();
            return "";
        }

        public DataSet GetNextEmployeeId()
        {
            string query = "SELECT MAX(eid) FROM employee";
            return fn.getData(query);
        }

        public void RegisterEmployee(string name, long mobile, string gender, string email, string username, string pass, string role)
        {
            string query = $"INSERT INTO employee (ename, mobile, gender, emailid, username, pass, role) VALUES (N'{name}', {mobile}, N'{gender}', N'{email}', N'{username}', N'{pass}', N'{role}')";
            fn.setData(query, "Đăng ký nhân viên thành công!!");
        }

        public DataTable GetAllEmployees()
        {
            string query = "SELECT * FROM employee";
            return fn.getData(query).Tables[0];
        }
        public void DeleteEmployeeByName(string name)
        {
            string query = $"DELETE FROM employee WHERE ename = N'{name}'";
            fn.setData(query, "Xóa nhân viên thành công!");
        }
    }
}
