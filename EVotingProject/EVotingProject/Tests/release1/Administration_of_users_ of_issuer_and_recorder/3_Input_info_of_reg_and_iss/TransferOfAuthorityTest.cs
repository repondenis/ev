using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;

namespace EVotingProject
{
    [TestFixture]
    [Description("Делегирование полномочий эмитента регистратору - ???")]
    public class Transfer_of_authority : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            browser.Navigate(urlDemo);
        }

        [SetUp]
        public void SetUp()
        {


        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin",
              TestName = "1.Проверка инициации делегирования полномочий, 57071")]
        [Ignore("непонятно,Как реализовать тест-кейс")]
        public void Test57071(string menuPar, string loginPar, string login, string pass)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);
            Assert.True(LoginPage.isTruePage());

            //Step-1
            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isTruePage());
            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");

            PortalPage.clickUserName();

            // ????????????????????? как и куда нажимать?



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
