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
    [Description("Брэндирование представитель эминетна")]
    public class BrandingAdminIssuerTest : UnitTestClassBase
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
         //   browser.Navigate(urlDemo);
            PageHelper.setBrowser(browser);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin_denisov_iss", "admin_denisov_iss", "ОАО \"НК \"Роснефть\"", "D:\\work\\test\\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "56856.Проверка инициации настройки брендирования")]
        public void Test56856(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);
            


            autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);

            PortalPage.gotoMenuProfileOrg();
            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            NewOrganizationPage.clickLoadLogo();

            NewOrganizationPage.clickLoadLogoHeader();

            Console.WriteLine(DateTime.Now + "clickLoadLogoList after");
           // Assert.False(NewOrganizationPage.isOpenFileDialog());
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            //NewOrganizationPage.clickOkOfOpenFileDialog();
            Console.WriteLine(DateTime.Now + "clickLoadLogoList before");


            //            Reporter.ReportEvent("Setting value in edit box", "", Status.Passed, browser.GetSnapshot());


            NewOrganizationPage.clickLoadLogo();
            NewOrganizationPage.clickLoadLogoList();
            NewOrganizationPage.selectLogoFileOfDialog(filePathList);
            NewOrganizationPage.setColorHeader(color);
            NewOrganizationPage.setColorButton(color);
            Assert.True(NewOrganizationPage.isSaveExist());
            NewOrganizationPage.save();

        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "D:\\work\\test\\logoh.jpg", "#001199", "Успешно сохранен!",
       TestName = "56857.Проверка загрузки некоректного файла с логотипом, брендирование")]
        public void Test56857(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string color, string message)
        {

            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            NewOrganizationPage.clickLoadLogo();

            NewOrganizationPage.clickLoadLogoHeader();

            Console.WriteLine(DateTime.Now + "clickLoadLogoList after");
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            Console.WriteLine(DateTime.Now + "clickLoadLogoList before");

            Assert.True(NewOrganizationPage.isSaveExist());
            NewOrganizationPage.save();

        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "D:\\work\\test\\logoh.png", "#001199", "Успешно сохранен!",
       TestName = "56858.Проверка Отмены загрузки файла с логотипом, брендирование")]
        public void Test56858(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string color, string message)
        {

            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            NewOrganizationPage.clickLoadLogo();

            NewOrganizationPage.clickLoadLogoHeader();

            Console.WriteLine(DateTime.Now + "clickLoadLogoList after");
           // Assert.True(NewOrganizationPage.isOpenFileDialog());
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
           // NewOrganizationPage.clickCancelOfOpenFileDialog();
            Console.WriteLine(DateTime.Now + "clickLoadLogoList before");

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
