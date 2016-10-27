using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingTestProjectMs.Pages
{
    class MeetingPage : Helpers.PageHelper
    {
        private static CSSDescription block = new CSSDescription("div#meeting-block");//главн див
        private static CSSDescription state = new CSSDescription("div.meeting-menu div span.result-header-page");//статус - Доступно заочное голосование на собрании
        private static CSSDescription name = new CSSDescription("div.meeting-menu div span.header-meeting-item");//Годовое собрание акционеров
        private static CSSDescription emitent = new CSSDescription("div.meeting-menu div span.header-meeting-item");//Акционерный коммерческий Сберегательный бан

        private static CSSDescription dateMeet = new CSSDescription("form#controlPanelForm div span.result-label-data");//Дата собрания

        private static XPathDescription editMeeting = new XPathDescription(".//button[span[text()='Редактирование собрания']]");//Редактирование собран, вылезает подкнопка
        private static XPathDescription manageMeeting = new XPathDescription(".//a[span[text()='Управление собранием']]"); // meetingControlPage


        private static XPathDescription previewMeeting = new XPathDescription(".//button[span[text()='Предпросмотр собрания']]");//Предпросмотр собрания

        private static XPathDescription loadInfo = new XPathDescription(".//button[span[text()='Загрузить информацию']]");

        private static XPathDescription unloadInfo = new XPathDescription(".//button[span[text()='Выгрузить сообщение о собрании']]");//появляется след кнопка
        private static XPathDescription unloadInfotoFile = new XPathDescription(".//a[span[text()='В файл']]");

        private static CSSDescription editState = new CSSDescription("button[id='controlPanelForm:changeStatus_button']");//Изменить статус
        private static XPathDescription editStateOpen = new XPathDescription(".//a[span[text()='Открыть эмитенту и регистратору']]");

        //Отменить собрание
        private static XPathDescription cancelMeeting = new XPathDescription(".//button[span[text()='Отменить собрание']]");//появляется диалог
        private static CSSDescription cancelDialog = new CSSDescription("div#cancelDialog");//новый диалог  с полями
        private static CSSDescription cancelDialogTitle = new CSSDescription("span#cancelDialog_title");//"Отменить собрание"
        private static CSSDescription cancelDialogReasson = new CSSDescription("textarea[id='cancelForm:cancelReason']");//причина отмены
        private static CSSDescription cancelDialogCode = new CSSDescription("label[id='cancelForm:cancelReasonCode_label']");//Код причины отмены
        private static CSSDescription cancelDialogCodeToggle = new CSSDescription("div[id='cancelForm:cancelReasonCode'] div span");//
        private static CSSDescription cancelDialogCodeSelect = new CSSDescription("ul[id='cancelForm:cancelReasonCode_items']");//выпад списко
        private static CSSDescription addFileMeeting = new CSSDescription("div.wrap-button-upload>span>span>input");//прикрепить файл
        private static CSSDescription cancelDialogCancelMeeting = new CSSDescription("button[id='cancelForm:cancelMeetingFile']");
        private static XPathDescription cancelDialogCloseForm = new XPathDescription(".//button[span[text()='закрыть']]");


        //MENU
        private static XPathDescription menuFullInfo = new XPathDescription(".///a[text()='Общая информация']");
        private static XPathDescription menuMater = new XPathDescription(".///a[text()='Материалы']");
        private static XPathDescription menuBullet = new XPathDescription(".///a[text()='Бюллетень']");
        private static XPathDescription menuList = new XPathDescription(".///a[text()='Список к собранию']");
        private static XPathDescription menuViewers = new XPathDescription(".///a[text()='Наблюдатели']");
        private static XPathDescription menuSettings = new XPathDescription(".///a[text()='Настройки']");


        //Общая информация
        private static CSSDescription emitentName = new CSSDescription("div#main-form>div>div>div>div.header-meeting-item-inside");//эмитент 2 элемента почему-то
        private static CSSDescription orgName = new CSSDescription("div#main-form >div>div>div.table-row-e-voting > div.table-content-style");//- 4 items
        private static XPathDescription securities = new XPathDescription();
        private static XPathDescription editSecurities = new XPathDescription(".//div[div[div[text()='ценные бумаги']]]/div/div/button[span[text()='редактировать']]");// редактировать ценные бумаги
        private static CSSDescription issuerFullName = new CSSDescription("input[id='tabView:mainForm:issuerFullName']");//Полное фирменное наименование эмитента
        private static CSSDescription meetingId = new CSSDescription("input[id='tabView:mainForm:meetingId']");//Идентификатор собрания
        private static CSSDescription formTypeLabel = new CSSDescription("label[id='tabView:mainForm:formType_label']");//Форма проведения общего собрания
        private static CSSDescription meetingStartInput = new CSSDescription("input[id='tabView:mainForm:meetingStart_input']");//Дата и время проведения собрания
        private static CSSDescription meetingCountryInput = new CSSDescription("input[id='tabView:mainForm:meetingCountry_input']");//Страна проведения собрания
        private static CSSDescription meetingAddress = new CSSDescription("input[id='tabView:mainForm:meetingAddress']");//Адрес проведения собрания
        private static CSSDescription voteMktDdlnInput = new CSSDescription("input[id='tabView:mainForm:voteMktDdln_input']");//Дата окончания приема бюллетеней
        private static CSSDescription participantsRegisterStartInput = new CSSDescription("input[id='tabView:mainForm:participantsRegisterStart_input']");//Время начала регистрации участников
        private static CSSDescription entitlementFixingDate_input = new CSSDescription("input[id='tabView:mainForm:entitlementFixingDate_input']");//Дата определения участников собрания
        private static CSSDescription postCountry_input = new CSSDescription("input[id='tabView:mainForm:postCountry_input']");//Страна
        private static CSSDescription postAddressInput = new CSSDescription("input[id='tabView:mainForm:postAddress']");//Адрес
        private static CSSDescription agenda = new CSSDescription("textarea[id='tabView:mainForm:agenda']");//Повестка собрания
        private static CSSDescription procOfFamiliarWMaterials = new CSSDescription("textarea[id='tabView:mainForm:procOfFamiliarWMaterials']");//Порядок ознакомления с информацией
        private static XPathDescription addAddress = new XPathDescription(".//button[span[text()='Добавить адрес']]");//Dобавить адрес - появл поле
        private static CSSDescription addAddressCountryInput = new CSSDescription("div[id='tabView:mainForm:addresses'] span>input.ui-autocomplete-dd-input");//страна input+list
        private static CSSDescription addAddressCityInput = new CSSDescription("div[id='tabView:mainForm:addresses'] div>input.ui-inputtext");//city
        private static CSSDescription announcementDate_input = new CSSDescription("input[id='tabView:mainForm:announcementDate_input']");//Дата принятия решения о созыве собрания
        private static CSSDescription additionalVotingReq = new CSSDescription("textarea[id='tabView:mainForm:additionalVotingReq']");//Дополнительные требования к голосованию
        private static XPathDescription editComplete = new XPathDescription(".//div[span[text()='Редактирование раздела завершено']]");//checkBox Редактирование завершено - ui-state-active
        private static XPathDescription save = new XPathDescription(".//button[span[text()='Сохранить']]");//
        // end Общая информация

        //МАТЕРИАЛЫ
        private static CSSDescription divMaterial = new CSSDescription("div#material-page");
        private static XPathDescription addFileMat = new XPathDescription(".//button[span[text()='прикрепить']]");
        private static XPathDescription addFileMatLink = new XPathDescription(".//a[span[text()='Ссылку']]");
        private static XPathDescription addFileMatFile = new XPathDescription(".//a[span[text()='Файл']]");
        //МАТЕРИАЛЫ - форма прикрепления файла
        private static CSSDescription addFileMatFileDiv = new CSSDescription("div[id='tabView:materialUpload']");
        private static CSSDescription addFileMatFileDivTitle = new CSSDescription("span[id='tabView:materialUpload_title']");//"прикрепить файл"
        private static CSSDescription addFileMatFileDivButton = new CSSDescription("input[id='tabView:materialUploadForm:materialUploader_input']");//загрузить файл
        private static CSSDescription addFileMatFileDivFileName = new CSSDescription("span[id='tabView:materialUploadForm:fileName']");//после загрузки - имя файла
        private static CSSDescription addFileMatFileDivMaterial = new CSSDescription("div[id='tabView:materialUploadForm:uploadType'] label");//material
        private static CSSDescription addFileMatFileDivMaterialToggle = new CSSDescription("div[id='tabView:materialUploadForm:uploadType'] div>span");
        private static CSSDescription addFileMatFileDivMaterialSelect = new CSSDescription("ul[id='tabView:materialUploadForm:uploadType_items']");//список выбор MaterialSelect
        private static CSSDescription addFileMatFileDivMaterialAdd = new CSSDescription("button[span='Прикрепить']");
        private static CSSDescription addFileMatFileDivMaterialCancel = new CSSDescription("button[span='Отмена']");



    }
}
