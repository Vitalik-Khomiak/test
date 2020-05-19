using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {





            int R = 90;
            int result = ConsoleApp1.Program.Rating_write(R);
            Assert.AreEqual(1, result);


        }
    }
}

    

