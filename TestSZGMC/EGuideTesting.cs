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
            _driver.Navigate().GoToUrl("https://www.szgmc.gov.ae/en/EGuideBookings.aspx");
            _driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        [Test]
        public void Test()
        {
            EGuidePage eGuidePage = new EGuidePage(_driver);
            eGuidePage.fillBookingForm("kiran", "67554443433");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

    }
}
