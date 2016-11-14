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
    [Description("проверка инициации передачи файла с сообщением о собрании из файла MN админ ЕВотинга")]
    public class VerifInitiationFromFileMNTest : UnitTestClassBase
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

        //либо искать ОРГ по ИНН = 1027700043502
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", "D:\\temp\\MN НРД (Роснефть) 1.xml", "Успешно сохранен!",
              TestName = "56943.проверка инициации передачи файла с сообщением о собрании из файла MN админ ЕВотинга")]
        public void Test56943(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string message)
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
            PortalPage.clickNewMeeting();
            Assert.True(NewMeetingPage.isTruePage());
            //2
            NewMeetingPage.selectMethodCreateMeetingList(MeetingMethodCreate.FILE);
            NewMeetingPage.loadFromFile(filePathHeader);

            //3
            NewMeetingPage.loadFromFile(filePathHeader);




         
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
        }
    }
}
