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
        Function fn = new Function();        
        public DataTable GetAllCustomerRequest()
        {
            string query = "SELECT * FROM customerRequest";
            return fn.getData(query).Tables[0];
        }
    }
}
