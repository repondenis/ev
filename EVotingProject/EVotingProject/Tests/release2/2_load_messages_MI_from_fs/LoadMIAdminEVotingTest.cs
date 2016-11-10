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
    [Description("Брэндирование админ ЕВотинга")]
    public class LoadMIAdminEVotingTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            ReportConfiguration r = new ReportConfiguration();
            r.IsOverrideExisting = true;
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
            // Before each test
        }

        //либо искать ОРГ по ИНН = 1027700043502
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "D:\\work\\test\\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "56849.Проверка инициации настройки брендирования админ ЕВотинга")]
        public void Test56849(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);

            browser.Navigate(urlDev);
            Assert.True(LoginPage.isTruePage());

            // для админ паге - не надо LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            browser.Navigate(urlDevAdmin);
            Assert.True(LoginLocalPage.isTruePage());

            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage());

            PortalPage.gotoMenuOrganizations();

            Assert.True(OrganizationPage.isTruePage());
            OrganizationPage.setOrganizationSearhInput(orgName);//фильтр

            OrganizationPage.getOrganizationTable(orgName);//получаем табл
            OrganizationPage.editOrganizationOfTable(orgName);//нажим РЕдактировать нужного 
            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            NewOrganizationPage.clickLoadLogo();

            NewOrganizationPage.clickLoadLogoHeader();

            Console.WriteLine(DateTime.Now + "clickLoadLogoList after");
            Assert.False(NewOrganizationPage.isOpenFileDialog());
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            NewOrganizationPage.clickOkOfOpenFileDialog();
            Console.WriteLine(DateTime.Now + "clickLoadLogoList before");


            //            Reporter.ReportEvent("Setting value in edit box", "", Status.Passed, browser.GetSnapshot());


            NewOrganizationPage.clickLoadLogo();
            NewOrganizationPage.clickLoadLogoList();
            NewOrganizationPage.selectLogoFileOfDialog(filePathList);
            NewOrganizationPage.setColorHeader(color);
            NewOrganizationPage.setColorButton(color);

            NewOrganizationPage.save();

        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "D:\\work\\test\\logoh.jpg", "#001199", "Успешно сохранен!",
       TestName = "56850.Проверка загрузки некоректного файла с логотипом, брендирование админ ЕВотинга")]
        public void Test56850(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string color, string message)
        {

            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            NewOrganizationPage.clickLoadLogo();

            NewOrganizationPage.clickLoadLogoHeader();

            Console.WriteLine(DateTime.Now + "clickLoadLogoList after");
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            Console.WriteLine(DateTime.Now + "clickLoadLogoList before");


            NewOrganizationPage.save();

        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "D:\\work\\test\\logoh.png", "#001199", "Успешно сохранен!",
       TestName = "56851.Проверка Отмены загрузки файла с логотипом, брендирование админ ЕВотинга")]
        public void Test56851(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string color, string message)
        {

            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            NewOrganizationPage.clickLoadLogo();

            NewOrganizationPage.clickLoadLogoHeader();

            Console.WriteLine(DateTime.Now + "clickLoadLogoList after");
            Assert.True(NewOrganizationPage.isOpenFileDialog());
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            NewOrganizationPage.clickCancelOfOpenFileDialog();
            Console.WriteLine(DateTime.Now + "clickLoadLogoList before");


            NewOrganizationPage.save();

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
