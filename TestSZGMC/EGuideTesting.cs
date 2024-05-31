using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestSZGMC.Pages;

namespace TestSZGMC
{
    public class EGuideTesting
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void LoadURLs()
        {
            List<string> urls = new List<string>
            {
                "https://www.szgmc.gov.ae/en/ClubCarBookings.aspx",

                "https://www.szgmc.gov.ae/en/EGuideBookings.aspx"
            };

            foreach (string url in urls)
            {
                _driver.Navigate().GoToUrl(url);
                EGuidePage eGuidePage = new EGuidePage(_driver);
                FillForm(eGuidePage);
            }
        }

        public void FillForm(EGuidePage eGuidePage)
        {
            eGuidePage.EnterName("Raman");
            eGuidePage.EnterPhone("9766555555");
            SeleniumCustomMethods.WaitForPageToLoad(_driver, 10);
            eGuidePage.SelectNationality("India");
            eGuidePage.EnterEmail("R@gmail.com");
            eGuidePage.SelectDate();
            _driver.TakeScreenshotAndSave("ScrTester.png");
            eGuidePage.SelectTime();
            eGuidePage.EnterSize("2");
            eGuidePage.SelectLanguage("English");
            eGuidePage.SubmitForm();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}