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
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support;
using HP.LFT.SDK.Insight;

namespace EVotingProject
{
    [TestFixture]
    [Description("Ввод и коррестировка матералов ОС ,админ ЕВотинга")]
    public class InputMaterialsOSAdminEVotingTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            ReportConfiguration r = new ReportConfiguration();
            r.IsOverrideExisting = false;
            r.Title = "My LeanFT Report";
            Reporter.Init(r);

            browser = BrowserFactory.Launch(BrowserType.Chrome);
            
            // browser.ClearCache();
            // browser.DeleteCookies();
            PageHelper.setBrowser(browser);

        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }





        //либо искать ОРГ по ИНН = 1027700043502
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", @"D:\work\test\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "56909.Проверка добавл нового материала ОС,админ ЕВотинга")]
       // [TestCaseSource("ALM")]
        public void Test56849(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);

            browser.Navigate(urlDemo);
            Assert.True(LoginPage.isTruePage());

            browser.Navigate(urlDemoAdmin);

            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isTruePage(),"должна быть страница авториз по логину-паролю");
            // для админ паге - не надо LoginPage.caseMenuParam(menuPar);


            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");



            PortalPage.setMeetingsSearhText(orgName);//фильтр
            PortalPage.editMeetingOfTable(orgName);

            //.............

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
