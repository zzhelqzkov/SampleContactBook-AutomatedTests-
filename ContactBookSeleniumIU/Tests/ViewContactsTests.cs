using ContactBookSeleniumIU.PageObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookSeleniumIU.Tests
{
    class ViewContactsTests : BaseTest
    {
        // List contacts and assert that the first contact is “Steve Jobs”
        [Test]
        public void AsserFirstContactIsSteveJobs()
        {
            var page = new ViewContactsPage(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());
            
            Assert.IsTrue(page.FirsContactFirstName() == "Steve");
            Assert.IsTrue(page.FirsContactLastName() == "Jobs");
        }
    }
}
