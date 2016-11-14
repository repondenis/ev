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
    public class VerificationOfLogicalTestAdminIssuerTest : UnitTestClassBase
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

        [TestCase(MenuParam.organizators, LoginParam.login, "admin_denisov_iss", "admin_denisov_iss", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", "D:\\work\\test\\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "56973.Проверка логического контроля админ эмитента")]
        public void Test56973(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);

            browser.Navigate(urlDemo);
            Assert.True(LoginPage.isTruePage());

            // для админ паге - не надо LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            browser.Navigate(urlDemoAdmin);
            browser.Sync();
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
