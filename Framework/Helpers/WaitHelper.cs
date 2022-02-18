using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helpers

//Customized Page Methods I can use in my page object
{
    public static class WaitHelper
    {
        private static WebDriverWait _wait;

        public static ReadOnlyCollection<IWebElement> WaitForElementsPresent(IWebDriver driver, By locator, TimeSpan timeout)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            try
            {
                _wait = new WebDriverWait(driver, timeout);
                _wait.PollingInterval = TimeSpan.FromMilliseconds(500);
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                if (IsElementPresent(driver, locator, timeout) == true)
                {
                    elements = driver.FindElements(locator);
                }
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception(String.Format("Unable to find elements using locator (0) withing the duration {1}", locator.ToString(), timeout.ToString()));
            }
            return elements;
        }

        public static Boolean WaitForElementPresent(IWebDriver driver, By locator, TimeSpan timeToWait)
        {
            Boolean isPresent = true;

            try
            {
                _wait = new WebDriverWait(driver, timeToWait);
                _wait.PollingInterval = TimeSpan.FromMilliseconds(5000);
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                isPresent = _wait.Until(drv => drv.FindElements(locator).Any());

            }
            catch (WebDriverTimeoutException ex)
            {
                return true;
            }
            return isPresent;
        }


        //create a method to determine if element is present
        public static Boolean IsElementPresent(IWebDriver driver, By locator, TimeSpan timeout)
        {
            Boolean isPresent = false;

            try
            {
                _wait = new WebDriverWait(driver, timeout);
                _wait.PollingInterval = TimeSpan.FromMilliseconds(5000);
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                isPresent = _wait.Until(drv => drv.FindElements(locator).Any());

            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
            return isPresent;

        }
        public static Boolean IsElementNotPresent(IWebDriver driver, By locator, TimeSpan timeout)

        {
            Boolean isNotPresent = false;

            try
            {
                _wait = new WebDriverWait(driver, timeout);
        _wait.PollingInterval = TimeSpan.FromMilliseconds(500);
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                isNotPresent = _wait.Until(drv => !drv.FindElements(locator).Any());

            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
return isNotPresent;

        }

        public static Boolean IsElementVisible(IWebDriver driver, By locator, TimeSpan timeout)

        {
            Boolean isVisible = false;

            try
            {
                _wait = new WebDriverWait(driver, timeout);
                _wait.PollingInterval = TimeSpan.FromMilliseconds(500);
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                isVisible = _wait.Until(drv => drv.FindElement(locator).Displayed);

            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
            return isVisible;

        }

        public static Boolean IsElementNotVisible(IWebDriver driver, By locator, TimeSpan timeout)

        {
            Boolean isNotVisible = false;

            try
            {
                _wait = new WebDriverWait(driver, timeout);
                _wait.PollingInterval = TimeSpan.FromMilliseconds(500);
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                isNotVisible = _wait.Until(drv => !drv.FindElement(locator).Displayed);

            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
            return isNotVisible;

        }
    }
}
