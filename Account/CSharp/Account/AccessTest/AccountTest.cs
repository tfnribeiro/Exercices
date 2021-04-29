using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Account;

namespace Account
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void BaseCase_WriterDelete()
        {
            Assert.AreEqual(false, Account.Access.Writer.HasFlag(Account.Access.Delete));
        }
        [TestMethod]
        public void Owner_has_all_base_permissions()
        {
            Assert.AreEqual(true, Account.Access.Owner.HasFlag(Account.Access.Delete)
                && Account.Access.Owner.HasFlag(Account.Access.Publish)
                && Account.Access.Owner.HasFlag(Account.Access.Submit)
                && Account.Access.Owner.HasFlag(Account.Access.Comment)
                && Account.Access.Owner.HasFlag(Account.Access.Modify));
        }
        [TestMethod]
        public void Owner_has_Writer_and_Editor()
        {
            Assert.AreEqual(true, Account.Access.Owner.HasFlag(Account.Access.Writer)
                && Account.Access.Owner.HasFlag(Account.Access.Editor));
        }
        [TestMethod]
        public void Writer_has_Submit_Modify()
        {
            Assert.AreEqual(true, Account.Access.Writer.HasFlag(Account.Access.Submit)
                && Account.Access.Writer.HasFlag(Account.Access.Modify));
        }
        [TestMethod]
        public void Editor_has_delete_publish_comment()
        {
            Assert.AreEqual(true, Account.Access.Editor.HasFlag(Account.Access.Delete)
                && Account.Access.Editor.HasFlag(Account.Access.Publish)
                && Account.Access.Editor.HasFlag(Account.Access.Comment));
        }
    }
}
