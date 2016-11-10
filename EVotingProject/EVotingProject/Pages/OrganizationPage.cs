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
                browser.Describe<IWebElement>(organizationTitle).InnerText.Equals("организации");
        }

        public static void setOrganizationSearhInput(string str)
        {
            var searhInput = browser.Describe<IEditField>(organizationSearhInput);
            searhInput.SetValue(str);
            searhInput.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));

        }

        public static void getOrganizationTable(string str)
        {

            var table = browser.Describe<ITable>(organizationDateTabl);
            Console.WriteLine("table.Exists=" + table.Exists() + " " + table.Rows.Count + " " + table.Rows[0].Cells.Count);
            Console.WriteLine("FindRowWithCellText = " + table.Rows[1].Cells[1].Text);

            // Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).ToString());
            //            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells[1].Text.ToString());

            //            Console.WriteLine("FindRowWithCellText = " + table.FindRowWithCellText(str).Cells[0].Text);
            var itable = table.FindRowWithCellText(@str);
            if (itable != null)
            {
                Console.WriteLine(itable);
                Console.WriteLine("FindRowWithCellText = " + itable.Cells.Count);
            }
        }

        public static void editOrganizationOfTable(string orgName)
        {
            var table = browser.Describe<ITable>(organizationDateTabl);
            if (table != null && table.Rows.Count > 0)
            {
                //Console.WriteLine(table.);
                for (int i = 0; i < table.Rows.Count; i++)
                    if (table.Rows[i].Cells[0].Text.Equals(orgName))
                        table.Rows[i].Cells[0].FindChildren<ILink>().Click();
            }

            //table.FindRowWithCellText(orgName).Cells[0].FindChildren<ILink>().Click();
            //table.FindRowWithCellTextInColumn(orgName, 0).Cells[0].FindChildren<ILink>().Click();
        }
    }
}
