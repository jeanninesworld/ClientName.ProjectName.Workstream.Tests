using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Assemblies
{
    public class WebDriverFactory
    {
        private IWebDriver _driver;

        public WebDriverFactory() { }
        public IWebDriver OpenBrowser()
        {
            _driver = new ChromeDriver();
            return _driver;
        }



    }
}
