using Framework.Assemblies;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class GoogleHomePage :BasePage
    {
        By _searchInput = By.XPath("//input[@title='Search']");
        By _searchBtn = By.XPath("//input[@value='Google Search']");
        public GoogleHomePage(IWebDriver driver) :base(driver){}

        public GoogleResultsPage SearchText(String textToSearch)
        {
            EnterText(_searchInput,TimeSpan.FromSeconds(5), "FishingGuru");
            Click(_searchBtn, TimeSpan.FromSeconds(15));
            return new GoogleResultsPage(Driver);
        }

        public Boolean IsDisplayed() => GetTitle().Equals("Google");
    }
}
