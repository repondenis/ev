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
    [Description("Получение списка участников собрания админ регистратора")]
    public class LoadMIAdminRegTest : UnitTestClassBase
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

        //либо искать ОРГ по ИНН = 1027700043502
        [TestCase(MenuParam.organizators, LoginParam.login, "adm_recorder", "adm_recorder", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"",
            @"D:\work\test\MI НРД (Роснефть) 3 без деном.xml", "Успешно сохранен!",
              TestName = "56974.Проверка получения списка участников админ регистратора")]
        public void Test56974(string menuPar, string loginPar, string login, string pass, string orgName, string filePathMI, string message)
        {

            Console.WriteLine(DateTime.Now);
            autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);
            PortalPage.setMeetingsSearhText(orgName);
            PortalPage.selectMeetingStatusFilterItems(MeetingStatus.itemLoadMN);

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
