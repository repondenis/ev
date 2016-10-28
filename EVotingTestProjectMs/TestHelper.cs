using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.SDK;
using HP.LFT.SDK.Web;
using HP.LFT.Verifications;
using EVotingTestProjectMs.Pages;
using EVotingTestProjectMs.Models;
using EVotingTestProjectMs.Helpers;

namespace EVotingTestProjectMs
{

    [TestClass]
    public class TestHelper : UnitTestClassBase<TestHelper>
    {
        public IBrowser browser;
        private string url = "https://demo-evoting.test.gosuslugi.ru";
        private string url2 = "https://portal-dev-evoting.test.gosuslugi.ru";


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GlobalSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            browser = BrowserFactory.Launch(BrowserType.InternetExplorer);
            browser.Navigate(this.url);
            PageHelper.browser = browser;
        }

        [TestMethod]
        public void TestLoginLocal()
        {

            //как передать тут браузер?)
            Assert.IsTrue(LoginPage.isLoginPage());
            LoginPage.caseMenuParam(MenuParam.registrators);
            LoginPage.caseLoginParam(LoginParam.login);
            Assert.IsTrue(LoginLocalPage.isLoginLocalPage());
            LoginLocalPage.runLogin("admin_status_reg", "admin_status_reg");
            //проверка авторизованности
        }


        [TestMethod]
        public void TestLoginSert()
        {
            //как передать тут браузер?)
            Assert.IsTrue(LoginPage.isLoginPage());
            LoginPage.caseMenuParam(MenuParam.registrators);
            LoginPage.caseLoginParam(LoginParam.sertif);
            Assert.IsTrue(LoginSertPage.isLoginSertPage());
            LoginSertPage.loadFileClick("C:\\temp\\sert.pem");
            Assert.Equals(LoginSertPage.getFileNameLoad(), "sert.pem");
            LoginSertPage.setPassword("paSS123#");
            LoginSertPage.submit();
            //проверка авторизованности
        }

        [TestMethod]
        public void TestLoginEsia()
        {
            //как передать тут браузер?)
            Assert.IsTrue(LoginPage.isLoginPage());
            LoginPage.caseMenuParam(MenuParam.registrators);
            LoginPage.caseLoginParam(LoginParam.esia);
            Assert.IsTrue(LoginEsiaPage.isLoginEsiaPage());
            LoginEsiaPage.setMobileMail("repon06@ya.ru");
            LoginEsiaPage.setPassword("paSS123#");
            LoginEsiaPage.submit();
            //проверка авторизованности
        }

        [TestCleanup]
        public void TestCleanup()
        {
            browser.Close();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

            GlobalTearDown();
        }
    }
}
