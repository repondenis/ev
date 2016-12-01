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
    [Description("Брэндирование админ ЕВотинга")]
    public class BrandingAdminEVotingTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            ReportConfiguration r = new ReportConfiguration();
            r.IsOverrideExisting = false;
            r.Title = "My LeanFT Report";
            Reporter.Init(r);

            browser = BrowserFactory.Launch(BrowserType.Chrome);


            /*
                               ChromeOptions CO = new ChromeOptions();
                               CO.AddExtension(@"C:\Program Files (x86)\HP\LeanFT\Installations\Chrome\Agent.crx");
                               IWebDriver chromeDriver = new ChromeDriver(CO);
                               browser = BrowserFactory.Attach(new BrowserDescription
                               {
                                   Type = BrowserType.Chrome
                              });

                        chromeDriver.Navigate().GoToUrl(urlDemo);
            */
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
              TestName = "56849.Проверка инициации настройки брендирования админ ЕВотинга")]
       // [TestCaseSource("ALM")]
        public void Test56849(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
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
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");

            PortalPage.gotoMenuOrganizations();

            Assert.True(OrganizationPage.isTruePage());
            OrganizationPage.setOrganizationSearhInput(orgName);//фильтр

            OrganizationPage.getOrganizationTable(orgName);//получаем табл
            OrganizationPage.editOrganizationOfTable(orgName);//нажим РЕдактировать нужного 
            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            // NewOrganizationPage.clickLoadLogo();

            // NewOrganizationPage.clickLoadLogoHeader();

            //Assert.False(NewOrganizationPage.isOpenFileDialog());
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            //NewOrganizationPage.clickOkOfOpenFileDialog();


            //            Reporter.ReportEvent("Setting value in edit box", "", Status.Passed, browser.GetSnapshot());

            // --//-- ПОВТОРИТЬ ДЛЯ 2 ЛОГОТИПА

            NewOrganizationPage.setColorHeader(color);
            NewOrganizationPage.setColorButton(color);

            Assert.True(NewOrganizationPage.isSaveExist());
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


            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);


            Assert.True(NewOrganizationPage.isSaveExist());
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


            // Assert.True(NewOrganizationPage.isOpenFileDialog());
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            // NewOrganizationPage.clickCancelOfOpenFileDialog();


            Assert.True(NewOrganizationPage.isSaveExist());
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
