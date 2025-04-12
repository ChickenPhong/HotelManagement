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
    }
}
