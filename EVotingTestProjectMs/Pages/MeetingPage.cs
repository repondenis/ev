using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVotingTestProjectMs.Pages
{
    class MeetingPage
    {

       главн див
            <div id= "meeting-block" >

           статус
< div class="meeting-menu">
<div>
<span class="result-header-page">Доступно заочное голосование на собрании</span>


<div class="meeting-menu">
<div>
<span class="header-meeting-item">Годовое собрание акционеров</span>
</div>



<div class="meeting-menu">
<div>
<span class="header-meeting-item">Акционерный коммерческий Сберегательный банк Российской Федерации(открытое акционерное общество)</span>
</div>


<form id = "controlPanelForm" enctype="application/x-www-form-urlencoded" action="/portal/meeting/edit.xhtml" method="post" name="controlPanelForm">
<input type = "hidden" value="controlPanelForm" name="controlPanelForm">
<div class="meeting-menu">
<div>
<span class="result-label-data-text">Дата собрания: </span>
<span class="result-label-data">11.10.2016 18:45</span>
</div>

редактировать собрание
            <div class="ui-toolbar-group-left">
<div class="wrap-btn-e-voting">
<span id = "controlPanelForm:j_idt52" class="ui-menubutton">
<button id = "controlPanelForm:j_idt52_button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icon-left" type="button" name="controlPanelForm:j_idt52_button" role="button" aria-disabled="false">
<span class="ui-button-icon-left ui-icon ui-c ui-icon-triangle-1-s"></span>
<span class="ui-button-text ui-c">Редактирование собрания</span>
</button>
</span>


предспросмотр собрания
<div class="ui-toolbar-group-left">
<div class="wrap-btn-e-voting">
<div class="wrap-btn-additional-e-voting">
<button id = "controlPanelForm:j_idt60" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" type="submit" onclick="PrimeFaces.bcn(this,event,[function(event){window.open('/public/#/meeting-item/b2f83a55-2f76-420f-acb2-24d64a306057', '_blank')},function(event){PrimeFaces.ab({s:"controlPanelForm:j_idt60"});return false;}]);" 
            name="controlPanelForm:j_idt60" role="button" aria-disabled="false">
<span class="ui-button-text ui-c">Предпросмотр собрания</span>
</button>


Загрузить информацию
<button id = "controlPanelForm:j_idt65_button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icon-left ui-state-disabled" disabled="disabled" type="button" name="controlPanelForm:j_idt65_button">
<span class="ui-button-icon-left ui-icon ui-c ui-icon-triangle-1-s"></span>
<span class="ui-button-text ui-c">Загрузить информацию</span>
</button>


Выгрузить сообщение о собрании
<button id = "controlPanelForm:j_idt68_button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icon-left" type="button" name="controlPanelForm:j_idt68_button" role="button" aria-disabled="false">
<span class="ui-button-icon-left ui-icon ui-c ui-icon-triangle-1-s"></span>
<span class="ui-button-text ui-c">Выгрузить сообщение о собрании</span>
</button>




Изменить стату
<span id = "controlPanelForm:changeStatus" class="ui-menubutton menu-ui-icon-document">
<button id = "controlPanelForm:changeStatus_button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icon-left" type="button" name="controlPanelForm:changeStatus_button" role="button" aria-disabled="false">
<span class="ui-button-icon-left ui-icon ui-c ui-icon-triangle-1-s"></span>
<span class="ui-button-text ui-c">Изменить статус</span>
</button>



Отменить собрани
<button id = "controlPanelForm:j_idt74" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icon-left" type="submit" onclick="PrimeFaces.ab({s:"controlPanelForm:j_idt74",p:"@none",u:"@none",onco:function(xhr,status,args){PF('cancelDialog').show();;}});return false;" name="controlPanelForm:j_idt74" role="button" aria-disabled="false">
<span class="ui-button-icon-left ui-icon ui-c ui-icon-circle-close"></span>
<span class="ui-button-text ui-c">Отменить собрание</span>
</button>


меню
<div id="tabView" class="ui-tabs ui-widget ui-widget-content ui-corner-all ui-hidden-container ui-tabs-top" data-widget="widget_tabView">
<ul class="ui-tabs-nav ui-helper-reset ui-widget-header ui-corner-all" role="tablist">
<li class="ui-state-default ui-corner-top ui-tabs-selected ui-state-active" aria-selected="true" aria-expanded="true" role="tab" tabindex="0">
<a tabindex = "-1" href="#tabView:main">Общая информация</a>
</li>

разделы меню
Общая информация
Материалы Бюллетень Список к собранию Наблюдатели Настройки



РАЗДЕЛЫ:
ОБЩАЯ ИНФ:
<div id = "tabView"

имя
<div class="header-meeting-item-inside">эмитент: Акционерный коммерческий Сберегательный банк Российской Федерации(открытое акционерное общество)</div>



наименование орг
"div#main-form >div>div>div.table-row-e-voting > div.table-content-style"; - 4 items

редактировать ценные бумаги
".//div[div[div[text()='ценные бумаги']]]/div/div/button[span[text()='редактировать']]"

Полное фирменное наименование эмитента
<input id = "tabView:mainForm:issuerFullName"

Идентификатор собрания
< input id= "tabView:mainForm:meetingId"


Форма проведения общего собрания
< label id= "tabView:mainForm:formType_label"


Дата и время проведения собрания*
    < input id= "tabView:mainForm:meetingStart_input"

    Страна проведения собрания
    < input id= "tabView:mainForm:meetingCountry_input"

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
< textarea id= "tabView:mainForm:additionalVotingReq"


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
