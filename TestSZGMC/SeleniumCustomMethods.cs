using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TestSZGMC
{
    public static class SeleniumCustomMethods
    {
        public static void ClickElement(this IWebElement locator, string text)
        {
            locator.Click();
            locator.SendKeys(text);
        }

        public static void SZGMCDropDown(IWebDriver driver, string text)
        {
            driver.SwitchTo().ActiveElement().SendKeys(text);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Return);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void ClickIfFound(this IWebElement locator)
        {
            if (locator.Displayed && locator.Enabled)
            {
                locator.Click();
            }
        }

        public static void SelectOptionByIndexIfDisplayed(IWebDriver driver, By emiratesBy2Id, By emiratesById, int index)
        {
            IWebElement element = null;

            if (driver.FindElement(emiratesBy2Id).Displayed)
            {
                element = driver.FindElement(emiratesBy2Id);
            }
            else if (driver.FindElement(emiratesById).Displayed)
            {
                element = driver.FindElement(emiratesById);
            }

            if (element != null)
            {
                SelectElement selectElement = new SelectElement(element);
                selectElement.SelectByIndex(index);
            }
        }

        public static void VerifyDropdownOptionsCount(this IWebElement locator, int expectedCount)
        {
            SelectElement selectElement = new SelectElement(locator);
            Assert.AreEqual(selectElement.Options.Count, expectedCount);
            return;
        }

        public static void SelectDropDownByText(this IWebElement locator, string text)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }

        public static void SelectDropDownByValue(this IWebElement locator, string value)
        {
            SelectElement selectElement = new SelectElement(locator);

            if (selectElement.AllSelectedOptions.Count == 1 && selectElement.SelectedOption.GetAttribute("value") == "0")
            {
                foreach (var option in selectElement.Options)
                {
                    if (option.GetAttribute("value") == value)
                    {
                        option.Click();
                        return;
                    }
                }
            }
            else
            {
                selectElement.SelectByValue(value);
            }
        }

        public static void SelectDropDownByIndex(this IWebElement locator, int index)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByIndex(index);
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectPrayerEmirateByIndex(IWebDriver driver, int index)
        {
            string js = $@"
            var selectElement = document.querySelector(""[id$='ddlPrayerEmirates']"");
            if (selectElement) {{
                selectElement.selectedIndex = {index};
                selectElement.dispatchEvent(new Event('change'));
            }}";
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(js);
        }

        public static void ScreenShot(IWebDriver driver)
        {
           ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            screenshot.GetScreenshot().SaveAsFile("Test.png");
            driver.Quit();
        }


        //public static void SelectDropDownValue(this IWebElement locator, string type, string value)
        //{
        //    SelectElement selectElement = new SelectElement(locator);
        //    switch (type)
        //    {
        //        case "index":
        //            selectElement.SelectByIndex(int.Parse(value));
        //            break;
        //        case "value":
        //            selectElement.SelectByValue(value);
        //            break;
        //        case "text":
        //            selectElement.SelectByText(value);
        //            break;
        //        default:
        //            Console.WriteLine("please pass correct selection");
        //            break;
        //    }
        //}

        //public static void SetDateField(this IWebElement locator)
        //{
        //    DateTime tomorrow = DateTime.Today.AddDays(1);
        //    string formattedDate = tomorrow.ToString("dd-MM-yyyy");
        //    locator.SendKeys(formattedDate);
        //}
    }
}
