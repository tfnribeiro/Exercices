using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserInput;

namespace UserInput
{
    [TestClass]
    public class UserInputTest
    {
        [TestMethod]
        public void ExampleGiven()
        {
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Assert.AreEqual("10", input.GetValue());
        }
        [TestMethod]
        public void ParentClassOnly_TextInput()
        {
            TextInput input = new TextInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Assert.AreEqual("1a0", input.GetValue());
        }
        [TestMethod]
        public void ChildClassOnly_NumericInput()
        {
            NumericInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Assert.AreEqual("10", input.GetValue());
        }
        [TestMethod]
        public void NumericInput_VariousTypeOfChar()
        {
            NumericInput input = new NumericInput();
            input.Add('1');
            input.Add('&');
            input.Add('%');
            input.Add('_');
            input.Add('§');
            input.Add('2');
            Assert.AreEqual("12", input.GetValue());
        }
        [TestMethod]
        public void TextInput_castNumericInput_VariousTypeOfChar()
        {
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('&');
            input.Add('%');
            input.Add('_');
            input.Add('§');
            input.Add('2');
            Assert.AreEqual("12", input.GetValue());
        }
        [TestMethod]
        public void TextInput_VariousTypeOfChar()
        {
            TextInput input = new TextInput();
            input.Add('1');
            input.Add('&');
            input.Add('%');
            input.Add('_');
            input.Add('§');
            input.Add('2');
            Assert.AreEqual("1&%_§2", input.GetValue());
        }
    }
}
