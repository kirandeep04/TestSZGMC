using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

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
        IWebElement nationality => driver.FindElement(By.XPath("//*[@id='select2-ddlNationality-container']"));
        IWebElement Email => driver.FindElement(By.Id("txtVisiterEmail"));
        IWebElement date => driver.FindElement(By.Id("txtProposedVisitDate"));
        IWebElement Size => driver.FindElement(By.Id("txtGroupsize"));
        IWebElement Chooselanguage => driver.FindElement(By.Id("ddlLanguage"));
        IWebElement Submit => driver.FindElement(By.Id("btnPayment"));
        IWebElement captchaImage => driver.FindElement(By.Id("txtCaptcha"));
        public void EnterName(string name)
        {
            SeleniumCustomMethods.ClickElement(Name, name);
        }
        public void EnterPhone(string phoneNumber)
        {
            PhoneNumber.ClickElement(phoneNumber);
        }
        public void SelectNationality(string Nationality)
        {
            SeleniumCustomMethods.ClickIfFound(nationality);
            SeleniumCustomMethods.SZGMCDropDown(driver, Nationality);
        }


        public void EnterEmail(string email)
        {
            Email.ClickElement(email);
        }
        public void SelectDate()
        {
            date.Click();
            DateTime currentDate = DateTime.Now;
            DateTime targetDate = currentDate.AddDays(1);
            int day = targetDate.Day;
            string js = $"$('.ui-state-default').filter((x, obj) => $(obj).text() == '{day}').click()";
            driver.ExecuteJavaScript(js);
        }
        public void SelectTime()
        {
            string js2 = "$('#ddlProposedTime').val($('#ddlProposedTime option:eq(2)').val())";
            driver.ExecuteJavaScript(js2);
        }
        public void EnterSize(string groupSize)
        {
            Size.ClickElement(groupSize);
        }
        public void SelectLanguage(string language)
        {
            SeleniumCustomMethods.SelectDropDownByText(Chooselanguage, language);
        }

        public void SubmitForm()
        {
            Submit.Click();
        }
    }
}
