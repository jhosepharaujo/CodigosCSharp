using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAnalista
{
    public class Destino : IPoint
    {
        public Destino()
        {
            //Point = new Point();
            Point = Point.GetPoint();
        }
        public Point Point { get; set; }
        public void RandonPoint()
        {
            Point.X = Point.RandonNumber();
            Point.Y = Point.RandonNumber();
        }
    }
}
