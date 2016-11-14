using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;
using HP.LFT.Report;
using System.Drawing;

namespace EVotingProject
{
    [TestFixture]
    public class VerificationOfLogicalTestAdminRegTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            ReportConfiguration r = new ReportConfiguration();
            r.IsOverrideExisting = true;
            r.Title = "E-Voting reports";
            Reporter.Init(r);

            browser = BrowserFactory.Launch(BrowserType.Chrome);
            //        browser.ClearCache();
            //        browser.DeleteCookies();
            PageHelper.setBrowser(browser);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [TestCase(MenuParam.registrators, LoginParam.login, "admin_reestrrn_reg", "admin_reestrrn_reg", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", "D:\\work\\test\\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "56975.Проверка получения списка участников админ регистратора")]
        public void Test56975(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);

            browser.Navigate(urlDemo);
            Assert.True(LoginPage.isTruePage());

            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            //browser.Navigate(urlDemoAdmin);
            //browser.Sync();
            Assert.True(LoginLocalPage.isTruePage());

            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage());

            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage());

            //????????????????????????????

        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            Reporter.GenerateReport();
            PortalPage.logout();
            browser.Close();
        } // Clean up once per fixture

    }
}
