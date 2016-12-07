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
    [Description("Управление полномочиями рег и эмит - админ эмитента")]
    public class ManageAccessOfAdminOfIssuerTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            browser.Navigate(urlDemo);


        }

        [SetUp]
        public void SetUp()
        {


        }

        [TestCase(MenuParam.registrators, LoginParam.login, "admin_denisov_iss", "admin_denisov_iss", "Андрей Денисов", "Успешно сохранен!",
              TestName = "1.Проверка инициации изменения полномочий, 57017")]
        public void Test57017(string menuPar, string loginPar, string login, string pass, string userName, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(LoginPage.isTruePage());

            //2
            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isTruePage(),"должна быть страница авториз по логину-паролю");
            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");

            //3
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName);//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName);//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());

        }

        [TestCase("Андрей Денисов", "01", "Успешно сохранен!",
TestName = "2.Проверка редактирования данных и полномочий, 57018")]
        public void Test57018(string userName, string suff, string message)
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

        [TestCase("Андрей Денисов", "01", "Используются недопустимые символы", "Заполнены не все обязательные поля",
              TestName = "3.Проверка редактирования полномочий, 57019")]
        public void Test57019(string userName, string suff, string message1, string message2)
        {

            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1 2
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.gotoRolePanel();
            Assert.True(NewEmployeePage.isRolePanel());
            NewEmployeePage.clickAvailRoleListToogle();//нажимаем полномочия
            NewEmployeePage.isRoleCheckBoxExist(availRoles.adminOfRegistrators);
            NewEmployeePage.selectRolePermission(availRoles.adminOfRegistrators, 1, true);//чекнуть 1 роль

        }



        [TestCase("Андрей Денисов", "01",
     TestName = "4.Проверка отмены редактирования данных и полномочий, 57020")]
        public void Test57020(string userName, string suff)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.setFirstName(NewEmployeePage.getFirstName() + suff);
            NewEmployeePage.setLastName(NewEmployeePage.getLastName() + suff);
            NewEmployeePage.setOtherName(NewEmployeePage.getOtherName() + suff);
            NewEmployeePage.setLogin(NewEmployeePage.getLogin() + suff);

            NewEmployeePage.cancel();

            Assert.True(EmployeePage.isTruePage());
            EmployeePage.getEmployeesTable(userName);//проверяем есть ли старый не измененный пользователь

        }


        [TestCase("Андрей Денисов", "01", "Используются недопустимые символы",
        TestName = "5.Проверка редактирования данных и полномочий представителя рег, 57021")]
        public void Test57021(string userName, string suff, string message1)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName.Replace(" ", suff + " "));//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName.Replace(" ", suff + " "));//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());
            //
            NewEmployeePage.setPhone("AbC_12$");
            NewEmployeePage.setMail("AbC_12$");
            NewEmployeePage.save();
            Assert.False(NewEmployeePage.isMessageGrowleOk(message1), message1);

            NewEmployeePage.cancel();
            Assert.True(EmployeePage.isTruePage());

        }









        [TestCase("Андрей Денисов", "01", "Блокировка администратора НРД невозможна",
            TestName = "4.Проверка незаблокированных администраторов, 57000")]
        public void Test57000(string userName, string suff, string message)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName.Replace(" ", suff + ""));//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName.Replace(" ", suff + ""));//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());
            //
            NewEmployeePage.setFirstName("Татьянова");
            NewEmployeePage.setLastName("Татьяна");
            Assert.True(NewEmployeePage.isBlockExist());
            NewEmployeePage.block();//блокируем
            //2
            NewEmployeePage.save();
            //3
            Assert.True(NewEmployeePage.isMessageGrowleOk(message), message);
            Assert.True(NewEmployeePage.isBlockExist());
            Assert.Equals(NewEmployeePage.getFirstName(), "Татьянова");
            Assert.Equals(NewEmployeePage.getLastName(), "Татьяна");

            // ОСТАНОВИЛСЯ ТУТ!http://clip2net.com/s/3E81iz1
        }


        [TestCase("Андрей Денисов", "01",
            TestName = "5.Проверка отмены редактирования данных и полномочий, 56998")]
        public void Test56998(string userName, string suff)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.setFirstName(NewEmployeePage.getFirstName() + suff);
            NewEmployeePage.setLastName(NewEmployeePage.getLastName() + suff);
            NewEmployeePage.setOtherName(NewEmployeePage.getOtherName() + suff);
            NewEmployeePage.setLogin(NewEmployeePage.getLogin() + suff);

            NewEmployeePage.cancel();

            Assert.True(EmployeePage.isTruePage());
            EmployeePage.getEmployeesTable(userName);//проверяем есть ли старый не измененный пользователь

        }
        // //////////////////////////// РЕГИСТРАТОР

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Андрей Денисов", "Успешно сохранен!",
       TestName = "6.Проверка инициации изменения полномочий представителя рег, 57010")]
        public void Test57010(string menuPar, string loginPar, string login, string pass, string userName, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            if (PortalPage.isUserNameExist())
                PortalPage.logout();


            //1
            Assert.True(LoginPage.isTruePage());

            //2
            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isTruePage(),"должна быть страница авториз по логину-паролю");
            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");

            //3
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName);//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName);//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());

        }

        [TestCase("Андрей Денисов", "01", "Успешно сохранен!",
            TestName = "7.Проверка редактирования данных и полномочий представителя рег, 57012")]
        public void Test57012(string userName, string suff, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);
            //
            Assert.True(NewEmployeePage.isTruePage());

            //1
            NewEmployeePage.gotoRolePanel();
            Assert.True(NewEmployeePage.isRolePanel());
            //2
            NewEmployeePage.selectAvailRolesList(availRoles.memberOfCounter);
            //3
            NewEmployeePage.gotoInfoPanel();
            Assert.True(NewEmployeePage.isInfoPanel());

            //4-10
            NewEmployeePage.setFirstName(NewEmployeePage.getFirstName() + suff);
            NewEmployeePage.setLastName(NewEmployeePage.getLastName() + suff);
            NewEmployeePage.setOtherName(NewEmployeePage.getOtherName() + suff);
            NewEmployeePage.setLogin(NewEmployeePage.getLogin() + suff);
            NewEmployeePage.setSnils("111-111-111 11");
            NewEmployeePage.setPhone("+ 7 (123) 456-78-90");// 1234567890
            NewEmployeePage.setMail("test@test.ru");
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
            EmployeePage.getEmployeesTable(userName.Replace(" ", suff + " "));//проверяем есть ли новый и3мененный пользователь

        }

        [TestCase("Андрей Денисов", "01", "Используются недопустимые символы", "Заполнены не все обязательные поля",
                TestName = "8.Проверка редактирования данных и полномочий представителя рег, 57016")]
        public void Test57016(string userName, string suff, string message1, string message2)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName.Replace(" ", suff + " "));//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName.Replace(" ", suff + " "));//нажим РЕдактировать нужного польз
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

            EmployeePage.getEmployeesTable(userName.Replace(" ", suff + " "));//проверяем есть ли HEищмененный пользователь

        }


        [TestCase("Андрей Денисов", "01", "сбербанк России ОАО", "Рога и копыта", "Используются недопустимые символы", "Заполнены не все обязательные поля",
       TestName = "9.Проверка редактирования организации представителя рег, 57011")]
        public void Test57011(string userName, string suff, string orgNameTrue, string orgNameFalse, string message1, string message2)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName.Replace(" ", suff + " "));//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName.Replace(" ", suff + " "));//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());
            //

            NewEmployeePage.setOrganization(orgNameTrue);
            Assert.True(NewEmployeePage.isOrganizationPanelAppear());
            NewEmployeePage.selectItemOfOrganizationPanel(orgNameTrue);

            NewEmployeePage.save();
            Assert.False(NewEmployeePage.isMessageGrowleOk(message1), message1);

            //2
            NewEmployeePage.setOrganization(orgNameFalse);
            Assert.False(NewEmployeePage.isOrganizationPanelAppear());
        }


        [TestCase(
                TestName = "10.Проверка редактирования перечня эмитентов представителя рег, 57014")]
        [Ignore("57014 - непонятен ТЕстКейс")]
        public void Test57014()
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            // ????????????

        }

        [TestCase("Андрей Денисов", "01",
            TestName = "11.Проверка редактирования полномочий выбранной роли представителя рег, 57013")]
        [Ignore("57014 - непонятен ТЕстКейс")]
        public void Test57013(string userName, string suff)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.gotoRolePanel();
            Assert.True(NewEmployeePage.isRolePanel());
            NewEmployeePage.clickAvailRoleListToogle();//нажимаем полномочия
            NewEmployeePage.isRoleCheckBoxExist(availRoles.adminOfRegistrators);
            NewEmployeePage.selectRolePermission(availRoles.adminOfRegistrators, 1, true);//чекнуть 1 роль

        }


        [TestCase("Андрей Денисов", "01",
            TestName = "12.Проверка отмены редактирования данных и полномочий, 57015")]
        public void Test57015(string userName, string suff)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.setFirstName(NewEmployeePage.getFirstName() + suff);
            NewEmployeePage.setLastName(NewEmployeePage.getLastName() + suff);
            NewEmployeePage.setOtherName(NewEmployeePage.getOtherName() + suff);
            NewEmployeePage.setLogin(NewEmployeePage.getLogin() + suff);

            NewEmployeePage.cancel();

            Assert.True(EmployeePage.isTruePage());
            EmployeePage.getEmployeesTable(userName);//проверяем есть ли старый не измененный пользователь

        }
        // //////////////////////////// ЭМИТЕНТ
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Еленова Елена Еленовна", "Успешно сохранен!",
                TestName = "13.Проверка инициации изменения полномочий представителя эмитента, 57003")]
        public void Test57003(string menuPar, string loginPar, string login, string pass, string userName, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            if (PortalPage.isUserNameExist())
                PortalPage.logout();


            //1
            Assert.True(LoginPage.isTruePage());

            //2
            LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            Assert.True(LoginLocalPage.isTruePage(),"должна быть страница авториз по логину-паролю");
            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage(),"должна быть страница собраний");

            //3
            PortalPage.gotoMenuEmployees();
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName);//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName);//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());

        }

        [TestCase("Еленова Елена Еленовна", "01", "Успешно сохранен!",
            TestName = "14.Проверка редактирования данных и полномочий представителя эмитента, 57005")]
        public void Test57005(string userName, string suff, string message)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);
            //
            Assert.True(NewEmployeePage.isTruePage());

            //1
            NewEmployeePage.gotoRolePanel();
            Assert.True(NewEmployeePage.isRolePanel());
            //2
            NewEmployeePage.selectAvailRolesList(availRoles.memberOfCounter);
            //3
            NewEmployeePage.gotoInfoPanel();
            Assert.True(NewEmployeePage.isInfoPanel());

            //4-10
            NewEmployeePage.setFirstName(NewEmployeePage.getFirstName() + suff);
            NewEmployeePage.setLastName(NewEmployeePage.getLastName() + suff);
            NewEmployeePage.setOtherName(NewEmployeePage.getOtherName() + suff);
            NewEmployeePage.setLogin(NewEmployeePage.getLogin() + suff);
            NewEmployeePage.setSnils("111-111-111 11");
            NewEmployeePage.setPhone("+ 7 (123) 456-78-90");// 1234567890
            NewEmployeePage.setMail("test@test.ru");
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
            EmployeePage.getEmployeesTable(userName.Replace(" ", suff + " "));//проверяем есть ли новый и3мененный пользователь

        }

        [TestCase("Еленова Елена Еленовна", "01", "Используются недопустимые символы", "Заполнены не все обязательные поля",
         TestName = "15.Проверка редактирования данных и полномочий представителя эмитента, 57009")]
        public void Test57009(string userName, string suff, string message1, string message2)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName.Replace(" ", suff + " "));//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName.Replace(" ", suff + " "));//нажим РЕдактировать нужного польз
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

            EmployeePage.getEmployeesTable(userName.Replace(" ", suff + " "));//проверяем есть ли HEищмененный пользователь

        }

        [TestCase("Еленова Елена Еленовна", "01", "сбербанк России ОАО", "Рога и копыта", "Используются недопустимые символы", "Заполнены не все обязательные поля",
        TestName = "16.Проверка редактирования организации представителя эмитента, 57004")]
        public void Test57004(string userName, string suff, string orgNameTrue, string orgNameFalse, string message1, string message2)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(EmployeePage.isTruePage());
            EmployeePage.setFioSnilsFilter(userName.Replace(" ", suff + " "));//заполняем фильтр
            EmployeePage.editEmployeesOfTable(userName.Replace(" ", suff + " "));//нажим РЕдактировать нужного польз
            Assert.True(NewEmployeePage.isTruePage());
            //

            NewEmployeePage.setOrganization(orgNameTrue);
            Assert.True(NewEmployeePage.isOrganizationPanelAppear());
            NewEmployeePage.selectItemOfOrganizationPanel(orgNameTrue);

            NewEmployeePage.save();
            Assert.False(NewEmployeePage.isMessageGrowleOk(message1), message1);

            //2
            NewEmployeePage.setOrganization(orgNameFalse);
            Assert.False(NewEmployeePage.isOrganizationPanelAppear());
        }


        [TestCase("Еленова Елена Еленовна", "01", "сбербанк России ОАО",
            TestName = "17.Проверка редактирования полномочий выбранной роли представителя эмитента, 57007")]
        [Ignore("57014 - непонятен ТЕстКейс")]
        public void Test57007(string userName, string suff, string orgNameTrue)
        {
            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.gotoRolePanel();
            Assert.True(NewEmployeePage.isRolePanel());
            NewEmployeePage.clickAvailRoleListToogle();//нажимаем полномочия
            NewEmployeePage.isRoleCheckBoxExist(availRoles.adminOfRegistrators);
            NewEmployeePage.selectRolePermission(availRoles.adminOfRegistrators, 1, true);//чекнуть 1 роль

        }

        [TestCase("Еленова Елена Еленовна", "01",
            TestName = "18.Проверка отмены редактирования данных и полномочий представителя эмитента, 57008")]
        public void Test57008(string userName, string suff)
        {


            Console.WriteLine(DateTime.Now);
            PageHelper.setBrowser(browser);

            //1
            Assert.True(NewEmployeePage.isTruePage());
            NewEmployeePage.setFirstName(NewEmployeePage.getFirstName() + suff);
            NewEmployeePage.setLastName(NewEmployeePage.getLastName() + suff);
            NewEmployeePage.setOtherName(NewEmployeePage.getOtherName() + suff);
            NewEmployeePage.setLogin(NewEmployeePage.getLogin() + suff);

            NewEmployeePage.cancel();

            Assert.True(EmployeePage.isTruePage());
            EmployeePage.getEmployeesTable(userName);//проверяем есть ли старый не измененный пользователь

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
