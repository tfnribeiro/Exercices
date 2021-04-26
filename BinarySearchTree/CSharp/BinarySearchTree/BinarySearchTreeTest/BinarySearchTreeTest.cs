using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearch;
using System.Diagnostics;

namespace BinarySearchTreeTest
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void ExampleCase()
        {
            Node n1 = new Node(1, null, null);
            Node n3 = new Node(3, null, null);
            Node n2 = new Node(2, n1, n3);

            Assert.AreEqual(true, BinarySearchTree.Contains(n2, 3));
        }
        [TestMethod]
        public void NullCase()
        {
            Node n1 = null;

            Assert.AreEqual(false, BinarySearchTree.Contains(n1, 3));
        }
        [TestMethod]
        public void LeftHeavyTree()
        {
            Node n6 = new Node(1, null, null);
            Node n5 = new Node(5, null, null);
            Node n4 = new Node(3, n6, null);
            Node n3 = new Node(10, null, null);
            Node n2 = new Node(4, n4, n5);
            Node n1 = new Node(6, n2, n3); // root

            Assert.AreEqual(true, BinarySearchTree.Contains(n1, 1));
        }
        [TestMethod]
        public void RightLightTree()
        {
            Node n6 = new Node(1, null, null);
            Node n5 = new Node(5, null, null);
            Node n4 = new Node(3, n6, null);
            Node n3 = new Node(10, null, null);
            Node n2 = new Node(4, n4, n5);
            Node n1 = new Node(6, n2, n3); // root

            Assert.AreEqual(true, BinarySearchTree.Contains(n1, 10));
        }
        [TestMethod]
        public void FasterThanLinearSearch_BestCaseBinary()
        {
            // Performance 
            Node n6 = new Node(1, null, null);
            Node n5 = new Node(5, null, null);
            Node n4 = new Node(3, n6, null);
            Node n3 = new Node(10, null, null);
            Node n2 = new Node(4, n4, n5);
            Node n1 = new Node(6, n2, n3); // root

            int[] array = new int[] { 1, 3, 4, 5, 6, 10 };

            Stopwatch linearSearchTime = new Stopwatch();
            Stopwatch binaryTreeSearchTime = new Stopwatch();

            linearSearchTime.Start();
            LinearSearch(array, 10);
            linearSearchTime.Stop();

            binaryTreeSearchTime.Start();
            BinarySearchTree.Contains(n1, 10);
            binaryTreeSearchTime.Stop();

            Assert.IsTrue(binaryTreeSearchTime.ElapsedTicks <= linearSearchTime.ElapsedTicks);
        }
        private bool LinearSearch(int [] array, int value)
        {
            foreach (int v in array)
                if (v == value) return true;

            return false;
        }
    }
}
