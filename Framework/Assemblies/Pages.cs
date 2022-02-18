using Framework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Assemblies
{
    public class Pages
    {
        IWebDriver _driver;
        GoogleHomePage _googleHome;
        GoogleResultsPage _googleResults;


        public Pages(IWebDriver driver)
        {
            _driver = driver;
        }

        //method called register
        public void PageRegistrations()
        {
            _googleHome = new GoogleHomePage(_driver);
            _googleResults = new GoogleResultsPage(_driver);
        }

        public GoogleHomePage GoogleHome
        {
            get {  return _googleHome; }
        }

        public GoogleResultsPage GoogleResults
        {  
            get {  return _googleResults; } 
        }

    }


}
