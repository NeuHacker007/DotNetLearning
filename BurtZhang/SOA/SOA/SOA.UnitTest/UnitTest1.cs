using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SOA.UnitTest.SOAUnitTest;

namespace SOA.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {

        }
        [TestMethod]
        public void TestMethod()
        {
            using (MyWebServiceSoapClient client = new MyWebServiceSoapClient())
            {
               var result1 = client.HelloWorld();
               var result2 = client.Get();
               var result3 = client.Plus(1, 2);

                Assert.AreEqual(3, result3);
                Assert.AreEqual("Hello World", result1);
                //Assert.IsInstanceOfType(result2, typeof(User));
            }

        }
    }
}
