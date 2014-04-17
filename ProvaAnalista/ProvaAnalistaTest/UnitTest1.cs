using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvaAnalista;

namespace ProvaAnalistaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Robo r = new Robo();
            Destino d = new Destino();

           // r.Point.X = 0;
           // r.Point.Y = 5;

            //d.Point.X = 0;
            //d.Point.Y = 0;

           r.RandonPoint();
           d.RandonPoint();

            r.CaminharAte(d);
        }
    }
}
