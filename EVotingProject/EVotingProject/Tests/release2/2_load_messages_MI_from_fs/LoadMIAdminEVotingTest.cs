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
    [Description("Получение списка участников собрания админ ЕВотинга")]
    public class LoadMIAdminEVotingTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            //ReportConfiguration r = new ReportConfiguration();
            //r.IsOverrideExisting = false;
            //r.Title = "E-Voting test reports 4";
            //Reporter.Init(r);

            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            PageHelper.setBrowser(browser);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        //либо искать ОРГ по ИНН = 1027700043502
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\MI НРД (Роснефть) 3 без деном.xml", "Успешно сохранен!",
              TestName = "56968.Проверка получения списка участников админ ЕВотинга")]
        public void Test56968(string menuPar, string loginPar, string login, string pass, string orgName, string filePathMI, string message)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.setMeetingsSearhText(orgName);
            PortalPage.selectMeetingStatusFilterItems(MeetingStatusFilter.itemLoadMN);

            PortalPage.editMeetingOfTable(orgName);//нажим РЕдактировать нужного 
            Assert.True(MeetingPage.isTruePage(orgName));
            MeetingPage.gotoMenuList();
            Assert.True(MeetingPage.isListOfMeetingExist());
            MeetingPage.clickLoadListParticipants();
            MeetingPage.selectFileParticipants(filePathMI);
            MeetingPage.clickUploadFile();
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
