using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingTestProjectMs.Pages
{
    class EmployeeAddPage : Helpers.PageHelper
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


        private static XPathDescription save = new XPathDescription(".//button[span[text()='Сохранить']]");
        private static XPathDescription cancel = new XPathDescription(".//button[span[text()='Отменить']]");




        public static bool isEmployeeAddPage()
        {
            return browser.Describe<IWebElement>(divEmployeeAddInfoTitle).Exists() && browser.Describe<IWebElement>(divEmployeeAddInfoTitle).GetVisibleText().Equals("Добавление пользователя");
        }
    }
}
