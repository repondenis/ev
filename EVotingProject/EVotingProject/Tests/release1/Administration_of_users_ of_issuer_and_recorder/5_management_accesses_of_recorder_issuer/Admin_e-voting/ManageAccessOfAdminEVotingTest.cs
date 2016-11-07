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
    [Description("Управление полномочиями рег и эмит - админ e-voting")]
    public class ManageAccessOfAdminEVotingTest : UnitTestClassBase
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

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Ибрагимов Ибрагим Ибрагимович", "Успешно сохранен!",
              TestName = "1.Проверка инициации изменения полномочий, 56995")]
        public void Test56995(string menuPar, string loginPar, string login, string pass, string userName, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(LoginPage.isLoginPage());

            //2
            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isLoginLocalPage());
            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isPortalPage());

            //3
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName);//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName);//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());



        }

        [TestCase(MenuParam.organizators, LoginParam.login, "Ибрагимов01 Ибрагим01 Ибрагимович01", "01", "Используются недопустимые символы", "Заполнены не все обязательные поля",
              TestName = "3.Проверка редактирования данных и полномочий, 56999")]
        public void Test56999(string menuPar, string loginPar, string userName, string suff, string message1, string message2)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName);//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName);//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());
            //
            NewEmployeePage.setFirstName("AbC_12$");
            NewEmployeePage.setLastName("AbC_12$");
            NewEmployeePage.save();
            Assert.False(NewEmployeePage.isMessageGrowleOk(message1), message1);
            //
            NewEmployeePage.setFirstName("");
            NewEmployeePage.setLastName("");
            NewEmployeePage.save();
            Assert.False(NewEmployeePage.isMessageGrowleOk(message1), message2);

            NewEmployeePage.cancel();
            Assert.True(EmployeePage.isTruePage());

            EmployeePage.getEmployeesTable(userName);//проверяем есть ли новый ищмененный пользователь

        }


        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Ибрагимов Ибрагим Ибрагимович", "01", "Успешно сохранен!",
      TestName = "2.Проверка редактирования данных и полномочий, 56997")]
        public void Test56997(string menuPar, string loginPar, string login, string pass, string userName, string suff, string message)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1 2 3 4 5
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.setFirstName(NewEmployeePage.getFirstName() + suff);
            NewEmployeePage.setLastName(NewEmployeePage.getLastName() + suff);
            NewEmployeePage.setOtherName(NewEmployeePage.getOtherName() + suff);
            NewEmployeePage.setLogin(NewEmployeePage.getLogin() + suff);
            NewEmployeePage.setSnils("111-111-111 11");
            //6-7
            if (NewEmployeePage.isBlockExist())
                NewEmployeePage.block();//блокируем
            else
                 if (NewEmployeePage.isUnblockExist())
                NewEmployeePage.unblock();

            //8
            NewEmployeePage.save();
            Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.getEmployeesTable(userName);//проверяем есть ли новый ищмененный пользователь

        }



        [TestCase(MenuParam.organizators, LoginParam.login, "Ибрагимов01 Ибрагим01 Ибрагимович01", "01", "Блокировка администратора НРД невозможна",
            TestName = "4.Проверка незаблокированных администраторов, 57000")]
        public void Test57000(string menuPar, string loginPar, string userName, string suff, string message)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName);//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName);//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());
            //
            NewEmployeePage.setFirstName("Ибрагимов");
            NewEmployeePage.setLastName("Ибрагим");
            Assert.True(NewEmployeePage.isBlockExist());
            NewEmployeePage.block();//блокируем
            //2
            NewEmployeePage.save();
            //3
            Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);
            Assert.True(NewEmployeePage.isBlockExist());
            Assert.Equals(NewEmployeePage.getFirstName(), "Ибрагимов");
            Assert.Equals(NewEmployeePage.getLastName(), "Ибрагим");

            ОСТАНОВИЛСЯ ТУТ!http://clip2net.com/s/3E81iz1
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
