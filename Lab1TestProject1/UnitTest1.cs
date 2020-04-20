using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string n = "Autumn";
            int resultsum = lab1.Program.main(n);
            Assert.AreEqual(9, resultsum);

           
        }
    }
}
