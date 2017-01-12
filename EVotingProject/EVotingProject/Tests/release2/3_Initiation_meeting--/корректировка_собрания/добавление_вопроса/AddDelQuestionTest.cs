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
    [Description("Добавление вопроса, проектов решений")]
    public class AddDelQuestionTest : UnitTestClassBase
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
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56915.Проверка добавл вопроса и проектов решений,админ ЕВотинга"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_issuer", "adm_issuer", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56915.Проверка добавл вопроса и проектов решений,представитель эмитента"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_recorder", "adm_recorder", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56915.Проверка добавл вопроса и проектов решений,представитель регистратора")]
        // [TestCaseSource("ALM")]
        public void Test56915(string menuPar, string loginPar, string login, string pass, string orgName, string photoCandidatefile, string message, string meetStat)
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
            MeetingPage.addQuestion();
            MeetingPage.addQuestionWithoutChoice();
            MeetingPage.addNoticeOfQuestion("test text max 1024 symb");
            //4
            MeetingPage.clickAddDecision();
            //5
            MeetingPage.clickAddDecisionSimple();
            //6 настроить выпуски ЦБ - голосубющие по вопросу - только для собрания по акциям
            MeetingPage.checkProceduralQuestion(true);// ???????? может не то?
            //7
            MeetingPage.addDescriptionOfQuestion("test text max 1024 symb");
            //8
            MeetingPage.saveQuestion();

            //9
            MeetingPage.addQuestion();
            MeetingPage.addQuestionWithoutChoice();

            //10
            MeetingPage.addNoticeOfQuestion("test text max 1024 symb");
            //11
            MeetingPage.clickAddDecision();
            MeetingPage.clickAddDecisionDiff();
            //12 настроить выпуски ЦБ - голосубющие по вопросу - только для собрания по акциям
            MeetingPage.checkProceduralQuestion(true);// ???????? может не то?
            //13
            MeetingPage.addDescriptionOfQuestion("test text max 1024 symb");
            //14 ??
            MeetingPage.setKoefficient(5);
            //15 добавление кандидатов
            MeetingPage.addCandidate(1, "ФИО", photoCandidatefile, "независимый кандидат", "рекомендован советом директоров");

            //16
            MeetingPage.save();

        }



        //либо искать ОРГ по ИНН = 1027700043502 
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56916.Проверка отмены добавл вопроса и проектов решений,админ ЕВотинга"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_issuer", "adm_issuer", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56916.Проверка отмены добавл вопроса и проектов решений,представитель эмитента"),
         TestCase(MenuParam.organizators, LoginParam.login, "adm_recorder", "adm_recorder", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"", @"D:\work\test\photo.png", "Успешно сохранен!", MeetingStatus.itemMeetOpen, TestName = "56916.Проверка отмены добавл вопроса и проектов решений,представитель регистратора")]
        // [TestCaseSource("ALM")]
        public void Test56916(string menuPar, string loginPar, string login, string pass, string orgName, string photoCandidatefile, string message, string meetStat)
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
            //1-2
            MeetingPage.addQuestion();
            MeetingPage.addQuestionWithoutChoice();
            MeetingPage.addNoticeOfQuestion("test text max 1024 symb");
            //3
            MeetingPage.clickAddDecision();
            //4
            MeetingPage.clickAddDecisionSimple();
            // настроить выпуски ЦБ - голосубющие по вопросу - только для собрания по акциям
            MeetingPage.checkProceduralQuestion(true);// ???????? может не то?
            //5
            MeetingPage.addDescriptionOfQuestion("test text max 1024 symb");
            //6
            MeetingPage.cancelQuestion();

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
