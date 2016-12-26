using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;

namespace EVotingProject
{
    [TestFixture]
    [Description("Делегирование полномочий эмитента регистратору - ???")]
    public class Transfer_of_authority : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            var r = new HP.LFT.Report.ReportConfiguration();
            r.IsOverrideExisting = false;
            r.Title = "My LeanFT Report";
            Reporter.Init(r);

            browser = BrowserFactory.Launch(BrowserType.Chrome);

            browser.ClearCache();
            browser.DeleteCookies();
            PageHelper.setBrowser(browser);
        }

        [SetUp]
        public void SetUp()
        {


        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin",
              TestName = "1.Проверка инициации делегирования полномочий, 57071")]
        [Ignore("непонятно,Как реализовать тест-кейс")]
        public void Test57071(string menuPar, string loginPar, string login, string pass)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);


            autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);
            PortalPage.clickUserName();

            // ????????????????????? как и куда нажимать?



        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            PortalPage.logout();
            browser.Close();
        }
    }
}
