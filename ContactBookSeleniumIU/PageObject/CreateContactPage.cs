using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookSeleniumIU.PageObject
{
    class CreateContactPage : BasePage
    {
        public CreateContactPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://samplecontactbook.zhivkozhelqzkov.repl.co/contacts/create";

        public IWebElement InputFieldFirstName =>
            driver.FindElement(By.Id("firstName"));

        public IWebElement InputFieldLastName =>
            driver.FindElement(By.Id("lastName"));

        public IWebElement InputFieldEmail =>
            driver.FindElement(By.Id("email"));

        public IWebElement InputFieldPhone =>
            driver.FindElement(By.Id("phone"));

        public IWebElement InputFieldComments =>
            driver.FindElement(By.Id("comments"));

        public IWebElement buttonSubmit =>
            driver.FindElement(By.CssSelector("form button"));

        public IWebElement ErrorMsgField =>
            driver.FindElement(By.ClassName("err"));

        public void createContact(Contact contact)
        {
            this.InputFieldFirstName.SendKeys(contact.fname);
            this.InputFieldLastName.SendKeys(contact.lname);
            this.InputFieldEmail.SendKeys(contact.email);
            this.InputFieldPhone.SendKeys(contact.phone);
            this.InputFieldComments.SendKeys(contact.comment);
            this.buttonSubmit.Click();
        }

        public string ErrorMsg()
        {
            return this.ErrorMsgField.Text;
        }
    }
}
