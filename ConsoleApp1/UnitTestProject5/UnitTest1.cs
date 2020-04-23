using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            int[] Data = new int[4] { 61, 0, 5, 0 };
            int result = ConsoleApp1.Program.test1(Data);
            Assert.AreEqual(3, result);
        }

    }
}
