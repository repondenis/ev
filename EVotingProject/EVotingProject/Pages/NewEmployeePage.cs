using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using EVotingProject.Helpers;
using EVotingProject.Models;
using System.Threading;

namespace EVotingProject.Pages
{
    class NewEmployeePage : PortalPage//PageHelper
    {
        private static CSSDescription divEmployeeAddInfoTitle = new CSSDescription("div#employee-setting label.main-header-page");//28112016(".//form[@id='form']/div/div/label");//"Добавление пользователя"

        private static CSSDescription menuInfo = new CSSDescription("div[id='form:tabView']>ul>li:nth-child(1)>a");//ДАННЫЕ
        private static CSSDescription menuRole = new CSSDescription("div[id='form:tabView']>ul>li:nth-child(2)>a");//ROLE

        //ДАННЫЕ
        private static CSSDescription organizationInput_ = new CSSDescription("input[id='form:tabView:organization_input']");
        private static CSSDescription lastName = new CSSDescription("input[id='form:tabView:lastName']");
        private static CSSDescription firstName = new CSSDescription("input[id='form:tabView:firstName']");
        private static CSSDescription phone = new CSSDescription("input[id='form:tabView:phone']");
        //ПОИСК ОРГ
        private static XPathDescription orgSearchButtonEdit = new XPathDescription(".//button[span[text()='Изменить']]");
        private static CSSDescription orgSearchInput = new CSSDescription("input[id='form:tabView:orgSearchInput']");
        private static XPathDescription orgSearchButton = new XPathDescription(".//button[span[text()='найти']]");
        private static CSSDescription orgSearchTable = new CSSDescription("table[role='grid']");



        private static CSSDescription organizationPanel = new CSSDescription("div[id='form:tabView:organization_panel']>ul");


        private static CSSDescription otherName = new CSSDescription("input[id='form:tabView:middleName']");
        private static CSSDescription login = new CSSDescription("div#employee-data-custom>div.ui-g>div:nth-child(2)>div:nth-child(1) input");//28112016//("div#employee-data-custom>div:nth-child(6) input");
        private static CSSDescription loginLocal = new CSSDescription("div#employee-data-custom>div.ui-g>div:nth-child(2)>div:nth-child(2) input");
        private static CSSDescription snils = new CSSDescription("div#employee-data-custom>div.ui-g>div:nth-child(2)>div:nth-child(2) input");
        private static CSSDescription mail = new CSSDescription("input[id='form:tabView:email']");
        //ЕНД ДАННЫЕ


        //РОЛИ
        private static CSSDescription availRolesLabel = new CSSDescription("label[id='form:tabView:availRoles_label']");
        private static CSSDescription availRolesToggle = new CSSDescription("div[id='form:tabView:availRoles']>div>span.ui-icon-triangle-1-s");
        private static CSSDescription availRolesSelect = new CSSDescription("ul[id='form:tabView:availRoles_items']");//LIST

        private static CSSDescription availRoleList = new CSSDescription(
            "span[id='form:tabView:roleList']>div>div:nth-child(1)>div:nth-child(1)");//роли, которые активируются при выборе нужн роли в списке - текст из Models.availRoles



        // ".//span[@id='form:tabView:roleList']/div/div/div[1]"
        private static CSSDescription availRoleListToogle = new CSSDescription(
            "span[id='form:tabView:roleList']>div>div:nth-child(1)>label");//кнопка 'полномочия' выбора чек-боксов ролей
        private static CSSDescription availRoleIssuer = new CSSDescription(
            "div[data-widget='actions_ISSUER']");//роли Администратор эмитента 
        private static CSSDescription availRoleRegistrators = new CSSDescription(
             "div[data-widget='actions_REGISTRATOR']");//роли администратора регистратора
        private static CSSDescription availRoleComission = new CSSDescription(
            "div[data-widget='actions_COMMISSION']");//роли Участник счетной комиссии 

        private static CSSDescription availRoleTableRegistrators = new CSSDescription(
        "div[data-widget='actions_REGISTRATOR']>div>table");
        private static CSSDescription availRoleTableIssuer = new CSSDescription(
           "div[data-widget='actions_ISSUER']>div>table");//роли Администратор эмитента 
        private static CSSDescription availRoleTableComission = new CSSDescription(
            "div[data-widget='actions_COMMISSION']>div>table");//роли Участник счетной комиссии 
        //END РОЛИ


        private static XPathDescription saveB = new XPathDescription(".//button[span[text()='Сохранить']]");
        private static XPathDescription addB = new XPathDescription(".//button[span[text()='Добавить']]");
        private static XPathDescription cancelB = new XPathDescription(".//button[span[text()='Отменить']]");


        private static XPathDescription unblockB = new XPathDescription(".//a[text()='Разблокировать']");//(".//button[span[text()='Разблокировать']]");
        private static XPathDescription blockB = new XPathDescription(".//a[text()='Заблокировать']");//(".//button[span[text()='Заблокировать']]");





        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(divEmployeeAddInfoTitle).Exists() &&
                (browser.Describe<IWebElement>(divEmployeeAddInfoTitle).InnerText.Equals("Добавление пользователя") |
                browser.Describe<IWebElement>(divEmployeeAddInfoTitle).InnerText.Contains("Редактирование пользователя"));
        }


        internal static string getFirstName()
        {
            return browser.Describe<IEditField>(firstName).Value;
        }

        internal static string getLastName()
        {
            return browser.Describe<IEditField>(lastName).Value;
        }

        internal static string getOtherName()
        {
            return browser.Describe<IEditField>(otherName).Value;
        }

        internal static string getLogin()
        {
            return browser.Describe<IEditField>(login).Value;
        }

        internal static string getLoginLocal()
        {
            return browser.Describe<IEditField>(loginLocal).Value;
        }

        public static bool isOrganizationPanelAppear()
        {
            return browser.Describe<IWebElement>(organizationPanel).Exists();
        }

        public static void selectItemOfOrganizationPanel(string v)
        {

            browser.Describe<IWebElement>(organizationPanel).Describe<IListBox>(new CSSDescription("li")).Select(v);

        }

        public static bool isOrgSearchInputExist()
        {
            return browser.Describe<IEditField>(orgSearchInput).Exists();
        }

        /// <summary>
        /// выбрать организацию
        /// </summary>
        /// <param name="v"></param>
        public static void setOrganization(string v)
        {
            var editButton = browser.Describe<IButton>(orgSearchButtonEdit);
            editButton.Click();

            if (isOrgSearchInputExist())
            {
                var orgInput = browser.Describe<IEditField>(orgSearchInput);
                orgInput.SetValue(v);
                orgInput.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));

                var searchButton = browser.Describe<IButton>(orgSearchButton);
                if (searchButton.Exists() && searchButton.IsVisible)
                {

                    //Console.WriteLine("В ТАБЛ = " + getItemOfTable(browser.Describe<IWebElement>(orgSearchTable), 0, 0));

                    searchButton.Click();
                    Thread.Sleep(1000);

                   // Console.WriteLine("В ТАБЛ = " + getItemOfTable(browser.Describe<IWebElement>(orgSearchTable), 0, 0));

                    //Console.WriteLine("нажали searchButton");
                    var table = browser.Describe<IWebElement>(orgSearchTable);
                    clickLinkOfTable(v, table, 0, 4, new CSSDescription("a"));
                   
                    // selectOrgOfTable(v, table);
                }
            }
        }

        /*// <summary>
        /// выбрать организацию в таблице из списка
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static void selectOrgOfTable(string v, IWebElement table)
        {
            
            //Console.WriteLine("поиск орг -" + v);
            //var table = browser.Describe<IWebElement>(orgSearchTable);

            var rows = table.FindChildren<IWebElement>(new CSSDescription("tr"));
            if (rows != null && rows.Length > 1)
                for (int i = 0; i < rows.Length; i++)
                {
                    var columns = rows[i].FindChildren<IWebElement>(new CSSDescription("td"));
                    if (columns != null && columns.Length > 1)
                    {
                        // Console.WriteLine(columns[0].InnerText + " " + columns[4].InnerText);

                        if (columns[0].InnerText.Contains(@v))
                        {
                            //Console.WriteLine("содержит");
                            var select = columns[4].FindChildren<ILink>(new CSSDescription("a"));
                            if (select.Length > 0)
                                select[0].Click();
                        }
                    }
                }
        }
        */



        /*
        /// <summary>
        /// нажать "Выбрать" в списке организаций
        /// </summary>
        /// <param name="orgName"></param>
        public static void selectOrgOfTable_old(string v)
        {
            //Console.WriteLine("поиск орг -" + v);
            var table = browser.Describe<ITable>(orgSearchTable);
            var row = table.FindRowWithCellText(v);
            if (row != null)
            {
                row.Cells[4].FindChildren<ILink>().Click();
                Console.WriteLine("нажали -Выбрать");
            }
            //else Console.WriteLine("HE нажали -Выбрать");


        }
        */

        public static void setFirstName(string v)
        {
            browser.Describe<IEditField>(firstName).SetValue(v);
        }

        public static void setOtherName(string v)
        {
            browser.Describe<IEditField>(otherName).SetValue(v);
        }

        public static void setLastName(string v)
        {
            browser.Describe<IEditField>(lastName).SetValue(v);
        }

        public static void setLogin(string v)
        {
            browser.Describe<IEditField>(login).SetValue(v);
        }

        public static void setLoginLocal(string v)
        {
            browser.Describe<IEditField>(loginLocal).SetValue(v);
        }

        public static void setSnils(string v)
        {
            browser.Describe<IEditField>(snils).SetValue(v);
        }

        public static void setMail(string v)
        {
            browser.Describe<IEditField>(mail).SetValue(v);
        }

        public static void setPhone(string v)
        {
            browser.Describe<IEditField>(phone).SetValue(v);
        }

        public static void save()
        {
            if (isTrueTitle("Редактирование пользователя"))
                browser.Describe<IButton>(saveB).Click();
            else
                 if (isTrueTitle("Добавление пользователя"))
                browser.Describe<IButton>(addB).Click();

        }

        public static void cancel()
        {
            browser.Describe<IButton>(cancelB).Click();
        }

        /// <summary>
        /// "Добавление пользователя"
        /// "Редактирование пользователя"
        /// </summary>
        /// <param name="v"></param>
        public static bool isTrueTitle(string v)
        {
            return browser.Describe<IWebElement>(divEmployeeAddInfoTitle).Exists() &&
                    browser.Describe<IWebElement>(divEmployeeAddInfoTitle).InnerText.Equals(v);
        }

        public static bool isUnblockExist()
        {
            return browser.Describe<ILink>(unblockB).Exists();
        }

        public static void unblock()
        {
            isUnblockExist();
            browser.Describe<ILink>(unblockB).Click();
        }

        /// <summary>
        /// есть ли кнопка блокировки польз?
        /// </summary>
        /// <returns></returns>
        public static bool isBlockExist()
        {
            return browser.Describe<ILink>(blockB).Exists();
        }

        public static void block()
        {
            isBlockExist();
            browser.Describe<ILink>(blockB).Click();
        }

        public static void gotoInfoPanel()
        {
            browser.Describe<ILink>(menuInfo).Click();
        }

        public static void gotoRolePanel()
        {
            browser.Describe<ILink>(menuRole).Click();
        }

        public static bool isInfoPanel()
        {
            return browser.Describe<IWebElement>(lastName).Exists() && browser.Describe<IWebElement>(lastName).IsVisible;
        }

        public static bool isRolePanel()
        {
            return browser.Describe<IWebElement>(availRolesLabel).Exists();
        }

        public static void clickSelectRole()
        {
            browser.Describe<IWebElement>(availRolesLabel).Click();
        }

        public static void clickAvailRolesToggle()
        {
            browser.Describe<IWebElement>(availRolesToggle).Click();
        }


        public static void selectAvailRolesList(string v)
        {
            // Console.WriteLine(browser.Describe<IWebElement>(availRolesSelect).InnerText);
            browser.Describe<IListBox>(availRolesSelect).Select(v);
        }

        /**
         * поиск подсказок по полям
         */
        public static bool getFieldsError(string message)
        {
            return getMessagesGrowleOk().Contains(message);
        }


        public static bool isAvailRoleList(string str)
        {
            return browser.Describe<IWebElement>(availRoleList).Exists() &&
                browser.Describe<IWebElement>(availRoleList).InnerText.Contains(str);
        }

        /**
         * нажимаем на ПОЛНОМОЧИЯ
         */
        public static void clickAvailRoleListToogle()
        {
            browser.Describe<IWebElement>(availRoleListToogle).Click();
        }

        /**
         * появилась ли форма чек-боксов нужной роли? 
         */
        public static bool isRoleCheckBoxExist(string adminOfRegistrators)
        {
            CSSDescription descr = null; ;

            // availRoles.adminOfRegistrators;
            switch (adminOfRegistrators)
            {

                case availRoles.adminOfRegistrators:
                    descr = availRoleRegistrators;
                    break;
                case availRoles.adminOfIssuer:
                    descr = availRoleIssuer;
                    break;
                case availRoles.memberOfCounter:
                    descr = availRoleComission;
                    break;
            }

            return browser.Describe<IWebElement>(descr).Exists();
        }

        public static void selectRolePermission(string adminOfRegistrators, int indexRole, bool state)
        {
            CSSDescription descr = null;
            switch (adminOfRegistrators)
            {

                case availRoles.adminOfRegistrators:
                    descr = availRoleTableRegistrators;
                    break;
                case availRoles.adminOfIssuer:
                    descr = availRoleTableIssuer;
                    break;
                case availRoles.memberOfCounter:
                    descr = availRoleTableComission;
                    break;
            }

            var roles = browser.FindChildren<ICheckBox>(descr);
            if (roles.Length >= indexRole)
            {
                roles[0].Set(state);
            }
        }
    }
}
