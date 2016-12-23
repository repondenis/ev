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
    [Description("Проверка ввода представителя-участника сч комиссии от регистратора")]
    public class AddNewMemberOfComissionOfRegistrTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
           // browser.Navigate(urlDemoAdmin);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "adm_reg", "adm_reg",
                     TestName = "1.Проверка инициации добавления нового уч сч комиссии регистратора E-Voting, 57061")]
        public void Test57061(string menuPar, string loginPar, string login, string pass)
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
                throw;
            }
        }

        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "не должно вылететь ошибки",
                     TestName = "2.Проверка ввода данных уч сч комиссии регистратора, 57062")]
        public void Test57062(string lastName, string firstName, string otherName, string login, string snils, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
                throw;
            }
        }

        [TestCase("Татьянова", "Татьяна", "Татьяновна", "memb_comis_reg", "46444648414", "не должно вылететь ошибки", availRoles.memberOfCounter,
                    TestName = "3.Проверка заполнения полей логина, снилс, 57064")]
        public void Test57064(string lastName, string firstName, string otherName, string login, string snils, string message, string role)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step1

                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");

                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);

                //step2
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
                throw;
            }
        }



        [TestCase("Name$", "Family&", "Pather+Name", "ЛогиН", "0001", "используются недопустимые символы",
                    TestName = "4.Проверка ввода невалидных данных уч сч комиссии регистратора, 57066")]
        public void Test57066(string lastName, string firstName, string otherName, string login, string snils, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                PortalPage.gotoMenuEmployees();

                //step-1
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
                throw;
            }
        }


        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "такая запись уже существует",
                    TestName = "5.Проверка ввода дублирующих данных уч сч комиссии регистратора, 57067")]
        public void Test57067(string lastName, string firstName, string otherName, string login, string snils, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");

                //step-3
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");

                //step-4 ???
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");
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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");


            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
                throw;
            }
        }


        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "all ok", availRoles.memberOfCounter,
           TestName = "6.Проверка настройки полномочий, 57063")]
        public void Test57063(string lastName, string firstName, string otherName, string login, string snils, string message, string role)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");

                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//FALSE проверяем есть ли текущий пользователь в табл пользователей

                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");

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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//TRUE проверяем есть ли текущий пользователь в табл пользователей
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
                throw;
            }
        }

        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "all ok", availRoles.memberOfCounter,
     TestName = "7.Проверка отмены добавления уч сч комиссии, 57065")]
        public void Test57065(string lastName, string firstName, string otherName, string login, string snils, string message, string role)
        {

            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");

                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//FALSE проверяем есть ли текущий пользователь в табл пользователей

                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isTruePage(),"должна быть страница Добавления нов пользователя");

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
                Assert.True(EmployeePage.isTruePage(),"должна быть страница Пользователей");
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);//FALSE проверяем есть ли текущий пользователь в табл пользователей
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
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
