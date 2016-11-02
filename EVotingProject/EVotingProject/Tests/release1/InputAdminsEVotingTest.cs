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
        private string url = "https://demo-evoting.test.gosuslugi.ru/idp/sso#/";
        private string url2 = "https://portal-dev-evoting.test.gosuslugi.ru/";

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

        [TestCase(TestName = "2.Проверка ввода данных администратора, 57031")]
        public void Test57031()
        {
            try
            {

                PageHelper.setBrowser(browser);

                Assert.True(NewEmployeePage.isNewEmployeePage());
                NewEmployeePage.setLastName("Имя2");
                NewEmployeePage.setFirstName("Фамилия2");
                NewEmployeePage.setOtherName("Отчество2");
                NewEmployeePage.setLogin("fio1234");
                NewEmployeePage.setSnils("22345678910");//123-456-789 10
                NewEmployeePage.save();
                Assert.False(NewEmployeePage.isMessageGrowleError());
                NewEmployeePage.unblock();
                NewEmployeePage.save();
                Assert.True(NewEmployeePage.isBlockExist());
                
                NewEmployeePage.gotoMenuUsers();
                Assert.True(EmployeePage.isEmployeePage());
                EmployeePage.getEmployeesTable();

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
