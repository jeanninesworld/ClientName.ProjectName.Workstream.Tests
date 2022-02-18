using Framework.Assemblies;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class GoogleResultsPage : BasePage
    {
        By _resultLinks = By.XPath("//h3[contains(text(),'Fishing Guru')]");
        public GoogleResultsPage(IWebDriver driver) :base(driver) {}

        public IReadOnlyCollection<IWebElement> GetResults()
        {
            return GetElements(_resultLinks,TimeSpan.FromSeconds(15));
        }
    }   
}
