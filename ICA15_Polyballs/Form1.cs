using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using BallBase;

namespace ICA15_Polyballs
{
    public partial class Form1 : Form
    {
        CDrawer canvas;
        List<CBall> ballList = new List<CBall>();
        Random rnd = new Random();
        private delegate void delVoidCDrawerPoint(Point pos, CDrawer dr);

        public Form1()
        {
            InitializeComponent();
            canvas = new CDrawer();
            canvas.MouseLeftClick += Canvas_MouseLeftClick;
            canvas.MouseRightClick += Canvas_MouseRightClick;
        }

        private void Canvas_MouseRightClick(Point pos, CDrawer dr)
        {
            Invoke(new delVoidCDrawerPoint(GetRightClick), pos, dr);
        }

        private void Canvas_MouseLeftClick(Point pos, CDrawer dr)
        {
            Invoke(new delVoidCDrawerPoint(GetLeftClick), pos, dr);
        }

        private void GetLeftClick(Point pos, CDrawer dr)
        {
            CBall newBall;

            newBall = new CBall(pos, rnd.Next(1, 366));
            ballList.Add(newBall);
            newBall.Render(dr);
        }

        private void GetRightClick(Point pos, CDrawer dr)
        {
            CBallDerived newDBall;

            newDBall = new CBallDerived(pos, rnd.Next(1, 366), 2.5, 800, 600, 20);
            ballList.Add(newDBall);
            newDBall.Render(dr);
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            canvas.Clear();
            ballList.ForEach(ball => ball.Move());
            ballList.ForEach(ball => ball.Render(canvas));
            //foreach (CBall ball in ballList)
            //{
            //    if (ball is CBallDerived)
            //    {
            //        ((CBallDerived)ball).Move();
            //        ((CBallDerived)ball).Render(canvas);
            //    }
            //    else
            //    {
            //        ball.Move();
            //        ball.Render(canvas);
            //    }
            //}
        }
    }
}
