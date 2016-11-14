using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using HP.LFT.SDK.StdWin;
using EVotingProject.Models;

namespace EVotingProject.Pages
{
    class NewMeetingPage : Helpers.PageHelper
    {
        private static CSSDescription headertext = new CSSDescription("label.main-header-page");

        //
        private static XPathDescription methodCreateMeeting = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/label");////способ созд собрания
        private static XPathDescription methodCreateMeetingToggle = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/div/span");//способ созд собрания - кнопочка вниз -список
        private static CSSDescription methodCreateMeetingList_hz = new CSSDescription("div.ui-selectonemenu-items-wrapper ul");
        private static XPathDescription methodCreateMeetingList = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/div/select");//способ созд собрания список


        //string divMethodCreateMeeting = ".//div[@id='create-meeting-page']/div[div[label[text()='Способ создания собрания']]]";

        //загрузить из файла
        private static CSSDescription uploadFile = new CSSDescription("a.upload-file-link"); // Загрузить файл
        private static WindowDescription uploadFileWin = new WindowDescription { WindowTitleRegExp = "Выгрузка файла" };

        //ранее загруженные собрания
        private static CSSDescription formMeetingsLoated = new CSSDescription("div#meetingNotificationMessagesDialog");//Форма появляетс
        private static CSSDescription formMeetingsLoatedTitle = new CSSDescription("span#meetingNotificationMessagesDialog_title");//текст
        private static CSSDescription formMeetingsLoatedClose = new CSSDescription("a.ui-dialog-titlebar-close");
        private static CSSDescription formMeetingsLoatedFilter = new CSSDescription("input#meetingNotificationMessagesForm:meetingNotificationTable:globalFilter");//поле фильтра
        private static CSSDescription formMeetingsLoatedCreate = new CSSDescription("button#meetingNotificationMessagesForm:applyButtton");//создать собрание
        private static XPathDescription formMeetingsLoatedCancel = new XPathDescription(".//button[span[text()='Отмена']]");



        //поля создания собрания
        // private static CSSDescription securityType_ = new CSSDescription("div[id='form:securityType'] label");
        private static CSSDescription securityTypeLabel = new CSSDescription("label[id='form:securityType_label']");
        private static CSSDescription securityTypeToggle = new CSSDescription("div[id='form:securityType'] div span");
        private static CSSDescription securityTypeSelect = new CSSDescription("ul[id='form:securityType_items']");//Tип ценных бумаг

        private static CSSDescription meetingTypeLabel = new CSSDescription("label[id='form:meetingType_label']");
        private static CSSDescription meetingTypeToggle = new CSSDescription("div[id='form:meetingType'] div span");
        private static CSSDescription meetingTypeSelect = new CSSDescription("ul[id='form:meetingType_items']");//Вид общего собрания

        private static CSSDescription formTypeLabel = new CSSDescription("label[id='form:formType_label']");//Форма проведения общего собрания
        private static CSSDescription formTypeToggle = new CSSDescription("div[id='form:formType'] div span");
        private static CSSDescription formTypeSelect = new CSSDescription("ul[id='form:formType_items']");

        private static CSSDescription meetingStartInput = new CSSDescription("input[id=form:meetingStart_input]");//Дата и время проведения собрания

        private static XPathDescription meetingStartLable = new XPathDescription(".//div[div[label[text()='Дата и время проведения собрания']]]/div/div/label");//время проведения собрания
        private static XPathDescription meetingStartToggle = new XPathDescription(".//div[div[label[text()='Дата и время проведения собрания']]]/div/div/div/span");

        private static CSSDescription issuerOrganizationInput = new CSSDescription("input[id='form:issuerOrganization_input']");

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
        private static CSSDescription contractInputToggle = new CSSDescription("div.contracts-auto span[id='form:contracts'] button span.ui-button-icon-primary");
        private static CSSDescription contractInputSelect = new CSSDescription("div[id='form:contracts_panel'] ul");


        private static XPathDescription submit = new XPathDescription(".//button[span[text()='продолжить']]");
        private static XPathDescription cancel = new XPathDescription(".//button[span[text()='Отменить']]");

        public static bool isTruePage()
        {
            return browser.Describe<IWebElement>(headertext).Exists()
                && browser.Describe<IWebElement>(headertext).InnerText.Equals("создание собрания");
        }

        public static void selectMethodCreateMeetingList(string method)
        {

            /*  // MeetingMethodCreate
              switch (method)
              {
                  case MeetingMethodCreate.FILE:

                      break;
              }
             */

            var select = browser.Describe<HP.LFT.SDK.Web.IListBox>(methodCreateMeetingList);
            select.Select(method);

            //            browser.Describe<IWebElement>(new CSSDescription("div.ui-fileupload-buttonbar")).Click();
            //            browser.Describe<IWebElement>(new CSSDescription("div.ui-fileupload-buttonbar>span")).Click();
            //            browser.Describe<ILink>(new XPathDescription(".//a[text()='Загрузить файл']")).Click();
            browser.Describe<IFileField>(new CSSDescription("input[type=file]")).SetValue("D:\\temp\\MN НРД (Роснефть) 1.xml");
        }
        public static void loadFromFile(string filePathHeader)
        {
            //throw new NotImplementedException();
        }


    }
}
