using FluentAssertions;
using Framework.Assemblies;
using Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.UITests;

namespace Test.UITests
{
    [TestFixture]
    public class TestClass : UIBaseTest
    {
       
        [Test]
                //UnitOfWork_StateUnderTest_ExpectedBehavior
        public void Chrome_Launch_Successful()
        {
            //verify a browser is open
            PageContext.GoogleHome.IsDisplayed().Should().BeTrue();
            
        }

        [Test]
        public void ChromeBrowserSearchSuccessful()
        {

            //perform our search method
            PageContext.GoogleHome.SearchText("Fishing Guru").GetResults().Should().HaveCountGreaterThan(1);
        }
    }
}