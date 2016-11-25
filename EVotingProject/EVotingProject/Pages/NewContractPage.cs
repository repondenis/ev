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
        private static CSSDescription organizationPanelList = new CSSDescription("div[id='materialForm:organization_panel'] li");
        private static CSSDescription contractNumber = new CSSDescription("form#materialForm>div:nth-child(5)>div:nth-child(2)>input");
        private static CSSDescription contractDate = new CSSDescription("form#materialForm span>input.hasDatepicker");
        private static CSSDescription contractDateSelected = new CSSDescription("a.ui-state-highlight");

        private static CSSDescription accessOfRegistrator = new CSSDescription("form#materialForm>div:nth-child(6) *[type='checkbox']");//Доступен регистратору
        private static CSSDescription serviceTableCb = new CSSDescription("div#cntr-services-edit>table");//чек-боксы с сервисами
        private static CSSDescription serviceCb = new CSSDescription("div#cntr-services-edit>table>tbody input[type='checkbox']");//чек-боксы с сервисами

        private static XPathDescription saveB = new XPathDescription(".//button[span[text()='Сохранить']]");
        private static XPathDescription cancelB = new XPathDescription(".//button[span[text()='Отменить']]");
        private static XPathDescription closeB = new XPathDescription(".//button[span[text()='закрыть']]");

        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(pageTitle).Exists() &&
                (browser.Describe<IWebElement>(pageTitle).InnerText.Equals("новый договор") | browser.Describe<IWebElement>(pageTitle).InnerText.Contains("договор №"));//
        }

        public static bool isOrganizationPanelAppear()
        {
            return browser.Describe<IWebElement>(organizationPanel).Exists();
        }

        public static void selectItemOfOrganization(int position, string name)
        {

            var orgSelect = browser.Describe<IWebElement>(organizationPanel).Describe<IWebElement>(new CSSDescription("li"));


            var select = browser.FindChildren<IWebElement>(organizationPanelList);
            if (select.Length > 0 && position <= select.Length)
                if (select[position].Exists() && select[position].IsVisible)
                {
                    Console.WriteLine(select[position].InnerText);
                    select[position].Click();
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
            var date = browser.Describe<IEditField>(contractDate);
            date.SetValue(v);

        }

        public static void selectService(int num, bool state)
        {
            var table = browser.Describe<ITable>(serviceTableCb);
            //Console.WriteLine("Text = " + table.Rows[num].Cells[1].Text);
            table.Rows[num].Cells[0].FindChildren<ICheckBox>(0).Set(state);
            //Console.WriteLine("IsChecked = " + table.Rows[num].Cells[0].FindChildren<ICheckBox>().IsChecked);
        }

        /// <summary>
        /// группа чек-боксов - выставляем статус 
        /// по порядк номеру
        /// </summary>
        /// <param name="num">порядк номер</param>
        /// <param name="state">статус true/false</param>
        public static void selectService2(int num, bool state)
        {
            var services = browser.FindChildren<ICheckBox>(serviceCb);
            if (services.Length > 0 && num <= services.Length)
            {
                services[num].Set(state);
                // Console.WriteLine("IsChecked = " + services[1].IsChecked);//
            }
        }

        /// <summary>
        /// чек-бокс - доступен регистратору
        /// </summary>
        /// <param name="state"></param>
        public static void selectAceessOfregistrator(bool state)
        {
            browser.Describe<ICheckBox>(accessOfRegistrator).Set(state);
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
