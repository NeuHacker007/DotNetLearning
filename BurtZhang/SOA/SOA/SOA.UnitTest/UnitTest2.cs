using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SOA.UnitTest.MyWebWCF;


namespace SOA.UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            //using (MyWebWCF.MyWCFClient client = new MyWCFClient())
            //{
            //    client.DoWork();
            //    client.GetUsers(3);
            //    client.GetString();
            //}

            MyWCFClient client = null;

            try
            {
                client = new MyWCFClient();
                client.DoWork();
                client.GetUsers(3);
                client.GetString();

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (client != null) client.Abort();
                throw;
            }
        }
    }
}
