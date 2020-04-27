using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifier.Tests
{
    [TestClass]
    public class CheckIdentifier
    {
        [TestMethod]
        public void Empty_identifier()
        {
            bool res = Program.CheckIdentifierForErrors("");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Identifier_begin_with_number()
        {
            bool res = Program.CheckIdentifierForErrors("1abc");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Identifier_with_incorect_char()
        {
            bool res = Program.CheckIdentifierForErrors("abc.d");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Correct_identifier()
        {
            bool res = Program.CheckIdentifierForErrors("ab12cd2");
            Assert.IsTrue(res);
        }
    }
}
