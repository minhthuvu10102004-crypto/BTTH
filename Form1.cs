using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Data.SqlClient;

namespace QLNhaThuoc
{
    public partial class Home : Form
    {
        // thay bằng connection string thật
        private readonly string connectionString = @"Data Source=MINHTHUVU\MINHTHU;Initial Catalog=QLBH_NhaThuoc;Integrated Security=True;Encrypt=False";
        private DataTable invoicesTable = new DataTable();

        public Home()
        {
            InitializeComponent();
            this.Load += Home_Load;
            tblDSHD.CellClick += tblDSHD_CellClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnTaoHD.Click += btnTaoMoiHD_Click;
            btnInHD.Click += btnInHD_Click;
            btnSearch.Click += btnSearch_Click;


        }
        private void LoadCustomers()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = @"SELECT kh.MaKH, kh.TenKH, kh.SDT, kh.DiaChi, ISNULL(SUM(hd.TongTien), 0) AS DoanhThu
                FROM KhachHang kh
                LEFT JOIN HoaDon hd ON kh.MaKH = hd.MaKH
                GROUP BY kh.MaKH, kh.TenKH, kh.SDT, kh.DiaChi
                ORDER BY DoanhThu DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    tblDsKhachHang.Rows.Clear();
                    int stt = 1;
                    while (dr.Read())
                    {
                        tblDsKhachHang.Rows.Add(
                            stt++,
                            dr["TenKH"].ToString(),
                            dr["SDT"].ToString(),
                            dr["DiaChi"].ToString(),
                            string.Format("{0:N0}", dr["DoanhThu"])
                        );
                    }
                }
            }
        }


        private void LoadInvoices(string search = null)
        {
            invoicesTable.Clear();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                string sql = @"SELECT hd.MaHoaDon, ISNULL(kh.TenKH, '') AS TenKH,
                hd.NgayLap,
                hd.TongTien,

                ISNULL((
                SELECT STUFF((
                SELECT ', ' + t.TenThuoc
                FROM ChiTietHoaDon c
                JOIN Thuoc t ON c.MaThuoc = t.MaThuoc
                WHERE c.MaHoaDon = hd.MaHoaDon
                FOR XML PATH('')), 1, 2, '')
                ), '') AS DanhMuc
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                ";
                if (!string.IsNullOrWhiteSpace(search))
                {
                    sql += " WHERE hd.MaHoaDon LIKE @q OR kh.TenKH LIKE @q ";
                }
                sql += " ORDER BY hd.NgayLap DESC ";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    if (!string.IsNullOrWhiteSpace(search))
                        cmd.Parameters.AddWithValue("@q", "%" + search + "%");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(invoicesTable);
                    }
                }
            }
            DataTable dt = invoicesTable.Copy();
            if (!dt.Columns.Contains("STT"))
                dt.Columns.Add("STT", typeof(int));
            int idx = 1;
            foreach (DataRow r in dt.Rows)
            {
                r["STT"] = idx++;
            }
            tblDSHD.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.Trim();
            LoadInvoices(q);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tblDSHD.Rows[e.RowIndex];
                string maHoaDon = row.Cells["MaHoaDon"].Value?.ToString();

                MessageBox.Show(maHoaDon);
            }

        }
        private void tblDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (tblDSHD.Columns[e.ColumnIndex].Name == "XemChiTiet")
                {
                    var cell = tblDSHD.Rows[e.RowIndex].Cells["MaHoaDon"].Value;
                    string maHoaDon = cell?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(maHoaDon))
                    {
                        try
                        {
                            frmHoaDonBH fChiTiet = new frmHoaDonBH(maHoaDon);
                            fChiTiet.StartPosition = FormStartPosition.CenterParent;
                            fChiTiet.ShowDialog(this);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể xem hóa đơn: " + ex.Message);
                        }
                    }
                }
                else
                {
                    var cell = tblDSHD.Rows[e.RowIndex].Cells["MaHoaDon"].Value;
                    string maHoaDon = cell?.ToString() ?? "";
                }
            }

        }



        private void btnInHD_Click(object sender, EventArgs e)
        {
            string maIn = null;
            foreach (DataGridViewRow row in tblDSHD.Rows)
            {
                var cell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                bool isChecked = false;
                if (cell?.Value != null && bool.TryParse(cell.Value.ToString(), out bool val))
                    isChecked = val;

                if (isChecked)
                {
                    maIn = row.Cells["MaHoaDon"].Value?.ToString();
                    break;
                }
            }

            if (string.IsNullOrEmpty(maIn))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
                return;
            }
            PrintInvoice(maIn);

        }

        private void btnTaoMoiHD_Click(object sender, EventArgs e)
        {
            try
            {
                frmThemHD fThemHD = new frmThemHD();
                fThemHD.StartPosition = FormStartPosition.CenterParent;
                if (fThemHD.ShowDialog(this) == DialogResult.OK)
                {
                    LoadInvoices();
                }
                else
                {
                    LoadInvoices();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo hóa đơn: " + ex.Message);
            }
        }
        private void PrintInvoice(string maHoaDon)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = @"SELECT hd.MaHoaDon, ISNULL(kh.TenKH,'') AS TenKH, hd.NgayLap, hd.TongTien,
                 ISNULL((
                 SELECT STUFF((SELECT CHAR(13)+CHAR(10) + t.TenThuoc + ' x' + CAST(c.SoLuong AS VARCHAR(10))
                 FROM ChiTietHoaDon c JOIN Thuoc t ON c.MaThuoc = t.MaThuoc
                 WHERE c.MaHoaDon = hd.MaHoaDon FOR XML PATH('')),1,1,'')
                 ), '') AS ChiTiet
                 FROM HoaDon hd
                 LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                 WHERE hd.MaHoaDon = @ma
                 ";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@ma", maHoaDon);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            string info = $"Hóa đơn: {r["MaHoaDon"]}\r\nKhách: {r["TenKH"]}\r\nNgày: {r["NgayLap"]}\r\nTổng: {r["TongTien"]}\r\n\r\nChi tiết:\r\n{r["ChiTiet"]}";

                            MessageBox.Show(info, "In hóa đơn - Preview");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn để in.");
                        }
                    }
                }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadInvoices();
            //
            txtSearch.Text = "Tìm kiếm...";
            txtSearch.ForeColor = Color.Gray;

            // Gắn sự kiện
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;

            // Test data

            tblDsKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tblDsKhachHang.ColumnHeadersHeight = 56;
            tblDsKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            tblDsKhachHang.RowTemplate.Height = 40;
            //
            tblDSHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tblDSHD.ColumnHeadersHeight = 56;
            tblDSHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            tblDSHD.RowTemplate.Height = 40;
            foreach (DataGridViewRow row in tblDSHD.Rows)
            {
                row.Height = 40;
            }
            //
            Image resized = new Bitmap(btnSearch.Image, new Size(24, 24));

            // Gán ảnh vào nút
            btnSearch.Image = resized;
            btnSearch.MouseHover += (s, e) =>
            {
                btnSearch.BackColor = Color.FromArgb(221, 235, 247);
            };
            btnSearch.MouseLeave += (s, e) =>
            {
                btnSearch.BackColor = Color.White;
            };
            
            
            //
            Image resize = new Bitmap(btnrefresh.Image, new Size(24, 24));

            // Gán ảnh vào nút
            btnrefresh.Image = resize;
            btnrefresh.MouseHover += (s, e) =>
            {
                btnrefresh.BackColor = Color.FromArgb(221, 235, 247);
            };
            btnrefresh.MouseLeave += (s, e) =>
            {
                btnrefresh.BackColor = Color.White;
            };
         
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            tblDsKhachHang.ClearSelection();
        }
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string q = txtSearch.Text.Trim();
            LoadInvoices(q);

        }
        private void LoadInvoicesByCustomer(string maKH)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = @"SELECT hd.MaHoaDon, hd.NgayLap, hd.TongTien, ISNULL((
                 SELECT STUFF((
                 SELECT ', ' + t.TenThuoc
                 FROM ChiTietHoaDon ct
                 JOIN Thuoc t ON ct.MaThuoc = t.MaThuoc
                 WHERE ct.MaHoaDon = hd.MaHoaDon
                 FOR XML PATH('')
                 ), 1, 2, '')
                 ), '') AS DanhMuc
                 FROM HoaDon hd
                 WHERE hd.MaKH = @MaKH
                 ORDER BY hd.NgayLap DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        tblDSHD.DataSource = dt;
                    }
                }
            }
        }

        private void tblDsKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string maKH = tblDsKhachHang.Rows[e.RowIndex].Cells["maKH"].Value?.ToString();
            if (string.IsNullOrEmpty(maKH)) return;
            LoadInvoicesByCustomer(maKH);

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
            tblDSHD.DataSource = null;
            txtSearch.Text = "Tìm kiếm...";

        }
    }
}

