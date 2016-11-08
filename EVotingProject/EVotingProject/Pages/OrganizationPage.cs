using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Pages
{
    class OrganizationPage : PortalPage
    {
        private static CSSDescription organizationTitle = new CSSDescription("div#organization-block>label");//эмитенты
        private static CSSDescription organizationSearhInput = new CSSDescription("div#organization-block>div>div>input");
        private static CSSDescription organizationDateTabl = new CSSDescription("table[role='grid']");

        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(organizationTitle).Exists() &&
                browser.Describe<IWebElement>(organizationTitle).InnerText.Equals("эмитенты");
        }

        public static void setOrganizationSearhInput(string str)
        {
            var searhInput = browser.Describe<IEditField>(organizationSearhInput);
            searhInput.SetValue(str);
            searhInput.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));
        }

        public static void getOrganizationTable(string str)
        {
            Console.WriteLine("searh of " + str);
            var table = browser.Describe<ITable>(organizationDateTabl);

            Console.WriteLine("FindRowWithCellText = " + table.Rows[0].Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells.Count);

        }

        public static void editOrganizationOfTable(string orgName)
        {
            Console.WriteLine("searh of " + orgName);
            var table = browser.Describe<ITable>(organizationDateTabl);

            Console.WriteLine("FindRowWithCellText = " + table.Rows[0].Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(orgName).Cells[0].Text);
            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(orgName).Cells.Count);

            table.FindRowWithCellText(orgName).Cells[0].FindChildren<ILink>().Click();
        }
    }
}
