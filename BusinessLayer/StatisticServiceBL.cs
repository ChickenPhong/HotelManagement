using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StatisticServiceBL
    {
        Function fn = new Function();

        public int GetTotalRoom()
        {
            string query = "SELECT COUNT(*) FROM rooms";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        public int GetTotalCustomer()
        {
            string query = "SELECT COUNT(*) FROM customer";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        public int GetTotalRevenue()
        {
            string query = "SELECT SUM(price) FROM customer c JOIN rooms r ON c.roomid = r.roomid WHERE chekout = 'YES'";
            DataSet ds = fn.getData(query);
            // Nếu không có khách nào checkout thì doanh thu = 0
            return Convert.ToInt32(ds.Tables[0].Rows[0][0] == DBNull.Value ? 0 : ds.Tables[0].Rows[0][0]);
        }

        // Tổng khách checkout trong ngày
        public int GetTotalCustomerByDay(DateTime date)
        {
            string query = $"SELECT COUNT(*) FROM customer WHERE CAST(checkin AS DATE) = '{date.ToString("yyyy-MM-dd")}'";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        // Tổng khách checkout trong tháng
        public int GetTotalCustomerByMonth(DateTime date)
        {
            string query = $"SELECT COUNT(*) FROM customer WHERE MONTH(checkin) = {date.Month} AND YEAR(checkin) = {date.Year}";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        // Tổng khách checkout trong quý
        public int GetTotalCustomerByQuarter(DateTime date)
        {
            int quarter = (date.Month - 1) / 3 + 1;
            string query = $"SELECT COUNT(*) FROM customer WHERE DATEPART(QUARTER, checkin) = {quarter} AND YEAR(checkin) = {date.Year}";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        // Tổng khách checkout trong năm
        public int GetTotalCustomerByYear(DateTime date)
        {
            string query = $"SELECT COUNT(*) FROM customer WHERE YEAR(checkin) = {date.Year}";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        // Doanh thu trong ngày
        public int GetTotalRevenueByDay(DateTime date)
        {
            string query = $@"
                SELECT SUM((DATEDIFF(DAY, c.checkin, c.checkout)+ 1) * r.price)
                FROM customer c
                JOIN rooms r ON c.roomid = r.roomid
                WHERE c.chekout = 'YES'
                AND CAST(c.checkout AS DATE) = '{date:yyyy-MM-dd}'";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0] == DBNull.Value ? 0 : ds.Tables[0].Rows[0][0]);
        }

        // Doanh thu trong tháng
        public int GetTotalRevenueByMonth(DateTime date)
        {
            string query = $@"
                SELECT SUM((DATEDIFF(DAY, c.checkin, c.checkout)+ 1) * r.price)
                FROM customer c
                JOIN rooms r ON c.roomid = r.roomid
                WHERE c.chekout = 'YES'
                AND MONTH(c.checkout) = {date.Month}
                AND YEAR(c.checkout) = {date.Year}";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0] == DBNull.Value ? 0 : ds.Tables[0].Rows[0][0]);
        }

        // Doanh thu trong quý
        public int GetTotalRevenueByQuarter(DateTime date)
        {
            int quarter = (date.Month - 1) / 3 + 1;
            string query = $@"
                SELECT SUM((DATEDIFF(DAY, c.checkin, c.checkout)+ 1) * r.price)
                FROM customer c
                JOIN rooms r ON c.roomid = r.roomid
                WHERE c.chekout = 'YES'
                AND DATEPART(QUARTER, c.checkout) = {quarter}
                AND YEAR(c.checkout) = {date.Year}";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0] == DBNull.Value ? 0 : ds.Tables[0].Rows[0][0]);
        }

        // Doanh thu trong năm
        public int GetTotalRevenueByYear(DateTime date)
        {
            string query = $@"
                SELECT SUM((DATEDIFF(DAY, c.checkin, c.checkout)+ 1) * r.price)
                FROM customer c
                JOIN rooms r ON c.roomid = r.roomid
                WHERE c.chekout = 'YES'
                AND YEAR(c.checkout) = {date.Year}";
            DataSet ds = fn.getData(query);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0] == DBNull.Value ? 0 : ds.Tables[0].Rows[0][0]);
        }

        //hàm lấy doanh thu 3 tháng theo quý
        public List<int> GetRevenueByQuarter(DateTime date)
        {
            List<int> revenueList = new List<int>();
            int quy = (date.Month - 1) / 3 + 1;

            int startMonth = (quy - 1) * 3 + 1; // tháng bắt đầu của quý
            for (int i = 0; i < 3; i++)
            {
                DateTime month = new DateTime(date.Year, startMonth + i, 1);
                int revenue = GetTotalRevenueByMonth(month); // đã có sẵn
                revenueList.Add(revenue);
            }
            return revenueList;
        }

        //hàm lấy doanh thu theo từng tháng
        public List<int> GetRevenueByYear(DateTime date)
        {
            List<int> revenueList = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                DateTime month = new DateTime(date.Year, i, 1);
                int revenue = GetTotalRevenueByMonth(month); // đã có sẵn hàm này rồi
                revenueList.Add(revenue);
            }
            return revenueList;
        }
    }
}
