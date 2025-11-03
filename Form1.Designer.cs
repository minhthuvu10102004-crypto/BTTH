namespace QLNhaThuoc
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            label1 = new System.Windows.Forms.Label();
            FromDate = new System.Windows.Forms.DateTimePicker();
            ToDate = new System.Windows.Forms.DateTimePicker();
            txtSearch = new System.Windows.Forms.TextBox();
            tblDSHD = new System.Windows.Forms.DataGridView();
            Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            XemChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
            btnInHD = new System.Windows.Forms.Button();
            tblDsKhachHang = new System.Windows.Forms.DataGridView();
            fromdatelbl = new System.Windows.Forms.Label();
            todatelbl = new System.Windows.Forms.Label();
            btnTaoHD = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            btnrefresh = new System.Windows.Forms.Button();
            pnlloc = new System.Windows.Forms.Panel();
            sttKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            sdtKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dcKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)tblDSHD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tblDsKhachHang).BeginInit();
            pnlloc.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = System.Drawing.Color.FromArgb(66, 144, 242);
            label1.Name = "label1";
            // 
            // FromDate
            // 
            resources.ApplyResources(FromDate, "FromDate");
            FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            FromDate.Name = "FromDate";
            FromDate.Value = new System.DateTime(2025, 10, 1, 0, 0, 0, 0);
            // 
            // ToDate
            // 
            resources.ApplyResources(ToDate, "ToDate");
            ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            ToDate.Name = "ToDate";
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            txtSearch.Name = "txtSearch";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // tblDSHD
            // 
            tblDSHD.BackgroundColor = System.Drawing.Color.White;
            tblDSHD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            tblDSHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tblDSHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblDSHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Select, STT, MaHoaDon, DanhMuc, XemChiTiet });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            tblDSHD.DefaultCellStyle = dataGridViewCellStyle3;
            tblDSHD.GridColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(tblDSHD, "tblDSHD");
            tblDSHD.Name = "tblDSHD";
            tblDSHD.RowHeadersVisible = false;
            tblDSHD.RowTemplate.Height = 24;
            tblDSHD.CellContentClick += tblDSHD_CellClick;
            // 
            // Select
            // 
            resources.ApplyResources(Select, "Select");
            Select.Name = "Select";
            Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // STT
            // 
            resources.ApplyResources(STT, "STT");
            STT.Name = "STT";
            STT.ReadOnly = true;
            // 
            // MaHoaDon
            // 
            resources.ApplyResources(MaHoaDon, "MaHoaDon");
            MaHoaDon.Name = "MaHoaDon";
            MaHoaDon.ReadOnly = true;
            // 
            // DanhMuc
            // 
            resources.ApplyResources(DanhMuc, "DanhMuc");
            DanhMuc.Name = "DanhMuc";
            DanhMuc.ReadOnly = true;
            // 
            // XemChiTiet
            // 
            XemChiTiet.DataPropertyName = "Xem chi tiết";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            XemChiTiet.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(XemChiTiet, "XemChiTiet");
            XemChiTiet.Name = "XemChiTiet";
            XemChiTiet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            XemChiTiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            XemChiTiet.Text = "Xem chi tiết";
            XemChiTiet.UseColumnTextForButtonValue = true;
            // 
            // btnInHD
            // 
            btnInHD.BackColor = System.Drawing.Color.FromArgb(66, 144, 242);
            btnInHD.FlatAppearance.BorderSize = 0;
            btnInHD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(118, 173, 243);
            resources.ApplyResources(btnInHD, "btnInHD");
            btnInHD.ForeColor = System.Drawing.Color.White;
            btnInHD.Name = "btnInHD";
            btnInHD.UseVisualStyleBackColor = false;
            btnInHD.Click += btnInHD_Click;
            // 
            // tblDsKhachHang
            // 
            tblDsKhachHang.BackgroundColor = System.Drawing.Color.White;
            tblDsKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(66, 144, 242);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            tblDsKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            tblDsKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblDsKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { sttKH, TenKH, sdtKH, dcKH, DoanhThu });
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            tblDsKhachHang.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(tblDsKhachHang, "tblDsKhachHang");
            tblDsKhachHang.Name = "tblDsKhachHang";
            tblDsKhachHang.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            tblDsKhachHang.RowsDefaultCellStyle = dataGridViewCellStyle6;
            tblDsKhachHang.RowTemplate.Height = 24;
            // 
            // fromdatelbl
            // 
            resources.ApplyResources(fromdatelbl, "fromdatelbl");
            fromdatelbl.BackColor = System.Drawing.Color.LightGray;
            fromdatelbl.Name = "fromdatelbl";
            // 
            // todatelbl
            // 
            resources.ApplyResources(todatelbl, "todatelbl");
            todatelbl.BackColor = System.Drawing.Color.LightGray;
            todatelbl.Name = "todatelbl";
            // 
            // btnTaoHD
            // 
            btnTaoHD.BackColor = System.Drawing.Color.FromArgb(66, 144, 242);
            btnTaoHD.FlatAppearance.BorderSize = 0;
            btnTaoHD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(118, 173, 243);
            resources.ApplyResources(btnTaoHD, "btnTaoHD");
            btnTaoHD.ForeColor = System.Drawing.Color.White;
            btnTaoHD.Name = "btnTaoHD";
            btnTaoHD.UseVisualStyleBackColor = false;
            btnTaoHD.Click += btnTaoMoiHD_Click;
            // 
            // btnSearch
            // 
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(66, 144, 242);
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnrefresh
            // 
            btnrefresh.FlatAppearance.BorderSize = 0;
            btnrefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(66, 144, 242);
            resources.ApplyResources(btnrefresh, "btnrefresh");
            btnrefresh.Name = "btnrefresh";
            btnrefresh.UseVisualStyleBackColor = true;
            btnrefresh.Click += btnrefresh_Click;
            // 
            // pnlloc
            // 
            pnlloc.BackColor = System.Drawing.Color.Gainsboro;
            pnlloc.Controls.Add(FromDate);
            pnlloc.Controls.Add(fromdatelbl);
            pnlloc.Controls.Add(ToDate);
            pnlloc.Controls.Add(todatelbl);
            resources.ApplyResources(pnlloc, "pnlloc");
            pnlloc.Name = "pnlloc";
            // 
            // sttKH
            // 
            resources.ApplyResources(sttKH, "sttKH");
            sttKH.Name = "sttKH";
            sttKH.ReadOnly = true;
            // 
            // TenKH
            // 
            resources.ApplyResources(TenKH, "TenKH");
            TenKH.Name = "TenKH";
            // 
            // sdtKH
            // 
            resources.ApplyResources(sdtKH, "sdtKH");
            sdtKH.Name = "sdtKH";
            // 
            // dcKH
            // 
            resources.ApplyResources(dcKH, "dcKH");
            dcKH.Name = "dcKH";
            // 
            // DoanhThu
            // 
            resources.ApplyResources(DoanhThu, "DoanhThu");
            DoanhThu.Name = "DoanhThu";
            DoanhThu.ReadOnly = true;
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(btnrefresh);
            Controls.Add(btnSearch);
            Controls.Add(btnTaoHD);
            Controls.Add(tblDsKhachHang);
            Controls.Add(btnInHD);
            Controls.Add(tblDSHD);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(pnlloc);
            Name = "Home";
            Load += Home_Load;
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)tblDSHD).EndInit();
            ((System.ComponentModel.ISupportInitialize)tblDsKhachHang).EndInit();
            pnlloc.ResumeLayout(false);
            pnlloc.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView tblDSHD;
        
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.DataGridView tblDsKhachHang;
        private System.Windows.Forms.Label fromdatelbl;
        private System.Windows.Forms.Label todatelbl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhMuc;
        private System.Windows.Forms.DataGridViewButtonColumn XemChiTiet;
        private System.Windows.Forms.Button btnTaoHD;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Panel pnlloc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sttKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdtKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoanhThu;
    }
}

