using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class EmployeeServiceBL
    {
        Function fn = new Function();

        EmployeeServiceDL employeeServiceDL = new EmployeeServiceDL();

        public bool CheckLogin(string username, string password)
        {
            string query = $"SELECT username, pass FROM employee WHERE username = '{username}' AND pass = '{password}'";
            DataSet ds = employeeServiceDL.CheckLogin(query);
            return ds.Tables[0].Rows.Count > 0;
        }

        public int GetNextEmployeeId()
        {
            string query = "SELECT MAX(eid) FROM employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
            }

            return 1;
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
