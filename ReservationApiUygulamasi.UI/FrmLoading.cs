using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReservationApiUygulamasi.UI
{
    public partial class FrmLoading : Form
    {
        private Timer timer;
        private int angle = 0;

        public FrmLoading()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen; // ORTALAMA FIX
            this.Size = new Size(200, 200);
            this.BackColor = Color.FromArgb(255, 135, 190, 250);
            this.TopMost = true;
            this.DoubleBuffered = true;

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += (s, e) =>
            {
                angle += 10;
                if (angle >= 360) angle = 0;
                this.Invalidate();
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int size = 60;
            int x = (this.Width / 2) - (size / 2);
            int y = (this.Height / 2) - (size / 2);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.White, 5))
            {
                e.Graphics.DrawArc(pen, x, y, size, size, angle, 270);
            }
        }
    }
}