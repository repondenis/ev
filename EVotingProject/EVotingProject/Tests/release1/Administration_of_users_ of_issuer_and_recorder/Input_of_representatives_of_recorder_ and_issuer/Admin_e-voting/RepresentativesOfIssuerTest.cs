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
    public class InputRegistratorAndIssuerTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            browser.Navigate(this.url2);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin",
            TestName = "1.Проверка инициации добавления нового представителя регистратора E-Voting, 57045")]
        public void Test57045(string menuPar, string loginPar, string login, string pass)
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);
                Assert.True(LoginPage.isLoginPage());
                LoginPage.caseMenuParam(menuPar);
                LoginPage.caseLoginParam(loginPar);
                Assert.True(LoginLocalPage.isLoginLocalPage());
                LoginLocalPage.runLogin(login, pass);
                Assert.True(PortalPage.isPortalPage());
                PortalPage.gotoMenuUsers();
                Assert.True(EmployeePage.isEmployeePage());
                EmployeePage.addNewUser();
                Assert.True(NewEmployeePage.isNewEmployeePage());

            }
            catch (Exception e)
            {
                Reporter.ReportEvent(GetTestName(), "Failed during validation", Status.Failed, e);
                throw;
            }
        }

        [TestCase("Имя", "Фамилия", "Отчество", "fio12369", "96345678910", "не должно вылететь ошибки",
            TestName = "2.Проверка ввода данных представителя регистратора, 57047")]
        public void Test57047(string lastName, string firstName, string otherName, string login, string snils, string message)
        {

            try
            {
                Console.WriteLine(DateTime.Now);

                PageHelper.setBrowser(browser);

                Assert.True(NewEmployeePage.isNewEmployeePage());
                NewEmployeePage.setLastName(lastName);
                NewEmployeePage.setFirstName(firstName);
                NewEmployeePage.setOtherName(otherName);
                NewEmployeePage.setLogin(login);
                NewEmployeePage.setSnils(snils);

                NewEmployeePage.setPhone("+7(927)159-11-81");
                NewEmployeePage.setMail("test@test.ru");

                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isMessageGrowleOk(), message);

                NewEmployeePage.unblock();
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isBlockExist());
                NewEmployeePage.GotoRole

                NewEmployeePage.gotoMenuUsers();
                Assert.True(EmployeePage.isEmployeePage());

                //проверяем есть ли текущий пользователь в табл пользователей
                EmployeePage.getEmployeesTable(lastName + " " + firstName + " " + otherName);

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
