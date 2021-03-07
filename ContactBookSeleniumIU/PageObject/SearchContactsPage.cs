using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookSeleniumIU.PageObject
{
    class SearchContactsPage : BasePage
    {
        public SearchContactsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://samplecontactbook.zhivkozhelqzkov.repl.co/contacts/search";

        public IWebElement SearchButton =>
            driver.FindElement(By.CssSelector("form button"));

        public IWebElement SearchField =>
            driver.FindElement(By.Id("keyword"));

        public IWebElement SearchResaultMsgField =>
            driver.FindElement(By.Id("searchResult"));

        public void SearchContact(string keyword)
        {
            this.SearchField.SendKeys(keyword);
            this.SearchButton.Click();
        }

        public string SearchResultMsg()
        {
            return this.SearchResaultMsgField.Text;
        }
    }
}
