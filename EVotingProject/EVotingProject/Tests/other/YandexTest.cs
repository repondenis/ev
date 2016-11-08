﻿using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.SDK.Web;
using HP.LFT.Verifications;
using EVotingProject.Pages;
using HP.LFT.Report;

namespace EVotingProject
{
    [TestFixture]
    public class LeanFtTest : UnitTestClassBase
    {


        private new string url = "http://yandex.ru";

        [OneTimeSetUp]// [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
        }

        [SetUp]
        public void SetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.Navigate(this.url);
        }

        [TestCase(true, TestName = "Tест пройден, №503770", Description = "тест пройден")]
        [TestCase(false, TestName = "Tест не пройден, №503723", Description = "тест не пройден")]
        [Ignore("тестовый яндекс тест")]
        public void Test1(bool state)
        {
            Assert.True(state);
        }

        [Test]
        [Ignore("тестовый яндекс тест")]
        public void TestYandex()
        {
            try
            {
                YandexPage.setBrowser(browser);
                YandexPage.sendText("бензин");
                Assert.True(YandexPage.isSearhElementsExist());
                YandexPage.clickSearh();
                Assert.GreaterOrEqual(YandexPage.getCountContent(), 0);
                //Assert.True(browser.URL.Contains("text=%D0%B1%D0%B5%D0%BD%D0%B7%D0%B8%D0%BD"));
            }
            catch (AssertionException e)
            {
                Reporter.ReportEvent("TestYandex", "Failed during validation", Status.Failed, e);
                throw;
            }
        }




        [Test]
        [Ignore("тестовый тест")]
        public void Verify_SearchSuggestionsArePresentedAndMoreThan0()
        {

            browser.Navigate("http://www.google.com");

            // Use try-catch to add a warning to the run report if the assert validation fails.          
            try
            {
                // Enter the value "LeanFT" in the search box.
                var search = browser.Describe<IEditField>(new EditFieldDescription
                {
                    Name = "q"
                });
                search.SetValue("LeanFT");

                // Simulate a single key down event to trigger the opening of the suggestion box.
                search.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));



                // Identify the suggestion box using a CSS selector and wait until the suggestion box opens.
                /*var suggestions = browser.Describe<IWebElement>(new WebElementDescription
                {
                    CSSSelector = @".sbsb_a",
                });*/
                var sbsb = new CSSDescription(".sbsb_a");
                var suggestions = browser.Describe<IWebElement>(sbsb);
                suggestions.WaitUntil(s => s.Exists() && s.IsVisible);

                var suggestionList = suggestions.FindChildren<IWebElement>(new WebElementDescription
                {
                    TagName = "LI"
                });


                // Enclosing the Assert method in a try-catch statement ensures the application 
                // does not throw a runtime error if the Assert returns false. 

                // Verify that the suggestion box exists and contains content.
                Assert.IsTrue(suggestions.IsVisible);
                Assert.Greater(suggestionList.Length, 0);

            }
            catch (AssertionException e)
            // Adds a step to the run report on failure.
            {
                Reporter.ReportEvent("Verify_SearchSuggestionsAreOpenUponUserInput", "Failed during validation", HP.LFT.Report.Status.Failed, e);
                browser.Close();
                throw;
            }

        }


        [TearDown]
        public void TearDown()
        {
            browser.Close();
        }

        [OneTimeTearDown]//[TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
