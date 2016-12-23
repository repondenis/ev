using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.SDK.Web;
using EVotingProject.Pages;
using EVotingProject.Helpers;
using EVotingProject.Models;
using HP.LFT.Report;
using HP.LFT.SDK.StdWin;
using System.Diagnostics;

namespace EVotingProject
{
    [TestFixture]
    [Description("Проверка создания собрания из файла MN админ ЕВотинга")]
    public class VerifInitiationFromFileMNTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            //ReportConfiguration r = new ReportConfiguration();
            //r.IsOverrideExisting = false;
            //r.Title = "E-Voting test reports 5";
            //Reporter.Init(r);

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
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"",
            @"D:\work\test\MN НРД (Роснефть) 1.xml", "D:\\temp\\Screen Shot 09-15-16 at 07.00 PM.PNG", "Успешно сохранен!",
              TestName = "56943.проверка инициации передачи файла сообщ о собрании MN админ ЕВотинга")]
        public void Test56943(string menuPar, string loginPar, string login, string pass, string orgName, string filePathTrueXSD, string filePathBadXSD, string message)
        {

            Console.WriteLine(DateTime.Now);

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");

            PortalPage.clickNewMeeting();
            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");

            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);

            //1
            NewMeetingPage.loadFromFile(filePathTrueXSD);

            //2 - файл не явл сообщ о проведении собрания XML
            NewMeetingPage.loadFromFile(filePathBadXSD);
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"",
  "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть)56945.xml", "Успешно сохранен!",
   TestName = "56945.проверка контроля формата сообщения из XSD из файла MN админ ЕВотинга")]
        public void Test56945(string menuPar, string loginPar, string login, string pass, string orgName, string filePathTrueXSD, string filePathBadXSD, string message)
        {

            Console.WriteLine(DateTime.Now);

            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");

            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);

            //1
            NewMeetingPage.loadFromFile(filePathTrueXSD);

            //2 - нет откр, закр тега, нет символа /, незакрытый комментарий
            NewMeetingPage.loadFromFile(filePathBadXSD);
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin", "Открытое акционерное общество \"Нефтяная компания \"Роснефть\"",
        "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "Успешно сохранен!",
        TestName = "56946.проверка logich контроля формата сообщения из файла MN админ ЕВотинга")]
        public void Test56946(string menuPar, string loginPar, string login, string pass, string orgName, string filePath1, string filePath2, string filePath3, string filePath4, string message)
        {

            Console.WriteLine(DateTime.Now);

            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");

            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);

            //1
            NewMeetingPage.loadFromFile(filePath1);

            //2 
            NewMeetingPage.loadFromFile(filePath2);

            //3 
            NewMeetingPage.loadFromFile(filePath3);

            //4
            NewMeetingPage.loadFromFile(filePath4);
        }

        //либо искать ОРГ по ИНН = 1027700043502
        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin",
            "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml", "D:\\temp\\MN НРД (Роснефть) 1.xml",
           "D:\\temp\\MN НРД (Роснефть) 2.xml", "D:\\temp\\MN НРД (орг_эмитента) 1.xml", "Успешно сохранен!",
              TestName = "56944.проверка типа KD (тип бумаги вид собрания эмитент) MN админ ЕВотинга")]
        public void Test56944(string menuPar, string loginPar, string login, string pass,
           string filePath1, string filePath2, string filePath3, string filePath4, string filePath5, string filePath6, string filePath7,
           string filePathAnyIssuer, string filePathItIssuer, string message)
        {


            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");

            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);

            //1-7
            NewMeetingPage.loadFromFile(filePath1);
            NewMeetingPage.loadFromFile(filePath2);
            NewMeetingPage.loadFromFile(filePath3);
            NewMeetingPage.loadFromFile(filePath4);
            NewMeetingPage.loadFromFile(filePath5);
            NewMeetingPage.loadFromFile(filePath6);
            NewMeetingPage.loadFromFile(filePath7);
            /*
            foreach (string fp in filesPaths)
            {
                NewMeetingPage.loadFromFile(fp);

            }
            */

            //8 проверить созд собрания под админом НРД выбрав любой эмитент
            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");
            PortalPage.clickNewMeeting();
            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");
            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);
            NewMeetingPage.loadFromFile(filePathAnyIssuer);
            NewMeetingPage.cancel();
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "adm_iss", "adm_iss",
            "D:\\temp\\MN НРД (Роснефть) 2.xml", "D:\\temp\\MN НРД (орг_эмитента) 1.xml", "Успешно сохранен!",
        TestName = "56944Step9-10.проверка типа KD (тип бумаги вид собрания эмитент) MN админ эмитента")]
        public void Test56944Step910(string menuPar, string loginPar, string login, string pass,
         string filePathAnyIssuer, string filePathItIssuer, string message)
        {
            //9 созд собр адм эмитента - свой эмитент

            autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);


            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");
            PortalPage.clickNewMeeting();
            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");
            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);
            NewMeetingPage.loadFromFile(filePathItIssuer);


            //10 созд собр адм эмитента - чужой эмитент
            NewMeetingPage.loadFromFile(filePathAnyIssuer);
            NewMeetingPage.cancel();
            NewMeetingPage.logout();
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "adm_reg", "adm_reg",
     "D:\\temp\\MN НРД (Роснефть) 2.xml", "D:\\temp\\MN НРД (орг_эмитента) 1.xml", "Успешно сохранен!",
 TestName = "56944Step11-12.проверка типа KD (тип бумаги вид собрания эмитент) MN админ регистратора")]
        public void Test56944Step1112(string menuPar, string loginPar, string login, string pass,
  string filePathAnyIssuer, string filePathItIssuer, string message)
        {

            //11 созд собр адм регистратора - свой эмитент
            autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);

            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");
            PortalPage.clickNewMeeting();
            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");
            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);
            NewMeetingPage.loadFromFile(filePathItIssuer);


            //12 созд собр адм регистратора - чужой эмитент
            NewMeetingPage.loadFromFile(filePathAnyIssuer);
            NewMeetingPage.cancel();


            //13
            // ???????????? вручную? - см 15
            //14
            // ???????????? вручную? - см 15


            NewMeetingPage.logout();
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "Rn_sk_1", "Rn_sk_1",
"D:\\temp\\MN НРД (Роснефть) 2.xml", "D:\\temp\\MN НРД (орг_эмитента) 1.xml", "Успешно сохранен!",
TestName = "56944Step15.проверка типа KD (тип бумаги вид собрания эмитент) MN участник сч комиссии")]
        public void Test56944Step15(string menuPar, string loginPar, string login, string pass,
string filePathAnyIssuer, string filePathItIssuer, string message)
        {

            //15 ВРУЧНУЮ???????????????????????
            autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);

            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");
            PortalPage.clickNewMeeting();
            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");
            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.MANUAL);
            NewMeetingPage.selectSecurityType(securityType.akcii);
            NewMeetingPage.selectmeetingType(meetingType.years);
            NewMeetingPage.selectFormType(formType.sendList);
            NewMeetingPage.setMeetingStartInput("26.05.2016 10:30");

            NewMeetingPage.cancel();

            NewMeetingPage.logout();
        }

        [TestCase(MenuParam.organizators, LoginParam.login, "admin", "admin",
        "D:\\temp\\MN НРД (Роснефть) 2.xml", "Успешно сохранен!",
        TestName = "56964.проверка отображения стр собрания и подствержд созд собрания, адм evot) MN участник сч комиссии")]
        public void Test56964(string menuPar, string loginPar, string login, string pass, string filePath, string message)
        {
            Console.WriteLine(DateTime.Now);

            var contractName = "00005";

            autorizeFromEVoting(urlDemoAdmin, loginPar, menuPar, login, pass);

            PortalPage.gotoMenuMeetings();
            Assert.True(PortalPage.isTruePage(), "должна быть страница собраний");
            PortalPage.clickNewMeeting();
            Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");

            NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);

            //before
            NewMeetingPage.loadFromFile(filePath);

            //1-2
            Assert.IsNotEmpty(NewMeetingPage.getSelectedSecurityType());
            Assert.IsNotEmpty(NewMeetingPage.getSelectedMeetingType());
            Assert.IsNotEmpty(NewMeetingPage.getSelectedFormType());
            Assert.IsNotEmpty(NewMeetingPage.getMeetingStartInput());
            Assert.IsNotEmpty(NewMeetingPage.getIssuerOrganization());
            Assert.IsNotEmpty(NewMeetingPage.getIssuerOrganizationInn());
            Assert.IsNotEmpty(NewMeetingPage.getIssuerOrganizationOgrn());

            //NewMeetingPage.setContract(contractName);
            NewMeetingPage.clickContractInputToggle();
            Assert.True(NewMeetingPage.isContractPanelAppear());
            NewMeetingPage.selectItemOfContract(contractName);

            //3
            NewMeetingPage.submit();
            Assert.False(NewMeetingPage.isErrorMsg(), "При сохранении произошла ошибка!");
            Assert.True(NewMeetingPage.isInfoMsg(), "При сохранении не произошло ошибки!");

            Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");
            var state = MeetingPage.getState();
            MeetingPage.clickEditState();
            MeetingPage.clickEditStateCreate();
            Assert.AreNotEqual(state, MeetingPage.getState(), "должен измениться статус собрания");

            //4
            //??

            //5
            state = MeetingPage.getState();
            var issuerFullName = MeetingPage.getissuerFullName();
            var meetingId = MeetingPage.getmeetingId();
            var formType = MeetingPage.getformTypeLabel();
            var meetingStart = MeetingPage.getmeetingStart();
            var meetingCountry = MeetingPage.getmeetingCountry();
            var meetingAddress = MeetingPage.getMeetingAddress();
            var voteMktDdln = MeetingPage.getVoteMktDdln();
            var participantsRegisterStart = MeetingPage.getParticipantsRegisterStart();
            var entitlementFixingDate = MeetingPage.getentitlementFixingDate();
            var postCountry = MeetingPage.getPostCountry();
            var postAddress = MeetingPage.getPostAddress();
            var agenda = MeetingPage.getAgenda();
            browser.Refresh();
            Assert.AreEqual(issuerFullName, MeetingPage.getissuerFullName());
            Assert.AreEqual(meetingId, MeetingPage.getmeetingId());
            Assert.AreEqual(formType, MeetingPage.getformTypeLabel());
            Assert.AreEqual(meetingStart, MeetingPage.getmeetingStart());
            Assert.AreEqual(meetingCountry, MeetingPage.getmeetingCountry());
            Assert.AreEqual(meetingAddress, MeetingPage.getMeetingAddress());
            Assert.AreEqual(voteMktDdln, MeetingPage.getVoteMktDdln());
            Assert.AreEqual(participantsRegisterStart, MeetingPage.getParticipantsRegisterStart());
            Assert.AreEqual(entitlementFixingDate, MeetingPage.getentitlementFixingDate());
            Assert.AreEqual(postCountry, MeetingPage.getPostCountry());
            Assert.AreEqual(postAddress, MeetingPage.getPostAddress());
            Assert.AreEqual(agenda, MeetingPage.getAgenda());

            MeetingPage.logout();
        }

        string[] s = { "123", "asd" };

        /// <summary>
        /// 56957
        /// </summary>
        /// <param name="menuPar"></param>
        /// <param name="loginPar"></param>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <param name="orgName"></param>
        /// <param name="filePath"></param>
        /// <param name="message"></param>
        /// <param name="contractName"></param>
        [TestCase(MenuParam.organizators, LoginParam.login, "adm_iss", "adm_iss", "ОАО \"НК \"Роснефть\"",
        @"D:\work\test\MN НРД (Роснефть) 2.xml", @"D:\work\test\MN НРД (Роснефть) 1.xml", @"D:\work\test\MN НРД (Роснефть) 1.xml",
        "Успешно сохранен!", "012345",
        TestName = "56957.проверка отображения стр собрания и подтвержд созд собрания, адм evot) MN участник сч комиссии")]
        public void Test56957(string menuPar, string loginPar, string login, string pass, string orgName,
            string filePath, string filePathStep6, string filePathStep7, string message, string contractName)
        {
            try
            {
                Console.WriteLine(DateTime.Now);

                addNewContract(orgName, contractName);

                autorizeFromEVoting(urlDemo, loginPar, menuPar, login, pass);


                PortalPage.clickNewMeeting();
                Assert.True(NewMeetingPage.isTruePage(), "должна быть страница создания собрания");

                NewMeetingPage.selectMethodCreateMeeting(MeetingMethodCreate.FILE);

                NewMeetingPage.loadFromFile(filePath);

                Assert.False(NewMeetingPage.isErrorMsg(), "не должно быть ошибки после загрузки файла");


                Assert.True(NewMeetingPage.getIssuerOrganization(orgName), "должна поменяться организация");

                //NewMeetingPage.setContract(contractName);
                NewMeetingPage.clickContractInputToggle();
                Assert.True(NewMeetingPage.isContractPanelAppear(), "должен появитсья спикок контрактов");
                NewMeetingPage.selectItemOfContract(contractName);

                //NewMeetingPage.clickContractInputToggle();
                //NewMeetingPage.selectContract(0, contractName);


                NewMeetingPage.submit();
                Assert.False(NewMeetingPage.isErrorMsg(), "При сохранении произошла ошибка!");
                //                Assert.True(NewMeetingPage.isInfoMsg(), "При сохранении не произошла ошибка!");

                Assert.True(MeetingPage.isTruePage(), "должна быть страница собрания");
                var state = MeetingPage.getState();

                //2
                //Console.WriteLine(MeetingPage.getMeetingAddress() + "<?>" + ReadXmlHelper.getElement("AdrLine"));
                Assert.AreEqual(MeetingPage.getMeetingAddress(), ReadXmlHelper.getElement("AdrLine"), "проверка Address");

                //3
                MeetingPage.setmeetingAddress("1111111111111111111111111111111111111111111111111111111111111111111111");//70symb
                MeetingPage.save();

                MeetingPage.setmeetingAddress("11111111111111111111111111111111111111111111111111111111111111111111111");//71symb
                MeetingPage.save();

                //4
                //Console.WriteLine(MeetingPage.getmeetingCountry() + "<?>" + ReadXmlHelper.getElement("Ctry"));
                Assert.AreEqual(MeetingPage.getmeetingCountry(), ReadXmlHelper.getElement("Ctry"), "проверка Country");

                //5 обяззательность поля ReadXmlHelper.getElement("Ctry")

                //6 ???
                NewMeetingPage.loadFromFile(filePathStep6);
                //7 ???
                NewMeetingPage.loadFromFile(filePathStep7);
                //    MeetingPage.logout();
            }
            catch (AssertionException e)
            {
                Reporter.ReportEvent(GetTestName(), "Ошибка проверки", Status.Failed, e, browser.GetSnapshot());
                throw;
            }
        }





        [TestCase]
        public void TestCalculator()
        {
            //  SDK.Init(new SdkConfiguration());

            Reporter.Init(new ReportConfiguration());
            Process.Start(@"C:\Windows\System32\calc.exe");



            var win = Desktop.Describe<HP.LFT.SDK.StdWin.IWindow>(new HP.LFT.SDK.StdWin.WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"CalcFrame",
                WindowTitleRegExp = @"Калькулятор"
            });

            var bt8 = win.Describe<HP.LFT.SDK.StdWin.IButton>(new HP.LFT.SDK.StdWin.ButtonDescription
            {
                Text = @"8",
                NativeClass = @"Button"
            });

            Console.WriteLine(win.Text + " " + win.WindowTitleRegExp);
            Console.WriteLine(bt8.WindowTitleRegExp);

            bt8.Click();


            var result = win.Describe<IStatic>(new StaticDescription
            {
                WindowId = 150,
                NativeClass = @"Static"
            });
            Trace.WriteLine("Result text contains " + result.Text);


            Trace.WriteLine("Result of addition is " + result.Text);
            Assert.AreEqual("8", result.Text, "Addition of 8");
            win.Close();
            Reporter.GenerateReport();
            //  SDK.Cleanup();

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
