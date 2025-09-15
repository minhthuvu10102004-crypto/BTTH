using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB2
{
    public partial class Form1 : Form
    {
        double a, b, c, d, x1, x2;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnend_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            a=Convert.ToDouble(txta.Text);
            b=Convert.ToDouble(txtb.Text);
            c=Convert.ToDouble(txtc.Text);
            d=b*b-4*a*c;
            if (d < 0)
                lblkq.Text = "Phương trình vô nghiệm";
            else if (d == 0)
            {
                x1 = -b / (2 * a);
                lblkq.Text = "Phương trình có nghiệm kép: x1=x2=" + Math.Round(x1,1);
            }
            else
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                lblkq.Text = "Phương trình có 2 nghiệm phân biệt: x1=" + Math.Round(x1,1) + ", x2=" + Math.Round(x2,1);

            }
    }
}
}
