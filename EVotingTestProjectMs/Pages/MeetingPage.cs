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
        private static CSSDescription addFile = new CSSDescription("div.wrap-button-upload>span>span>input");//прикрепить файл
        private static CSSDescription cancelDialogCancelMeeting = new CSSDescription("button[id='cancelForm:cancelMeetingFile']");
        private static XPathDescription cancelDialogCloseForm = new XPathDescription(".//button[span[text()='закрыть']]");


        //MENU
        private static XPathDescription menuFullInfo = new XPathDescription(".///a[text()='Общая информация']");
        private static XPathDescription menuMater = new XPathDescription(".///a[text()='Материалы']");
        private static XPathDescription menuBullet = new XPathDescription(".///a[text()='Бюллетень']");
        private static XPathDescription menuList = new XPathDescription(".///a[text()='Список к собранию']");
        private static XPathDescription menuViewers = new XPathDescription(".///a[text()='Наблюдатели']");
        private static XPathDescription menuSettings = new XPathDescription(".///a[text()='Настройки']");


        //
        private static CSSDescription emitentName = new CSSDescription("div.header-meeting-item-inside");//эмитент

        private static CSSDescription orgName = new CSSDescription("div#main-form >div>div>div.table-row-e-voting > div.table-content-style");//- 4 items

        private static XPathDescription securities = new XPathDescription();



        редактировать ценные бумаги
".//div[div[div[text()='ценные бумаги']]]/div/div/button[span[text()='редактировать']]"

Полное фирменное наименование эмитента
<input id = "tabView:mainForm:issuerFullName"

Идентификатор собрания
< input id = "tabView:mainForm:meetingId"


Форма проведения общего собрания
< label id = "tabView:mainForm:formType_label"


Дата и время проведения собрания*
    < input id = "tabView:mainForm:meetingStart_input"

    Страна проведения собрания
    <input id= "tabView:mainForm:meetingCountry_input"

Адрес проведения собрания
<input id="tabView:mainForm:meetingAddress" 

    Дата окончания приема бюллетеней
    <input id="tabView:mainForm:voteMktDdln_input"

Время начала регистрации участников
<input id="tabView:mainForm:participantsRegisterStart_input" 


Дата определения участников собрания
<input id="tabView:mainForm:entitlementFixingDate_input" 

Страна
<input id="tabView:mainForm:postCountry_input"

Адрес
<input id="tabView:mainForm:postAddress" 

Повестка собрания
<textarea id="tabView:mainForm:agenda" 

    Порядок ознакомления с информацией
    <textarea id="tabView:mainForm:procOfFamiliarWMaterials" 




обавить адрес
<button id="tabView:mainForm:j_idt259" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" type="submit" onclick="PrimeFaces.ab({s:"tabView:mainForm:j_idt259",p:"tabView:mainForm:j_idt259 tabView:mainForm:addresses",u:"tabView:mainForm:addresses"});return false;" 
            name="tabView:mainForm:j_idt259" role="button" aria-disabled="false">
<span class="ui-button-text ui-c">Добавить адрес</span>
</button>

Дата принятия решения о созыве собрания
<input id = "tabView:mainForm:announcementDate_input"


Дополнительные требования к голосованию
< textarea id = "tabView:mainForm:additionalVotingReq"


checkBox
<div class="ui-chkbox-box ui-widget ui-corner-all ui-state-default ui-state-active">
<span class="ui-chkbox-icon ui-icon ui-c ui-icon-check"></span>
</div>
<span class="ui-chkbox-label">Редактирование раздела завершено</span>
</div>

            <div class="ui-chkbox-box ui-widget ui-corner-all ui-state-default ui-state-active">Checket
            <div class="ui-chkbox-box ui-widget ui-corner-all ui-state-default"> unchecked

save
<button id="tabView:mainForm:j_idt273" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" type="submit" onclick="PrimeFaces.ab({s:"tabView:mainForm:j_idt273",p:"tabView:mainForm",u:"tabView:mainForm tabView controlPanelForm"});return false;" name="tabView:mainForm:j_idt273" role="button" aria-disabled="false">
<span class="ui-button-text ui-c">Сохранить</span>
</button>

    }
}
