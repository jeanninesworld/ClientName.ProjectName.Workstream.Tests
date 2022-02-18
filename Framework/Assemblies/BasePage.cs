using Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Assemblies
{
    public class BasePage
    {
        IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnterText(By locator, TimeSpan timeToWait, string textToEnter)
        {
            GetElement(locator, timeToWait).SendKeys(textToEnter);
        }
        public void Click(By locator, TimeSpan timeToWait)
        {
            GetElement(locator, timeToWait).Click();
        }

        public IWebElement GetElement(By locator, TimeSpan timeToWait)
        {
            IWebElement elem = null;
            if(WaitHelper.IsElementPresent(Driver,locator, timeToWait) == true)
            {
                elem = Driver.FindElement(locator);
            }

            return elem;
        }

        public IReadOnlyCollection<IWebElement>GetElements(By locator, TimeSpan timeToWait)
        {
            return WaitHelper.WaitForElementsPresent(Driver, locator, timeToWait);            
        }

        public string GetTitle()
        {
            return Driver.Title;
        }

        protected IWebDriver Driver
        {
            get {  return _driver; }
            set {  _driver = value; }
        }



    }
}
