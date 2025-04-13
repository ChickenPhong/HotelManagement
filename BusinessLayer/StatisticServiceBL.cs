using DataLayer;
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
    public class StatisticServiceBL
    {
        StatisticServiceDL statisticDL = new StatisticServiceDL();

        public int GetTotalRoom()
        {
            return statisticDL.GetTotalRoom();
        }

        public int GetTotalCustomer()
        {
            return statisticDL.GetTotalCustomer();
        }

        public int GetTotalRevenue()
        {
            // Nếu không có khách nào checkout thì doanh thu = 0
            return statisticDL.GetTotalRevenue();
        }

        // Tổng khách checkout trong ngày
        public int GetTotalCustomerByDay(DateTime date)
        {
            return statisticDL.GetTotalCustomerByDay(date);
        }

        // Tổng khách checkout trong tháng
        public int GetTotalCustomerByMonth(DateTime date)
        {
            return statisticDL.GetTotalCustomerByMonth(date);
        }

        // Tổng khách checkout trong quý
        public int GetTotalCustomerByQuarter(DateTime date)
        {
            return statisticDL.GetTotalCustomerByQuarter(date);
        }

        // Tổng khách checkout trong năm
        public int GetTotalCustomerByYear(DateTime date)
        {
            return statisticDL.GetTotalCustomerByYear(date);
        }

        // Doanh thu trong ngày
        public int GetTotalRevenueByDay(DateTime date)
        {
            return statisticDL.GetTotalRevenueByDay(date);
        }

        // Doanh thu trong tháng
        public int GetTotalRevenueByMonth(DateTime date)
        {
            return statisticDL.GetTotalRevenueByMonth(date);
        }

        // Doanh thu trong quý
        public int GetTotalRevenueByQuarter(DateTime date)
        {
            return statisticDL.GetTotalRevenueByQuarter(date);
        }

        // Doanh thu trong năm
        public int GetTotalRevenueByYear(DateTime date)
        {
            return statisticDL.GetTotalRevenueByYear(date);
        }

        //hàm lấy doanh thu 3 tháng theo quý
        public List<int> GetRevenueByQuarter(DateTime date)
        {
            return statisticDL.GetRevenueByQuarter(date);
        }

        //hàm lấy doanh thu theo từng tháng
        public List<int> GetRevenueByYear(DateTime date)
        {
            return statisticDL.GetRevenueByYear(date);
        }
    }
}
