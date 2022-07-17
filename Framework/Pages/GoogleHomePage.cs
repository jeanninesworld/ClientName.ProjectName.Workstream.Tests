using Framework.Assemblies;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class GoogleHomePage : BasePage
    {
        By _searchInput = By.XPath("//*[@aria-label='Search']");
        By _searchBtn = By.XPath("//*[@class='FPdoLc lJ9FBc']//*[@value='Google Search']");
        By _clickAway = By.XPath("//*[@jsmodel='sj77Re vWNDde P9Kqfe']");
        public GoogleHomePage(IWebDriver driver) : base(driver) { }

        public GoogleResultsPage SearchText(String textToSearch)
        {
           
            EnterText(_searchInput, TimeSpan.FromSeconds(10), "FishingGuru");
            Click(_clickAway, TimeSpan.FromSeconds(15));
            Click(_searchBtn, TimeSpan.FromSeconds(15));
            return new GoogleResultsPage(Driver);
        }

        public Boolean IsDisplayed() => GetTitle().Equals("Google");
    }
}
