using NUnit.Framework.Internal;
using OpenQA.Selenium;


namespace TestSZGMC.Pages
{
    public class EGuidePage
    {
        private readonly IWebDriver driver;

        public EGuidePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement Name => driver.FindElement(By.Id("txtVisiterName"));
        IWebElement PhoneNumber => driver.FindElement(By.Id("txtVisiterPhoneNumber"));
        IWebElement nationality => driver.FindElement(By.Id("ddlNationality"));
        IWebElement Email => driver.FindElement(By.Id("txtVisiterEmail"));
        IWebElement date => driver.FindElement(By.Id("txtProposedVisitDate"));
        IWebElement Size => driver.FindElement(By.Id("txtGroupsize"));
        IWebElement Chooselanguage => driver.FindElement(By.Id("ddlLanguage"));
        IWebElement Submit => driver.FindElement(By.Id("btnPayment"));
        public void fillBookingForm(string name, string phoneNumber)//, string Email, DateTime date,int Size,string Chooselanguage) 
        {
            SeleniumCustomMethods.ClickElement(Name, name);
            SeleniumCustomMethods.ClickElement(PhoneNumber, phoneNumber);
            SeleniumCustomMethods.SelectDropDownByIndex(nationality,4);
        }



    }
}
