using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAnalista
{
    public class Point
    {

        public static int RANDON_PARAM = 10;
        private static readonly Random randon = new Random();

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y);
        }

        public static int RandonNumber()
        {
            return randon.Next(RANDON_PARAM);
        }

        public static Point GetPoint()
        {
            return new Point { X = RandonNumber(), Y = RandonNumber() };
        }
    }
}
