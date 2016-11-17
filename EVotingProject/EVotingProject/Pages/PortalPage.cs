using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
//using HP.LFT.SDK.StdWin;
//using HP.LFT.SDK.WinForms;


namespace EVotingProject.Pages
{
    class PortalPage : Helpers.PageHelper
    {

        //MENU
        private static XPathDescription menuPortal = new XPathDescription(".//a[@href='/portal/' and span[img]]");
        private static XPathDescription menuMeetings = new XPathDescription(".//a[span[text()='Собрания']]");
        private static XPathDescription menuUsers = new XPathDescription(".//a[span[text()='Пользователи']]");
        private static XPathDescription menuOrganizations = new XPathDescription(".//a[span[text()='Организации']]");
        private static XPathDescription menuEmitents = new XPathDescription(".//a[span[text()='Эмитенты']]");
        private static XPathDescription menuProfileOrg = new XPathDescription(".//a[span[text()='Профиль организации']]");
        private static XPathDescription menuContracts = new XPathDescription(".//a[span[text()='Договоры']]");


        //форма пользователя-логаут
        private static CSSDescription menuUserName = new CSSDescription("a.user-name");
        private static CSSDescription userNameToggle = new CSSDescription("a.link-toggle");
        private static CSSDescription userNameBlock = new CSSDescription("div.block__info-user");//text name user
        private static CSSDescription userNameLogout = new CSSDescription("a.link-cancel-e-voting");// button exit


        //
        private static XPathDescription newMeeting = new XPathDescription(".//button[@type='submit' and span[text()='Новое собрание']]");//;button


        //private static CSSDescription organizationTitle = new CSSDescription("div#wrap-meeting-list>div>div>label");//эмитенты
        private static XPathDescription organizationTitle = new XPathDescription(".//div[@id='wrap-meeting-list']/div/div/label");

        //
        private static CSSDescription meetingsSearhText = new CSSDescription("input[id='form:meetingsList:searchText']");//Нименование эмитента или огрн ввод тескт поле
        private static CSSDescription meetingsStartInput = new CSSDescription("input#form:meetingsList:meetingStart_input");// дата собр, текст поле



        private static CSSDescription meetingsFixingDateInput = new CSSDescription("input#form:meetingsList:entitlementFixingDate_input");// дата фиксац списка участн, текст поле

        //статус
        private static CSSDescription meetingStatusFilterLabel = new CSSDescription("label#form:meetingsList:meetingStatusFilter_label");//статус собрания - текст, нажимается-выпадает
        private static XPathDescription meetingStatusFilterToggle = new XPathDescription(".//div[@id='form:meetingsList:meetingStatusFilter']/div/span");
        private static CSSDescription meetingStatusFilterItems = new CSSDescription("ul[id='form:meetingsList:meetingStatusFilter_items']");//input




        //список собраний - редактировать выбранное
        private static CSSDescription meetingsList = new CSSDescription("div[id='form:meetingsList_content']>ul>li");//список созданных собраний:
        private static CSSDescription meetingState = new CSSDescription("span.status-meeting-item"); //статус внутри meetingsList
        private static CSSDescription meetingOrgName = new CSSDescription("span.header-meeting-item"); // наименование орг -//-
        private static XPathDescription meetingDate = new XPathDescription(".//div[div[contains(text(),'Дата собрания')]]/div/span");//дата собрания -//-
        private static XPathDescription meetingDateFix = new XPathDescription(".//div[div[contains(text(),'Дата фиксации списка участников')]]/div/span");//Дата фиксации списка участников-//-
        private static XPathDescription meetingEdit = new XPathDescription(".//a[text()='Редактирование']");//ведет на MeetingPage



        public static bool isTruePage()
        {

            browser.Sync();
            //Console.WriteLine("textMeeting=" + browser.Describe<IWebElement>(organizationTitle).InnerText);
            return browser.Describe<IWebElement>(organizationTitle).Exists() &&
                browser.Describe<IWebElement>(organizationTitle).InnerText.Equals("собрания");

        }


        public static bool ismenuContractsExist()
        {
            return browser.Describe<ILink>(menuContracts).Exists();
        }
        public static void gotoMenuPortal()
        {
            browser.Describe<ILink>(menuPortal).Click();
        }

        /// <summary>
        /// собрания
        /// </summary>
        public static void gotoMenuMeetings()
        {
            browser.Describe<ILink>(menuMeetings).Click();
        }

        public static void gotoMenuEmployees()
        {
            browser.Describe<ILink>(menuUsers).Click();
        }

        public static void gotoMenuEmitents()
        {
            browser.Describe<ILink>(menuEmitents).Click();
        }

        public static void gotoMenuOrganizations()
        {
            browser.Describe<ILink>(menuOrganizations).Click();
        }

        public static void gotoMenuContracts()
        {
            browser.Describe<ILink>(menuContracts).Click();
        }

        public static void gotoMenuProfileOrg()
        {
            browser.Describe<ILink>(menuProfileOrg).Click();
        }

        public static bool isUserNameExist()
        {
            return browser.Describe<ILink>(menuUserName).Exists();
        }

        public static void clickUserName()
        {
            browser.Describe<ILink>(menuUserName).Click();
        }

        public static void clickToggleUserName()
        {
            browser.Describe<IWebElement>(userNameToggle).Click();
        }

        public static bool isToggleUserNameExist()
        {
            return browser.Describe<IWebElement>(userNameToggle).Exists();
        }

        public static bool isBlockUserName()
        {
            return browser.Describe<IWebElement>(userNameBlock).Exists();
        }

        public static void logout()
        {
            if (isToggleUserNameExist() && isUserNameExist())
            {
                clickToggleUserName();

                if (isBlockUserName())
                    browser.Describe<ILink>(userNameLogout).Click();
            }
        }


        public static string getUserName()
        {
            return browser.Describe<IWebElement>(userNameBlock).InnerText;
        }

        public static void clickNewMeeting()
        {
            browser.Describe<IButton>(newMeeting).Click();
        }


        public static void setMeetingsSearhText(string value)
        {
            browser.Describe<IEditField>(meetingsSearhText).SetValue(value);
        }

        public static void setMeetingsStartInput(string value)
        {
            browser.Describe<IEditField>(meetingsStartInput).SetValue(value);
        }

        public static void setMeetingsFixingDateInput(string value)
        {
            browser.Describe<IEditField>(meetingsFixingDateInput).SetValue(value);
        }

        public static void clickMeetingStatusFilterLabel()
        {
            browser.Describe<ILink>(meetingStatusFilterLabel).Click();
        }

        public static void clickMeetingStatusFilterToggle()
        {
            browser.Describe<ILink>(meetingStatusFilterToggle).Click();
        }

        public static void selectMeetingStatusFilterItems(string meetingStatusFilter)
        {
            browser.Describe<IListBox>(meetingStatusFilterItems).Select(meetingStatusFilter);
        }

        /// <summary>
        /// Открытое акционерное общество \"Нефтяная компания \"Роснефть\"
        /// </summary>
        /// <param name="orgName"></param>
        public static void editMeetingOfTable(string orgNameT)
        {

            var liMeetings = browser.FindChildren<IWebElement>(meetingsList);
            if (liMeetings != null && liMeetings.Length > 0)
            {
                for (int i = 0; i < liMeetings.Length; i++)
                {
                    var meetingChldr = liMeetings[i].Describe<IWebElement>(new CSSDescription("span.header-meeting-item"));
                    Console.WriteLine(i + ":" + meetingChldr.InnerText);
                    if (meetingChldr.Exists() && meetingChldr.InnerText.Equals(orgNameT))
                    {
                        liMeetings[i].FindChildren<ILink>(new XPathDescription(".//a[text()='Редактирование']"))[0].Click();
                        break;
                    }

                }


            }

        }

    }
}
