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
        private static CSSDescription pageTitle = new CSSDescription("label.main-header-page");//28112016("div#contract-block>div>div>label.main-header-page")
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
            return browser.Describe<IWebElement>(pageTitle).Exists() && 
                browser.Describe<IWebElement>(pageTitle).InnerText.Equals("Договоры");
        }

        public static void clickTitle()
        {
            browser.Describe<IWebElement>(pageTitle).Click();
        }

        public static void clickNewContract()
        {
            browser.Describe<IButton>(newContractBt).Click();
        }



        /// <summary>
        /// есть ли договор в таблице?
        /// MeetingStatusFilter
        /// </summary>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public static bool isContractsOfTableExist(string contractName, string meetingStatus)
        {
            //var table = browser.Describe<ITable>(contractDateTabl);
            var table = browser.Describe<IWebElement>(contractDateTabl);

            var rows = table.FindChildren<IWebElement>(new CSSDescription("tr"));
            if (rows != null && rows.Length > 0)
                for (int i = 0; i < rows.Length; i++)
                {
                    var columns = rows[i].FindChildren<IWebElement>(new CSSDescription("td"));
                    if (columns != null && columns.Length > 0)
                        if (columns[0].InnerText.Contains(contractName) && columns[3].InnerText.Contains(meetingStatus))
                            // if (columns[0].InnerText.Contains(contractName) && columns[3].InnerText.Contains("Не создано"))
                            return true;
                }
            return false;
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
