using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MergeNames;
using System.Linq;

namespace MergeNamesTest
{
    [TestClass]
    public class TestMergeNames
    {
        [TestMethod]
        public void SameLengthArray_NoDuplicates()
        {
            // Input
            string[] names1 = { "Anna", "Tiago", "Brook" };
            string[] names2 = { "Jason", "Carol", "Jon" };

            // Output
            string[] output = MergeNames.MergeNames.UniqueNames(names1, names2);

            // Tests, each name is Unique in the new list.
            Assert.AreEqual(1, output.Count(name => name == "Anna"));
            Assert.AreEqual(1, output.Count(name => name == "Tiago"));
            Assert.AreEqual(1, output.Count(name => name == "Brook"));
            Assert.AreEqual(1, output.Count(name => name == "Jason"));
            Assert.AreEqual(1, output.Count(name => name == "Carol"));
            Assert.AreEqual(1, output.Count(name => name == "Jon"));
        }
        [TestMethod]
        public void SameLengthArray_Duplicates()
        {
            // Input
            string[] names1 = { "Anna", "Tiago", "Brook" };
            string[] names2 = { "Anna", "Carol", "Jon" };

            // Output
            string[] output = MergeNames.MergeNames.UniqueNames(names1, names2);

            // Tests, each name is Unique in the new list.
            Assert.AreEqual(1, output.Count(name => name == "Anna"));
            Assert.AreEqual(1, output.Count(name => name == "Tiago"));
            Assert.AreEqual(1, output.Count(name => name == "Brook"));
            Assert.AreEqual(1, output.Count(name => name == "Carol"));
            Assert.AreEqual(1, output.Count(name => name == "Jon"));
        }
        [TestMethod]
        public void DifferentLengthArray_Duplicates()
        {
            // Input
            string[] names1 = { "Anna", "Tiago", "Brook" };
            string[] names2 = { "Anna", "Carol", "Jon", "Jane", "James" };

            // Output
            string[] output = MergeNames.MergeNames.UniqueNames(names1, names2);

            // Tests, each name is Unique in the new list.
            Assert.AreEqual(1, output.Count(name => name == "Anna"));
            Assert.AreEqual(1, output.Count(name => name == "Tiago"));
            Assert.AreEqual(1, output.Count(name => name == "Brook"));
            Assert.AreEqual(1, output.Count(name => name == "Carol"));
            Assert.AreEqual(1, output.Count(name => name == "Jon"));
            Assert.AreEqual(1, output.Count(name => name == "Jane"));
            Assert.AreEqual(1, output.Count(name => name == "James"));
        }
        [TestMethod]
        public void EmptyArray()
        {
            // Input
            string[] names1 = { "Anna", "Tiago", "Brook" };
            string[] names2 = new string[1];

            // Output
            string[] output = MergeNames.MergeNames.UniqueNames(names1, names2);

            // Tests, each name is Unique in the new list.
            Assert.AreEqual(1, output.Count(name => name == "Anna"));
            Assert.AreEqual(1, output.Count(name => name == "Tiago"));
            Assert.AreEqual(1, output.Count(name => name == "Brook"));
        }
    }
}
