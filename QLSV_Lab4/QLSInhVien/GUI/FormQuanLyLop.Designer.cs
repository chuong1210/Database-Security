namespace QLSInhVien.GUI
{
    partial class FormQuanLyLop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanLyLop));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQlSV = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.txt_tenlh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.data_nhanvien = new System.Windows.Forms.DataGridView();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txt_malop = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.MaLH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.data_nhanvien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, -38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 26);
            this.label1.TabIndex = 72;
            this.label1.Text = "DANH MỤC NHÂN VIÊN";
            // 
            // btnQlSV
            // 
            this.btnQlSV.BackColor = System.Drawing.Color.Transparent;
            this.btnQlSV.BackgroundImage = global::QLSInhVien.Properties.Resources.wp7124745;
            this.btnQlSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQlSV.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQlSV.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.btnQlSV.Location = new System.Drawing.Point(775, 197);
            this.btnQlSV.Name = "btnQlSV";
            this.btnQlSV.Size = new System.Drawing.Size(112, 84);
            this.btnQlSV.TabIndex = 94;
            this.btnQlSV.Text = "Quản lý nhân viên";
            this.btnQlSV.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(209, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 22);
            this.label9.TabIndex = 93;
            this.label9.Text = "Thông tin lớp học";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(627, 611);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(79, 49);
            this.btnsave.TabIndex = 92;
            this.btnsave.Text = "Ghi/Lưu";
            this.btnsave.UseVisualStyleBackColor = true;
            // 
            // txt_tenlh
            // 
            this.txt_tenlh.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_tenlh.Location = new System.Drawing.Point(314, 296);
            this.txt_tenlh.Name = "txt_tenlh";
            this.txt_tenlh.Size = new System.Drawing.Size(345, 28);
            this.txt_tenlh.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 89;
            this.label3.Text = "Tên Lớp học:";
            // 
            // btn_thoat
            // 
            this.btn_thoat.BackColor = System.Drawing.Color.Transparent;
            this.btn_thoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_thoat.BackgroundImage")));
            this.btn_thoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_thoat.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_thoat.ForeColor = System.Drawing.Color.Sienna;
            this.btn_thoat.Location = new System.Drawing.Point(775, 389);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(112, 84);
            this.btn_thoat.TabIndex = 87;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = false;
            // 
            // data_nhanvien
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_nhanvien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_nhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_nhanvien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLH,
            this.TenLop,
            this.MaNV});
            this.data_nhanvien.ContextMenuStrip = this.contextMenuStrip1;
            this.data_nhanvien.GridColor = System.Drawing.Color.SteelBlue;
            this.data_nhanvien.Location = new System.Drawing.Point(199, 355);
            this.data_nhanvien.Name = "data_nhanvien";
            this.data_nhanvien.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_nhanvien.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_nhanvien.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_nhanvien.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.data_nhanvien.RowTemplate.Height = 24;
            this.data_nhanvien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_nhanvien.Size = new System.Drawing.Size(524, 211);
            this.data_nhanvien.TabIndex = 86;
            this.data_nhanvien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_nhanvien_CellClick);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(487, 611);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(79, 49);
            this.btnsua.TabIndex = 85;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(349, 611);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(79, 49);
            this.btnxoa.TabIndex = 84;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(219, 611);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(79, 49);
            this.btnthem.TabIndex = 83;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txt_malop
            // 
            this.txt_malop.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_malop.Location = new System.Drawing.Point(314, 253);
            this.txt_malop.Name = "txt_malop";
            this.txt_malop.Size = new System.Drawing.Size(345, 28);
            this.txt_malop.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 78;
            this.label7.Text = "Mã lớp học:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 75;
            this.label4.Text = "Mã nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(438, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 29);
            this.label6.TabIndex = 73;
            this.label6.Text = "QUẢN LÝ LỚP HỌC";
            // 
            // cboNV
            // 
            this.cboNV.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(314, 209);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(345, 29);
            this.cboNV.TabIndex = 95;
            // 
            // MaLH
            // 
            this.MaLH.FillWeight = 79.61784F;
            this.MaLH.HeaderText = "Mã lớp học";
            this.MaLH.MinimumWidth = 6;
            this.MaLH.Name = "MaLH";
            this.MaLH.Visible = false;
            this.MaLH.Width = 125;
            // 
            // TenLop
            // 
            this.TenLop.FillWeight = 78.99979F;
            this.TenLop.HeaderText = "Tên lớp";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            this.TenLop.Visible = false;
            this.TenLop.Width = 124;
            // 
            // MaNV
            // 
            this.MaNV.FillWeight = 141.3824F;
            this.MaNV.HeaderText = "Mã nhân viên phụ trách";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.Visible = false;
            this.MaNV.Width = 222;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::QLSInhVien.Properties.Resources.wp7124745;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.Location = new System.Drawing.Point(775, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 84);
            this.button1.TabIndex = 96;
            this.button1.Text = "Quản lý sinh viên";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormQuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 802);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.btnQlSV);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txt_tenlh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.data_nhanvien);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.txt_malop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "FormQuanLyLop";
            this.Text = "FormQuanLyLop";
            this.Load += new System.EventHandler(this.FormQuanLyLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_nhanvien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQlSV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txt_tenlh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.DataGridView data_nhanvien;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txt_malop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}