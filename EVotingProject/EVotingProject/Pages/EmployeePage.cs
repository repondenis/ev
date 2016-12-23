using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Pages
{
    /// <summary>
    /// пользователи
    /// </summary>
    class EmployeePage : PortalPage
    {
        //private static CSSDescription divEmployee = new CSSDescription("div#employee-block");
        private static CSSDescription divEmployeeTitle = new CSSDescription(
            "div#employee-block label.main-header-page");
        private static XPathDescription employeeAdd = new XPathDescription(
            ".//button[span[text()='Добавить пользователя']]");

        private static XPathDescription adminAdd = new XPathDescription(
    ".//button[span[text()='Добавить администратора e-voting']]");

        private static CSSDescription fioSnilsFilter = new CSSDescription(
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
        //private static CSSDescription employeesDateTabl2 = new CSSDescription("thead[id='personForm:employeeTable_head']");//("tbody[id='personForm:employeeTable_data']");


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

        /// <summary>
        /// добавить нового пользователя
        /// </summary>
        public static void addNewUser()
        {
            browser.Describe<IButton>(employeeAdd).Click();
        }

        public static void addNewAdminEVoting()
        {
            browser.Describe<IButton>(adminAdd).Click();
        }

        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(divEmployeeTitle).Exists() &&
                browser.Describe<IWebElement>(divEmployeeTitle).InnerText.Equals("пользователи");
        }

        public static void getEmployeesTable(string str)
        {


            Console.WriteLine("searh of " + str);


            setFioSnilsFilter(str);


            var table = browser.Describe<ITable>(employeesDateTabl);
            isItemExistOfTable(str, table, 0);

            //  Console.WriteLine("FindRowWithCellText = " + table.Rows[0].Cells[0].Text);
            //  Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells[0].Text);
            //  Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells.Count);

            //table.FindRowWithCellText(str).Cells[0].FindChildren<ILink>().Click();

        }

        /// <summary>
        /// нажимаем на РЕДАКТИРОВАНИЕ на нужном контакте
        /// </summary>
        /// <param name="str"></param>
        public static void editEmployeesOfTable(string str)
        {
            var table = browser.Describe<ITable>(employeesDateTabl);
            var row = table.FindRowWithCellText(str);
            if (row != null)
                row.Cells[0].FindChildren<ILink>().Click();
        }

        public static void setFioSnilsFilter(string v)
        {
            var filter = browser.Describe<IEditField>(fioSnilsFilter);
            filter.SetValue(v);
            filter.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));

        }

    }
}
