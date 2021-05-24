using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace App
{

    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void Paint2()
        {
            PaintClock();
        }
        private void PaintClock()
        {
            g.Clear(Color.White);
            this.Width = 400;
            this.Height = 400;
            Pen cir_pen = new Pen(Color.Black, 2);
            Pen hour = new Pen(Color.Green, 4);
            Pen minute = new Pen(Color.Blue, 2);
            Pen seconds = new Pen(Color.Yellow, 1);
            Brush brush = new SolidBrush(Color.Indigo);
            int w = this.Width;
            int h = this.Height;
            g.DrawEllipse(cir_pen, 10, 10, 340, 340);
            int r = 340 / 2;
            int center_x = 10 + r;
            int center_y = 10 + r;
            g.DrawEllipse(cir_pen, center_x-2, center_y-2, 4, 4);
            for (int i = 0; i < 12; ++i)
            {
                double x = center_x + r * Math.Sin(30 * i * Math.PI / 180);
                double x1 = x - 25 * Math.Sin(30 * i * Math.PI / 180);
                double y = center_y + r * Math.Cos(30 * i * Math.PI / 180);
                double y1 = y - 25 * Math.Cos(30 * i * Math.PI / 180);
                g.DrawLine(cir_pen, (int)x, (int)y, (int)x1, (int)y1);
            }
            for (int i = 0; i < 60; ++i)
            {
                double x = center_x + r * Math.Sin(6 * i * Math.PI / 180);
                double x1 = x - 10 * Math.Sin(6 * i * Math.PI / 180);
                double y = center_y + r * Math.Cos(6 * i * Math.PI / 180);
                double y1 = y - 10 * Math.Cos(6 * i * Math.PI / 180);
                g.DrawLine(cir_pen, (int)x, (int)y, (int)x1, (int)y1);
            }
            DateTime dt = DateTime.Now; ;
            double x2 = center_x + (r-100) * Math.Cos( (30*(dt.Hour % 12) - 90) * Math.PI / 180 );
            double y2 = center_y + (r-100) * Math.Sin( (30*(dt.Hour % 12) - 90) * Math.PI / 180 );
            g.DrawLine(hour, center_x, center_y, (int)x2, (int)y2);

            x2 = center_x + (r - 50) * Math.Cos((6 * dt.Minute - 90) * Math.PI / 180);
            y2 = center_y + (r - 50) * Math.Sin((6 * dt.Minute - 90) * Math.PI / 180);
            g.DrawLine(minute, center_x, center_y, (int)x2, (int)y2);

            x2 = center_x + (r - 25) * Math.Cos((6 * dt.Second - 90) * Math.PI / 180);
            y2 = center_y + (r - 25) * Math.Sin((6 * dt.Second - 90) * Math.PI / 180);
            g.DrawLine(seconds, center_x, center_y, (int)x2, (int)y2);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PaintClock();
        }
    }
}
