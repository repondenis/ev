using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;
using HP.LFT.Report;


namespace EVotingProject
{
    [TestFixture]
    [Description("Корректировка вопроса, проектов решений")]
    public class EditQuestionTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            var r = new HP.LFT.Report.ReportConfiguration();
            r.IsOverrideExisting = false;
            r.Title = "My LeanFT Report";
            Reporter.Init(r);

            browser = BrowserFactory.Launch(BrowserType.Chrome);

            browser.ClearCache();
            browser.DeleteCookies();
            PageHelper.setBrowser(browser);
        }

        [SetUp]
        public void SetUp()
        {

        }


        //либо искать ОРГ по ИНН = 1027700043502 
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56917.Проверка корректировки вопроса и проектов решений,админ ЕВотинга"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_iss", "adm_iss", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56917.Проверка корректировки вопроса и проектов решений,представитель эмитента"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_reg", "adm_reg", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56917.Проверка корректировки вопроса и проектов решений,представитель регистратора")]
        // [TestCaseSource("ALM")]
        public void Test56917(string menuPar, string loginPar, string login, string pass, string orgName, string photoCandidatefile, string message, string meetStat)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.setMeetingsSearhText(orgName);//фильтр
            PortalPage.selectMeetingStatusFilterItems(meetStat);
            //долэно быть создано общее собр или открыто эмитенту и рег или перенесено на портал голосов или опублик общ собрание
            PortalPage.editMeetingOfTable(orgName);
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");

            // ! аттрибут "введен бюллютень" для собрания - false
            MeetingPage.gotoMenuBullet();
            Assert.True(MeetingPage.isBulletenPanel("повестка дня"));
            //3
            MeetingPage.clickEditQuestion(1);

            //4 - вносим изменения
            MeetingPage.clickAddDecision();
            MeetingPage.clickAddDecisionSimple();
            // настроить выпуски ЦБ - голосубющие по вопросу - только для собрания по акциям
            MeetingPage.checkProceduralQuestion(true);// ???????? может не то?
            MeetingPage.addDescriptionOfQuestion("2 test text max 1024 symb");
            //5
            MeetingPage.saveQuestion();

            MeetingPage.save();

        }



        //либо искать ОРГ по ИНН = 1027700043502 
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56918.Проверка отмены корректировки вопроса и проектов решений,админ ЕВотинга"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_iss", "adm_iss", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56918.Проверка отмены корректировки вопроса и проектов решений,представитель эмитента"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_reg", "adm_reg", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56918.Проверка отмены корректировки вопроса и проектов решений,представитель регистратора")]
        // [TestCaseSource("ALM")]
        public void Test56918(string menuPar, string loginPar, string login, string pass, string orgName, string photoCandidatefile, string message, string meetStat)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.setMeetingsSearhText(orgName);//фильтр
            PortalPage.selectMeetingStatusFilterItems(meetStat);
            //долэно быть создано общее собр или открыто эмитенту и рег или перенесено на портал голосов или опублик общ собрание
            PortalPage.editMeetingOfTable(orgName);
            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");

            // ! аттрибут "введен бюллютень" для собрания - false
            MeetingPage.gotoMenuBullet();
            Assert.True(MeetingPage.isBulletenPanel("повестка дня"));
            //3
            MeetingPage.clickEditQuestion(1);

            //4 - вносим изменения
            MeetingPage.clickAddDecision();
            MeetingPage.clickAddDecisionSimple();
            // настроить выпуски ЦБ - голосубющие по вопросу - только для собрания по акциям
            MeetingPage.checkProceduralQuestion(true);// ???????? может не то?
            MeetingPage.addDescriptionOfQuestion("2 test text max 1024 symb");
            //5
            MeetingPage.cancelQuestion();

            MeetingPage.save();

        }

        [TearDown]
        public void TearDown()
        {

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
