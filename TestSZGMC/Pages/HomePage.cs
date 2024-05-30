using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace TestSZGMC.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        // IWebElement EmiratesById => driver.FindElement(By.CssSelector("[id$='ddlPrayerEmirates']"));

        IWebElement Emirates => driver.FindElement(By.Name("ctl00$contentMain$ContentLeft1$ddlPrayerEmirates"));

        IWebElement AbuDhabicity => driver.FindElement(By.Name("ctl00$contentMain$ContentLeft1$ddlPrayerCities"));

        IWebElement message => driver.FindElement(By.Id("btnClose"));

        public void FillBookingForm()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SeleniumCustomMethods.ClickIfFound(message);

            SeleniumCustomMethods.VerifyDropdownOptionsCount(Emirates, 7);
            Thread.Sleep(10000);
            string js = "var selectElement = document.querySelector(\"[id$='ddlPrayerEmirates']\");selectElement.selectedIndex = 0; selectElement.dispatchEvent(new Event(\"change\"));";
            driver.ExecuteJavaScript(js);

            SeleniumCustomMethods.VerifyDropdownOptionsCount(AbuDhabicity, 31);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string js1 = "var selectElement = document.querySelector(\"[id$='ddlPrayerEmirates']\");selectElement.selectedIndex = 1; selectElement.dispatchEvent(new Event(\"change\"));";
            driver.ExecuteJavaScript(js1);

            SeleniumCustomMethods.VerifyDropdownOptionsCount(AbuDhabicity, 3);
            Thread.Sleep(1000);

            string js2 = "var selectElement = document.querySelector(\"[id$='ddlPrayerEmirates']\");selectElement.selectedIndex = 2; selectElement.dispatchEvent(new Event(\"change\"));";
            driver.ExecuteJavaScript(js2);

            SeleniumCustomMethods.VerifyDropdownOptionsCount(AbuDhabicity, 8);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string js3 = "var selectElement = document.querySelector(\"[id$='ddlPrayerEmirates']\");selectElement.selectedIndex = 3; selectElement.dispatchEvent(new Event(\"change\"));";
            driver.ExecuteJavaScript(js3);

            SeleniumCustomMethods.VerifyDropdownOptionsCount(AbuDhabicity, 3);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string js4 = "var selectElement = document.querySelector(\"[id$='ddlPrayerEmirates']\"); selectElement.selectedIndex = 4; selectElement.dispatchEvent(new Event(\"change\"));";
            driver.ExecuteJavaScript(js4);

            SeleniumCustomMethods.VerifyDropdownOptionsCount(AbuDhabicity, 1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string js5 = "var selectElement =document.querySelector(\"[id$='ddlPrayerEmirates']\"); selectElement.selectedIndex = 5; selectElement.dispatchEvent(new Event(\"change\"));";
            driver.ExecuteJavaScript(js5);
            SeleniumCustomMethods.VerifyDropdownOptionsCount(AbuDhabicity, 7);
            Thread.Sleep(10000);

            string js6 = "var selectElement = document.querySelector(\"[id$='ddlPrayerEmirates']\"); selectElement.selectedIndex = 6; selectElement.dispatchEvent(new Event(\"change\"));";
            driver.ExecuteJavaScript(js6);

            SeleniumCustomMethods.VerifyDropdownOptionsCount(AbuDhabicity, 7);
        }
    }
}

