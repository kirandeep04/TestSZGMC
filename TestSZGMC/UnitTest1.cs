using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestSZGMC.Pages;


namespace TestSZGMC
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            //_driver = new ChromeDriver();
            //_driver.Navigate().GoToUrl("https://www.szgmc.gov.ae/en/home");
            //_driver.Manage().Window.Maximize();
            //Thread.Sleep(1000);
        }

        [Test]
        public void LaunchBrowser()
        {
            List<string> urls = new List<string>
            {
                "https://www.szgmc.gov.ae/en/Home",
            "https://www.szgmc.gov.ae/en/ClubCarBookings.aspx",
                "https://www.szgmc.gov.ae/en/EGuideBookings.aspx",
               "https://www.szgmc.gov.ae/en/tour-booking-form.aspx",
               "https://www.szgmc.gov.ae/en/sura-booking",
               "https://www.szgmc.gov.ae/en/careers",
                "https://www.szgmc.gov.ae/en/friday-sermon",
               "https://www.szgmc.gov.ae/en/ramadan-activities",
                "https://www.szgmc.gov.ae/en/resendActivation.aspx",
                "https://www.szgmc.gov.ae/en/search.aspx",
                "https://www.szgmc.gov.ae/en/sitemap.aspx",
                "https://www.szgmc.gov.ae/en/suggestion-complaint.aspx",
                "https://www.szgmc.gov.ae/en/TourOperatorLogIn.aspx",
                "https://www.szgmc.gov.ae/en/userlogin?ReturnUrl=%2fen%2fuser_profile.aspx",
                "https://www.szgmc.gov.ae/en/UserLogin.aspx",
                "https://www.szgmc.gov.ae/en/mosque-manner",
                "https://www.szgmc.gov.ae/en/mosque-opening-hours",
                "https://www.szgmc.gov.ae/en/registration_form",
                "https://www.szgmc.gov.ae/en/getting-to-the-mosque",
                "https://www.szgmc.gov.ae/en/services",
                "https://www.szgmc.gov.ae/en/questions",
                "https://www.szgmc.gov.ae/en/prayer-timings",
                "https://www.szgmc.gov.ae/en/contact-us.aspx",
                "https://www.szgmc.gov.ae/en/Default.aspx",
                "https://www.szgmc.gov.ae/en/forgot-password.aspx",
                "https://www.szgmc.gov.ae/en/Filming-Permission.aspx",
                "https://www.szgmc.gov.ae/en/IslamicGardenEvent.aspx",
                "https://www.szgmc.gov.ae/en/lost-found.aspx",
                "https://www.szgmc.gov.ae/en/News_List.aspx",
                "https://www.szgmc.gov.ae/en/photography_award.aspx",
                "https://www.szgmc.gov.ae/en/poll-archive.aspx",
                "https://www.szgmc.gov.ae/en/publication_List.aspx",
                "https://www.szgmc.gov.ae/en/QuranRecitationCourse.aspx",
                "https://www.szgmc.gov.ae/en/exhibitions",
                "https://www.szgmc.gov.ae/en/activities",
                "https://www.szgmc.gov.ae/en/social-initiatives",
                "https://www.szgmc.gov.ae/en/spaces-of-light",
                "https://www.szgmc.gov.ae/en/children-handbook",
                "https://www.szgmc.gov.ae/en/media-form",
                "https://www.szgmc.gov.ae/en/Contactus.aspx"
            };

            foreach (string url in urls)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Navigate().GoToUrl(url);
                Thread.Sleep(10000);
                HomePage homePage = new HomePage(_driver);
                homePage.FillBookingForm();
                _driver.Quit();
            }
        }

        //[Test]
        //public void Test1()
        //{
        //    HomePage homePage = new HomePage(_driver);

        //    homePage.FillBookingForm();

        //}

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