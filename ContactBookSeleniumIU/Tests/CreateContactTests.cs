using ContactBookSeleniumIU.PageObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookSeleniumIU.Tests
{
    class CreateContactTests : BaseTest
    {
        // Try to create a new contact, holding invalid data, and assert an error is shown
        [Test]
        public void CreateNewContact_Empty_Name()
        {
            var page = new CreateContactPage(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());

            var contactData = new Contact
            {
                fname = "",
                lname = "Nakov",
                email = "nakov@nakov.bg",
                phone = "+359888624598",
                comment = "Softuni owner and trainer"
            };

            page.createContact(contactData);

            Assert.AreEqual(page.ErrorMsg(), "Error: First name cannot be empty!");
        }

        [Test]
        public void CreateNewContact_Invailid_Email()
        {
            var page = new CreateContactPage(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());

            var contactData = new Contact
            {
                fname = "Svetlin",
                lname = "Nakov",
                email = "nakov",
                phone = "+359888624598",
                comment = "Softuni owner and trainer"
            };

            page.createContact(contactData);

            Assert.AreEqual(page.ErrorMsg(), "Error: Invalid email!");
        }

        //Create a new contact, holding valid data, 
        //and assert the new contact is added and is properly listed at the end of the contacts page

        [Test]
        public void CreateNewContact_Vailid_Data()
        {
            var page = new CreateContactPage(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());

            var contactData = new Contact
            {
                fname = "Svetlin",
                lname = "Nakov",
                email = "nakov@nakov.com",
                phone = "+359888624598",
                comment = "Softuni owner and trainer"
            };

            page.createContact(contactData);

            var pageView = new ViewContactsPage(driver);
            var actualResault = pageView.LastAddedContact();

            Assert.AreEqual(contactData.email, actualResault.email);
            Assert.AreEqual(contactData.fname, actualResault.fname);
            Assert.AreEqual(contactData.lname, actualResault.lname);
            Assert.AreEqual(contactData.phone, actualResault.phone);
            Assert.AreEqual(contactData.comment, actualResault.comment);

            // Опитах да асъртна че двата обекта са еднакви но не ми стигна времето за да видя къде греша
            //Assert.That(contactData, Is.SameAs(actualResault));
            //Assert.AreEqual(contactData, actualResault);
        }
    }
}
