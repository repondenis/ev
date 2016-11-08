using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;

namespace EVotingProject.Tests.release2
{
    [TestFixture]
    [Description("Брэндирование")]
    public class BrandingTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            browser.Navigate(this.url);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [TestCase(MenuParam.registrators, LoginParam.login, "admin_reestrrn_reg", "admin_reestrrn_reg", "Орлов Сергей Сергеевич", "Успешно сохранен!",
              TestName = "1.Проверка инициации изменения полномочий, 57022")]
        public void Test57022(string menuPar, string loginPar, string login, string pass, string userName, string message)
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
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName);//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName);//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());

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
