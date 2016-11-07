using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Pages
{
    class NewContractPage : PortalPage
    {
        private static CSSDescription pageTitle = new CSSDescription("form#materialForm label.main-header-page");
        private static CSSDescription organizationInput = new CSSDescription("input[id='materialForm:organization_input']");
        private static CSSDescription organizationPanel = new CSSDescription("div[id='materialForm:organization_panel']>ul");
        private static CSSDescription contractNumber = new CSSDescription("form#materialForm>div:nth-child(5)>div:nth-child(2)>input");
        private static CSSDescription contractDate = new CSSDescription("form#materialForm>div:nth-child(5)>div:nth-child(4)>span>input");

        private static CSSDescription serviceTableCb = new CSSDescription("div#cntr-services-edit>table");//чек-боксы с сервисами
        private static CSSDescription serviceCb = new CSSDescription("div#cntr-services-edit>table>tbody input[type='checkbox']");//чек-боксы с сервисами

        private static XPathDescription saveB = new XPathDescription(".//button[span[text()='Сохранить']]");
        private static XPathDescription cancelB = new XPathDescription(".//button[span[text()='Отменить']]");
        private static XPathDescription closeB = new XPathDescription(".//button[span[text()='закрыть']]");

        public static bool isTruePage()
        {
            return browser.Describe<IWebElement>(pageTitle).Exists() &&
                (browser.Describe<IWebElement>(pageTitle).InnerText.Equals("новый договор") | browser.Describe<IWebElement>(pageTitle).InnerText.Contains("договор №"));//
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

        public static string getContractNumber()
        {
            return browser.Describe<IEditField>(contractNumber).Value;
        }

        public static void setContractNumber(string v)
        {
            browser.Describe<IEditField>(contractNumber).SetValue(v);
        }

        public static void setContractDate(string v)
        {
            browser.Describe<IEditField>(contractDate).SetValue(v);
        }

        public static void selectService(int num, bool state)
        {
            //serviceTableCb
            Console.WriteLine("searh of " + num);
            var table = browser.Describe<ITable>(serviceTableCb);
            Console.WriteLine("Text = " + table.Rows[num].Cells[1].Text);
            Console.WriteLine("IsChecked = " + table.Rows[num].Cells[0].FindChildren<ICheckBox>().IsChecked);
            table.Rows[num].Cells[0].FindChildren<ICheckBox>(0).Set(state);
            Console.WriteLine("IsChecked = " + table.Rows[num].Cells[0].FindChildren<ICheckBox>().IsChecked);// FindRowWithCellText(str).Cells[0].Text);

        }

        public static void selectService2(int num, bool state)
        {
            //serviceTableCb
            Console.WriteLine("searh of " + num);
            var services = browser.FindChildren<ICheckBox>(serviceCb);
            if (services.Length > 0)
            {
                Console.WriteLine("IsChecked = " + services[1].IsChecked);//
                services[1].Set(state);
                Console.WriteLine("IsChecked = " + services[1].IsChecked);//
            }
        }

        public static void save()
        {
            browser.Describe<IButton>(saveB).Click();
        }

        public static void cancel()
        {
            browser.Describe<IButton>(cancelB).Click();
        }

        public static void close()
        {
            browser.Describe<IButton>(closeB).Click();
        }
    }
}
