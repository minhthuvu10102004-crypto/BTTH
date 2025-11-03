using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLNhaThuoc
{
    public partial class frmThemHD : Form
    {
        //thay bằng connection string thật
        private readonly string connectionString = @"Data Source=MINHTHUVU\MINHTHU;Initial Catalog=QLBH_NhaThuoc;Integrated Security=True;Encrypt=False";
        private DataTable thuocTable = new DataTable();

        public frmThemHD()
        {
            InitializeComponent();
        }

        private void frmThemHD_Load(object sender, EventArgs e)
        {
            LoadThuocList();

            dgvChiTietHD.EditingControlShowing += dgvChiTietHD_EditingControlShowing;
            dgvChiTietHD.CellValueChanged += dgvChiTietHD_CellValueChanged;
            dgvChiTietHD.RowsAdded += (s, ev) => CapNhatSTT();
            dgvChiTietHD.UserDeletedRow += (s, ev) => UpdateTongTien();
        }

        private void LoadThuocList()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaThuoc, TenThuoc, GiaBan FROM Thuoc", cnn);
                da.Fill(thuocTable);
            }

            var cbbCol = (DataGridViewComboBoxColumn)dgvChiTietHD.Columns["TenThuoc"];
            cbbCol.DataSource = thuocTable;
            cbbCol.DisplayMember = "TenThuoc";
            cbbCol.ValueMember = "MaThuoc";
        }

        private void dgvChiTietHD_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvChiTietHD.CurrentCell.ColumnIndex == dgvChiTietHD.Columns["TenThuoc"].Index)
            {
                if (e.Control is ComboBox cbb)
                {
                    cbb.SelectedIndexChanged -= Cbb_SelectedIndexChanged;
                    cbb.SelectedIndexChanged += Cbb_SelectedIndexChanged;
                }
            }
        }

        private void Cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbb = sender as ComboBox;
            if (cbb?.SelectedValue == null) return;

            var row = dgvChiTietHD.CurrentRow;
            DataRow[] found = thuocTable.Select($"MaThuoc = '{cbb.SelectedValue}'");
            if (found.Length > 0)
            {
                row.Cells["DonGia"].Value = found[0]["DonGia"];
                row.Cells["SoLuong"].Value = 1;
                row.Cells["ThanhTien"].Value = found[0].Field<decimal>("DonGia");
                UpdateTongTien();
            }
        }

        private void dgvChiTietHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChiTietHD.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            if (e.ColumnIndex == dgvChiTietHD.Columns["SoLuong"].Index ||
                e.ColumnIndex == dgvChiTietHD.Columns["DonGia"].Index)
            {
                if (decimal.TryParse(Convert.ToString(row.Cells["SoLuong"].Value), out decimal sl) &&
                    decimal.TryParse(Convert.ToString(row.Cells["DonGia"].Value), out decimal dg))
                {
                    row.Cells["ThanhTien"].Value = sl * dg;
                }
                UpdateTongTien();
            }
        }

        private void CapNhatSTT()
        {
            for (int i = 0; i < dgvChiTietHD.Rows.Count; i++)
            {
                if (!dgvChiTietHD.Rows[i].IsNewRow)
                    dgvChiTietHD.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void UpdateTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow r in dgvChiTietHD.Rows)
            {
                if (r.IsNewRow) continue;
                if (decimal.TryParse(Convert.ToString(r.Cells["ThanhTien"].Value), out decimal tt))
                    tong += tt;
            }
            lblTongTien.Text = tong.ToString("N0") + " VNĐ";
        }
        private string GenerateMaHoaDon(SqlConnection cnn, SqlTransaction tran)
        {
            string newMa = "HD001";
            string sql = "SELECT TOP 1 MaHoaDon FROM HoaDon ORDER BY MaHoaDon DESC";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, tran))
            {
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int num = int.Parse(result.ToString().Substring(2));
                    newMa = "HD" + (num + 1).ToString("D3");
                }
            }
            return newMa;
        }

        private string GenerateMaKhachHang(SqlConnection cnn, SqlTransaction tran)
        {
            string newMa = "KH001";
            string sql = "SELECT TOP 1 MaKH FROM KhachHang ORDER BY MaKH DESC";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, tran))
            {
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int num = int.Parse(result.ToString().Substring(2));
                    newMa = "KH" + (num + 1).ToString("D3");
                }
            }
            return newMa;
        }

        private string KiemTraVaThemKhachHang(SqlConnection cnn, SqlTransaction tran)
        {
            string maKH;
            string sqlCheck = "SELECT MaKH FROM KhachHang WHERE SDT = @sdt";
            using (SqlCommand cmd = new SqlCommand(sqlCheck, cnn, tran))
            {
                cmd.Parameters.AddWithValue("@sdt", txtSdt.Text.Trim());
                var result = cmd.ExecuteScalar();
                if (result != null)
                    return result.ToString();
            }

            maKH = GenerateMaKhachHang(cnn, tran);
            string sqlInsert = @"INSERT INTO KhachHang(MaKH, TenKH, SDT, DiaChi)
                                 VALUES(@ma, @ten, @sdt, @dc)";
            using (SqlCommand cmd = new SqlCommand(sqlInsert, cnn, tran))
            {
                cmd.Parameters.AddWithValue("@ma", maKH);
                cmd.Parameters.AddWithValue("@ten", txtTenKH.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSdt.Text.Trim());
                cmd.Parameters.AddWithValue("@dc", txtDchi.Text.Trim());
                cmd.ExecuteNonQuery();
            }
            return maKH;
        }

        // thêm nút Lưu (btnLuu) với Hủy (btnHuy) giúp t nhé quên mất 
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHD.Rows.Count <= 1)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một thuốc vào hóa đơn!");
                return;
            }

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlTransaction tran = cnn.BeginTransaction();

                    try
                    {
                        string maHD = GenerateMaHoaDon(cnn, tran);
                        string maKH = KiemTraVaThemKhachHang(cnn, tran);
                        decimal tongTien = 0;

                        foreach (DataGridViewRow r in dgvChiTietHD.Rows)
                        {
                            if (r.IsNewRow) continue;
                            tongTien += Convert.ToDecimal(r.Cells["ThanhTien"].Value);
                        }

                        string sqlHD = @"INSERT INTO HoaDon(MaHoaDon, MaKH, NgayLap, TongTien, PTTT)
                                         VALUES(@MaHD, @MaKH, GETDATE(), @TongTien, @PTTT)";
                        using (SqlCommand cmd = new SqlCommand(sqlHD, cnn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maHD);
                            cmd.Parameters.AddWithValue("@MaKH", maKH);
                            cmd.Parameters.AddWithValue("@TongTien", tongTien);
                            cmd.Parameters.AddWithValue("@PTTT", (this.Controls.Find("cbbPTTT", true).FirstOrDefault() as ComboBox)?.SelectedItem?.ToString() ?? "");
                            cmd.ExecuteNonQuery();
                        }

                        string sqlCT = @"INSERT INTO ChiTietHoaDon(MaHoaDon, MaThuoc, SoLuong, DonGia)
                                         VALUES(@MaHD, @MaThuoc, @SoLuong, @DonGia)";
                        foreach (DataGridViewRow r in dgvChiTietHD.Rows)
                        {
                            if (r.IsNewRow) continue;

                            string maThuoc = r.Cells["TenThuoc"].Value?.ToString();
                            if (string.IsNullOrEmpty(maThuoc)) continue;

                            using (SqlCommand cmd = new SqlCommand(sqlCT, cnn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaHD", maHD);
                                cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);
                                cmd.Parameters.AddWithValue("@SoLuong", r.Cells["SoLuong"].Value);
                                cmd.Parameters.AddWithValue("@DonGia", r.Cells["DonGia"].Value);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        MessageBox.Show("Thêm hóa đơn thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hóa đơn: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txtSdt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSdt.Text)) return;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT TenKH, DiaChi FROM KhachHang WHERE SDT = @sdt";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@sdt", txtSdt.Text.Trim());
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtTenKH.Text = r["TenKH"].ToString();
                            txtDchi.Text = r["DiaChi"].ToString();
                        }
                        else
                        {
                            txtTenKH.Text = "";
                            txtDchi.Text = "";
                        }
                    }
                }
            }
        }
    }
}


