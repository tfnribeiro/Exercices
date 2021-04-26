using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuadraticEquation;

namespace QuadraticEquation
{
    [TestClass]
    public class QuadraticEquationTest
    {
        [TestMethod]
        public void A_isZero()
        {
            // This is mathematically impossible it should return a non number
            // double.nan in this case.
            var result = QuadraticEquation.QuadraticEquation.FindRoots(0, 2, 3);
            Assert.AreEqual(new Tuple<double,double>(double.NaN, double.NaN), result);
        }
        [TestMethod]
        public void Equal_Roots()
        {
            // Needs to return both tuples to be the same
            var result = QuadraticEquation.QuadraticEquation.FindRoots(1, 4, 4);
            Assert.AreEqual(new Tuple<double, double>(-2, -2), result);
        }
        [TestMethod]
        public void NegativeRoot()
        {
            // Return NaN
            var result = QuadraticEquation.QuadraticEquation.FindRoots(1, 2, 3);
            Assert.AreEqual(new Tuple<double, double>(double.NaN, double.NaN), result);
        }
        [TestMethod]
        public void DifferentRoots()
        {
            // Return NaN
            var result = QuadraticEquation.QuadraticEquation.FindRoots(5, 10, 4);
            Assert.AreEqual(-0.5527, result.Item1, 0.0001);
            Assert.AreEqual(-1.4472, result.Item2, 0.0001);
        }
    }
}
