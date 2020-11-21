using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyVault.Core.Tests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void ShouldGenerate8CharsLongPassword()
        {
            var password = MyVault.Core.Password.Generate();
            Assert.AreEqual(password.Length, 8);
        }
    }
}
