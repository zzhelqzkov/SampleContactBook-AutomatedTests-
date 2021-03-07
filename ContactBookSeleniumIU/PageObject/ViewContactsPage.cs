using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactBookSeleniumIU.PageObject
{
    class ViewContactsPage : BasePage
    {
        public ViewContactsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://samplecontactbook.zhivkozhelqzkov.repl.co/contacts";


        public IList<IWebElement> TableWithContacts =>
            driver.FindElements(By.ClassName("contact-entry"));


        public void OpenContact()
        {
            this.TableWithContacts[0].Click();
        }

        public string FirsContactFirstName()
        {
            return this.TableWithContacts.First().FindElement(By.CssSelector(".fname td")).Text;
        }

        public string FirsContactLastName()
        {
            return this.TableWithContacts.First().FindElement(By.CssSelector(".lname td")).Text;
        }

        public Contact LastAddedContact()
        {
            Contact Object = new Contact 
            { 
                fname = this.TableWithContacts.Last().FindElement(By.CssSelector(".fname td")).Text,
                lname = this.TableWithContacts.Last().FindElement(By.CssSelector(".lname td")).Text,
                email = this.TableWithContacts.Last().FindElement(By.CssSelector("tr .email")).Text,
                phone = this.TableWithContacts.Last().FindElement(By.CssSelector("tr .phone")).Text,
                comment = this.TableWithContacts.Last().FindElement(By.CssSelector("td .comments")).Text
            };

            return Object;
        }
    }
}
