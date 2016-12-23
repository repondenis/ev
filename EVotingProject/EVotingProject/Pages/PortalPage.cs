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

        private static CSSDescription menuUserName2 = new CSSDescription("a.header-username");
        private static CSSDescription userNameLogout2 = new CSSDescription("button.btn-logout");// button exit


        //
        private static XPathDescription newMeeting = new XPathDescription(".//button[@type='submit' and span[text()='Новое собрание']]");//;button


        //private static CSSDescription organizationTitle = new CSSDescription("div#wrap-meeting-list>div>div>label");//эмитенты
        private static CSSDescription organizationTitle = new CSSDescription("div#wrap-meeting-list>div>label");//28112016(".//div[@id='wrap-meeting-list']/div/div/label");

        // search
        private static CSSDescription meetingsSearhText = new CSSDescription("input[id='form:searchText']");//28-11-16("input[id='form:meetingsList:searchText']");//Нименование эмитента или огрн ввод тескт поле
        private static CSSDescription meetingsStartInput = new CSSDescription("form:meetingStart_input");//("input#form:meetingsList:meetingStart_input");// дата собр, текст поле
        private static CSSDescription meetingsFixingDateInput = new CSSDescription("input[id='form:entitlementFixingDate_input']");//28-11-16("input#form:meetingsList:entitlementFixingDate_input");// дата фиксац списка участн, текст поле

        //статус
        private static CSSDescription meetingStatusFilterLabel = new CSSDescription("label[id='form:meetingStatusFilter_label']");//("label#form:meetingsList:meetingStatusFilter_label");//статус собрания - текст, нажимается-выпадает
        private static XPathDescription meetingStatusFilterToggle = new XPathDescription(".//div[@id='form:meetingStatusFilter']/div/span");//(".//div[@id='form:meetingsList:meetingStatusFilter']/div/span");
        private static CSSDescription meetingStatusFilterItems = new CSSDescription("ul[id='form:meetingStatusFilter_items']");//("ul[id='form:meetingsList:meetingStatusFilter_items']");//input




        //список собраний - редактировать выбранное - ИЗМЕНИЛ селекты!
        private static CSSDescription meetingsList = new CSSDescription("div[id='form:meetingsList_content']>ul>li");//список созданных собраний:
        private static CSSDescription meetingState = new CSSDescription("div.main-info__status>span.text");//внутри("span.status-meeting-item"); //статус внутри meetingsList
        private static CSSDescription meetingOrgName = new CSSDescription("div.main-info__header>span.text");//внутри("span.header-meeting-item"); // наименование орг -//-
        private static CSSDescription meetingDate = new CSSDescription("div.additional-info__data-meeting>span.data");//внутри(".//div[div[contains(text(),'Дата собрания')]]/div/span");//дата собрания -//-
        private static CSSDescription meetingDateFix = new CSSDescription("div.additional-info__data-fixing>span.data");//внутри(".//div[div[contains(text(),'Дата фиксации списка участников')]]/div/span");//Дата фиксации списка участников-//-
        private static CSSDescription meetingEdit = new CSSDescription("div.additional-info__actions>div.action__edit>a");//(".//a[text()='Редактирование']");//ведет на MeetingPage


        /// <summary>
        /// если страница Собрания
        /// </summary>
        /// <returns></returns>
        public static bool isTruePage()
        {
            browser.Sync();
            //Console.WriteLine("textMeeting=" + browser.Describe<IWebElement>(organizationTitle).InnerText);
            return browser.Describe<IWebElement>(organizationTitle).Exists() &&
                browser.Describe<IWebElement>(organizationTitle).InnerText.Equals("собрания");
        }

        /// <summary>
        /// если существует меню договоры
        /// </summary>
        /// <returns></returns>
        public static bool isMenuContractsExist()
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
            if (!isTruePage())
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
            Console.WriteLine("menuUserName " + browser.Describe<ILink>(menuUserName).Exists());
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
            // Console.WriteLine("userNameToggle " + browser.Describe<IWebElement>(userNameToggle).Exists());
            return browser.Describe<IWebElement>(userNameToggle).Exists();
        }

        public static bool isUserName2Exist()
        {
            // Console.WriteLine("menuUserName2 " + browser.Describe<IWebElement>(menuUserName2).Exists());
            return browser.Describe<IWebElement>(menuUserName2).Exists();
        }


        public static bool isBlockUserName()
        {
            return browser.Describe<IWebElement>(userNameBlock).Exists();
        }

        public static void logout()
        {
            if (isToggleUserNameExist() /*&& isUserNameExist()*/)
            {
                clickToggleUserName();

                if (isBlockUserName())
                    browser.Describe<ILink>(userNameLogout).Click();
            }/*
            else if (isUserName2Exist())
            {
                clickUserName2();
                if (isUserNameLogout2Exist())
                    browser.Describe<IButton>(userNameLogout2).Click();
            }*/

        }

        public static void clickUserName2()
        {
            browser.Describe<ILink>(menuUserName2).Click();
        }

        private static bool isUserNameLogout2Exist()
        {
            // Console.WriteLine("userNameLogout2 " + browser.Describe<IButton>(userNameLogout2).Exists());
            return browser.Describe<IButton>(userNameLogout2).Exists();
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
        /// Нажимаем - редактировать в нужном собрании по ОРГ
        /// </summary>
        /// <param name="orgName">Открытое акционерное общество \"Нефтяная компания \"Роснефть\"</param>
        public static void editMeetingOfTable(string orgNameT)
        {
            var liMeetings = browser.FindChildren<IWebElement>(meetingsList);
            if (liMeetings != null && liMeetings.Length > 0)
                for (int i = 0; i < liMeetings.Length; i++)
                {
                    var meetingChldr = liMeetings[i].Describe<IWebElement>(meetingOrgName);
                    Console.WriteLine(i + ":" + meetingChldr.InnerText);
                    if (meetingChldr.Exists() && meetingChldr.InnerText.Equals(orgNameT))
                    {
                        liMeetings[i].FindChildren<ILink>(meetingEdit)[0].Click();
                        break;
                    }

                }
        }

        /// <summary>
        /// есть ли Item <br>V</br> в данной табл в столбце <br>columnNumber</br>
        /// </summary>
        /// <param name="v"></param>
        /// <param name="table"></param>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public static bool isItemExistOfTable(string v, IWebElement table, int columnNumber)
        {
            // var table = browser.Describe<IWebElement>(orgSearchTable);

            var rows = table.FindChildren<IWebElement>(new CSSDescription("tr"));
            if (rows != null && rows.Length > 1)
                for (int i = 0; i < rows.Length; i++)
                {
                    var columns = rows[i].FindChildren<IWebElement>(new CSSDescription("td"));
                    if (columns != null && columns.Length > 1)
                        if (columns[columnNumber].InnerText.Contains(@v))
                        {
                            Console.WriteLine("содержит {0}", v);
                            return true;
                        }
                }
            return false;
        }


    }
}
