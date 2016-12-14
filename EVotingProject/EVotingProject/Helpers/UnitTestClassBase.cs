using System;
using System.Linq;
using NUnit.Framework;
using HP.LFT.Report;
using HP.LFT.UnitTesting;
using NUnit.Framework.Interfaces;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;

namespace EVotingProject
{


    [TestFixture]
    public abstract class UnitTestClassBase : UnitTestBase
    {

        public static IBrowser browser;
        public static string urlDemo = "http://demo-evoting.test.gosuslugi.ru/";//idp/sso#/
        public static string urlDemoAdmin = "https://demo-evoting.test.gosuslugi.ru/idp/sso/#/?admin";//28112016"https://demo-evoting.test.gosuslugi.ru/idp/sso#/local?admin=";//ивотинг для администратора
        public static string urlDev = "https://portal-dev-evoting.test.gosuslugi.ru/";
        public static string urlDevAdmin = "https://portal-dev-evoting.test.gosuslugi.ru/idp/sso#/local?admin";//ивотинг для администратора

        public static string adminEvotingLogin = "admin";
        public static string adminEvotingPassword = "admin";

        /// <summary>
        /// авторизация на проекте
        /// </summary>
        /// <param name="url"></param>
        /// <param name="loginParam"></param>
        /// <param name="menuParam"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public static void autorizeFromEVoting(string url, string loginParam, string menuParam, string login, string password)
        {
            Console.WriteLine(DateTime.Now + " autorizeFromEVoting().");

            PortalPage.logout();
            browser.Navigate(urlDemo);
            Assert.True(LoginPage.isTruePage());

            //если надо залогиниться под админом
            if (url.Equals(urlDemoAdmin))
                browser.Navigate(urlDemoAdmin);
            else
                LoginPage.caseMenuParam(menuParam);

            LoginPage.caseLoginParam(loginParam);
            Assert.True(LoginLocalPage.isTruePage(), "должна быть страница авториз по логину-паролю");

            LoginLocalPage.runLogin(login, password);
            Assert.True(PublicPage.isTruePage(), "должна быть общая страница голосований");
            PublicPage.gotoPortalPage();
            Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");
        }


        /// <summary>
        /// поиск/добавление нового договора к орг
        /// "ОАО \"НК \"Роснефть\""
        /// только под админом е-voting
        /// </summary>
        public static void addNewContract(string orgName, string contrName)
        {
            Console.WriteLine(DateTime.Now + " Verification of existence of document and his addition.");
            PageHelper.setBrowser(browser);
            if (!PortalPage.isMenuContractsExist())
            {
                autorizeFromEVoting(urlDemoAdmin, LoginParam.login, null, adminEvotingLogin, adminEvotingPassword);

                /*
                PortalPage.logout();
                browser.Navigate(urlDemo);
                Assert.True(LoginPage.isTruePage());
                browser.Navigate(urlDemoAdmin);
                LoginPage.caseLoginParam(LoginParam.login);
                Assert.True(LoginLocalPage.isTruePage(), "должна быть страница авториз по логину-паролю");

                LoginLocalPage.runLogin(adminEvotingLogin, adminEvotingPassword);
                Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");
                */
            }

            // if (PortalPage.isMenuContractsExist())//если мы залогинены
            //  {
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage());

            ContractPage.setFilter(contrName);
            ContractPage.clickTitle();
            if (!ContractPage.isContractsOfTableExist(contrName, MeetingStatusFilter.itemIsNotCreated))
            {
                ContractPage.clickNewContract();
                Assert.True(NewContractPage.isTruePage());

                NewContractPage.setOrganization(orgName);
                Assert.True(NewContractPage.isOrganizationPanelAppear());
                NewContractPage.selectItemOfOrganization(0, orgName);

                NewContractPage.setContractNumber(contrName);
                NewContractPage.setContractDate(DateTime.Now.ToString("dd.MM.yyyy"));//"26.05.1984"
                //Console.WriteLine(DateTime.Now + " selectService");
                //NewContractPage.selectService(1, true);//чекаем 1 чек-бокс
                NewContractPage.selectAceessOfregistrator(true);
                NewContractPage.selectService2(0, true);//чекаем 2 чек-бокс
                NewContractPage.selectService2(2, true);//чекаем 2 чек-бокс
                NewContractPage.selectService2(3, true);//чекаем 2 чек-бокс
                NewContractPage.save();
            }
            // }
            PortalPage.logout();
            Assert.True(LoginPage.isTruePage());
        }


        [OneTimeSetUp]
        public void GlobalSetup()
        {
            TestSuiteSetup();
        }

        [SetUp]
        public void BasicSetUp()
        {
            TestSetUp();
        }

        [TearDown]
        public void BasicTearDown()
        {
            TestTearDown();
        }

        protected override string GetClassName()
        {
            return TestContext.CurrentContext.Test.FullName;
        }

        protected override string GetTestName()
        {
            return TestContext.CurrentContext.Test.Name;
        }

        protected override Status GetFrameworkTestResult()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Failed:
                    return Status.Failed;
                case TestStatus.Inconclusive:
                case TestStatus.Skipped:
                    return Status.Warning;
                case TestStatus.Passed:
                    return Status.Passed;
                default:
                    return Status.Passed;
            }
        }
    }
}

/// <summary>
/// Runs before all classes and tests in the current project.
/// <remarks>This class must remain outside any namespace in order to provide setup and tear down for the entire assembly.
/// To get more information follow this link: https://github.com/nunit/docs/wiki/SetUpFixture-Attribute
/// </remarks>
/// </summary>
[SetUpFixture]
public class SetupFixture : UnitTestSuiteBase
{
    [OneTimeSetUp]
    public void AssemblySetUp()
    {

        TestSuiteSetup(TestContext.CurrentContext.WorkDirectory);
    }

    [OneTimeTearDown]
    public void AssemblyTearDown()
    {
        TestSuiteTearDown();

        Reporter.GenerateReport();
    }
}