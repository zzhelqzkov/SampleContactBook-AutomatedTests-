using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace ContactBookMobileApp
{
    public class ContactBookApp
    {

        private AndroidDriver<AndroidElement> driver;
        private const string backendUrl = "https://contactbook.nakov.repl.co/api";

        [OneTimeSetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions() { PlatformName = "Android" };
            appiumOptions.AddAdditionalCapability("app", @"C:\Users\zhivko\Documents\QA automatio\Final Exam\contactbook-androidclient.apk");

            driver = new AndroidDriver<AndroidElement>(
                new Uri("http://[::1]:4723/wd/hub"), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void ContactBookTest()
        {
            var backEndInputField = driver.FindElementById("contactbook.androidclient:id/editTextApiUrl");
            backEndInputField.Clear();
            backEndInputField.SendKeys(backendUrl);

            var buttonConnect = driver.FindElementById("contactbook.androidclient:id/buttonConnect");
            buttonConnect.Click();
            
            var keywordInputField = driver.FindElementById("contactbook.androidclient:id/editTextKeyword");
            keywordInputField.SendKeys("steve");

            var buttonSearch = driver.FindElementById("contactbook.androidclient:id/buttonSearch");
            buttonSearch.Click();

            var firstName = driver.FindElementById("contactbook.androidclient:id/textViewFirstName");
            var lastName = driver.FindElementById("contactbook.androidclient:id/textViewLastName");

            Assert.AreEqual("Steve", firstName.Text);
            Assert.AreEqual("Jobs", lastName.Text);

        }


        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}