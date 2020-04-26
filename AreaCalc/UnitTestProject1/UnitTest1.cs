using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSAreaCalc;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLessZero()
        {
            double[][] args = new double[][] {
                new double[] { 0 },
                new double[] { 1, 2, -1 },
            };
            foreach (double[] arg in args)
            {
                Assert.IsFalse(TestEqual(arg, 0));
            }
        }
        
        [TestMethod]
        public void TestUnknownShapes()
        {
            double[][] args = new double[][] {
                new double[] { },
                new double[] { 1, 3 },
                new double[] { 1, 2, 5, 4 },
            };
            foreach(double[] arg in args)
            {
                Assert.IsFalse(TestEqual(arg, 0));
            }
        }

        [TestMethod]
        public void TestCalcTriangle()
        {
            double[] arg = new double[]
            {
                3, 4 ,5
            };

            Assert.IsTrue(TestEqual(arg, 6));
        }

        [TestMethod]
        public void TestCalcCircle()
        {
            double[] arg = new double[]
            {
                1
            };

            Assert.IsTrue(TestEqual(arg, Math.PI * Math.Pow(arg[0], 2)));
        }

        bool TestNotEqual(double[] arg, double eq)
        {
            double area;
            try
            {
                area = AreaCalc.area(arg);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            Console.WriteLine("Calculated area: {0}", area);
            return area != eq;
        }

        bool TestEqual(double[] arg, double eq)
        {
            double area;
            try
            {
                area = AreaCalc.area(arg);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            Console.WriteLine("Calculated area: {0}", area);
            return area == eq;
        }
    }
}
