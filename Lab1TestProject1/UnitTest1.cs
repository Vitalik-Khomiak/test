using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int n = 1352;
            int resultsum = lab1.Program.summa(n);
            Assert.AreEqual(11, resultsum);

            int resultdob = lab1.Program.dob(n);
            Assert.AreEqual(30,resultdob);
        }
    }
}
