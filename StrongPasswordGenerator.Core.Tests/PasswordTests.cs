using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StrongPasswordGenerator.Core.Tests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void ShouldGenerate12CharsLongPassword()
        {
            var password = Password.Generate(12);
            Assert.AreEqual(12, password.Length);
        }
    }
}