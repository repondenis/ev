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
    public class VerificationOfLogicalTestAdminRegTest : UnitTestClassBase
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

        [TestCase(MenuParam.registrators, LoginParam.login, "adm_recorder", "adm_recorder", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", "D:\\work\\test\\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "56975.Проверка получения списка участников админ регистратора")]
        public void Test56975(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);


            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");

            //????????????????????????????

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
        } // Clean up once per fixture

    }
}
