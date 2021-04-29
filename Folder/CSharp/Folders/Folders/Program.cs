using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Folders
{
    public class Folders
    {
        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            XElement folderStructure = XElement.Parse(xml);
            IEnumerable<string> startLetterFolders = from folder in folderStructure.DescendantsAndSelf("folder")
                                                     // Usage of DescendantsandSelf is needed as the first element
                                                     // can be a folder element in of itself. 
                                                     // If Descendant is used then it wouldn't take root into
                                                     // consideration.
                                                     where ((string)folder.Attribute("name"))[0] == startingLetter
                                                     select (string)folder.Attribute("name");

            return startLetterFolders;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

            foreach (string name in Folders.FolderNames(xml, 'u'))
                Console.WriteLine(name);
            Console.ReadLine();
        }
    }
}
