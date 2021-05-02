using System;
using RoutePlanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoutePlanner
{
    [TestClass]
    public class RoutePlannerTest
    {
        private bool[,] baseCaseMap = {
                {true,  false, false},
                {true,  true,  false},
                {false, true,  true},
            };
        private bool[,] complexCaseMap = {
                {true,  true,  true,  true,  true,  true},
                {false, false, false, false, false, true},
                {true,  true,  false, true,  true,  true},
                {false, true,  false, true,  true,  true},
                {true,  true,  true,  true,  true,  true},
                {true,  true,  true,  true,  true,  true}
            };

        [TestMethod]
        public void BaseCase()
        {
            Assert.AreEqual(true, RoutePlanner.RouteExists(0, 0, 2, 2, baseCaseMap));
        }
        [TestMethod]
        public void BaseCase_Reversed()
        {
            Assert.AreEqual(true, RoutePlanner.RouteExists(2, 2, 0, 0, baseCaseMap));
        }
        [TestMethod]
        public void BaseCase_NoRoute()
        {
            Assert.AreEqual(false, RoutePlanner.RouteExists(0, 0, 0, 2, baseCaseMap));
        }
        [TestMethod]
        public void BaseCase_StartFalse()
        {
            Assert.AreEqual(false, RoutePlanner.RouteExists(0, 2, 2, 2, baseCaseMap));
        }
        [TestMethod]
        public void ComplexCase()
        {
            Assert.AreEqual(true, RoutePlanner.RouteExists(0, 0, 2, 0, complexCaseMap));
        }
        [TestMethod]
        public void ComplexCase_Reversed()
        {
            Assert.AreEqual(true, RoutePlanner.RouteExists(2, 0, 0, 0, complexCaseMap));
        }
        [TestMethod]
        public void ComplexCase_FalsePath()
        {
            Assert.AreEqual(false, RoutePlanner.RouteExists(0, 0, 1, 2, complexCaseMap));
        }
        [TestMethod]
        public void EmptyMap()
        {
            Assert.AreEqual(false, RoutePlanner.RouteExists(0, 0, 1, 2, new bool[,] { }));
        }

    }
}
