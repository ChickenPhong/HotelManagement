using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CustomerServiceBL
    {
        CustomerServiceDL dataAccessCustomer = new CustomerServiceDL();
        Function fn = new Function();

        // Lấy toàn bộ danh sách khách hàng
        public DataTable GetAllCustomers()
        {
            string query = "SELECT * FROM customer";
            return fn.getData(query).Tables[0];
        }

        // Lấy khách chưa checkout
        public DataTable GetCheckedInCustomers()
        {
            string query = "SELECT * FROM customer WHERE checkout IS NULL";
            return fn.getData(query).Tables[0];
        }

        // Lấy khách đã checkout
        public DataTable GetCheckedOutCustomers()
        {
            string query = "SELECT * FROM customer WHERE checkout IS NOT NULL";
            return fn.getData(query).Tables[0];
        }

        // Trả phòng (checkout)
        public void CheckOutCustomer(int cid, string checkoutDate, string roomNo)
        {
            string query = $"UPDATE customer SET chekout = 'YES', checkout = '{checkoutDate}' WHERE cid = {cid}; " +
                           $"UPDATE rooms SET booked = 'NO' WHERE roomNo = '{roomNo}'";
            fn.setData(query, "Thanh toán thành công");
        }

        // Đăng ký khách vào phòng
        public void AllotCustomer(string name, long mobile, string nationality, string gender, string dob,
                                  string idproof, string address, string checkin, int roomId, string roomNo)
        {
            string query = $"INSERT INTO customer (cname, mobile, nationality, gender, dob, idproof, address, checkin, roomid) " +
                           $"VALUES ('{name}', {mobile}, '{nationality}', '{gender}', '{dob}', '{idproof}', '{address}', '{checkin}', {roomId}); " +
                           $"UPDATE rooms SET booked = 'YES' WHERE roomNo = '{roomNo}'";
            fn.setData(query, $"Số Phòng {roomNo} Đăng ký khách hàng thành công.");
        }

        // Lấy danh sách phòng trống theo loại giường và loại phòng
        public DataTable GetAvailableRooms(string bed, string roomType)
        {
            string query = $"SELECT roomNo FROM rooms WHERE bed = '{bed}' AND roomType = '{roomType}' AND booked = 'NO'";
            return fn.getData(query).Tables[0];
        }

        // Lấy giá tiền và roomid theo roomNo
        public (int Price, int RoomId) GetRoomInfo(string roomNo)
        {
            string query = $"SELECT price, roomid FROM rooms WHERE roomNo = '{roomNo}'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int price = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                int roomId = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                return (price, roomId);
            }
            else
            {
                // Nếu không tìm thấy phòng trả về giá trị mặc định
                return (0, 0);
            }
        }

        public DataTable GetCustomerDetails(string filterOption)
        {
            string query;

            switch (filterOption)
            {
                case "All":
                    query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid";
                    break;

                case "Current":
                    query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE checkout IS NULL";
                    break;

                case "Past":
                    query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE checkout IS NOT NULL";
                    break;

                default:
                    throw new ArgumentException("Invalid filter option");
            }

            return fn.getData(query).Tables[0];
        }

        public DataTable GetActiveCustomerRoomInfo()
        {
            string query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE chekout = 'NO'";
            return fn.getData(query).Tables[0];
        }

        public DataTable SearchCustomerByName(string name)
        {
            string query = $"SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE cname LIKE '{name}%' AND chekout = 'NO'";
            return fn.getData(query).Tables[0];
        }

        public void CheckOut(int customerId, string checkoutDate, string roomNo)
        {
            string query = $"UPDATE customer SET chekout = 'YES', checkout = '{checkoutDate}' WHERE cid = {customerId}; " +
                   $"UPDATE rooms SET booked = 'NO' WHERE roomNo = '{roomNo}'";

            fn.setData(query, "Thanh toán thành công");
        }

        public void AddCustomerRequest(string roomNo, string request, string employee, string status)
        {
            string query = $"INSERT INTO customerRequest (RoomNo, Request, EmployeeName, Status) VALUES ('{roomNo}', '{request}', '{employee}', '{status}')";
            fn.setData(query, "Yêu cầu đã được thêm vào.");
        }

        //public DataTable GetAllCustomerRequest()
        //{
        //    string query = "SELECT * FROM customerRequest";
        //    return fn.getData(query).Tables[0];
        //}
        public DataTable GetAllCustomerRequest()
        {
            return dataAccessCustomer.GetAllCustomerRequest();
        }

        // Tìm kiếm phòng khách yêu cầu
        public DataTable SearchCustomerRequest()
        {
            string query = "SELECT * FROM rooms WHERE booked = 'YES'";
            return fn.getData(query).Tables[0];
        }
    }
}
