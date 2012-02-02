using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication23
{
    public partial class Form1 : Form
    {
        Bitmap radarScreenBmp;
        Graphics radarGraphic;
        Pen darkGreenPen;
        Pen blackPen;
        const int BASELINE = 400;
        const int WIDTH = 800;
        const int HEIGHT = 500;
        const int DIVSTEP = 8;
        const int MAXDIV = 500;
        int fi=10;
        int dir = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radarScreenBmp = new Bitmap(WIDTH, HEIGHT);
            radarScreen.Image = radarScreenBmp;
            radarGraphic = Graphics.FromImage(radarScreenBmp);
            radarGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            darkGreenPen = new Pen(Brushes.DarkGreen);
            blackPen = new Pen(Brushes.Black);
            drawDiv();
            radarGraphic.FillRectangle(Brushes.Black, 0, BASELINE, WIDTH, HEIGHT - BASELINE);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fi > 180 || fi < 10) dir *= -1; 
            fi += dir * 2;

            drawDiv();

            GraphicsPath path = new GraphicsPath();
            path.AddPie((WIDTH - (MAXDIV)) / 2, BASELINE - (((MAXDIV)) / 2), (MAXDIV), (MAXDIV), -fi, 10);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterPoint = new PointF(WIDTH-(WIDTH / 2 - (int)(Math.Cos(Deg2Rad((dir>0)?fi:fi-10)) * (MAXDIV / 2))), BASELINE - (int)(Math.Sin(Deg2Rad((dir>0)?fi:fi-10)) * (MAXDIV / 2)));
            brush.SurroundColors = new Color[] { Color.FromArgb(0, 0, 255, 0) };
            brush.CenterColor = Color.FromArgb(255, 0, 255, 0);
            radarGraphic.FillPath(brush, path);

            radarGraphic.FillRectangle(Brushes.Black, 0, BASELINE, WIDTH, HEIGHT - BASELINE);
            radarScreen.Invalidate();
            path.Dispose();
            brush.Dispose();
        }

        private double Deg2Rad(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private void drawDiv()
        {
            radarGraphic.Clear(Color.Black);
            radarGraphic.DrawLine(darkGreenPen, (WIDTH - MAXDIV) / 2, BASELINE, WIDTH - ((WIDTH - MAXDIV) / 2), BASELINE);
            for (int i = 1; i < DIVSTEP + 1; i++) radarGraphic.DrawEllipse(darkGreenPen, ((WIDTH - (MAXDIV / DIVSTEP) * i) / 2), BASELINE - (((MAXDIV / DIVSTEP) * i) / 2), (MAXDIV / DIVSTEP) * i, (MAXDIV / DIVSTEP) * i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
