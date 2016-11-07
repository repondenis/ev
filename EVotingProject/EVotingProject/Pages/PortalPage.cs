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

        //
        private static CSSDescription meetingsSearhText = new CSSDescription("input#form:meetingsList:searchText");//Нименование эмитента или огрн ввод тескт поле
        private static CSSDescription meetingsStartInput = new CSSDescription("input#form:meetingsList:meetingStart_input");// дата собр, текст поле
        private static CSSDescription meetingsFixingDateInput = new CSSDescription("input#form:meetingsList:entitlementFixingDate_input");// дата фиксац списка участн, текст поле
        
        //статус
        private static CSSDescription meetingStatusFilterLabel = new CSSDescription("label#form:meetingsList:meetingStatusFilter_label");//статус собрания - текст, нажимается-выпадает
        private static XPathDescription meetingStatusFilterToggle = new XPathDescription(".//div[@id='form:meetingsList:meetingStatusFilter']/div/span");
        private static CSSDescription meetingStatusFilterItems = new CSSDescription("ul#form:meetingsList:meetingStatusFilter_items");//input

        private static XPathDescription textMeeting = new XPathDescription(".//div[@id='wrap-meeting-list']/div/div/label");


        //список собраний - редактировать выбранное
        private static CSSDescription meetingsList = new CSSDescription("ul#form:meetingsList_list li");//список созданных собраний:
        private static CSSDescription meetingState = new CSSDescription("span.status-meeting-item"); //статус внутри meetingsList
        private static CSSDescription meetingOrgName = new CSSDescription("span.header-meeting-item"); // наименование орг -//-
        private static XPathDescription meetingDate = new XPathDescription(".//div[div[contains(text(),'Дата собрания')]]/div/span");//дата собрания -//-
        private static XPathDescription meetingDateFix = new XPathDescription(".//div[div[contains(text(),'Дата фиксации списка участников')]]/div/span");//Дата фиксации списка участников-//-
        private static XPathDescription meetingEdit = new XPathDescription(".//a[text()='Редактирование']");//ведет на MeetingPage



        public static bool isPortalPage()
        {

            browser.Sync();
            //Console.WriteLine("textMeeting=" + browser.Describe<IWebElement>(textMeeting).InnerText);
            return browser.Describe<IWebElement>(textMeeting).Exists() && browser.Describe<IWebElement>(textMeeting).InnerText.Equals("собрания");

        }

        public static void gotoMenuPortal()
        {
            browser.Describe<ILink>(menuPortal).Click();
        }

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

        public static void clickUserName()
        {
            browser.Describe<ILink>(menuUserName).Click();
        }

        public static void clickToggleUserName()
        {
            browser.Describe<IWebElement>(userNameToggle).Click();
        }

        public static bool isToggleUserName()
        {
            return browser.Describe<IWebElement>(userNameToggle).Exists();
        }

        public static bool isBlockUserName()
        {
            return browser.Describe<IWebElement>(userNameBlock).Exists();
        }

        public static void logout()
        {
            if (isToggleUserName())
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
            browser.Describe<IFileField>(meetingsSearhText).SetValue(value);
        }

        public static void setMeetingsStartInput(string value)
        {
            browser.Describe<IFileField>(meetingsStartInput).SetValue(value);
        }

        public static void setMeetingsFixingDateInput(string value)
        {
            browser.Describe<IFileField>(meetingsFixingDateInput).SetValue(value);
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



    }
}
