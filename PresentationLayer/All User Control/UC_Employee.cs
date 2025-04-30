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
        EmployeeServiceBL employeeService = new EmployeeServiceBL();

        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            labelToSET.Text = employeeService.GetNextEmployeeId().ToString();
            LoadEmployeeNames();
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
            if(txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != ""&& txtEmail.Text != "" && txtRole.Text != "")
            {
                String role = txtRole.Text;

                // Nếu là quản lý hoặc lễ tân thì phải có username và password
                if ((role == "Quản lý" || role == "Nhân viên lễ tân") &&
                    (txtUsername.Text == "" || txtPassword.Text == ""))
                {
                    MessageBox.Show("Bạn phải nhập tên người dùng và mật khẩu cho vai trò này!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                String name = txtName.Text;
                long mobile = long.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String username = (role == "Quản lý" || role == "Nhân viên lễ tân") ? txtUsername.Text : "NULL";
                String pass = (role == "Quản lý" || role == "Nhân viên lễ tân") ? txtPassword.Text : "NULL";
                
                employeeService.RegisterEmployee(name, mobile, gender, email, username, pass, role);

                clearAll();
                labelToSET.Text = employeeService.GetNextEmployeeId().ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtRole.SelectedIndex = -1;
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

        private void txtRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtRole.SelectedItem != null)
            {
                string selectedRole = txtRole.SelectedItem.ToString();

                if (selectedRole == "Quản lý" || selectedRole == "Nhân viên lễ tân")
                {
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    txtUsername.BackColor = Color.White;
                    txtPassword.BackColor = Color.White;
                }
                else
                {
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.BackColor = Color.LightGray;
                    txtPassword.BackColor = Color.LightGray;
                }
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
            if (txtID.SelectedIndex > 0)
            {
                string name = txtID.SelectedItem.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{name}' không?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    employeeService.DeleteEmployeeByName(name);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo");

                    LoadEmployeeNames(); // load lại danh sách
                    tabEmployee_SelectedIndexChanged(this, null); // nếu bạn có
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo");
            }
        }
        private void LoadEmployeeNames()
        {
            txtID.Items.Clear();
            txtID.Items.Add("");

            DataTable dt = employeeService.GetAllEmployees();

            foreach (DataRow row in dt.Rows)
            {
                string name = row["ename"].ToString();
                txtID.Items.Add(name);
            }

            txtID.SelectedIndex = 0;
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
