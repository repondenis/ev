using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using EVotingProject.Helpers;
using EVotingProject.Models;

namespace EVotingProject.Pages
{
    class NewEmployeePage : PortalPage//PageHelper
    {
        private static XPathDescription divEmployeeAddInfoTitle = new XPathDescription(".//form[@id='form']/div/div/label");//"Добавление пользователя"

        private static CSSDescription menuInfo = new CSSDescription("div[id='form:tabView']>ul>li:nth-child(1)>a");//ДАННЫЕ
        private static CSSDescription menuRole = new CSSDescription("div[id='form:tabView']>ul>li:nth-child(2)>a");//ROLE

        //ДАННЫЕ
        private static CSSDescription organizationInput = new CSSDescription("input[id='form:tabView:organization_input']");
        private static CSSDescription lastName = new CSSDescription("input[id='form:tabView:lastName']");
        private static CSSDescription firstName = new CSSDescription("input[id='form:tabView:firstName']");
        private static CSSDescription phone = new CSSDescription("input[id='form:tabView:phone']");

        private static CSSDescription organizationPanel = new CSSDescription("div[id='form:tabView:organization_panel']>ul");


        private static CSSDescription otherName = new CSSDescription("div#employee-data-custom>div:nth-child(4) input");
        private static CSSDescription login = new CSSDescription("div#employee-data-custom>div:nth-child(6) input");
        private static CSSDescription snils = new CSSDescription("div#employee-data-custom>div:nth-child(7) input");
        private static CSSDescription mail = new CSSDescription("div#employee-data-custom>div:nth-child(8) input");
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
        private static XPathDescription cancelB = new XPathDescription(".//button[span[text()='Отменить']]");

        private static XPathDescription unblockB = new XPathDescription(".//button[span[text()='Разблокировать']]");
        private static XPathDescription blockB = new XPathDescription(".//button[span[text()='Заблокировать']]");





        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(divEmployeeAddInfoTitle).Exists() &&
                (browser.Describe<IWebElement>(divEmployeeAddInfoTitle).InnerText.Equals("Добавление пользователя") | browser.Describe<IWebElement>(divEmployeeAddInfoTitle).InnerText.Contains("Редактирование пользователя"));
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
        public static bool isOrganizationPanelAppear()
        {
            return browser.Describe<IWebElement>(organizationPanel).Exists();
        }

        public static void selectItemOfOrganizationPanel(string v)
        {
            try
            {
                var orgSelect = browser.Describe<IWebElement>(organizationPanel).Describe<IListBox>(new CSSDescription("li"));
                orgSelect.Select(v);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace + "\r\n" + e.Message);
            }
        }

        public static void setOrganization(string v)
        {
            var orgInput = browser.Describe<IEditField>(organizationInput);
            orgInput.SetValue(v);
            orgInput.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));
        }

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
            browser.Describe<IButton>(saveB).Click();
        }

        public static void cancel()
        {
            browser.Describe<IButton>(cancelB).Click();
        }

        public static bool isUnblockExist()
        {
            return browser.Describe<IButton>(unblockB).Exists();
        }

        public static void unblock()
        {
            isUnblockExist();
            browser.Describe<IButton>(unblockB).Click();
        }

        /**
         * есть ли кнопка блокировки польз?
         */
        public static bool isBlockExist()
        {
            return browser.Describe<IButton>(blockB).Exists();
        }

        public static void block()
        {
            isBlockExist();
            browser.Describe<IButton>(blockB).Click();
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
            return browser.Describe<IWebElement>(organizationInput).Exists();
        }

        public static bool isRolePanel()
        {
            return browser.Describe<IWebElement>(availRolesLabel).Exists();
        }

        public static void clickAvailRolesToggle()
        {
            browser.Describe<IWebElement>(availRolesToggle).Click();
        }


        public static void selectAvailRolesList(string str)
        {
            Console.WriteLine(browser.Describe<IWebElement>(availRolesSelect).InnerText);
        }

        /**
         * поиск подсказок по полям
         */
        public static bool? getFieldsError(string message)
        {
            throw new NotImplementedException();
        }


        public static bool isAvailRoleList(string str)
        {
            return browser.Describe<IWebElement>(availRoleList).Exists() && browser.Describe<IWebElement>(availRoleList).InnerText.Contains(str);
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
