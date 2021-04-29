using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Folders;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;


namespace Folders
{
    [TestClass]
    public class FolderTest
    {
        [TestMethod]
        public void InitialCase()
        {
            string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

            IEnumerable<string> result = Folders.FolderNames(xml, 'u');
            string[] expected = { "uninstall information", "users" };
            CollectionAssert.AreEqual(expected, result.ToArray());
        }
        [TestMethod]
        public void ComplexFolderCase()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"uninstall information\" />" +
                    "</folder>" +
                    "<folder name=\"users\" />" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"importantProgram1\" />" +
                        "<folder name=\"officeSuit9000\">" +
                            "<folder name=\"veryInterestingDocuments\" />" +
                            "<folder name=\"fascinatingDocuments\">" +
                                "<folder name=\"designed\" />" +
                                    "<folder name=\"ordered\">" +
                                    "<folder name=\"paidFor\" />" +
                                "</folder>" +
                            "</folder>" +
                        "</folder>" +
                     "</folder>" +
                  "</folder>";
            

            IEnumerable<string> result = Folders.FolderNames(xml, 'd');
            string[] expected = { "designed" };
            CollectionAssert.AreEqual(expected, result.ToArray());
        }
        [TestMethod]
        public void IncludesDifferentElements()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                    "<file name=\"unsuspicious information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";


            IEnumerable<string> result = Folders.FolderNames(xml, 'u');
            string[] expected = { "uninstall information", "users" };
            CollectionAssert.AreEqual(expected, result.ToArray());
        }
        [TestMethod]
        public void RootContainsChar()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                    "<file name=\"unsuspicious information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";


            IEnumerable<string> result = Folders.FolderNames(xml, 'c');
            string[] expected = { "c" };
            CollectionAssert.AreEqual(expected, result.ToArray());
        }
    }
}
