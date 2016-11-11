using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;
using HP.LFT.Report;
using System.Drawing;

namespace EVotingProject
{
    [TestFixture]
    [Description("Получение списка участников собрания админ ЕВотинга")]
    public class LoadMIAdminEVotingTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            ReportConfiguration r = new ReportConfiguration();
            r.IsOverrideExisting = true;
            r.Title = "E-Voting reports";
            Reporter.Init(r);

            browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.ClearCache();
            browser.DeleteCookies();
            PageHelper.setBrowser(browser);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        //либо искать ОРГ по ИНН = 1027700043502
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "ОАО \"НК \"Роснефть\"", "D:\\work\\test\\logoh.png", "D:\\work\\test\\logol.png", "#001199", "Успешно сохранен!",
              TestName = "59968.Проверка получения списка участников админ ЕВотинга")]
        public void Test59968(string menuPar, string loginPar, string login, string pass, string orgName, string filePathHeader, string filePathList, string color, string message)
        {

            Console.WriteLine(DateTime.Now);

            browser.Navigate(urlDemo);
            Assert.True(LoginPage.isTruePage());

            // для админ паге - не надо LoginPage.caseMenuParam(menuPar);
            LoginPage.caseLoginParam(loginPar);
            browser.Navigate(urlDemoAdmin);
            browser.Sync();
            Assert.True(LoginLocalPage.isTruePage());

            LoginLocalPage.runLogin(login, pass);
            Assert.True(PortalPage.isTruePage());

            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage());
            PortalPage.setMeetingsSearhText(orgName);
            PortalPage.selectMeetingStatusFilterItems(MeetingStatusFilter.itemLoadMN);

            PortalPage.editMeetingOfTable(orgName);//нажим РЕдактировать нужного 
            Assert.True(MeetingPage.isTruePage());

            /*

            Assert.True(OrganizationPage.isTruePage());
            OrganizationPage.setOrganizationSearhInput(orgName);//фильтр

            OrganizationPage.getOrganizationTable(orgName);//получаем табл
            OrganizationPage.editOrganizationOfTable(orgName);//нажим РЕдактировать нужного 
            Assert.True(NewOrganizationPage.isTruePage(orgName));
            NewOrganizationPage.gotoMenuProfileOrg();

            Assert.True(NewOrganizationPage.isTitlePanelExist("Информация"));
            NewOrganizationPage.clickLoadLogo();

            NewOrganizationPage.clickLoadLogoHeader();

            Console.WriteLine(DateTime.Now + "clickLoadLogoList after");
            Assert.False(NewOrganizationPage.isOpenFileDialog());
            NewOrganizationPage.selectLogoFileOfDialog(filePathHeader);
            NewOrganizationPage.clickOkOfOpenFileDialog();
            Console.WriteLine(DateTime.Now + "clickLoadLogoList before");


            //            Reporter.ReportEvent("Setting value in edit box", "", Status.Passed, browser.GetSnapshot());


            NewOrganizationPage.clickLoadLogo();
            NewOrganizationPage.clickLoadLogoList();
            NewOrganizationPage.selectLogoFileOfDialog(filePathList);
            NewOrganizationPage.setColorHeader(color);
            NewOrganizationPage.setColorButton(color);

            NewOrganizationPage.save();
            */
        }



        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            Reporter.GenerateReport();
            PortalPage.logout();
            browser.Close();
        }
    }
}
