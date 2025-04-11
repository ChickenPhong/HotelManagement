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

        public DataSet CheckLogin(string query)
        {
            return fn.getData(query);
        }
    }
}
