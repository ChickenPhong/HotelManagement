﻿using System;
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
    public partial class Form1: Form
    {
        EmployeeServiceBL cs = new EmployeeServiceBL();
        String query;
        
        public Form1()
        {
            InitializeComponent();
        }

        public static string targetPage = "";


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cs.CheckLogin(txtUsername.Text, txtPassword.Text))
            {
                this.Hide();

                if (targetPage == "Dashboard")
                {
                    Dashboard dash = new Dashboard();
                    this.Hide();
                    dash.Show();
                }
                else if (targetPage == "ThongKe")
                {
                    ThongKe tk = new ThongKe(); // Form Thống Kê
                    this.Hide();
                    tk.Show();
                }
            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }

    }
}
