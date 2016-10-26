using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using HP.LFT.SDK.StdWin;

namespace EVotingTestProjectMs.Pages
{
    class NewMeetingPage : Helpers.PageHelper
    {
        private static CSSDescription headertext = new CSSDescription("label.main-header-page");

        //
        private static XPathDescription methodCreateMeeting = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/label");////способ созд собрания
        private static XPathDescription methodCreateMeetingToggle = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/div/span");//способ созд собрания - кнопочка вниз -список
        private static CSSDescription methodCreateMeetingList_hz = new CSSDescription("div.ui-selectonemenu-items-wrapper ul");
        private static XPathDescription methodCreateMeetingList = new XPathDescription(".//div[div[label[text()='Способ создания собрания']]]/div/div/div/div/select");//способ созд собрания список


        string divMethodCreateMeeting = ".//div[@id='create-meeting-page']/div[div[label[text()='Способ создания собрания']]]";

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

        private static CSSDescription addSecurityButton = new CSSDescription("button[id='form:addSecurityButton']");//добавить выпуск

        private static CSSDescription contractsInput = new CSSDescription("input[id='form:contracts_input']");// Договор на проведение собрания

        //Выпуски ЦБ участников- недоступен
        //Договор на проведение собрания-- недоступен

        private static XPathDescription submit = new XPathDescription(".//button[span[text()='продолжить']]");
        private static XPathDescription cancel = new XPathDescription(".//button[span[text()='Отменить']]");

        public static bool isNewMeetingPage()
        {
            return browser.Describe<IWebElement>(headertext).Exists() && browser.Describe<IWebElement>(headertext).GetVisibleText().Equals("создание собрания");
        }




    }
}
