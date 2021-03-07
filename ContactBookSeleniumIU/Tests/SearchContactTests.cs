using ContactBookSeleniumIU.PageObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookSeleniumIU.Tests
{
    class SearchContactTests : BaseTest
    {
        // Find contacts by keyword “albert” and assert that the first result holds “Albert Einstein”
        [Test]
        public void SearchByValidKeyword()
        {
            var page = new SearchContactsPage(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());

            page.SearchContact("albert");

            var pageView = new ViewContactsPage(driver);

            Assert.IsTrue(pageView.FirsContactFirstName() == "Albert");
            Assert.IsTrue(pageView.FirsContactLastName() == "Einstein");

        }

        // Find contacts by keyword “invalid2635” and assert that the results are empty
        [Test]
        public void SearchByInvalidKeyword()
        {
            var page = new SearchContactsPage(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());

            page.SearchContact("invalid2635");

            Assert.IsTrue(page.SearchResultMsg().Contains("No contacts found."));

        }
    }
}
