using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using BusinessLayer;
using QuanLyKhachSan;
using QuanLyKhachSan.All_User_Control;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        EmployeeServiceBL cs = new EmployeeServiceBL();

        public static string LoggedInUsername;
        public static string LoggedInRole;


        public Form1()
        {
            InitializeComponent();
        }

 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //if (cs.CheckLogin(txtUsername.Text, txtPassword.Text))
            if (cs.CheckLogin(username, password))
            {
                // Lưu lại thông tin đăng nhập
                LoggedInUsername = username;
                LoggedInRole = cs.GetRoleByUsername(username);

                DieuHuong tk = new DieuHuong(); 
                this.Hide();
                tk.Show();

            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }

    }
}
