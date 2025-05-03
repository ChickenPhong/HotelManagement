using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class CustomerServiceBL
    {
        CustomerServiceDL dataAccessCustomer = new CustomerServiceDL();
        //Function fn = new Function();

        // Lấy toàn bộ danh sách khách hàng
        //UC_CustomerRes
        public DataTable GetAllCustomers()
        {
            
            return dataAccessCustomer.GetAllCustomers();
        }

        //// Lấy khách chưa checkout

        public DataTable GetCheckedInCustomers()
        {
            return dataAccessCustomer.GetCheckedInCustomers();
        }

        //// Lấy khách đã checkout
        //public DataTable GetCheckedOutCustomers()
        //{
        //    string query = "SELECT * FROM customer WHERE checkout IS NOT NULL";
        //    return fn.getData(query).Tables[0];
        //}
        // Lấy khách đã checkout
        public DataTable GetCheckedOutCustomers()
        {
            return dataAccessCustomer.GetCheckedOutCustomers();
        }

        //// Trả phòng (checkout)
        //public void CheckOutCustomer(int cid, string checkoutDate, string roomNo)
        //{
        //    string query = $"UPDATE customer SET chekout = 'YES', checkout = '{checkoutDate}' WHERE cid = {cid}; " +
        //                   $"UPDATE rooms SET booked = 'NO' WHERE roomNo = '{roomNo}'";
        //    fn.setData(query, "Thanh toán thành công");
        //}
        // Trả phòng (checkout)
        public void CheckOutCustomer(int cid, string checkoutDate, string roomNo)
        {
            dataAccessCustomer.CheckOutCustomer(cid, checkoutDate, roomNo);
        }

        // Đăng ký khách vào phòng
        //UC_CustomerRes
        public void AllotCustomer(string name, long mobile, string nationality, string gender, string dob,
                                  string idproof, string address, string checkin, int roomId, string roomNo)
        {
            dataAccessCustomer.AllotCustomer(name, mobile, nationality, gender, dob, idproof, address, checkin, roomId, roomNo);
        }

        public void CancelCustomerByRoom(string roomNo)
        {
            dataAccessCustomer.CancelCustomerByRoom(roomNo);
        }

        //UC_CustomerRes
        public void CancelCustomerByRoomId(string roomId)
        {
            dataAccessCustomer.CancelCustomerByRoomId(roomId);
        }

        // Lấy danh sách phòng trống theo loại giường và loại phòng
        //UC_CustomerRes
        public DataTable GetAvailableRooms(string bed, string roomType)
        {
            return dataAccessCustomer.GetAvailableRooms(bed, roomType);
        }

        // Lấy giá tiền và roomid theo roomNo
        //UC_CustomerRequest
        //UC_CustomerRes
        public (int Price, int RoomId) GetRoomInfo(string roomNo)
        {
            DataSet ds = dataAccessCustomer.GetRoomInfo(roomNo);
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

        //UC_CustomerDetail
        public DataTable GetCustomerDetails(string filterOption)
        {
            return dataAccessCustomer.GetCustomerDetails(filterOption);
        }

        //UC_CheckOut
        public DataTable GetActiveCustomerRoomInfo()
        {
            return dataAccessCustomer.GetActiveCustomerRoomInfo();

        }

        //UC_CheckOut
        //UC_CustomerRes
        public DataTable SearchCustomerByName(string name)
        {
            return dataAccessCustomer.SearchCustomerByName(name);
        }

        // Trả về số ngày ở của khách
        //UC_CheckOut
        public int GetTotalDayStay(int cid, DateTime checkoutDate)
        {

            return dataAccessCustomer.GetTotalDayStay(cid, checkoutDate);
        }

        // Lấy giá phòng theo roomid
        //UC_CheckOut
        public long GetRoomPrice(int roomid)
        {
            return dataAccessCustomer.GetRoomPrice(roomid);
        }

        //UC_CheckOut
        public void CheckOut(int customerId, string checkoutDate, int roomid)
        {
            dataAccessCustomer.CheckOut(customerId, checkoutDate, roomid);
        }

        //UC_CustomerRequest
        public void AddCustomerRequest(string roomNo, string request, string employee, string status)
        {
            dataAccessCustomer.AddCustomerRequest(roomNo, request, employee, status);
        }

        //UC_CustomerRequest
        public DataTable GetAllCustomerRequest()
        {
            return dataAccessCustomer.GetAllCustomerRequest();
        }

        // Tìm kiếm phòng khách yêu cầu
        //UC_CustomerRequest
        public DataTable SearchCustomerRequest()
        {
            return dataAccessCustomer.SearchCustomerRequest();
        }
    }
}
