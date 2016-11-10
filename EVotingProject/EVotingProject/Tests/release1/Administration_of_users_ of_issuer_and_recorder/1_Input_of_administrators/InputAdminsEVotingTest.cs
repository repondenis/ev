using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Models;
using HP.LFT.Report;
using EVotingProject.Helpers;

namespace EVotingProject.Tests
{
    [TestFixture, Description("Ввод администраторов E-Voting")]
    public class InputOfAdministrarors : UnitTestClassBase
    {


        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            browser.Navigate(this.urlDemoAdmin);
        }

        [SetUp]
        public void SetUp()
        {

        }

        // [Test, Description("Проверка инициации добавления нового администратора E-Voting, 57030")]
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin"
            , TestName = "1.Проверка инициации добавления нового администратора E-Voting, 57030")]
        public void Test57030(string menuPar, string loginPar, string login, string pass)
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);
                Assert.True(LoginPage.isTruePage());
                LoginPage.caseMenuParam(menuPar);
                LoginPage.caseLoginParam(loginPar);
                Assert.True(LoginLocalPage.isTruePage());
                LoginLocalPage.runLogin(login, pass);
                Assert.True(PortalPage.isTruePage());
                PortalPage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }

        [TestCase(TestName = "2.Проверка ввода данных администратора, 57031")]
        public void Test57031()
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Имя");
                NewEmployeePage.setFirstName("Фамилия");
                NewEmployeePage.setOtherName("Отчество");
                NewEmployeePage.setLogin("fio12369");
                NewEmployeePage.setSnils("96345678910");
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(), "не должно вылететь ошибки");

                NewEmployeePage.unblock();
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isBlockExist());
                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable("Имя Фамилия Отчество");

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }

        [TestCase(TestName = "3.1.Проверка заполнения полей СНИЛС без ЛОГИН, 57032")]
        public void Test57032_1()
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Орлов");
                NewEmployeePage.setFirstName("Сергей");
                NewEmployeePage.setOtherName("Сергеевич");
                NewEmployeePage.setLogin("login123");
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk("Сохраненеи успешно прошло"));
                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable("Орлов Сергей Сергеевич");

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }


        [TestCase(TestName = "3.2.Проверка заполнения полей ЛОГИН без СНИЛС, 57032")]
        public void Test57032_2()
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Орлов");
                NewEmployeePage.setFirstName("Сергей");
                NewEmployeePage.setOtherName("Сергеевич");
                NewEmployeePage.setSnils("96365678910");
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk("Сохраненеи успешно прошло"));
                NewEmployeePage.gotoMenuEmployees();
                Assert.True(EmployeePage.isTruePage());

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable("Орлов Сергей Сергеевич");

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }

        [TestCase(TestName = "4.Проверка ввода данных с невалидными значениями, 57034")]
        public void Test57034()
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                //step1 - не указываем данные в обязат полях
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk(), "должна вылетель ошибка");
                NewEmployeePage.cancel();

                //step2 - заполн соотв поля не в соотв с Паттернами, login&snils is null
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Orlov6");
                NewEmployeePage.setFirstName("Сер гей 123");
                NewEmployeePage.setOtherName("123456");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk(), "должна вылетель ошибка");
                NewEmployeePage.cancel();

                //step3 - заполн соотв поля не в соотв с Паттернами, login&snils is not null
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Orlov6");
                NewEmployeePage.setFirstName("Сер гей 123");
                NewEmployeePage.setOtherName("123456");
                NewEmployeePage.setLogin("пароль&%$");
                NewEmployeePage.setSnils("один one");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk(), "должна вылетель ошибка");
                NewEmployeePage.cancel();

                //step3 - заполн соотв поля в соотв с Паттернами, login<6 symbols
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Имя");
                NewEmployeePage.setFirstName("Фамилия");
                NewEmployeePage.setOtherName("Отчество");
                NewEmployeePage.setLogin("lgn1");
                NewEmployeePage.setSnils("96345678910");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk(), "должна вылетель ошибка");
                NewEmployeePage.cancel();
            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }


        [TestCase(TestName = "5.Проверка дублир данных, 57035")]
        public void Test57035()
        {
            try
            {
                Console.WriteLine(DateTime.Now);
                PageHelper.setBrowser(browser);

                //step-1
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable("Имя" + " " + "Фамилия" + " " + "Отчество");//проверяем есть ли текущий пользователь в табл пользователей

                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Имя");
                NewEmployeePage.setFirstName("Фамилия");
                NewEmployeePage.setOtherName("Отчество");
                NewEmployeePage.setLogin("fio12369");
                NewEmployeePage.setSnils("96345678910");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk("такая запись уже существует"));
               
                //step-2
                NewEmployeePage.cancel();
                Assert.True(EmployeePage.isTruePage());

                //step-3 - вводим дубл данные, логин - пропускаем 
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable("Имя" + " " + "Фамилия" + " " + "Отчество");//проверяем есть ли текущий пользователь в табл пользователей

                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Имя");
                NewEmployeePage.setFirstName("Фамилия");
                NewEmployeePage.setOtherName("Отчество");
                NewEmployeePage.setSnils("96345678910");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk("такая запись уже существует"));
                NewEmployeePage.cancel();
                //step-4 - ???

                //step-5 - вводим дубл данные, снилс - пропускаем 
                Assert.True(EmployeePage.isTruePage());
                EmployeePage.getEmployeesTable("Имя" + " " + "Фамилия" + " " + "Отчество");//проверяем есть ли текущий пользователь в табл пользователей

                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Имя");
                NewEmployeePage.setFirstName("Фамилия");
                NewEmployeePage.setOtherName("Отчество");
                NewEmployeePage.setLogin("fio12369");
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleOk("такая запись уже существует"));


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


        [TestCase(TestName = "6.Проверка отмены добавления администратора, 57033")]
        public void Test57033()
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                Assert.True(EmployeePage.isTruePage());
                EmployeePage.addNewAdminEVoting();
                Assert.True(NewEmployeePage.isTruePage());
                NewEmployeePage.setLastName("Имя2");
                NewEmployeePage.setFirstName("Фамилия2");
                NewEmployeePage.setOtherName("Отчество2");
                NewEmployeePage.setLogin("fio666");
                NewEmployeePage.setSnils("66645678910");
                NewEmployeePage.cancel();
                Assert.True(EmployeePage.isTruePage());

                //проверяем НЕТ ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable("Имя2 Фамилия2 Отчество2");

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


        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            PortalPage.logout();
            browser.Close();
        }
    }
}
