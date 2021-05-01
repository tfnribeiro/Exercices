using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortedSearch;
using System.Diagnostics;
using System.Collections.Generic;

namespace SortedSearch
{
    [TestClass]
    public class SortedSearchTest
    {
        // List of (Array, LessThan, Expected)
        List<Tuple<int[], int, int>> testCases_SmallArrays =
            new List<Tuple<int[], int, int>> {
                new Tuple<int[], int, int> ( new int[] {1,3,5}, 5, 2),
                new Tuple<int[], int, int> ( new int[] {1}, 1, 0),
                new Tuple<int[], int, int> ( new int[] {1,3,5,7}, 4, 2),
                new Tuple<int[], int, int> ( new int[] {1,3,5,9,10}, 8, 3)
            };
        List<Tuple<int[], int, int>> testCases_LargeArrays =
            new List<Tuple<int[], int, int>> {
                        new Tuple<int[], int, int> ( new int[] {1, 2, 3, 5, 8, 13, 19, 32, 51}, 15, 6),
                        new Tuple<int[], int, int> ( new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19}, 20, 19),
                        new Tuple<int[], int, int> ( new int[] {1,2,3,4,5,6,7,8,9,10}, 1, 0)
            };

        [TestMethod]
        public void Small_Array_Test()
        {
            foreach(var testCase in testCases_SmallArrays)
            {
                Assert.AreEqual(testCase.Item3, SortedSearch.CountNumbers(testCase.Item1, testCase.Item2));
            }
        }
        [TestMethod]
        public void Empty_Array()
        {
            Assert.AreEqual(0, SortedSearch.CountNumbers(new int[] { }, 10));
        }
        [TestMethod]
        public void Element_Not_In_List()
        {
            Assert.AreEqual(3, SortedSearch.CountNumbers(new int[] { 3, 5, 8}, 10));
        }
        [TestMethod]
        public void Handles_Duplicates()
        {
            Assert.AreEqual(0, SortedSearch.CountNumbers(new int[] { 3, 3, 3, 4,}, 3));
            Assert.AreEqual(6, SortedSearch.CountNumbers(new int[] { 3, 3, 3, 4, 4, 4, 6 }, 6));
            Assert.AreEqual(3, SortedSearch.CountNumbers(new int[] { 3, 3, 3, 4, 4, 4, 6 }, 4));
        }

        [TestMethod]
        public void Long_Array_Test()
        {
            foreach (var testCase in testCases_LargeArrays)
            {
                Assert.AreEqual(testCase.Item3, SortedSearch.CountNumbers(testCase.Item1, testCase.Item2));
            }
        }
        [TestMethod]
        public void Performance_Against_Naive_Implementation()
        {
            Stopwatch stopwatchImplementation = new Stopwatch();
            Stopwatch stopwatchNaiveImplementation = new Stopwatch();

            stopwatchImplementation.Start();
            foreach (var testCase in testCases_SmallArrays)
            {
                Assert.AreEqual(testCase.Item3, SortedSearch.CountNumbers(testCase.Item1, testCase.Item2));
            }
            foreach (var testCase in testCases_SmallArrays)
            {
                Assert.AreEqual(testCase.Item3, SortedSearch.CountNumbers(testCase.Item1, testCase.Item2));
            }
            stopwatchImplementation.Stop();
            stopwatchNaiveImplementation.Start();
            foreach (var testCase in testCases_SmallArrays)
            {
                Assert.AreEqual(testCase.Item3, NaiveCountNumbers(testCase.Item1, testCase.Item2));
            }
            foreach (var testCase in testCases_SmallArrays)
            {
                Assert.AreEqual(testCase.Item3, NaiveCountNumbers(testCase.Item1, testCase.Item2));
            }
            stopwatchNaiveImplementation.Stop();
            Console.WriteLine($"Implementation took: {stopwatchImplementation.Elapsed} VS Naive Implementation: {stopwatchNaiveImplementation.Elapsed}");
            Assert.IsTrue(stopwatchImplementation.Elapsed < stopwatchNaiveImplementation.Elapsed);
        }
        private static int NaiveCountNumbers(int [] list, int lessthan) 
        {
            for(int i = 0; i < list.Length; i++)
            {
                if (list[i] >= lessthan)
                    return i;
            }
            return 0;
        } 
    }
}
