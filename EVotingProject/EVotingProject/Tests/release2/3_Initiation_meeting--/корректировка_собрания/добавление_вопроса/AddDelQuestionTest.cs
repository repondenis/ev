﻿using System;
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
    [Description("Добавление вопроса, проектов решений")]
    public class AddDelQuestionTest : UnitTestClassBase
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
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", /*"ОАО \"НК \"Роснефть\""*/ "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"",
            @"D:\work\test\export-2016.11.11.Nov.31.1478867467.xlsx", @"http://www.uniplast-kbe.ru/test/reshenie-29-333.doc", "linkName", "Успешно сохранен!", MeetingStatus.itemMeetOpen,
              TestName = "56915.Проверка добавл вопроса и проектов решений,админ ЕВотинга")]
        // [TestCaseSource("ALM")]
        public void Test56915(string menuPar, string loginPar, string login, string pass, string orgName, string fileMaterials, string urlFileMaterials, string linkName, string message, string meetStat)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);


            //LoginLocalPage.runLogin(login, pass);
            //Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");



            PortalPage.setMeetingsSearhText(orgName);//фильтр
            PortalPage.selectMeetingStatusFilterItems(meetStat);//создано общее собр или открыто эмитенту и рег или перенесено на портал голосов или опублик общ собрание
            PortalPage.editMeetingOfTable(orgName);
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");

            // ! аттрибут "введен бюллютень" для собрания - false
            

            sda

            /*
            MeetingPage.gotoMenuMater();
            Assert.True(MeetingPage.isMaterialPanel(), "должна быть панель материалов");

            MeetingPage.addButt();
            MeetingPage.addFileButt();
            Assert.True(MeetingPage.isAddFilePanel(), "должна быть форма прикрепления файла ");
            MeetingPage.loadFile(fileMaterials);
            Assert.True(MeetingPage.isLoadingFile(fileMaterials), "файл должен загрузиться");
            MeetingPage.clickTypeMaterial();
            MeetingPage.selectTypeMaterial(MaterialSelect.materialMeeting);
            MeetingPage.clickTypeMaterialLang();
            MeetingPage.selectTypeMaterialLang("Русский");
            MeetingPage.addFileMaterials();
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");
            Assert.True(MeetingPage.isExistsMaterialOfTable(fileMaterials), "файл должен быть в списке собрания в мат");

            MeetingPage.addButt();
            MeetingPage.addLinkButt();
            Assert.True(MeetingPage.isAddLinkPanel(), "должна быть форма прикрепления ссылки ");
            MeetingPage.setLinkName(linkName);
            MeetingPage.setLinkUrl(urlFileMaterials);
            MeetingPage.clickTypeMaterial();
            MeetingPage.selectTypeMaterial(MaterialSelect.materialMeeting);
            MeetingPage.addFileMaterials();
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");
            Assert.True(MeetingPage.isExistsMaterialOfTable(linkName), "ссылка должен быть в списке собрания в мат");

            */
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
