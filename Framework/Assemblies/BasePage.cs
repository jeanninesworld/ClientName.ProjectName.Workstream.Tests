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
            try
            {
                elem = WaitHelper.WaitForElementPresent(Driver, locator, timeToWait);
            }
            catch(StaleElementReferenceException ex)
            {
                elem = WaitHelper.WaitForElementPresent(Driver, locator, timeToWait);
            }
            return elem;
        }

        public IWebElement GetClickableElement(By locator, TimeSpan timeToWait)
        {
            IWebElement elem = null;
            try
            {
                elem = WaitHelper.WaitForElementVisible(Driver, locator, timeToWait);
            }
            catch(StaleElementReferenceException ex)
            {
                elem = WaitHelper.WaitForElementVisible(Driver, locator, timeToWait);
            }
            return elem;
        }

        public IReadOnlyCollection<IWebElement>GetElements(By locator, TimeSpan timeToWait)
        {
            IReadOnlyCollection<IWebElement> elems = null;
            try
            {
                elems = WaitHelper.WaitForElementsPresent(Driver, locator, timeToWait);
            }
            catch (StaleElementReferenceException ex)
            {
                elems = WaitHelper.WaitForElementsPresent(Driver, locator, timeToWait);
            }
            return elems;  
            
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
