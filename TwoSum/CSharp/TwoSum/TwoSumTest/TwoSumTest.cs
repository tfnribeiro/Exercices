using System;
using TwoSum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;


namespace TwoSum
{
    [TestClass]
    public class TwoSumTest
    {
        [TestMethod]
        public void BaseCase()
        {
            Tuple<int, int> result = TwoSum.FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
            Tuple<int, int> expected = new Tuple<int, int>(0, 3);
            Assert.IsTrue(TupleCompare(expected, result));
        }
        [TestMethod]
        public void No_Solution_Found()
        {
            Tuple<int, int> result = TwoSum.FindTwoSum(new List<int>() { 30, 12, 5, 7, 45, 9 }, 10);
            Tuple<int, int> expected = null;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void List_Is_Empty()
        {
            Tuple<int, int> result = TwoSum.FindTwoSum(new List<int>() { }, 10);
            Tuple<int, int> expected = null;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void List_Has_One_Element()
        {
            Tuple<int, int> result = TwoSum.FindTwoSum(new List<int>() { 9 }, 10);
            Tuple<int, int> expected = null;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Larger_List()
        {
            Tuple<int, int> result = TwoSum.FindTwoSum(new List<int>() { 
                74, 2, 37, 88, 89, 71, 45, 80, 38, 29, 55,
                100, 86, 31, 68, 96, 13, 6, 7, 16, 8, 85, 
                95, 57, 24, 75, 25, 50, 76, 64, 59, 33, 23, 94, 34, 15 }, 10);
            Tuple<int, int> expected = new Tuple<int, int>(1, 20);

            Assert.IsTrue(TupleCompare(expected,result));
        }
        [TestMethod]
        public void Larger_List_TimePerformance_Naive_Implementation()
        {
            List<int> testList = new List<int>() { 
                74, 2, 37, 88, 89, 71, 45, 80, 38, 29, 55,
                100, 86, 31, 68, 96, 13, 6, 7, 16, 8, 85,
                95, 57, 24, 75, 25, 50, 76, 64, 59, 33, 23, 94, 34, 15 };
            Stopwatch classImplementation = new Stopwatch();
            Stopwatch naiveImplementation = new Stopwatch();
            classImplementation.Start();
            Tuple<int, int> resultClass = TwoSum.FindTwoSum(testList, 10);
            classImplementation.Stop();
            naiveImplementation.Start();
            Tuple<int, int> resultSlow = NaiveFindTwoSum(testList, 10);
            naiveImplementation.Stop();
            Console.WriteLine(testList.Count);
            Console.WriteLine($"Class Implementation: {classImplementation.Elapsed} " +
                $"| Naive Implementation: {naiveImplementation.Elapsed}");
            Assert.IsTrue(classImplementation.Elapsed < naiveImplementation.Elapsed);
            Assert.IsTrue(TupleCompare(resultSlow, resultClass));
        }

        private static bool TupleCompare(Tuple<int,int> expected, Tuple<int,int> result)
        {
            return (result.Item1 == expected.Item1 && result.Item2 == expected.Item2) ||
                           (result.Item1 == expected.Item2 && result.Item2 == expected.Item1);
        }

        private static Tuple<int, int> NaiveFindTwoSum(IList<int> list, int sum)
        {
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = 0; j < list.Count; j++)
                {
                    if (i == j) continue; //We don't compare the same index
                    if (list[i] + list[j] == sum) return new Tuple<int, int>(i, j);
                }
            }
            return null;
        }
    }
}
