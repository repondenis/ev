using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
//using HP.LFT.SDK.StdWin;
using EVotingProject.Models;
using EVotingProject.Helpers;
using HP.LFT.SDK;


namespace EVotingProject.Pages
{
    /// <summary>
    /// страница нового собрания
    /// </summary>
    class NewMeetingPage : PortalPage
    {
        private static CSSDescription headertext = new CSSDescription("label.main-header-page");

        //
        private static XPathDescription methodCreateMeeting = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/label");////способ созд собрания
        private static XPathDescription methodCreateMeetingToggle = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/div/span");//способ созд собрания - кнопочка вниз -список
        private static CSSDescription methodCreateMeetingList_hz = new CSSDescription("div.ui-selectonemenu-items-wrapper ul");
        private static XPathDescription methodCreateMeetingSelect = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/div/select");//способ созд собрания список


        //string divMethodCreateMeeting = ".//div[@id='create-meeting-page']/div[div[label[text()='Способ создания собрания']]]";

        //загрузить из файла
        private static CSSDescription uploadFile = new CSSDescription("a.upload-file-link"); // Загрузить файл
        //private static WindowDescription uploadFileWin = new WindowDescription { WindowTitleRegExp = "Выгрузка файла" };

        //ранее загруженные собрания
        private static CSSDescription formMeetingsLoated = new CSSDescription("div#meetingNotificationMessagesDialog");//Форма появляетс
        private static CSSDescription formMeetingsLoatedTitle = new CSSDescription("span#meetingNotificationMessagesDialog_title");//текст
        private static CSSDescription formMeetingsLoatedClose = new CSSDescription("a.ui-dialog-titlebar-close");
        private static CSSDescription formMeetingsLoatedFilter = new CSSDescription("input#meetingNotificationMessagesForm:meetingNotificationTable:globalFilter");//поле фильтра
        private static CSSDescription formMeetingsLoatedCreate = new CSSDescription("button#meetingNotificationMessagesForm:applyButtton");//создать собрание
        private static XPathDescription formMeetingsLoatedCancel = new XPathDescription(".//button[span[text()='Отмена']]");



        //поля создания собрания
        // private static CSSDescription securityType_ = new CSSDescription("div[id='form:securityType'] label");
        //private static CSSDescription securityTypeLabel = new CSSDescription("label[id='form:securityType_label']");
        //private static CSSDescription securityTypeToggle = new CSSDescription("div[id='form:securityType'] div span");
        //private static CSSDescription securityTypeList = new CSSDescription("ul[id='form:securityType_items']");//Tип ценных бумаг
        private static CSSDescription securityTypeSelect = new CSSDescription("select[id='form:securityType_input']");//Tип ценных бумаг


        //private static CSSDescription meetingTypeLabel = new CSSDescription("label[id='form:meetingType_label']");
        // private static CSSDescription meetingTypeToggle = new CSSDescription("div[id='form:meetingType'] div span");
        // private static CSSDescription meetingTypeList = new CSSDescription("ul[id='form:meetingType_items']");//Вид общего собрания
        private static CSSDescription meetingTypeSelect = new CSSDescription("form:meetingType_input");//Вид общего собрания


        // private static CSSDescription formTypeLabel = new CSSDescription("label[id='form:formType_label']");//Форма проведения общего собрания
        // private static CSSDescription formTypeToggle = new CSSDescription("div[id='form:formType'] div span");
        //  private static CSSDescription formTypeList = new CSSDescription("ul[id='form:formType_items']");
        private static CSSDescription formTypeSelect = new CSSDescription("select[id='form:formType_input']");


        private static CSSDescription meetingStartInput = new CSSDescription("input[id=form:meetingStart_input]");//Дата и время проведения собрания

        private static XPathDescription meetingStartLable = new XPathDescription(".//div[div[label[text()='Дата и время проведения собрания']]]/div/div/label");//время проведения собрания
        private static XPathDescription meetingStartToggle = new XPathDescription(".//div[div[label[text()='Дата и время проведения собрания']]]/div/div/div/span");

        //Организация
        private static CSSDescription issuerOrganizationInput = new CSSDescription("input[id='form:issuerOrganization']");
        private static CSSDescription issuerOrganizationInn = new CSSDescription("label[id='form:issuerInn']");
        private static CSSDescription issuerOrganizationOgrn = new CSSDescription("label[id='form:issuerOgrn']");



        //ВЫПУСК Ценных бумаг
        private static CSSDescription addSecurityButton = new CSSDescription("button[id='form:addSecurityButton']");//добавить выпуск
        private static CSSDescription securitiesDialog = new CSSDescription("div#securitiesDialog");//окно диплога
        private static CSSDescription securitiesDialogTitle = new CSSDescription("div#securitiesDialog div span#securitiesDialog_title");//"Выбор выпусков ЦБ" окно диплога title
        private static CSSDescription securitiesDialogclose = new CSSDescription("div#securitiesDialog div a[aria-label='Close']");//окно диплога
        private static CSSDescription securitiesDialogInput = new CSSDescription("input[id='securityForm:securityTable:globalFilter']");
        private static CSSDescription securityTableTrTd = new CSSDescription("tbody[id='securityForm:securityTable_data'] tr");//выбрать нужн ев или тд <td role="gridcell">RU2222222222</td> td role="gridcell">24-1-429</td><td role="gridcell">Акция 2</td>
        private static CSSDescription securityFormApplyButton = new CSSDescription("button[id='securityForm:applyButton']");

        //Договор на проведение собрания - сервисы договора
        private static CSSDescription contractsInput = new CSSDescription("input[id='form:contracts_input']");// Договор на проведение собрания
        private static CSSDescription contractsInputh = new CSSDescription("input[id='form:contracts_hinput']");
        private static CSSDescription contractInputToggle = new CSSDescription("div.contracts-auto span[id='form:contracts'] button");//  span.ui-button-icon-primary
        private static CSSDescription contractInputSelect = new CSSDescription("div[id='form:contracts_panel']");
        private static CSSDescription contractInputList = new CSSDescription("div[id='form:contracts_panel'] ul li");

        private static XPathDescription submitb = new XPathDescription(".//button[span[text()='Продолжить']]");
        private static XPathDescription cancelb = new XPathDescription(".//button[span[text()='Отменить']]");

        public static new bool isTruePage()
        {
            return browser.Describe<IWebElement>(headertext).Exists()
                && browser.Describe<IWebElement>(headertext).InnerText.Equals("создание собрания");
        }

        /// <summary>
        /// Способ создания собрания
        /// </summary>
        /// <param name="method">MeetingMethodCreate</param>
        public static void selectMethodCreateMeeting(string method)
        {
            var select = browser.Describe<HP.LFT.SDK.Web.IListBox>(methodCreateMeetingSelect);
            select.Select(method);
        }

        /// <summary>
        /// тип ценных бумаг
        /// </summary>
        /// <param name="method"></param>
        public static void selectSecurityType(string method)
        {
            var select = browser.Describe<HP.LFT.SDK.Web.IListBox>(securityTypeSelect);
            select.Select(method);
        }

        /// <summary>
        /// Форма проведения общего собрания
        /// </summary>
        /// <param name="method"></param>
        public static void selectFormType(string method)
        {
            var select = browser.Describe<HP.LFT.SDK.Web.IListBox>(formTypeSelect);
            select.Select(method);
        }

        public static void selectmeetingType(string method)
        {
            var select = browser.Describe<HP.LFT.SDK.Web.IListBox>(meetingTypeSelect);
            select.Select(method);
        }

#region
        /*
        /// <summary>
        /// загрузить файл
        /// </summary>
        /// <param name="filePathHeader"></param>
        public static void loadFromFileOld(string filePathHeader)
        {
            if (System.IO.File.Exists(filePathHeader))
            {
                ReadXmlHelper.loadXml(filePathHeader);

                //Console.WriteLine(ReadXmlHelper.getBodyXml());

                var cssDivParent = "div.ui-fileupload";
                var cssSpanParent = "div.ui-fileupload>div>span";
                var cssSpanParentRemoteClass = "ui-fileupload-choose";
                var cssInputFile = "input[type=file]";

                browser.Page.RunJavaScript(
                "document.querySelector('" + cssDivParent + "').style.overflow='visible'; " +
                "document.querySelector('" + cssDivParent + "').style.display='inline-block'; " +
                "document.querySelector('" + cssDivParent + "').style.position='relative'; "
                );

                browser.Page.RunJavaScript("document.querySelector('" + cssSpanParent + "').classList.remove('" + cssSpanParentRemoteClass + "')"); //"ui-fileupload-choose"

                browser.Page.RunJavaScript(
                "document.querySelector('" + cssInputFile + "').style.overflow='visible'; " +
                "document.querySelector('" + cssInputFile + "').style.display='inline-block'; " +
                "document.querySelector('" + cssInputFile + "').style.opacity=1; " +
                "document.querySelector('" + cssInputFile + "').style.top=0; " +
                "document.querySelector('" + cssInputFile + "').style.left=0; " +
                "document.querySelector('" + cssInputFile + "').style.width=100; " +
                "document.querySelector('" + cssInputFile + "').style.height=20; " +
                "document.querySelector('" + cssInputFile + "').style.filter=''; " +
                "document.querySelector('" + cssInputFile + "').style.position='relative'; "
                );

                var input_file = browser.Describe<IFileField>(new CSSDescription(cssInputFile));
                input_file.SetValue(filePathHeader);

            }
        }
        */
#endregion

        /// <summary>
        /// загрузить файл
        /// </summary>
        /// <param name="filePath"></param>
        public static void loadFromFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                ReadXmlHelper.loadXml(filePath);

                var upload = browser.Describe<ILink>(uploadFile);

                click2Object(upload);

                WindowsHelper.setFilePath2WinDialog(browser.Version.Type, filePath);

            }
        }

        public static void setMeetingStartInput(string v)
        {
            browser.Describe<HP.LFT.SDK.Web.IEditField>(meetingStartInput).SetValue(v);
        }


        public static void cancel()
        {
            browser.Describe<HP.LFT.SDK.Web.IButton>(cancelb).Click();
        }
        public static void submit()
        {
            browser.Describe<HP.LFT.SDK.Web.IButton>(submitb).Click();
            //browser.Sync();
        }

        public static string getSelectedMethodCreateMeeting()
        {
            return browser.Describe<HP.LFT.SDK.Web.IListBox>(methodCreateMeetingSelect).SelectedItems[0].ToString();
        }

        public static string getSelectedSecurityType()
        {
            return browser.Describe<HP.LFT.SDK.Web.IListBox>(securityTypeSelect).SelectedItems[0].ToString();
        }

        public static string getSelectedFormType()
        {
            return browser.Describe<HP.LFT.SDK.Web.IListBox>(formTypeSelect).SelectedItems[0].ToString();
        }

        public static string getMeetingStartInput()
        {
            return browser.Describe<HP.LFT.SDK.Web.IListBox>(meetingStartInput).SelectedItems[0].ToString();
        }

        public static string getSelectedMeetingType()
        {
            return browser.Describe<HP.LFT.SDK.Web.IListBox>(meetingTypeSelect).SelectedItems[0].ToString();
        }

        public static void setIssuerOrganization(string v)
        {
            browser.Describe<HP.LFT.SDK.Web.IEditField>(issuerOrganizationInput).SetValue(v);
        }

        public static string getIssuerOrganization()
        {
            return browser.Describe<HP.LFT.SDK.Web.IEditField>(issuerOrganizationInput).Value;
        }
        public static bool getIssuerOrganization(string orgName)
        {
            var issuerOrganization = browser.Describe<HP.LFT.SDK.Web.IEditField>(issuerOrganizationInput);
            return issuerOrganization.Value.Equals(orgName); //WaitUntil(logo => logo.Exists() && logo.IsVisible);

        }
        public static string getIssuerOrganizationInn()
        {
            return browser.Describe<HP.LFT.SDK.Web.IEditField>(issuerOrganizationInn).Value.ToString();
        }
        public static string getIssuerOrganizationOgrn()
        {
            return browser.Describe<HP.LFT.SDK.Web.IEditField>(issuerOrganizationOgrn).Value;
        }

        /// <summary>
        /// Договор на проведение собрания - 
        /// кнопка выпад список
        /// </summary>
        public static void clickContractInputToggle()
        {
            browser.Describe<IWebElement>(contractInputToggle).Click();
        }

        public static void setContract(string v)
        {
            //Console.WriteLine("!!! " + contractsInputh.ToString());
            //browser.Page.RunJavaScript("document.querySelector('" + contractsInputh.ToString() + "').setAttribute('type', 'text')");
            // browser.Page.RunJavaScript("document.querySelector('" + contractsInputh.ToString() + "').removeAttribute('type')");
            var contractInput = browser.Describe<HP.LFT.SDK.Web.IEditField>(contractsInputh);
            contractInput.SetValue(v);
            contractInput.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));
        }

        public static bool isContractPanelAppear()
        {
            var contractList = browser.Describe<IWebElement>(contractInputSelect);
            contractList.WaitUntil(list => list.Exists() && list.IsVisible);
            return contractList.Exists();
        }

        /// <summary>
        /// Договор на проведение собрания - 
        /// сам список
        /// </summary>
        /// <param name="position"></param>
        public static void selectItemOfContract(string v)
        {
            browser.Describe<IListBox>(contractInputList).Select(v);
            

        }





    }
}

//   Console.WriteLine("aria-labelledby=" + browser.Page.RunJavaScript("document.querySelector('" + cssel + "').getAttribute('aria-labelledby'); "));
//   Console.WriteLine(browser.Page.RunJavaScript("document.querySelector('" + cssel + "').removeAttribute('aria-labelledby'); "));
//   Console.WriteLine("aria-labelledby=" + browser.Page.RunJavaScript("document.querySelector('" + cssel + "').getAttribute('aria-labelledby'); "));
