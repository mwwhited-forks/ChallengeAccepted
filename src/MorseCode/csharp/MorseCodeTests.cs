using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MorseCode
{
    [TestClass]
    public class MorseCodeTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow("Hello, World!", ".... . .-.. .-.. ---  .-- --- .-. .-.. _..")]
        [DataRow("hello world", ".... . .-.. .-.. ---  .-- --- .-. .-.. _..")]
        [DataRow("abcdefghijklmnopqrstuvwxyz1234567890", ".- -... -.-. _.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----")]
        public void EncodeTest(string message, string expected)
        {
            var result = new MorseCode().Encode(message);
            this.TestContext.WriteLine($"{message} -> {result}");
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(".... . .-.. .-.. ---  .-- --- .-. .-.. _..", "HELLO WORLD")]
        [DataRow( ".- -... -.-. _.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----", "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890")]
        public void DecodeTest(string message, string expected)
        {
            var result = new MorseCode().Decode(message);
            this.TestContext.WriteLine($"{message} -> {result}");
            Assert.AreEqual(expected, result);
        }
    }
}
