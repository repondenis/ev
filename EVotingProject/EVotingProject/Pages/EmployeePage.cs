using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Pages
{
    class EmployeePage : PortalPage
    {
        //private static CSSDescription divEmployee = new CSSDescription("div#employee-block");
        private static CSSDescription divEmployeeTitle = new CSSDescription(
            "div#employee-block label.main-header-page");
        private static XPathDescription employeeAdd = new XPathDescription(
            ".//button[span[text()='Добавить пользователя']]");

        private static CSSDescription fioSnils = new CSSDescription(
            "div#employee-block>div>div:nth-child(2)>div:nth-child(2) input");
        private static CSSDescription role = new CSSDescription(
            "div#employee-block>div>div:nth-child(2)>div:nth-child(4) input");//("div#employee-block>div>div:nth-child(2) span>input[placeholder='Все роли']");
        private static CSSDescription roleToggle = new CSSDescription(
            "div#employee-block>div>div:nth-child(2)>div:nth-child(4) button");
        private static CSSDescription active = new CSSDescription(
            "div#employee-block>div>div:nth-child(2)>div:nth-child(6) input");//("div#employee-block>div>div:nth-child(2) span>input[placeholder='Не важно']");
        private static CSSDescription activeToggle = new CSSDescription(
            "div#employee-block>div>div:nth-child(2)>div:nth-child(6) button");

        private static CSSDescription employeesDateTabl = new CSSDescription("table.table-condensed");//("tbody[id='personForm:employeeTable_data']");
        private static CSSDescription employeesDateTabl2 = new CSSDescription("thead[id='personForm:employeeTable_head']");//("tbody[id='personForm:employeeTable_data']");


        private static CSSDescription employeesDate = new CSSDescription(
            "tbody[id='personForm:employeeTable_data'] tr");//count empl
        private static CSSDescription employeesDateName = new CSSDescription(
            "tbody[id='personForm:employeeTable_data'] tr:nth-child(1)>td:nth-child(1)");//первый пользователь - имя



        private static CSSDescription employeesDateOrg = new CSSDescription(
            "tbody[id='personForm:employeeTable_data'] tr:nth-child(1)>td:nth-child(2)");//первый пользователь - ОРГ
        private static CSSDescription employeesDateRole = new CSSDescription(
            "tbody[id='personForm:employeeTable_data'] tr:nth-child(1)>td:nth-child(3)");//первый пользователь - роли
        private static CSSDescription employeesDateLock = new CSSDescription(
            "tbody[id='personForm:employeeTable_data'] tr:nth-child(1)>td:nth-child(4)");//первый пользователь - заблокирован
        private static CSSDescription employeesDateEdit = new CSSDescription(
            "tbody[id='personForm:employeeTable_data'] tr:nth-child(1)>td:nth-child(5)>a");//первый пользователь - редактировать

        public static void addNewUser()
        {
            browser.Describe<IButton>(employeeAdd).Click();
        }


        public static bool isEmployeePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(divEmployeeTitle).Exists() && browser.Describe<IWebElement>(divEmployeeTitle).InnerText.Equals("пользователи");
        }

        public static void getEmployeesTable(string str)
        {
            Console.WriteLine("searh of " + str);
            var table = browser.Describe<ITable>(employeesDateTabl);
            Console.WriteLine("FindRowWithCellText = " + browser.Describe<ITable>(employeesDateTabl).Rows[0].Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + browser.Describe<ITable>(employeesDateTabl).FindRowWithCellText(str).Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + browser.Describe<ITable>(employeesDateTabl).FindRowWithCellText(str).Cells.Count);

        }

    }
}
