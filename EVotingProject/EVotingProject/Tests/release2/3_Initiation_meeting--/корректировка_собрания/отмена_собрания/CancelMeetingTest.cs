using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;
using HP.LFT.Report;


namespace EVotingProject
{
    [TestFixture]
    [Description("Проверка отмены собрания")]
    public class CancelMeetingTest : UnitTestClassBase
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
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemMeetOpen, СancelDialogCode.errorEdit, TestName = "56939.Проверка отмены собрания,админ ЕВотинга"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_iss", "adm_iss", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemMeetOpen, СancelDialogCode.errorEdit, TestName = "56939.Проверка отмены собрания,представитель эмитента"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_reg", "adm_reg", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemMeetOpen, СancelDialogCode.errorEdit, TestName = "56939.Проверка отмены собрания,представитель регистратора")]
        // [TestCaseSource("ALM")]
        public void Test56939(string menuPar, string loginPar, string login, string pass, string orgName, string photoCandidatefile, string message, string meetStat, string cancelCode)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.setMeetingsSearhText(orgName);//фильтр
            PortalPage.selectMeetingStatusFilterItems(meetStat);
            //долэно быть создано общее собр или открыто эмитенту и рег или перенесено на портал голосов или опублик общ собрание
            PortalPage.editMeetingOfTable(orgName);
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");

            //2
            MeetingPage.clickCancelMeeting();

            Assert.True(MeetingPage.isCancelMeetingDialogExist(),"если появился диалог отмены собрания");
            //3
            MeetingPage.setCancelDialogReasson(message);
            MeetingPage.selectCancelDialogCode(cancelCode);

            MeetingPage.clickCancelDialogCancelMeeting();

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
