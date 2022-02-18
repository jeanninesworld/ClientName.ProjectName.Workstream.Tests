using Framework.Assemblies;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UITests
{
    public class UIBaseTest
    {
        IWebDriver _driver;
        Pages _pages;

        [SetUp]
        public void Test_Setup()
        {
            //Precondition:  This method will perform setup and will be run prior to executing any one test
            WebDriverFactory driverFactory = new WebDriverFactory();
            DriverContext = driverFactory.OpenBrowser();
            DriverContext.Manage().Window.Maximize();            
            _pages = new Pages(DriverContext);
            _pages.PageRegistrations();
            DriverContext.Url = "http://www.google.com";

        }

        [TearDown]
        public void Test_Tear_Down()
        {
            //PostCondition:  This method will perform tearing down the test and will run after any one test
            DriverContext.Quit();
        }

        protected IWebDriver DriverContext
        {
            get {  return _driver; }
            set {  _driver = value; }
        }

        protected Pages PageContext
        {
            get {  return _pages; }
        }
    }
}
