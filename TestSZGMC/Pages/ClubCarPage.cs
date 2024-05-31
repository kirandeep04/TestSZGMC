using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSZGMC.Pages
{
    public class ClubCarPage
    {
        private readonly IWebDriver driver;

        public ClubCarPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement Name => driver.FindElement(By.Id("txtVisiterName"));
        IWebElement PhoneNumber => driver.FindElement(By.Id("txtVisiterPhoneNumber"));
        IWebElement nationality => driver.FindElement(By.Id("select2-ddlNationality-container"));
        IWebElement Email => driver.FindElement(By.Id("txtVisiterEmail"));
        IWebElement date => driver.FindElement(By.Id("txtProposedVisitDate"));
        IWebElement Size => driver.FindElement(By.Id("txtGroupsize"));
        IWebElement Chooselanguage => driver.FindElement(By.Id("ddlLanguage"));
        IWebElement captcha => driver.FindElement(By.Id("txtCaptcha"));
        IWebElement Submit => driver.FindElement(By.Id("btnPayment"));


        public void FillBookingForm(string name, string phonenumber, string Nationality, string email, string groupSize, string language)
        {
            Name.ClickElement(name);
            PhoneNumber.ClickElement(phonenumber);
            nationality.Click();
            SeleniumCustomMethods.SZGMCDropDown(driver, Nationality);
            Email.ClickElement(email);
            date.Click();
            DateTime currentDate = DateTime.Now;
            DateTime targetDate = currentDate.AddDays(1);
            int day = targetDate.Day;
            string js = $"$('.ui-state-default').filter((x, obj) => $(obj).text() == '{day}').click()";
            driver.ExecuteJavaScript(js);
            Thread.Sleep(10000);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //string js2 = "$('#ddlProposedTime option').map((x, obj) => $(obj).val())[2]";
            //driver.ExecuteJavaScript(js2);
            string js2 = "$('#ddlProposedTime').val($('#ddlProposedTime option:eq(2)').val())";
            driver.ExecuteJavaScript(js2);
            Size.ClickElement(groupSize);
            SeleniumCustomMethods.SelectDropDownByText(Chooselanguage, language);
            //captcha.EnterText(captcha.Text);
            Submit.Click();
        }
    }
}
