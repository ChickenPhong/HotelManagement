using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CustomerServiceDL
    {
        DataProvider fn = new DataProvider();

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
                           $"VALUES (N'{name}', {mobile}, N'{nationality}', N'{gender}', N'{dob}', N'{idproof}', N'{address}', '{checkin}', {roomId}); " +
                           $"UPDATE rooms SET booked = 'YES' WHERE roomNo = '{roomNo}'";
            fn.setData(query, $"Số Phòng {roomNo} Đăng ký khách hàng thành công.");
        }

        public void CancelCustomerByRoom(string roomNo)
        {
            // Xóa khách có phòng tương ứng
            string deleteQuery = $"DELETE FROM customer WHERE roomid = (SELECT roomid FROM rooms WHERE roomNo = '{roomNo}')";
            fn.setData(deleteQuery, "Đã hủy khách hàng");

            // Cập nhật trạng thái phòng thành "NO"
            string updateRoom = $"UPDATE rooms SET booked = 'NO' WHERE roomNo = '{roomNo}'";
            fn.setData(updateRoom, "Đã cập nhật trạng thái phòng");
        }

        public void CancelCustomerByRoomId(string roomId)
        {
            string deleteQuery = $"DELETE FROM customer WHERE roomid = {roomId}";
            fn.setData(deleteQuery, "Đã hủy khách hàng");

            string updateRoom = $"UPDATE rooms SET booked = 'NO' WHERE roomid = {roomId}";
            fn.setData(updateRoom, "Đã cập nhật trạng thái phòng");
        }

        // Lấy danh sách phòng trống theo loại giường và loại phòng
        public DataTable GetAvailableRooms(string bed, string roomType)
        {
            string query = $"SELECT roomNo FROM rooms WHERE bed = N'{bed}' AND roomType = N'{roomType}' AND booked = 'NO'";
            return fn.getData(query).Tables[0];
        }

        // Lấy giá tiền và roomid theo roomNo
        public DataSet GetRoomInfo(string roomNo)
        {
            string query = $"SELECT price, roomid FROM rooms WHERE roomNo = '{roomNo}'";
            return fn.getData(query);
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
            string query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomid, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE chekout = 'NO'";
            return fn.getData(query).Tables[0];
        }

        public DataTable SearchCustomerByName(string name)
        {
            string query = $"SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomid, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE cname LIKE N'{name}%' AND chekout = 'NO'";
            return fn.getData(query).Tables[0];
        }

        // Trả về số ngày ở của khách
        public int GetTotalDayStay(int cid, DateTime checkoutDate)
        {
            string query = $"SELECT checkin, checkout FROM customer WHERE cid = {cid}";
            DataSet ds = fn.getData(query);
            // Kiểm tra nếu dữ liệu NULL thì return 0
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime checkin = Convert.ToDateTime(ds.Tables[0].Rows[0]["checkin"]);

                // Nếu checkout trong db có giá trị thì lấy
                if (ds.Tables[0].Rows[0]["checkout"] != DBNull.Value)
                {
                    checkoutDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["checkout"]);
                }

                int totalDay = (checkoutDate - checkin).Days + 1;
                return totalDay > 0 ? totalDay : 1; // Đề phòng trường hợp dữ liệu sai
            }
            else
            {
                return 0;
            }
        }

        // Lấy giá phòng theo roomid
        public long GetRoomPrice(int roomid)
        {
            string query = $"SELECT price FROM rooms WHERE roomid = {roomid}";
            DataSet ds = fn.getData(query);
            return Convert.ToInt64(ds.Tables[0].Rows[0][0]);
        }

        public void CheckOut(int customerId, string checkoutDate, int roomId)
        {
            string query = $"UPDATE customer SET chekout = 'YES', checkout = '{checkoutDate}' WHERE cid = {customerId}; " +
                   $"UPDATE rooms SET booked = 'NO' WHERE roomid = '{roomId}'";

            fn.setData(query, "Thanh toán thành công");
        }

        public void AddCustomerRequest(string roomNo, string request, string employee, string status)
        {
            string query = $"INSERT INTO customerRequest (RoomNo, Request, EmployeeName, Status) VALUES ('{roomNo}', N'{request}', N'{employee}', N'{status}')";
            fn.setData(query, "Yêu cầu đã được thêm vào.");
        }

        public DataTable GetAllCustomerRequest()
        {
            string query = "SELECT * FROM customerRequest ORDER BY Id DESC";
            return fn.getData(query).Tables[0];
        }

        // Tìm kiếm phòng khách yêu cầu
        public DataTable SearchCustomerRequest()
        {
            string query = "SELECT * FROM rooms WHERE booked = 'YES'";
            return fn.getData(query).Tables[0];
        }
    }
}
