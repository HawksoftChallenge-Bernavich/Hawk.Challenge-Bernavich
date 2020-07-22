using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hawk.Core.Data;
using System.Collections.Generic;
using System.Linq;
using Hawk.Core.Data.Model;

namespace Hawk.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadTest()
        {
            /*  The application must support a minimum of 20,000 users daily with each user having 
                roughly ~1,000 contact records. */
        }

        [TestMethod]
        public void TestCrud()
        {
            //Test database creation at instantiation IF it does not exist
            Controller dbController = new Controller();
            Assert.IsTrue(dbController.Context.Database.CanConnect(), "Database does not exist and was not created as expected on Context instantiation");

           int rowCount = dbController.Context.Contacts.Count();
           Assert.AreNotEqual(0,rowCount, "Expected initial records set");

            //INSERT
            Contact newRow = new Contact();

            newRow.Address = "Unit Test Land";
            newRow.Email = "UnitTestEmail1@gmail.com";
            newRow.Name = "UT VerifyDbInsert";

            dbController.Create(newRow);
            int newKey = newRow.ContactId;

            //check if it was put in our collection
            var results = dbController.Context.Contacts.Where(c => c.Name == "UT VerifyDbInsert").ToList();
            Assert.AreEqual(results.Count(), 1);

            //UPDATE
            newRow.Name = "UT Updated";
            dbController.Update(newRow);
            var old = dbController.Context.Contacts.Where(c => c.Name == "UT VerifyDbInsert").ToList();
            var newChange = dbController.Context.Contacts.Where(c => c.Name == "UT Updated").ToList();

            Assert.AreEqual(old.Count(), 0, "Should not be any records with the old name");
            Assert.AreEqual(newChange.Count(),1, results.Count(), "Should be one record with new name");

            //DELETE
            dbController.Delete(newRow);
            results = dbController.Context.Contacts.Where(c => c.Name == "UT VerifyDbInsert").ToList();
            Assert.AreEqual(0, results.Count());

        }
    }
}
