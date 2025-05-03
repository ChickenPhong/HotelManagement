using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class EmployeeServiceDL
    {
        DataProvider fn = new DataProvider();

        public DataSet CheckLogin(string username, string password)
        {
            string query = $"SELECT username, pass FROM employee " +
                           $"WHERE username IS NOT NULL AND pass IS NOT NULL " +
                           $"AND username != '' AND pass != '' " +
                           $"AND username = '{username}' AND pass = '{password}'" +
                           $"AND role IN (N'Quản lý', N'Nhân viên lễ tân')";

            return fn.getData(query);
        }

        //Form DangNhap
        public string GetRoleByUsername(string username)
        {
            string query = $"SELECT role FROM employee WHERE username = '{username}'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["role"].ToString();
            return "";
        }

        //Form DangNhap
        public EmployeeDTO GetEmployeeByUsername(string username)
        {
            string query = $"SELECT * FROM employee WHERE username = @username";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username", username)
            };

            DataSet ds = fn.getData(query, parameters); // đảm bảo bạn có overload getData(query, params)

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return new EmployeeDTO
                {
                    EmployeeId = Convert.ToInt32(row["eid"]),
                    EmployeeName = row["ename"].ToString(),
                    Mobile = row["mobile"].ToString(),
                    Gender = row["gender"].ToString(),
                    Email = row["emailid"].ToString(),
                    Username = row["username"].ToString(),
                    Password = row["pass"].ToString()
                };
            }

            return null;
        }

        //UC_Employee
        public DataSet GetNextEmployeeId()
        {
            string query = "SELECT MAX(eid) FROM employee";
            return fn.getData(query);
        }

        //UC_Employee
        public void RegisterEmployee(string name, long mobile, string gender, string email, string username, string pass, string role)
        {
            string query = $"INSERT INTO employee (ename, mobile, gender, emailid, username, pass, role) VALUES (N'{name}', {mobile}, N'{gender}', N'{email}', N'{username}', N'{pass}', N'{role}')";
            fn.setData(query, "Đăng ký nhân viên thành công!!");
        }

        //UC_CustomerRequest
        //UC_Employee
        public DataTable GetAllEmployees()
        {
            string query = "SELECT * FROM employee";
            return fn.getData(query).Tables[0];
        }


        //UC_Employee
        public void DeleteEmployeeByName(string name)
        {
            string query = $"DELETE FROM employee WHERE ename = N'{name}'";
            fn.setData(query, "Xóa nhân viên thành công!");
        }

        //Form ThayMatKhau
        public bool CheckPassword(string username, string password)
        {
            string query = $"SELECT * FROM employee WHERE username = N'{username}' AND pass = N'{password}'";
            DataSet ds = fn.getData(query);
            return ds.Tables[0].Rows.Count > 0;
        }

        //Form ThayMatKhau
        public bool UpdatePassword(string username, string newPassword)
        {
            string query = $"UPDATE employee SET pass = N'{newPassword}' WHERE username = N'{username}'";
            fn.setData(query, "Đã cập nhật mật khẩu.");
            return true;
        }
    }
}
