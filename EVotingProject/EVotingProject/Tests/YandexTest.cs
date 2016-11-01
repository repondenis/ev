using System;
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
        private IBrowser browser;
        private string url = "http://yandex.ru";

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

        [Test]
        public void TestYandex()
        {
            try
            {
                YandexPage.setBrowser(browser);
                YandexPage.sendText("бензин");
                Assert.True(YandexPage.isSearhElementsExist());
                YandexPage.clickSearh();
                Assert.True(browser.URL.Contains("text=%D0%B1%D0%B5%D0%BD%D0%B7%D0%B8%D0%BD"));
                Assert.GreaterOrEqual(YandexPage.getCountContent(), 0);
            }
            catch (AssertionException e)
            {
                Reporter.ReportEvent("TestYandex", "Failed during validation", Status.Failed, e);
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
