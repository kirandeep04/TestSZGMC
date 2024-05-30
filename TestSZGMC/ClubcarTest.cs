using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestSZGMC.Pages;

namespace TestSZGMC
{
    public class ClubcarTest
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.szgmc.gov.ae/en/ClubCarBookings.aspx");
            _driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        [Test]
        public void Test1()
        {
            ClubCarPage clubcarPage = new ClubCarPage(_driver);

            clubcarPage.FillBookingForm("kiran", "9876567890", "India", "k@gmail.com", "2", "English");

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
    }
}