using FluentAssertions;
using Framework.Assemblies;
using Framework.Helpers;
using Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
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

        public static IEnumerable<object> SearchData()
        {
            return ExcelDataHelper.ReadExcel(@"C:\Users\Jeannine.Kwasnik\source\repos\Lecture10\ClientName.ProjectName.Workstream.Tests\Tests1\TestData\SearchData.xlsx", "Sheet1");
        }

        [TestCaseSource("SearchData")]
        public void ChromeBrowser_MultipleSearch_Successfull(string searchtext)
        {
            //perform our search
            PageContext.GoogleHome.SearchText(searchtext).GetResults().Should().HaveCountGreaterThan(1);
        }

        [Test]

        public void ChromeBrowser_SingleSearch_Successfull()
        {
            string searchContent = ExcelDataHelper.ReadExcel(@"C:\Users\Jeannine.Kwasnik\source\repos\Lecture10\ClientName.ProjectName.Workstream.Tests\Tests1\TestData\SearchData1.xlsx", "Sheet1", 2, 1);
            //perform our search
            PageContext.GoogleHome.SearchText(searchContent).GetResults().Should().HaveCountGreaterThan(1);
        }


        [Test]
        public void ChromeBrowser_MultipleSearch2_Successfull()
        {
            string dataInput = NPOIHelper.ReadExcel(@"C:\Users\Jeannine.Kwasnik\source\repos\Lecture10\ClientName.ProjectName.Workstream.Tests\Tests1\TestData\SearchData.xlsx", 1, 0);

            //perform our search
            PageContext.GoogleHome.SearchText(dataInput).GetResults().Should().HaveCountGreaterThan(1);
        } 
    }
}