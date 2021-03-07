using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookSeleniumIU.PageObject
{
    class BasePage
    {
        protected readonly IWebDriver driver;

        public virtual string PageUrl { get; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }
    }
}
