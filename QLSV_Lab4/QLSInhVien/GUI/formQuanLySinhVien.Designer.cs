namespace QLSInhVien.GUI
{
    partial class formQuanLySinhVien
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formQuanLySinhVien));
            this.btnQlSV = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMATKHAU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.data_sinhvien = new System.Windows.Forms.DataGridView();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtDIACHI = new System.Windows.Forms.TextBox();
            this.txtTENDN = new System.Windows.Forms.TextBox();
            this.txtHOTEN = new System.Windows.Forms.TextBox();
            this.txtMASV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDM = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNGAYSINH = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.data_sinhvien)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQlSV
            // 
            this.btnQlSV.BackColor = System.Drawing.Color.Transparent;
            this.btnQlSV.BackgroundImage = global::QLSInhVien.Properties.Resources.wp7124745;
            this.btnQlSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQlSV.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQlSV.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.btnQlSV.Location = new System.Drawing.Point(737, 567);
            this.btnQlSV.Name = "btnQlSV";
            this.btnQlSV.Size = new System.Drawing.Size(144, 84);
            this.btnQlSV.TabIndex = 93;
            this.btnQlSV.Text = "Quản lý lớp học";
            this.btnQlSV.UseVisualStyleBackColor = false;
            this.btnQlSV.Click += new System.EventHandler(this.btnQlSV_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 92;
            this.label9.Text = "Thông tin sinh viên";
            // 
            // txtMATKHAU
            // 
            this.txtMATKHAU.Location = new System.Drawing.Point(707, 252);
            this.txtMATKHAU.Name = "txtMATKHAU";
            this.txtMATKHAU.Size = new System.Drawing.Size(248, 22);
            this.txtMATKHAU.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 88;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(600, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 87;
            this.label8.Text = "Mật khẩu:";
            // 
            // btn_thoat
            // 
            this.btn_thoat.BackColor = System.Drawing.Color.Transparent;
            this.btn_thoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_thoat.BackgroundImage")));
            this.btn_thoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_thoat.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_thoat.ForeColor = System.Drawing.Color.Sienna;
            this.btn_thoat.Location = new System.Drawing.Point(904, 567);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(97, 84);
            this.btn_thoat.TabIndex = 86;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = false;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // data_sinhvien
            // 
            this.data_sinhvien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.data_sinhvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_sinhvien.Location = new System.Drawing.Point(195, 311);
            this.data_sinhvien.Name = "data_sinhvien";
            this.data_sinhvien.RowHeadersWidth = 51;
            this.data_sinhvien.RowTemplate.Height = 24;
            this.data_sinhvien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_sinhvien.Size = new System.Drawing.Size(844, 211);
            this.data_sinhvien.TabIndex = 85;
            this.data_sinhvien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_sinhvien_CellClick);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(483, 567);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(107, 84);
            this.btnsua.TabIndex = 84;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(345, 567);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(107, 84);
            this.btnxoa.TabIndex = 83;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(215, 567);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(107, 84);
            this.btnthem.TabIndex = 82;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtDIACHI
            // 
            this.txtDIACHI.Location = new System.Drawing.Point(707, 209);
            this.txtDIACHI.Name = "txtDIACHI";
            this.txtDIACHI.Size = new System.Drawing.Size(248, 22);
            this.txtDIACHI.TabIndex = 81;
            // 
            // txtTENDN
            // 
            this.txtTENDN.Location = new System.Drawing.Point(310, 255);
            this.txtTENDN.Name = "txtTENDN";
            this.txtTENDN.Size = new System.Drawing.Size(248, 22);
            this.txtTENDN.TabIndex = 80;
            // 
            // txtHOTEN
            // 
            this.txtHOTEN.Location = new System.Drawing.Point(707, 168);
            this.txtHOTEN.Name = "txtHOTEN";
            this.txtHOTEN.Size = new System.Drawing.Size(248, 22);
            this.txtHOTEN.TabIndex = 79;
            // 
            // txtMASV
            // 
            this.txtMASV.Location = new System.Drawing.Point(310, 168);
            this.txtMASV.Name = "txtMASV";
            this.txtMASV.Size = new System.Drawing.Size(248, 22);
            this.txtMASV.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 77;
            this.label7.Text = "Ngày sinh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 75;
            this.label5.Text = "Họ tên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "Mã sinh viên:";
            // 
            // lbDM
            // 
            this.lbDM.AutoSize = true;
            this.lbDM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDM.Location = new System.Drawing.Point(210, 62);
            this.lbDM.Name = "lbDM";
            this.lbDM.Size = new System.Drawing.Size(266, 26);
            this.lbDM.TabIndex = 73;
            this.lbDM.Text = "DANH MỤC SINH VIÊN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 76;
            this.label6.Text = "Địa chỉ:";
            // 
            // dtpNGAYSINH
            // 
            this.dtpNGAYSINH.Location = new System.Drawing.Point(310, 215);
            this.dtpNGAYSINH.Name = "dtpNGAYSINH";
            this.dtpNGAYSINH.Size = new System.Drawing.Size(248, 22);
            this.dtpNGAYSINH.TabIndex = 94;
            // 
            // formQuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 715);
            this.Controls.Add(this.dtpNGAYSINH);
            this.Controls.Add(this.btnQlSV);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMATKHAU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.data_sinhvien);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.txtDIACHI);
            this.Controls.Add(this.txtTENDN);
            this.Controls.Add(this.txtHOTEN);
            this.Controls.Add(this.txtMASV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbDM);
            this.Controls.Add(this.label6);
            this.Name = "formQuanLySinhVien";
            this.Text = "formQuanLySinhVien";
            this.Load += new System.EventHandler(this.formQuanLySinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_sinhvien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQlSV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMATKHAU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.DataGridView data_sinhvien;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtDIACHI;
        private System.Windows.Forms.TextBox txtTENDN;
        private System.Windows.Forms.TextBox txtHOTEN;
        private System.Windows.Forms.TextBox txtMASV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNGAYSINH;
    }
}