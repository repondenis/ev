﻿using System;
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
    [Description("Получение списка участников собрания")]
    public class VerificationOfLogicalTestAdminEVotingTest : UnitTestClassBase
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

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", "D:\\work\\test\\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "56970.Проверка получения списка участников админ ЕВотинга")]
        public void Test56970(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");

           // ????????????????????????????

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
