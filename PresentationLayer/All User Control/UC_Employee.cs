using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.All_User_Control
{
    public partial class UC_Employee: UserControl
    {
        EmployeeService employeeService = new EmployeeService();
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            labelToSET.Text = employeeService.GetNextEmployeeId().ToString();
        }

        // --------------------------------------
        //public void getMaxID()
        //{
        //    query = "select max(eid) from employee";
        //    DataSet ds = fn.getData(query);

        //    if (ds.Tables[0].Rows[0][0].ToString() != "")
        //    {
        //        Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
        //        labelToSET.Text = (num + 1).ToString();
        //    }
        //}

        private void btnRegistation_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != ""&& txtEmail.Text != "" && txtUsername.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                long mobile = long.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text;
                String pass = txtPassword.Text;

                employeeService.RegisterEmployee(name, mobile, gender, email, username, pass);

                clearAll();
                labelToSET.Text = employeeService.GetNextEmployeeId().ToString();
            }    
        }

        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 1)
            {
                dgvThongTinNhanVien.DataSource = employeeService.GetAllEmployees();
            } else if (tabEmployee.SelectedIndex == 2)
            {
                dgvXoaNhanVien.DataSource = employeeService.GetAllEmployees();
            }    
        }

        //public void setEmployee(DataGridView dgv)
        //{
        //    query = "select * from employee";
        //    DataSet ds = fn.getData(query);
        //    dgv.DataSource = ds.Tables[0];
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = int.Parse(txtID.Text);
                    employeeService.DeleteEmployee(id);
                    tabEmployee_SelectedIndexChanged(this, null);
                }    
            }    
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
