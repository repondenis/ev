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
    [Description("Добавление договора")]
    public class AddContractTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            
            var r = new HP.LFT.Report.ReportConfiguration();
            r.IsOverrideExisting = false;
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


        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "012345", "26.05.1984", "Успешно сохранен!",
              TestName = "57076 1.Проверка инициации добавление договора")]
        public void Test57076(string menuPar, string loginPar, string login, string pass, string orgName, string contractName, string contrDate, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);


            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            //3
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage(), "Должна быть страница договоров1");
            ContractPage.clickNewContract();
            Assert.True(NewContractPage.isTruePage(), "Должна быть страница добавления договора");

            //4
            NewContractPage.setOrganization(orgName);
            Assert.True(NewContractPage.isOrganizationPanelAppear());
            NewContractPage.selectItemOfOrganization(orgName);

            //5
            NewContractPage.setContractNumber(contractName);
            NewContractPage.setContractDate(contrDate);
            NewContractPage.selectService2(3, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(2, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(4, true);//чекаем 4 чек-бокс
            NewContractPage.selectService2(1, true);//чекаем 4 чек-бокс

            NewContractPage.selectAceessOfregistrator(true);
            //6
            NewContractPage.save();
            Assert.True(NewContractPage.isMessageGrowleOk(message), message);

            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage(), "Должна быть страница договоров2");
           ContractPage.setFilter(contractName);
            ContractPage.clickTitle();
            ContractPage.isContractsOfTableExist(contractName, MeetingStatus.itemIsNotCreated);
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "cnmb123", "cnmb321", "Успешно сохранен!",
         TestName = "57079 1.Проверка внесения изменений в договор ")]
        public void Test57079(string menuPar, string loginPar, string login, string pass, string orgName, string contractName, string newcontractName, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage(), "Должна быть страница договоров");
            //2
            ContractPage.setFilter(orgName);//!!!!!не работает поле фильтра!
            ContractPage.clickTitle();
            ContractPage.isContractsOfTableExist(contractName, MeetingStatus.itemIsNotCreated);
            ContractPage.clickContractsOfTable(contractName);
            Assert.True(NewContractPage.isTruePage(), "Должна быть страница добавления договора");
            Assert.Equals(NewContractPage.getContractNumber(), contractName);

            //3
            NewContractPage.setContractNumber(newcontractName);

            //4
            NewContractPage.selectService2(3, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(2, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(4, true);//чекаем 4 чек-бокс
            NewContractPage.selectService2(1, true);//чекаем 4 чек-бокс
            //5
            NewContractPage.save();
            Assert.True(NewContractPage.isMessageGrowleOk(message), message);

            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage(), "Должна быть страница договоров");
            ContractPage.setFilter(newcontractName);
            ContractPage.clickTitle();
            ContractPage.isContractsOfTableExist(newcontractName, MeetingStatus.itemIsNotCreated);

        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "cnmb123", "cnmb321", "01.01.2016", "31.12.2016", "Успешно сохранен!",
  TestName = "57083 1.Проверка отмены внесения изменений в договор")]
        public void Test57083(string menuPar, string loginPar, string login, string pass, string orgName, string contractName, string contrNewNumb, string contrDate, string contrNewDate, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage(), "Должна быть страница договоров");
            //2
            ContractPage.setFilter(orgName);//!!!!!не работает поле фильтра!
            ContractPage.clickTitle();
            ContractPage.isContractsOfTableExist(contractName, MeetingStatus.itemIsNotCreated);
            ContractPage.clickContractsOfTable(contractName);
            Assert.True(NewContractPage.isTruePage(), "Должна быть страница добавления договора");
            Assert.Equals(NewContractPage.getContractNumber(), contractName);

            //3
            NewContractPage.setContractNumber(contrNewNumb);
            NewContractPage.setContractNumber(contrNewDate);

            //4
            NewContractPage.selectService2(3, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(2, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(4, true);//чекаем 4 чек-бокс
            NewContractPage.selectService2(1, true);//чекаем 4 чек-бокс

            //5
            NewContractPage.cancel();
            Assert.True(NewContractPage.isMessageGrowleOk(message), message);

            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage(), "Должна быть страница договоров");
            ContractPage.isContractsOfTableExist(contrNewNumb, MeetingStatus.itemIsNotCreated);//не должно быть такого договора

        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            PortalPage.logout();
            browser.Close();
        }
    }
}
