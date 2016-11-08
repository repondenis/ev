﻿using System;
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
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            browser.Navigate(this.urlAdmin);
        }

        [SetUp]
        public void SetUp()
        {


        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "сбербанк России ОАО", "cnmb123", "01.01.2016", "Успешно сохранен!",
              TestName = "1.Проверка инициации добавление договора, 57076")]
        public void Test57076(string menuPar, string loginPar, string login, string pass, string orgName, string contrNumb, string contrDate, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(LoginPage.isTruePage());

            //2
            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isLoginLocalPage());
            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage());

            //3
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage());
            ContractPage.clickNewContract();
            Assert.True(NewContractPage.isTruePage());

            //4
            NewContractPage.setOrganization(orgName);
            Assert.True(NewContractPage.isOrganizationPanelAppear());
            NewContractPage.selectItemOfOrganizationPanel(orgName);

            //5
            NewContractPage.setContractNumber(contrNumb);
            NewContractPage.setContractDate(contrDate);
            NewContractPage.selectService(1, true);//чекаем 1 чек-бокс
            NewContractPage.selectService2(2, true);//чекаем 2 чек-бокс

            //6
            NewContractPage.save();
            Assert.True(NewContractPage.isMessageGrowleOk(message), message);

            Assert.True(ContractPage.isTruePage());
            ContractPage.getContractsTable(contrNumb);
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "сбербанк России ОАО", "cnmb123", "cnmb321", "Успешно сохранен!",
         TestName = "1.Проверка внесения изменений в договор, 57079")]
        public void Test57079(string menuPar, string loginPar, string login, string pass, string orgName, string contrNumb, string newContrNumb, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage());
            //2
            ContractPage.setFilter(orgName);//!!!!!не работает поле фильтра!
            ContractPage.getContractsTable(contrNumb);
            ContractPage.clickContractsOfTable(contrNumb);
            Assert.True(NewContractPage.isTruePage());
            Assert.Equals(NewContractPage.getContractNumber(), contrNumb);

            //3
            NewContractPage.setContractNumber(newContrNumb);

            //4
            NewContractPage.selectService(3, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(4, true);//чекаем 4 чек-бокс

            //5
            NewContractPage.save();
            Assert.True(NewContractPage.isMessageGrowleOk(message), message);

            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage());
            ContractPage.getContractsTable(newContrNumb);

        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "сбербанк России ОАО", "cnmb123", "cnmb321","01.01.2016","31.12.2016", "Успешно сохранен!",
  TestName = "1.Проверка отмены внесения изменений в договор, 57083")]
        public void Test57083(string menuPar, string loginPar, string login, string pass, string orgName, string contrNumb, string contrNewNumb, string contrDate, string contrNewDate, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage());
            //2
            ContractPage.setFilter(orgName);//!!!!!не работает поле фильтра!
            ContractPage.getContractsTable(contrNumb);
            ContractPage.clickContractsOfTable(contrNumb);
            Assert.True(NewContractPage.isTruePage());
            Assert.Equals(NewContractPage.getContractNumber(), contrNumb);

            //3
            NewContractPage.setContractNumber(contrNewNumb);
            NewContractPage.setContractNumber(contrNewDate);

            //4
            NewContractPage.selectService(3, true);//чекаем 3 чек-бокс
            NewContractPage.selectService2(4, true);//чекаем 4 чек-бокс

            //5
            NewContractPage.cancel();
            Assert.True(NewContractPage.isMessageGrowleOk(message), message);

            PortalPage.gotoMenuContracts();
            Assert.True(ContractPage.isTruePage());
            ContractPage.getContractsTable(contrNewNumb);//не должно быть такого договора

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
