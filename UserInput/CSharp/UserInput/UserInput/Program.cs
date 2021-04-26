using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class TextInput
    {
        protected string value;
        public TextInput()
        {
            value = "";
        }
        public TextInput(string value)
        {
            this.value = value;
        }
        public virtual void Add(char c)
        {
            value += c;
        }
        public string GetValue()
        {
            return value;
        }

    }
    public class NumericInput : TextInput
    {
        public override void Add(char c)
        {
            // Override ensures that the ParentClass method is
            // never called. If the new keyword is used, when 
            // running the example bellow, the 'a' would be added.
            // This is because when new is used it will check the first
            // method in the hierarchy that is common on both classes.
            // When override is used, the method specific to the object
            // class will be used. Otherwise, if not defined, it will use
            // the parent class.
            int v;
            bool isNumeric = int.TryParse(c.ToString(), out v);
            if (isNumeric)
                this.value += c;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Console.WriteLine(input.GetValue());
            Console.ReadLine();
        }
    }
}
