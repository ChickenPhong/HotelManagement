namespace QuanLyKhachSan.All_User_Control
{
    partial class UC_CustomerRequest
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoomNo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRequest = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmployee = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddRequest = new Guna.UI2.WinForms.Guna2Button();
            this.dgvRequest = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Yêu Cầu Khách Hàng";
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.BackColor = System.Drawing.Color.Transparent;
            this.txtRoomNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomNo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoomNo.ForeColor = System.Drawing.Color.Black;
            this.txtRoomNo.ItemHeight = 30;
            this.txtRoomNo.Location = new System.Drawing.Point(39, 122);
            this.txtRoomNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(345, 36);
            this.txtRoomNo.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtRoomNo.TabIndex = 6;
            this.txtRoomNo.SelectedIndexChanged += new System.EventHandler(this.txtRoomNo_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 92);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 19);
            this.label12.TabIndex = 5;
            this.label12.Text = "Phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Yêu Cầu";
            // 
            // txtRequest
            // 
            this.txtRequest.BackColor = System.Drawing.Color.Transparent;
            this.txtRequest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRequest.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRequest.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRequest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRequest.ForeColor = System.Drawing.Color.Black;
            this.txtRequest.ItemHeight = 30;
            this.txtRequest.Items.AddRange(new object[] {
            "Khăn tắm",
            "Bàn chải đánh răng",
            "Dép",
            "Nước ngọt",
            "Rượu",
            "Dịch vụ giặt ủi",
            "Dọn phòng",
            "khác..."});
            this.txtRequest.Location = new System.Drawing.Point(39, 208);
            this.txtRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(345, 36);
            this.txtRequest.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtRequest.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 270);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nhân Viên";
            // 
            // txtEmployee
            // 
            this.txtEmployee.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEmployee.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmployee.ForeColor = System.Drawing.Color.Black;
            this.txtEmployee.ItemHeight = 30;
            this.txtEmployee.Location = new System.Drawing.Point(39, 299);
            this.txtEmployee.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.Size = new System.Drawing.Size(345, 36);
            this.txtEmployee.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtEmployee.TabIndex = 6;
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.BorderRadius = 18;
            this.btnAddRequest.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.btnAddRequest.BorderThickness = 1;
            this.btnAddRequest.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddRequest.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnAddRequest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRequest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRequest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddRequest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddRequest.FillColor = System.Drawing.Color.Blue;
            this.btnAddRequest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRequest.ForeColor = System.Drawing.Color.White;
            this.btnAddRequest.Location = new System.Drawing.Point(114, 378);
            this.btnAddRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(152, 57);
            this.btnAddRequest.TabIndex = 7;
            this.btnAddRequest.Text = "Thêm yêu cầu";
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // dgvRequest
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRequest.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRequest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequest.ColumnHeadersHeight = 4;
            this.dgvRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequest.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRequest.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRequest.Location = new System.Drawing.Point(438, 112);
            this.dgvRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRequest.Name = "dgvRequest";
            this.dgvRequest.ReadOnly = true;
            this.dgvRequest.RowHeadersVisible = false;
            this.dgvRequest.RowHeadersWidth = 62;
            this.dgvRequest.RowTemplate.Height = 28;
            this.dgvRequest.Size = new System.Drawing.Size(748, 404);
            this.dgvRequest.TabIndex = 8;
            this.dgvRequest.TabStop = false;
            this.dgvRequest.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRequest.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRequest.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRequest.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRequest.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRequest.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRequest.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRequest.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRequest.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRequest.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRequest.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRequest.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvRequest.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvRequest.ThemeStyle.ReadOnly = true;
            this.dgvRequest.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRequest.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRequest.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRequest.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRequest.ThemeStyle.RowsStyle.Height = 28;
            this.dgvRequest.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRequest.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // UC_CustomerRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRequest);
            this.Controls.Add(this.btnAddRequest);
            this.Controls.Add(this.txtEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRoomNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UC_CustomerRequest";
            this.Size = new System.Drawing.Size(1255, 554);
            this.Load += new System.EventHandler(this.UC_CustomerRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox txtRoomNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox txtRequest;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox txtEmployee;
        private Guna.UI2.WinForms.Guna2Button btnAddRequest;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRequest;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
