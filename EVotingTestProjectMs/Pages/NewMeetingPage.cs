using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

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

        divMethodCreateMeeting = ".//div[@id='create-meeting-page']/div[div[label[text()='Способ создания собрания']]]";





        способ созд собрания список
<ul id= "form:j_idt46_items" class="ui-selectonemenu-items ui-selectonemenu-list ui-widget-content ui-widget ui-corner-all ui-helper-reset" role="listbox" aria-activedescendant="form:j_idt46_0">
<li id = "form:j_idt46_0" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all ui-noselection-option ui-state-highlight" data-label="Выберите" tabindex="-1" role="option">Выберите</li>
<li id = "form:j_idt46_1" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all" data-label="Вручную" tabindex="-1" role="option">Вручную</li>
<li id = "form:j_idt46_2" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all" data-label="Из файла" tabindex="-1" role="option">Из файла</li>
<li id = "form:j_idt46_3" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all" data-label="Из загруженных" tabindex="-1" role="option">Из загруженных</li>
</ul>


  Загрузить файл
<a id = "form:j_idt52" class="ui-commandlink ui-widget upload-file-link" href="#" onclick="PF('uploadFileHidden').chooseButton.find('input[type=file]').click();PrimeFaces.ab({s:"form:j_idt52",p:"form:j_idt52"});return false;">Загрузить файл</a>


  Из уже загруженных:
Форма появляется, текст:
<div id = "meetingNotificationMessagesDialog" class="ui-dialog ui-widget ui-widget-content ui-corner-all ui-shadow ui-hidden-container ui-draggable" style="min-width: 1000px; border-radius: 0px; width: auto; height: auto; left: 132px; top: 49px; z-index: 1041; display: block;" role="dialog" aria-labelledby="meetingNotificationMessagesDialog_title" aria-hidden="false" aria-live="polite">
<div class="ui-dialog-titlebar ui-widget-header ui-helper-clearfix ui-corner-top ui-draggable-handle">
<span id = "meetingNotificationMessagesDialog_title" class="ui-dialog-title">Список загруженных собраний</span>

  закрыть
  <a class="ui-dialog-titlebar-icon ui-dialog-titlebar-close ui-corner-all" href="#" aria-label="Close" role="button">
<span class="ui-icon ui-icon-closethick"></span>
</a>

поле фильтра
<div class="ui-datatable-header ui-widget-header ui-corner-top">
<input id = "meetingNotificationMessagesForm:meetingNotificationTable:globalFilter" class="ui-inputfield ui-inputtext ui-widget ui-state-default ui-corner-all input-style-e-voting" name="meetingNotificationMessagesForm:meetingNotificationTable:globalFilter" onkeyup="PrimeFaces.ab({s:"meetingNotificationMessagesForm:meetingNotificationTable:globalFilter",e:"keyup",p:"meetingNotificationMessagesForm:meetingNotificationTable:globalFilter",u:"meetingNotificationMessagesForm:meetingNotificationTable",d:1000});" role="textbox" aria-disabled="false" aria-readonly="false" type="text">
</div>

создать собрание, отмена
<button id = "meetingNotificationMessagesForm:applyButtton" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" name="meetingNotificationMessagesForm:applyButtton" onclick="PrimeFaces.ab({s:"meetingNotificationMessagesForm:applyButtton"});return false;" type="submit" role="button" aria-disabled="false">
<span class="ui-button-text ui-c">Создать собрание</span>
</button>
<button id = "meetingNotificationMessagesForm:j_idt191" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" name="meetingNotificationMessagesForm:j_idt191" onclick="PrimeFaces.ab({s:"meetingNotificationMessagesForm:j_idt191"});return false;" type="submit" role="button" aria-disabled="false">
<span class="ui-button-text ui-c">Отмена</span>
</button>


тип ценных бумаг неактивн
<div id= "form:securityType" class="ui-selectonemenu ui-widget ui-state-default ui-corner-all input-style-e-voting result-item-dropdown-list ui-state-disabled" style="box-sizing: border-box;">
<label id = "form:securityType_label" class="ui-selectonemenu-label ui-inputfield ui-corner-all">Выберите</label>
-//- активн
<div id = "form:securityType" class="ui-selectonemenu ui-widget ui-state-default ui-corner-all input-style-e-voting result-item-dropdown-list" style="box-sizing: border-box;">
<label id = "form:securityType_label" class="ui-selectonemenu-label ui-inputfield ui-corner-all">Выберите</label
  

  Форма проведения общего собрания
  <label id="form:formType_label" class="ui-selectonemenu-label ui-inputfield ui-corner-all">Выберите</label>

-//- стрелка
<div class="ui-selectonemenu-trigger ui-state-default ui-corner-right">
<span class="ui-icon ui-icon-triangle-1-s ui-c"></span>
</div>

-//- сприсок
<ul id = "form:formType_items" class="ui-selectonemenu-items ui-selectonemenu-list ui-widget-content ui-widget ui-corner-all ui-helper-reset" role="listbox" aria-activedescendant="form:formType_0">
<li id = "form:formType_0" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all ui-noselection-option ui-state-highlight" data-label="Выберите" tabindex="-1" role="option">Выберите</li>
<li id = "form:formType_1" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all" data-label="Собрание (предусмотрена возможность направления заполненных бюллетеней)" tabindex="-1" role="option">Собрание(предусмотрена возможность направления заполненных бюллетеней)</li>
<li id = "form:formType_2" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all" data-label="Собрание (не предусмотрена возможность направления заполненных бюллетеней)" tabindex="-1" role="option">Собрание(не предусмотрена возможность направления заполненных бюллетеней)</li>
<li id = "form:formType_3" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all" data-label="Заочное голосование" tabindex="-1" role="option">Заочное голосование</li>
</ul>


  Дата и время проведения собрания
  <input id="form:meetingStart_input" class="ui-inputfield ui-widget ui-state-default ui-corner-all hasDatepicker" name="form:meetingStart_input" aria-required="true" aria-labelledby="form:j_idt74" role="textbox" aria-disabled="false" aria-readonly="false" type="text">

время
<label id="form:j_idt77_label" class="ui-selectonemenu-label ui-inputfield ui-corner-all">Выберите</label>

-//- стрелочка
<div class="ui-selectonemenu-trigger ui-state-default ui-corner-right">
<span class="ui-icon ui-icon-triangle-1-s ui-c"></span>
</div>

-//- данные
<ul id = "form:j_idt77_items" class="ui-selectonemenu-items ui-selectonemenu-list ui-widget-content ui-widget ui-corner-all ui-helper-reset" role="listbox" aria-activedescendant="form:j_idt77_0">
<li id = "form:j_idt77_0" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all ui-noselection-option ui-state-highlight" data-label="Выберите" tabindex="-1" role="option">Выберите</li>
<li id = "form:j_idt77_1" class="ui-selectonemenu-item ui-selectonemenu-list-item ui-corner-all" data-label="Москва, GMT+03:00" tabindex="-1" role="option">Москва, GMT+03:00</li>
</ul>

Организация - недоступен
<input id="form:issuerOrganization_input" class="ui-autocomplete-input ui-autocomplete-dd-input ui-inputfield ui-widget ui-state-default ui-corner-left ui-state-disabled" name="form:issuerOrganization_input" autocomplete="off" aria-labelledby="form:j_idt81" placeholder="Эмитент" value="" disabled="disabled" aria-required="true" role="textbox" aria-disabled="true" aria-readonly="false" aria-autocomplete="listbox" type="text">

инн- недоступен
огрн- недоступен
Выпуски ЦБ участников- недоступен
Договор на проведение собрания-- недоступен

кнопки
<button id= "form:j_idt134" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" name="form:j_idt134" onclick="PrimeFaces.ab({s:"form:j_idt134",p:"form",u:"form"});return false;" type="submit" role="button" aria-disabled="false">
<span class="ui-button-text ui-c">продолжить</span>
</button>
<button id = "form:j_idt136" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" name="form:j_idt136" onclick="PrimeFaces.ab({s:"form:j_idt136"});return false;" type="submit" role="button" aria-disabled="false">
<span class="ui-button-text ui-c">Отменить</span>
</button>




        public static bool isNewMeetingPage()
        {
            return browser.Describe<IWebElement>(headertext).Exists() && browser.Describe<IWebElement>(headertext).GetVisibleText().Equals("создание собрания");
        }




    }
}
