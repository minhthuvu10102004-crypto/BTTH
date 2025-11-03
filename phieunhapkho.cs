using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLNhaThuoc
{
    public partial class phieunhapkho : DevExpress.XtraReports.UI.XtraReport
    {
        public phieunhapkho()
        {
            InitializeComponent();
            // Lấy dòng cuối cùng (Tổng cộng)
            XRTableRow rowTong = xrTable2.Rows[xrTable2.Rows.Count - 1];

            // Gộp 8 ô đầu tiên (STT → Đơn giá)
            float totalWidth = 0;
            for (int i = 0; i < 8; i++)
            {
                totalWidth += rowTong.Cells[i].WidthF;
            }

            // Gán chiều rộng mới cho ô đầu tiên
            rowTong.Cells[0].WidthF = totalWidth;

            // Xóa 7 ô còn lại (vì đã gộp)
            for (int i = 1; i <= 7; i++)
            {
                rowTong.Cells.RemoveAt(1);
            }

            // Gán nội dung “Tổng cộng” cho ô đầu tiên
            rowTong.Cells[0].Text = "Tổng cộng";
            rowTong.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            rowTong.Cells[0].Font = new Font("Arial", 10F, FontStyle.Bold);
            // Căn chỉnh độ rộng theo bảng trên
            rowTong.Cells[0].Weight = xrTable2.Rows[0].Cells[0].Weight
                                    + xrTable2.Rows[0].Cells[1].Weight
                                    + xrTable2.Rows[0].Cells[2].Weight
                                    + xrTable2.Rows[0].Cells[3].Weight
                                    + xrTable2.Rows[0].Cells[4].Weight
                                    + xrTable2.Rows[0].Cells[5].Weight
                                    + xrTable2.Rows[0].Cells[6].Weight
                                    + xrTable2.Rows[0].Cells[7].Weight;  // nếu “Thành tiền” là cột 8

            rowTong.Cells[1].Weight = xrTable2.Rows[0].Cells[8].Weight;
            // gán số tiền từ caltongtien ở form chungtunhaphang vào ô thứ 2 dòng tổng cộng
            






        }
    }
}
