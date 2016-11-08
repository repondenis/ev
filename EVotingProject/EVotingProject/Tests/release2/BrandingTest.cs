using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;

namespace EVotingProject.Tests.release2
{
    [TestFixture]
    [Description("Брэндирование")]
    public class BrandingTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();

        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [TestCase(MenuParam.registrators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "Успешно сохранен!",
              TestName = "1.Проверка инициации настройки брендирования, 57022")]
        public void Test57022(string menuPar, string loginPar, string login, string pass, string orgName, string message)
        {

            Console.WriteLine(DateTime.Now);
            browser.Navigate(this.url);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(LoginPage.isTruePage());

            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isLoginLocalPage());
            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage());

            PortalPage.gotoMenuOrganizations();
            Assert.True(OrganizationPage.isTruePage());
            OrganizationPage.setOrganizationSearhInput(orgName);//фильтр
            OrganizationPage.getOrganizationTable(orgName);//получаем табл
            OrganizationPage.editOrganizationOfTable(orgName);//нажим РЕдактировать нужного 
            Assert.True(NewOrganizationPage.isTruePage(orgName));
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            PortalPage.logout();
            browser.Close();
        }
    }
}
