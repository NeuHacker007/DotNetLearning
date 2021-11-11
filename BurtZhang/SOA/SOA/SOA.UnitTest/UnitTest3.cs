using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SOA.UnitTest.ConsoleWCF;

namespace SOA.UnitTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConsoleWCF.MathServiceClient client = null;
            try
            {
                client = new MathServiceClient();
                var result = client.PlusInt(1, 2);
                Assert.AreEqual(3,result);
                client.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (client != null)
                {
                    client.Abort();
                }
                throw;
            }
        }
    }
}
