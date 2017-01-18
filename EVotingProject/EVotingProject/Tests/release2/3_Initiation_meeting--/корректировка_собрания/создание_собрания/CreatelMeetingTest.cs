using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;
using HP.LFT.Report;
using System.Collections.Generic;

namespace EVotingProject
{
    [TestFixture]
    [Description("Создание собрания, проверка инициации коррестировки общей инф ОС")]
    public class CreatelMeetingTest : UnitTestClassBase
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
        [TestCase(urlDemoAdmin, MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemLoadMN, СancelDialogCode.errorEdit, formType.absentBallot, formType.notSendList, TestName = "56890.Создание собрания, проверка инициации коррестировки общей инф ОС,админ ЕВотинга"),
         TestCase(urlDemo,MenuParam.organizators, LoginParam.login, "adm_issuer", "adm_issuer", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemLoadMN, СancelDialogCode.errorEdit, formType.absentBallot, formType.notSendList, TestName = "56890.Создание собрания, проверка инициации коррестировки общей инф ОС,представитель эмитента"),
         TestCase(urlDemo,MenuParam.registrators, LoginParam.login, "adm_recorder", "adm_recorder", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemLoadMN, СancelDialogCode.errorEdit, formType.absentBallot, formType.notSendList, TestName = "56890.Создание собрания, проверка инициации коррестировки общей инф ОС,представитель регистратора")]
        // [TestCaseSource("ALM")]
        public void Test56890(string url, string menuPar, string loginPar, string login, string pass, string orgName, string photoCandidatefile, string message, string meetStat, string cancelCode, string formType, string formType2)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(url, loginPar, menuPar, login, pass);

            PortalPage.setMeetingsSearhText(orgName);//фильтр
            PortalPage.selectMeetingStatusFilterItems(meetStat);

            Assert.False(PortalPage.isNotExistMeeting(), "не должно быть надписи 'нет собраний'");

            //долэно быть создано общее собр или открыто эмитенту и рег или перенесено на портал голосов или опублик общ собрание
            PortalPage.editMeetingOfTable(orgName);
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");
            //2 - форма проведения ОС - заочное голосование
            MeetingPage.setformTypeLabel(formType);

            //проверить заблокированы ли поля дата проведения, страна и адрес, время проведен, начало регистр лиц
            Assert.True(MeetingPage.getmeetingStartState());
            Assert.True(MeetingPage.getmeetingCountryState());
            Assert.True(MeetingPage.getmeetingAddrState());
            Assert.True(MeetingPage.getmeetingRegisterStartState());
            Assert.False(MeetingPage.getReadOnlyVoteMktDdln());




            //3
            MeetingPage.setformTypeLabel(formType2);
            //проверить заблокированы ли поля дата проведения, страна и адрес, время проведен, начало регистр лиц
            Assert.False(MeetingPage.getmeetingStartState());
            Assert.False(MeetingPage.getmeetingCountryState());
            Assert.False(MeetingPage.getmeetingAddrState());
            Assert.False(MeetingPage.getmeetingRegisterStartState());
            Assert.True(MeetingPage.getReadOnlyVoteMktDdln());

            //4
            //Console.WriteLine(DateTime.Now.ToString("ddMMyyyy"));
            MeetingPage.setEntitlementFixingDate_input("01302016");// DateTime.Now.ToString("ddMMyyyy") ("dd.MM.yyyy")
            MeetingPage.getentitlementFixingDate();

            MeetingPage.save();
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemLoadMN, СancelDialogCode.errorEdit, TestName = "56894.Проверка состава полей в зависимости от типа ЦБ,админ ЕВотинга"),
 TestCase(MenuParam.organizators, LoginParam.login, "adm_issuer", "adm_issuer", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemLoadMN, СancelDialogCode.errorEdit, TestName = "56894.Проверка состава полей в зависимости от типа ЦБ,представитель эмитента"),
 TestCase(MenuParam.organizators, LoginParam.login, "adm_recorder", "adm_recorder", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\cancelMeeting.pdf", "Причина отмены", MeetingStatus.itemLoadMN, СancelDialogCode.errorEdit, TestName = "56894.Проверка состава полей в зависимости от типа ЦБ,представитель регистратора")]
        // [TestCaseSource("ALM")]
        public void Test56894(string menuPar, string loginPar, string login, string pass, string orgName, string photoCandidatefile, string message, string meetStat, string cancelCode)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.setMeetingsSearhText(orgName);//фильтр
            PortalPage.selectMeetingStatusFilterItems(meetStat);
            //1 !!! выбрать собрание , где ТИП ЦБ = АКЦИИ


            //долэно быть создано общее собр или открыто эмитенту и рег или перенесено на портал голосов или опублик общ собрание
            PortalPage.editMeetingOfTable(orgName);
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");

            //2
            Assert.IsNotEmpty(MeetingPage.getmeetingId());
            Assert.IsNotEmpty(MeetingPage.getissuerFullName());
            Assert.IsNotEmpty(MeetingPage.getPostAddress());
            //2.4 - название собарния - хз
            Assert.IsNotEmpty(MeetingPage.getformTypeLabel());
            Assert.IsNotEmpty(MeetingPage.getentitlementFixingDate());
            Assert.IsNotEmpty(MeetingPage.getmeetingStart());
            Assert.IsNotEmpty(MeetingPage.getMeetingAddress());
            Assert.IsNotEmpty(MeetingPage.getVoteMktDdln());
            Assert.IsNotEmpty(MeetingPage.getParticipantsRegisterStart());
            //2.13 - выпуски ЦБ для которых проводится собрание
            Assert.IsNotEmpty(MeetingPage.getAgenda());
            Assert.IsNotEmpty(MeetingPage.getProcOfFamiliarWMaterials());
            Assert.IsNotEmpty(MeetingPage.getAnnouncementDate());
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
