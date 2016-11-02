using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using EVotingProject.Helpers;

namespace EVotingProject.Pages
{
    class NewEmployeePage : PortalPage//PageHelper
    {
        private static XPathDescription divEmployeeAddInfoTitle = new XPathDescription(".//form[@id='form']/div/div/label");//"Добавление пользователя"

        private static CSSDescription menuInfo = new CSSDescription("div[id='form:tabView']>ul>li:nth-child(1)>a");//ДАННЫЕ
        private static CSSDescription menuRole = new CSSDescription("div[id='form:tabView']>ul>li:nth-child(2)>a");//ROLE

        //ДАННЫЕ
        private static CSSDescription organization = new CSSDescription("input[id='form:tabView:organization_input']");
        private static CSSDescription lastName = new CSSDescription("input[id='form:tabView:lastName']");
        private static CSSDescription firstName = new CSSDescription("input[id='form:tabView:firstName']");
        private static CSSDescription phone = new CSSDescription("input[id='form:tabView:phone']");

        private static CSSDescription otherName = new CSSDescription("div#employee-data-custom>div:nth-child(4) input");
        private static CSSDescription login = new CSSDescription("div#employee-data-custom>div:nth-child(6) input");
        private static CSSDescription snils = new CSSDescription("div#employee-data-custom>div:nth-child(7) input");
        private static CSSDescription mail = new CSSDescription("div#employee-data-custom>div:nth-child(8) input");
        //ЕНД ДАННЫЕ


        //РОЛИ
        private static CSSDescription availRoles = new CSSDescription("label[id='form:tabView:availRoles_label']");
        private static CSSDescription availRolesToggle = new CSSDescription("div[id='form:tabView:availRoles']>div>span.ui-icon-triangle-1-s");
        private static CSSDescription availRolesList = new CSSDescription("ul[id='form:tabView:availRoles_items']");//LIST



        //END РОЛИ


        private static XPathDescription saveB = new XPathDescription(".//button[span[text()='Сохранить']]");
        private static XPathDescription cancelB = new XPathDescription(".//button[span[text()='Отменить']]");

        private static XPathDescription unblockB = new XPathDescription(".//button[span[text()='Разблокировать']]");
        private static XPathDescription blockB = new XPathDescription(".//button[span[text()='Заблокировать']]");





        public static bool isNewEmployeePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(divEmployeeAddInfoTitle).Exists() && browser.Describe<IWebElement>(divEmployeeAddInfoTitle).InnerText.Equals("Добавление пользователя");
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

        public static void gotoInfo()
        {
            browser.Describe<ILink>(menuInfo).Click();
        }

        public static void gotoRole()
        {
            browser.Describe<ILink>(menuRole).Click();
        }

        public static bool isInfoPanel()
        {
            return browser.Describe<IWebElement>(organization).Exists();
        }

        public static bool isRolePanel()
        {
            return browser.Describe<IWebElement>(availRoles).Exists();
        }

        public static void clickAvailRolesToggle()
        {
            browser.Describe<IWebElement>(availRolesToggle).Click();
        }

        public static void selectAvailRolesList()
        {
            Console.WriteLine(browser.Describe<IWebElement>(availRolesList).InnerText);
        }
    }
}
