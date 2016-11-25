using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Pages
{
    class ContractPage : PortalPage
    {
        private static CSSDescription pageTitle = new CSSDescription("div#contract-block>div>div>label.main-header-page");
        private static XPathDescription newContractBt = new XPathDescription(".//button[span[text()='добавить новый']]");
        private static CSSDescription contractDateTabl = new CSSDescription("table[role='grid']");
        private static CSSDescription contractFilter = new CSSDescription("input[id='contractForm:contractTable:globalFilter']");

        //статус
        private static CSSDescription contractStatusFilterLabel = new CSSDescription("div.ui-selectonemenu>label");//статус собрания - текст, нажимается-выпадает
        private static CSSDescription contractStatusFilterToggle = new CSSDescription("div.ui-selectonemenu>div.ui-selectonemenu-trigger>span");
        private static CSSDescription contractStatusFilterItems = new CSSDescription("div.ui-selectonemenu-items-wrapper>ul");//input выпад выбор - MeetingStatusFilter



        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(pageTitle).Exists() && browser.Describe<IWebElement>(pageTitle).InnerText.Equals("Договоры");
        }

        public static void clickTitle()
        {
            browser.Describe<IWebElement>(pageTitle).Click();
        }

        public static void clickNewContract()
        {
            browser.Describe<IButton>(newContractBt).Click();
        }

        /*
        public static void getContractsTable(string str)
        {
            Console.WriteLine("searh of " + str);
            var table = browser.Describe<ITable>(contractDateTabl);
            Console.WriteLine("FindRowWithCellText = " + table.Rows[0].Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells.Count);

        }
        */

        /// <summary>
        /// есть ли договор в таблице?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isContractsOfTableExist(string str)
        {
            var table = browser.Describe<ITable>(contractDateTabl);
            var row = table.FindRowWithCellText(str);

            return (row != null && row.Cells[3].Text.Contains("Не создано"));


            /* throw new NotImplementedException();
            if (row != null)
            {
                //return row.Cells[0].FindChildren<ILink>().Exists();
                return true;
            }
            else return false;
                */
        }

        public static void clickContractsOfTable(string str)
        {
            // Console.WriteLine("searh of " + str);
            var table = browser.Describe<ITable>(contractDateTabl);
            var row = table.FindRowWithCellText(str);
            if (row != null)
                row.Cells[0].FindChildren<ILink>().Click();
            // Console.WriteLine("FindRowWithCellText = " + table.Rows[0].Cells[0].Text);
        }

        /// <summary>
        /// не работает поле фильтра 07-11-2016 
        /// </summary>
        /// <param name="v"></param>
        public static void setFilter(string v)
        {
            browser.Describe<IEditField>(contractFilter).SetValue(v);
        }


        public static void clickStatusFilterLabel()
        {
            browser.Describe<ILink>(contractStatusFilterLabel).Click();
        }

        public static void clickstatusFilterToggle()
        {
            browser.Describe<ILink>(contractStatusFilterToggle).Click();
        }

        public static void selectStatusFilterItems(string meetingStatusFilter)
        {
            browser.Describe<IListBox>(contractStatusFilterItems).Select(meetingStatusFilter);
        }

    }
}
