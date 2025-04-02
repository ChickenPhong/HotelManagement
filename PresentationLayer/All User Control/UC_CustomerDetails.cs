using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using BusinessLayer;

namespace PresentationLayer.All_User_Control
{
    public partial class UC_CustomerDetails: UserControl
    {
        CustomerService customerService = new CustomerService();
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = "";

            if (txtSearchBy.SelectedIndex == 0)
                filter = "All";
            else if (txtSearchBy.SelectedIndex == 1)
                filter = "Current";
            else if (txtSearchBy.SelectedIndex == 2)
                filter = "Past";

            DataTable dt = customerService.GetCustomerDetails(filter);
            guna2DataGridView1.DataSource = dt;
        }

        //private void getRecord(String query)
        //{
        //    DataSet ds = fn.getData(query);
        //    guna2DataGridView1.DataSource = ds.Tables[0];
        //}
    }
}
