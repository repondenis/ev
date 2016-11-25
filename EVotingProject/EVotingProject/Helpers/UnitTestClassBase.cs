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
        public static string urlDemo = "https://demo-evoting.test.gosuslugi.ru/";//idp/sso#/
        public static string urlDemoAdmin = "https://demo-evoting.test.gosuslugi.ru/idp/sso#/local?admin";//ивотинг для администратора
        public static string urlDev = "https://portal-dev-evoting.test.gosuslugi.ru/";
        public static string urlDevAdmin = "https://portal-dev-evoting.test.gosuslugi.ru/idp/sso#/local?admin";//ивотинг для администратора


        /// <summary>
        /// поиск/добавление нового договора к орг
        /// "ОАО \"НК \"Роснефть\""
        /// </summary>
        public static void addNewContract(string orgName, string contrName)
        {
            Console.WriteLine(DateTime.Now + " addNewContract().");
            PageHelper.setBrowser(browser);
            if (!PortalPage.isMenuContractsExist())
            {
                PortalPage.logout();
                browser.Navigate(urlDemo);
                Assert.True(LoginPage.isTruePage());

                LoginPage.caseLoginParam(LoginParam.login);
                browser.Navigate(urlDemoAdmin);

                Assert.True(LoginLocalPage.isTruePage());

                LoginLocalPage.runLogin("admin", "admin");
                Assert.True(PortalPage.isTruePage());
            }

            // if (PortalPage.isMenuContractsExist())//если мы залогинены
            //  {
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage());

            ContractPage.setFilter(contrName);
            ContractPage.clickTitle();
            if (!ContractPage.isContractsOfTableExist(contrName))
            {
                ContractPage.clickNewContract();
                Assert.True(NewContractPage.isTruePage());

                NewContractPage.setOrganization(orgName);
                Assert.True(NewContractPage.isOrganizationPanelAppear());
                NewContractPage.selectItemOfOrganization(0, orgName);

                NewContractPage.setContractNumber(contrName);
                NewContractPage.setContractDate("26.05.1984");
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
        Console.WriteLine("AssemblySetUp");
        TestSuiteSetup(TestContext.CurrentContext.WorkDirectory);
    }

    [OneTimeTearDown]
    public void AssemblyTearDown()
    {
        TestSuiteTearDown();

        Reporter.GenerateReport();
    }
}