using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAnalista
{
    public class Robo : IPoint
    {

        public List<Point> CaminhoPercorrido;

        public Robo()
        {
            //Point = new Point();
            Point = Point.GetPoint();
            CaminhoPercorrido = new List<Point>();
        }
        public Point Point { get; set; }

        public void RandonPoint()
        {
            Point.X = Point.RandonNumber();
            Point.Y = Point.RandonNumber();

            CaminhoPercorrido.Add(new Point { X = this.Point.X, Y = this.Point.Y });
        }

        public void CaminharAte(Destino destino)
        {
            MoveX(destino.Point.X);
            MoveY(destino.Point.Y);
        }

        private void MoveX(int x)
        {
            int a = x - Point.X;
            if (a != 0)
            {
                int distancia = a > 0 ? 1 : -1;
                for (int i = 1; i <= Math.Abs(a); i++)
                {
                    this.Point.X += distancia;
                    CaminhoPercorrido.Add(new Point { X = this.Point.X, Y = this.Point.Y });
                }
            }
        }

        private void MoveY(int y)
        {
            int a = y - Point.Y;
            if (a != 0)
            {
                int distancia = a > 0 ? 1 : -1;

                for (int i = 1; i <= Math.Abs(a); i++)
                {
                    this.Point.Y += distancia;
                    CaminhoPercorrido.Add(new Point { X = this.Point.X, Y = this.Point.Y });
                }
            }
        }

    }
}
