using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Models;


namespace EVotingProject.Tests
{
    [TestFixture, Description("Ввод администраторов E-Voting")]
    public class InputOfAdministrarors : UnitTestClassBase
    {
        private string url = "https://demo-evoting.test.gosuslugi.ru/idp/sso#/";

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
        }

        [SetUp]
        public void SetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.Navigate(this.url);
        }

        [Test, Description("Проверка инициации добавления нового администратора E-Voting, 57030")]
        public void VerificationOfAddNewAdministrator()
        {
            Assert.True(LoginPage.isLoginPage());
            LoginPage.caseMenuParam(MenuParam.registrators);
            LoginPage.caseLoginParam(LoginParam.login);
            Assert.True(LoginLocalPage.isLoginLocalPage());
            LoginLocalPage.runLogin("admin","admin");
            Assert.True(PortalPage.isPortalPage());
        }

        [TearDown]
        public void TearDown()
        {
            browser.Close();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
