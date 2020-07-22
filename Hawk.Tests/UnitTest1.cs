using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hawk.Core.Data;

namespace Hawk.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrud()
        {
            Controller dbC = new Controller();
            Assert.IsTrue(dbC.Context.Database.CanConnect(), "Database does not exist and was not created as expected on Context instantiation");

        }
    }
}
