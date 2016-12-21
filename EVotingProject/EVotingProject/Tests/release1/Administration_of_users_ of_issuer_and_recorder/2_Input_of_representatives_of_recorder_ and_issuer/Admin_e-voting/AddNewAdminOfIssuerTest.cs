using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Models;
using EVotingProject.Helpers;
using HP.LFT.Report;

namespace EVotingProject.Tests.release1
{
    [TestFixture]
    [Description("Проверка ввода представителя-администратора эмитента")]
    public class AddNewAdminOfIssuerTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            //browser.Navigate(urlDemoAdmin);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin",
                     TestName = "1.Проверка инициации добавления нового администратора эмитента E-Voting, 57036")]
        public void Test57036(string menuPar, string loginPar, string login, string pass)
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }

        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "не должно вылететь ошибки",
                     TestName = "2.Проверка ввода данных администратора эмитента, 57038")]
        public void Test57038(string lastName, string firstName, string otherName, string login, string snils, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                NewEmployeePage.setLogin(login);
                NewEmployeePage.setSnils(snils);

                NewEmployeePage.setPhone("+7(927)159-11-81");
                NewEmployeePage.setMail("test@test.ru");

                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);

                NewEmployeePage.unblock();
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isBlockExist());


                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }

        [TestCase("Иванов", "Иван", "Иванович", "adm_iss", "26242628212", "не должно вылететь ошибки", availRoles.adminOfIssuer,
                    TestName = "3.Проверка заполнения полей логина, снилс, 57041")]
        public void Test57041(string lastName, string firstName, string otherName, string login, string snils, string message, string role)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step1

                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());

                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);

                NewEmployeePage.setLogin(login);

                NewEmployeePage.setPhone("+7(927)159-11-81");
                NewEmployeePage.setMail("test@test.ru");

                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);

                NewEmployeePage.unblock();
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isBlockExist());

                NewEmployeePage.gotoRolePanel();
                Assert.True(NewEmployeePage.isRolePanel());
                NewEmployeePage.selectAvailRolesList(role);//выбрать роль
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);

                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);

                //step2
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);

                NewEmployeePage.setSnils(snils);

                NewEmployeePage.setPhone("+7(927)159-11-81");
                NewEmployeePage.setMail("test@test.ru");

                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);

                NewEmployeePage.unblock();
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isBlockExist());

                NewEmployeePage.gotoRolePanel();
                Assert.True(NewEmployeePage.isRolePanel());
                NewEmployeePage.selectAvailRolesList(role);//выбрать роль
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);

                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }


        [TestCase("сбербанк России ОАО", "Рога и копыта", "не должно вылететь ошибки",
                    TestName = "4.Проверка ввода организации администратора, 57037")]
        public void Test57037(string orgNameTrue, string orgNameFalse, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setOrganization(orgNameTrue);
                Assert.True(NewEmployeePage.isOrganizationPanelAppear());
                NewEmployeePage.selectItemOfOrganizationPanel(orgNameTrue);

                //step-2
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setOrganization(orgNameTrue);
                Assert.False(NewEmployeePage.isOrganizationPanelAppear());


                /*
                //step-1
                PortalPage.gotoMenuOrganizations();
                Assert.True(OrganizationPage.isTruePage());
                OrganizationPage.setOrganizationSearhInput(orgNameTrue);

                //проверяем есть ли текущий пользователь в табл пользователей
                OrganizationPage.getOrganizationTable(orgNameTrue);

                //step-2
                PortalPage.gotoMenuOrganizations();
                Assert.True(OrganizationPage.isTruePage());
                OrganizationPage.setOrganizationSearhInput(orgNameFalse);

                //проверяем НЕТ ли текущий пользователь в табл пользователей
                OrganizationPage.getOrganizationTable(orgNameFalse);
                */
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }


        [TestCase("Name$", "Family&", "Pather+Name", "ЛогиН", "0001", "используются недопустимые символы",
                    TestName = "5.Проверка ввода невалидных данных администратора эмитента, 57043")]
        public void Test57043(string lastName, string firstName, string otherName, string login, string snils, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                PortalPage.gotoMenuEmployees();

                //step-1
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                //NewEmployeePage.setLastName(lastName);
                //NewEmployeePage.setFirstName(firstName);
                // NewEmployeePage.setOtherName(otherName);
                //NewEmployeePage.setLogin(login);
                // NewEmployeePage.setSnils(snils);
                NewEmployeePage.setPhone("+7(927)159-11-81");
                NewEmployeePage.setMail("test@test.ru");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk(message), message);
                NewEmployeePage.cancel();


                //step-2
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                //NewEmployeePage.setLogin(login);
                //NewEmployeePage.setSnils(snils);
                //NewEmployeePage.setPhone("+7(927)159-11-81");
                //NewEmployeePage.setMail("test@test.ru");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk(message), message);
                NewEmployeePage.cancel();

                //step-3
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                NewEmployeePage.setLogin(login);
                NewEmployeePage.setSnils(snils);
                //NewEmployeePage.setPhone("+7(927)159-11-81");
                //NewEmployeePage.setMail("test@test.ru");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.getFieldsError(message));//подсказки к полям
                Assert.False(NewEmployeePage.isMessageGrowleOk(message), message);
                NewEmployeePage.cancel();

                //step-4
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Имя");
                NewEmployeePage.setFirstName("Фамилия");
                NewEmployeePage.setOtherName("Отчество");
                NewEmployeePage.setLogin("user");//<6 symbols
                NewEmployeePage.setSnils("12345678910");
                //NewEmployeePage.setPhone("+7(927)159-11-81");
                //NewEmployeePage.setMail("test@test.ru");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.getFieldsError("не может быть короче 6 символов"));//подсказки к полям
                Assert.False(NewEmployeePage.isMessageGrowleOk(message), message);
                NewEmployeePage.cancel();

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }


        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "такая запись уже существует",
                    TestName = "6.Проверка ввода дублирующих данных администратора эмитента, 57044")]
        public void Test57044(string lastName, string firstName, string otherName, string login, string snils, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                NewEmployeePage.setLogin(login);
                NewEmployeePage.setSnils(snils);
                //NewEmployeePage.setPhone("+7(927)159-11-81");
                //NewEmployeePage.setMail("test@test.ru");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.getFieldsError("пользователь уже существует"));//подсказки к полям
                Assert.False(NewEmployeePage.isMessageGrowleOk(message), message);

                //step-2
                NewEmployeePage.cancel();
                Assert.True(EmployeePage.isTruePage());

                //step-3
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                // NewEmployeePage.setLogin(login);
                NewEmployeePage.setSnils(snils);
                //NewEmployeePage.setPhone("+7(927)159-11-81");
                //NewEmployeePage.setMail("test@test.ru");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.getFieldsError("пользователь уже существует"));//подсказки к полям
                Assert.False(NewEmployeePage.isMessageGrowleOk(message), message);
                NewEmployeePage.cancel();
                Assert.True(EmployeePage.isTruePage());

                //step-4 ???
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                NewEmployeePage.setLogin(login);
                // NewEmployeePage.setSnils(snils);
                //NewEmployeePage.setPhone("+7(927)159-11-81");
                //NewEmployeePage.setMail("test@test.ru");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.getFieldsError("пользователь уже существует"));//подсказки к полям
                Assert.False(NewEmployeePage.isMessageGrowleOk(message), message);

                //step-6
                NewEmployeePage.cancel();
                Assert.True(EmployeePage.isTruePage());


            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }


        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "all ok", availRoles.adminOfIssuer,
           TestName = "7.Проверка настройки полномочий, 57040")]
        public void Test57040(string lastName, string firstName, string otherName, string login, string snils, string message, string role)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//FALSE проверяем есть ли текущий пользователь в табл пользователей

                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());

                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                NewEmployeePage.setLogin(login);
                NewEmployeePage.setSnils(snils);

                NewEmployeePage.gotoRolePanel();
                Assert.True(NewEmployeePage.isRolePanel());
                NewEmployeePage.selectAvailRolesList(role);//выбрать роль
                NewEmployeePage.isAvailRoleList(role);//появилась ли роль
                NewEmployeePage.clickAvailRoleListToogle();//нажимаем на ПОЛНОМОЧИЯ
                NewEmployeePage.isRoleCheckBoxExist(role);//появились полномиочия?

                //NewEmployeePage.gotoInfo();
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);
                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//TRUE проверяем есть ли текущий пользователь в табл пользователей
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }

        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "all ok", availRoles.adminOfIssuer,
     TestName = "8.Проверка отмены добавления администратора, 57042")]
        public void Test57042(string lastName, string firstName, string otherName, string login, string snils, string message, string role)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//FALSE проверяем есть ли текущий пользователь в табл пользователей

                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage());

                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                NewEmployeePage.setLogin(login);
                NewEmployeePage.setSnils(snils);

                NewEmployeePage.gotoRolePanel();
                Assert.True(NewEmployeePage.isRolePanel());
                NewEmployeePage.selectAvailRolesList(role);//выбрать роль
                NewEmployeePage.isAvailRoleList(role);//появилась ли роль
                NewEmployeePage.clickAvailRoleListToogle();//нажимаем на ПОЛНОМОЧИЯ
                NewEmployeePage.isRoleCheckBoxExist(role);//появились полномиочия?

                //NewEmployeePage.gotoInfo();
                NewEmployeePage.cancel();

                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//FALSE проверяем есть ли текущий пользователь в табл пользователей
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
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
