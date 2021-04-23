using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeNames
{
    public class MergeNames
    {
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            List<string> newName = new List<string>();

            foreach (string name in names1)
            {
                if (!newName.Contains(name))
                    newName.Add(name);
            }
            foreach (string name in names2)
            {
                if (!newName.Contains(name))
                    newName.Add(name);
            }
            return newName.ToArray();
        }
        public static string[] UniqueNamesLINQ(string[] names1, string[] names2)
        {
            IEnumerable<string> query =
                names1.Select(name1 => name1).Concat(names2.Select(name2 => name2)).Distinct();
            return query.ToArray();
        }
    }
    class Program
    {

        public static void Main(string[] args)
        {
            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
            Console.WriteLine(string.Join(", ", MergeNames.UniqueNamesLINQ(names1, names2))); // should print Ava, Emma, Olivia, Sophia
            Console.ReadKey();
        }
    }
}
