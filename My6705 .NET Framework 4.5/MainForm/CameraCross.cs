using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public partial class Main 
    {
        private void cbEnCross_CheckedChanged(object sender, EventArgs e)
        {
            trbX.Enabled = cbEnCross.Checked;
            trbY.Enabled = cbEnCross.Checked;
        }

        private void trbY_Scroll(object sender, EventArgs e)
        {
            rectH = trbY.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            rectW = trbX.Value;
        }

        int rectW = 10, rectH = 10, ofset = 5;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (cbEnCross.Checked)
            {
                Pen p = new Pen(Color.Cyan, 2);
                Rectangle rect = new Rectangle(pictureBox1.Width / 2 - rectW / 2, pictureBox1.Height / 2 - rectH / 2, rectW, rectH);
                e.Graphics.DrawRectangle(p, rect);
                Point px1 = new Point(pictureBox1.Width / 2 - rectW / 2 - ofset, pictureBox1.Height / 2);
                Point px2 = new Point(pictureBox1.Width / 2 + rectW / 2 + ofset, pictureBox1.Height / 2);
                Point py1 = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2 - rectH / 2 - ofset);
                Point py2 = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2 + rectH / 2 + ofset);
                e.Graphics.DrawLine(p, px1, px2);
                e.Graphics.DrawLine(p, py1, py2);
            }
        }
    }
}
