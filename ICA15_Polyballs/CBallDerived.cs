using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using BallBase;
using System.Drawing;

namespace ICA15_Polyballs
{
    class CBallDerived : CBall
    {
        private int _time;
        public CBallDerived(PointF initPos, double dheading, double dSpeed, int xSize, int ySize, int time)
            :base(initPos, dheading, dSpeed, xSize, ySize)
        {
            _time = time;
        }

        public override void Move()
        {
            _time -= 1;
            
            base.Move();
        }

        public override void Render(CDrawer dr)
        {
            if (_time > 0)
            {
                
                base.Render(dr);
                dr.AddText(_time.ToString(), 10, (int)(Pos.X - 30), (int)(Pos.Y - 10), 60, 30, Color.Yellow);
            }
            
        }
    }
}
