using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

Each account on a website has a set of access flags that represent a users access.

Update and extend the enum so that it contains three new access flags:

    A Writer access flag that is made up of the Submit and Modify flags.
    An Editor access flag that is made up of the Delete, Publish and Comment flags.
    An Owner access that is made up of the Writer and Editor flags.
 
*/

namespace Account
{
    public class Account
    {
        [Flags]
        public enum Access
        {
            /*
             * Using the Flag Modifier for an enum causes
             * the enum for values to be combined. Each
             * value for the enum will then take a byte
             * and allows for the combination of bytes
             * to represent a combination of the permissions.
             * 
             * To allow for easily visibility I used the left-shift
             * operator. 
             */
            None    = 0, 
            Delete  = 1 << 0, //1  Shift Left 0 = 1
            Publish = 1 << 1, //2  Shift Left 1 = 10
            Submit  = 1 << 2, //4  Shift Left 2 = 100
            Comment = 1 << 3, //8  Shift Left 3 = 1000
            Modify  = 1 << 4, //16 Shift Left 4 = 10000
        //[NextVal] = 1 << 5, //32
        //...


            Writer = Submit | Modify, // 10100
            Editor = Delete | Publish | Comment, // 01011
            Owner = Writer | Editor // 11111
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Account.Access.Writer.HasFlag(Account.Access.Delete)); //Should print: "False"
        }
    }
}
