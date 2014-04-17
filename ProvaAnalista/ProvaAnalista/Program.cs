using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAnalista
{
    class Program
    {
        static void Main(string[] args)
        {
            Robo wall_e = new Robo();
            Destino destino = new Destino();
            //destino.RandonPoint();
            //wall_e.RandonPoint();

            wall_e.CaminharAte(destino);

            Console.WriteLine("Robo origem :" + wall_e.CaminhoPercorrido.First().ToString());
            Console.WriteLine("Destino : " + destino.Point.ToString());

            Console.WriteLine("Caminho percorrido pelo Wall-e ao ponto de destino");
            foreach(var item in wall_e.CaminhoPercorrido)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Caminho percorrido pelo Wall-e ao ponto de origem");
            wall_e.CaminhoPercorrido.Reverse();
            foreach (var item in wall_e.CaminhoPercorrido)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
