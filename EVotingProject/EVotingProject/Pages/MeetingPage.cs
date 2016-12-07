using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using EVotingProject.Models;

namespace EVotingProject.Pages
{
    /// <summary>
    /// Страница собрания
    /// </summary>
    class MeetingPage : PortalPage
    {

        //private static CSSDescription organizationTitle = new CSSDescription("div#wrap-meeting-list>div>div>label");//эмитенты
        //private static CSSDescription organizationSearhInput = new CSSDescription("div#wrap-meeting-list>div>div>input");
        // private static CSSDescription organizationDateTabl = new CSSDescription("table[role='grid']");



        private static CSSDescription block = new CSSDescription("div#meeting-block");//главн див
        private static CSSDescription state = new CSSDescription("div.meeting-menu div span.result-header-page");//статус - Доступно заочное голосование на собрании
        private static XPathDescription nameMeet = new XPathDescription(".//div[@class='meeting-menu']/div[1]/div[2]/span");//28-11("div.meeting-menu>div:nth-child(2)>span.header-meeting-item");//Годовое собрание акционеров
        private static XPathDescription nameOrg = new XPathDescription(".//div[@class='meeting-menu']/div[1]/div[3]/span");//28-11("div.meeting-menu>div:nth-child(3)>span.header-meeting-item");//org name
                                                                                                                           //  private static CSSDescription emitent = new CSSDescription("div.meeting-menu div span.header-meeting-item");//Акционерный коммерческий Сберегательный бан

        private static CSSDescription dateMeet = new CSSDescription("form#controlPanelForm div span.result-label-data");//Дата собрания

        private static XPathDescription editMeeting = new XPathDescription(".//button[span[text()='Редактирование собрания']]");//Редактирование собран, вылезает подкнопка
        private static XPathDescription manageMeeting = new XPathDescription(".//a[span[text()='Управление собранием']]"); // meetingControlPage


        private static XPathDescription previewMeeting = new XPathDescription(".//button[span[text()='Предпросмотр собрания']]");//Предпросмотр собрания

        private static XPathDescription loadInfo = new XPathDescription(".//button[span[text()='Загрузить информацию']]");

        private static XPathDescription unloadInfo = new XPathDescription(".//button[span[text()='Выгрузить сообщение о собрании']]");//появляется след кнопка
        private static XPathDescription unloadInfotoFile = new XPathDescription(".//a[span[text()='В файл']]");

        private static CSSDescription editState = new CSSDescription("button[id='controlPanelForm:changeStatus_button']");//Изменить статус
        private static XPathDescription editStateOpen = new XPathDescription(".//a[span[text()='Открыть эмитенту и регистратору']]");
        private static XPathDescription editStateCreate = new XPathDescription(".//a[span[text()='Создать общее собрание']]");

        //Отменить собрание
        private static XPathDescription cancelMeeting = new XPathDescription(".//button[span[text()='Отменить собрание']]");//появляется диалог
        private static CSSDescription cancelDialog = new CSSDescription("div#cancelDialog");//новый диалог  с полями
        private static CSSDescription cancelDialogTitle = new CSSDescription("span#cancelDialog_title");//"Отменить собрание"
        private static CSSDescription cancelDialogReasson = new CSSDescription("textarea[id='cancelForm:cancelReason']");//причина отмены
        //private static CSSDescription cancelDialogCode = new CSSDescription("label[id='cancelForm:cancelReasonCode_label']");//Код причины отмены
        //private static CSSDescription cancelDialogCodeToggle = new CSSDescription("div[id='cancelForm:cancelReasonCode'] div span");//
        //private static CSSDescription cancelDialogCodeList = new CSSDescription("ul[id='cancelForm:cancelReasonCode_items']");//выпад списко
        private static CSSDescription addFileMeeting = new CSSDescription("div.wrap-button-upload>span>span>input");//прикрепить файл
        private static CSSDescription cancelDialogCancelMeeting = new CSSDescription("button[id='cancelForm:cancelMeetingFile']");
        private static XPathDescription cancelDialogCloseForm = new XPathDescription(".//button[span[text()='закрыть']]");
        private static CSSDescription cancelDialogCodeSelect = new CSSDescription("select[id='cancelForm:cancelReasonCode_input']");






        //MENU
        private static XPathDescription menuFullInfo = new XPathDescription(".//a[text()='Общая информация']");
        private static XPathDescription menuMater = new XPathDescription(".//a[text()='Материалы']");
        private static XPathDescription menuBullet = new XPathDescription(".//a[text()='Бюллетень']");
        private static XPathDescription menuList = new XPathDescription(".//a[text()='Список к собранию']");
        private static XPathDescription menuViewers = new XPathDescription(".//a[text()='Наблюдатели']");
        private static XPathDescription menuSettings = new XPathDescription(".//a[text()='Настройки']");


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
        private static XPathDescription editCompleteAll = new XPathDescription(".//div[@id='meeting-block'] //div[span[text()='Редактирование раздела завершено']]");//checkBox Редактирование завершено - почему-то 2 шт - ui-state-active

        private static XPathDescription saveb = new XPathDescription(".//button[span[text()='Сохранить']]");//
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
        private static XPathDescription addFileMatFileDivMaterialAdd = new XPathDescription(".//button[span[text()='Прикрепить']]");
        private static XPathDescription addFileMatFileDivMaterialCancel = new XPathDescription(".//button[span[text()='Отмена']]");
        //end МАТЕРИАЛЫ - форма прикрепления файла

        //прикрепленные файлы
        private static CSSDescription materialTableDataFiles = new CSSDescription("tbody[id='tabView:materialForm:materialTable_data'] tr");//кол-во прикрепл материалов
        private static CSSDescription materialTableDataFile = new CSSDescription("tbody[id='tabView:materialForm:materialTable_data'] tr:nth-child(1)");//1 элемент из прикрепл файлов

        private static CSSDescription materialTableDataFileFileName = new CSSDescription("tbody[id='tabView:materialForm:materialTable_data'] tr:nth-child(1)>td:nth-child(1)>a");//1 элемент -назван файла-ссылка
        private static CSSDescription materialTableDataFileFileType = new CSSDescription("tbody[id='tabView:materialForm:materialTable_data'] tr:nth-child(1)>td:nth-child(2)");//1 элемент -тип файла
        private static CSSDescription materialTableDataFileMaterialType = new CSSDescription("tbody[id='tabView:materialForm:materialTable_data'] tr:nth-child(1)>td:nth-child(3)");//1 элемент из прикрепл файлов
        private static CSSDescription materialTableDataFileLang = new CSSDescription("tbody[id='tabView:materialForm:materialTable_data'] tr:nth-child(1)>td:nth-child(4)");//1 элемент -language
        private static CSSDescription materialTableDataFileDelete = new CSSDescription("tbody[id='tabView:materialForm:materialTable_data'] tr:nth-child(1)>td:nth-child(5)>a");//1 элемент -delete
        //end прикрепленные файлы
        private static XPathDescription editCompleteMaterial = new XPathDescription(".//div[@id='material-page'] //div[span[text()='Редактирование раздела завершено']]");//checkBox Редактирование завершено - ui-state-active


        //МАТЕРИАЛЫ прикрепление ссылки форма
        private static CSSDescription addFileMatLinkDiv = new CSSDescription("div[id='tabView:materialLink']");
        private static CSSDescription addFileMatLinkDivTitle = new CSSDescription("span[id='tabView:materialLink_title']");//"прикрепить файл"
        private static CSSDescription linkName = new CSSDescription("input[id='tabView:materialLinkForm:linkName']");// имя ссылки
        private static CSSDescription linkUrl = new CSSDescription("input[id='tabView:materialLinkForm:linkUrl']");// имя ссылки

        private static CSSDescription addFileMatLinkDivLink = new CSSDescription("div[id='tabView:materialLinkForm:linkType'] label");//material
        private static CSSDescription addFileMatLinkDivLinkToggle = new CSSDescription("div[id='tabView:materialLinkForm:linkType'] div>span");
        private static CSSDescription addFileMatLinkDivLinkSelect = new CSSDescription("ul[id='tabView:materialLinkForm:linkType_items']");//список выбор MaterialSelect

        private static XPathDescription addFileMatLinkAdd = new XPathDescription(".//div[@id='tabView:materialLink'] //button[span[text()='Прикрепить']]");
        private static XPathDescription addFileMatLinkCancel = new XPathDescription(".//div[@id='tabView:materialLink'] //button[span[text()='Отмена']]"); // .//button[span[text()='Отмена']]
        //end МАТЕРИАЛЫ прикрепление ссылки форма
        //end МАТЕРИАЛЫ


        //ПОВЕСТКА ДНЯ
        private static CSSDescription divQuestions = new CSSDescription("div#questions");
        private static CSSDescription divQuestionsLabel = new CSSDescription("div#questions>div>div>label");//"повестка дня"

        private static XPathDescription createReport = new XPathDescription(".//button[span[text()='сформировать отчет']]");
        private static XPathDescription addQuestions = new XPathDescription(".//button[span[text()='Добавить вопрос']]");
        private static XPathDescription addQuestionsWithoutChoice = new XPathDescription(".//a[span[text()='Вопрос']]");
        private static XPathDescription addQuestionsWithChoice = new XPathDescription(".//a[span[text()='Вопрос с выбором']]");

        private static CSSDescription questions = new CSSDescription("dl[id='tabView:questionsForm:questionsTable_list']>dt");//кол-во вопросов
        private static CSSDescription questionsNumb = new CSSDescription("dl[id='tabView:questionsForm:questionsTable_list']>dt:nth-child(1)>div>div:nth-child(1)>div");//1 вопрос - номер
        private static CSSDescription questionsNotice = new CSSDescription("dl[id='tabView:questionsForm:questionsTable_list']>dt:nth-child(1)>div>div:nth-child(2)>div>span");//1 вопрос - повестка
        private static XPathDescription questionsEdit = new XPathDescription(".//dl[@id='tabView:questionsForm:questionsTable_list']/dt[1] //a[text()='Редактировать']");//1 вопрос - Редактировать
        private static XPathDescription questionsDelete = new XPathDescription(".//dl[@id='tabView:questionsForm:questionsTable_list']/dt[1] //a[text()='Удалить']");//1 вопрос - Редактировать
                                                                                                                                                                     //
                                                                                                                                                                     //создание-редактирование вопроса                                                                                                                                                            //форма редактирования вопроса                                                                                                                                                           //форма редактирвоания/созд вопроса
        private static CSSDescription questionForm = new CSSDescription("form#questionForm");
        private static CSSDescription questionFormTitle = new CSSDescription("form#questionForm>label");//"редактирование вопроса"
        private static XPathDescription return2Bulleten = new XPathDescription(".//a[span[text()='бюллетень']]");
        private static CSSDescription number = new CSSDescription("input[id='questionForm:issuerLabel']");//номер вопроса - почему -то надо ставить по порядку 1 2 3 4
        private static CSSDescription description = new CSSDescription("textarea[id='questionForm:description']");//вопрос повестки дня <textarea id="" 
        private static CSSDescription proceduralCheckBox = new CSSDescription("div[id='questionForm:procedural']");//Процедурный вопрос
        private static CSSDescription decisionTextOne = new CSSDescription("div#wrap-question-block>div:nth-child(5) textarea");//если вопрос с выбором -Текст решения
        private static CSSDescription coutPlaces = new CSSDescription("div#wrap-question-block>div:nth-child(5) input");//если вопрос с выбором -Количество мест в избираемом органе

        private static XPathDescription addDecision = new XPathDescription(".//button[span[text()='Добавить решение']]");
        private static XPathDescription addDecisionSimple = new XPathDescription(".//a[span[text()='Простое голосование']]");
        private static XPathDescription addDecisionDiff = new XPathDescription(".//a[span[text()='Кумулятивное голосование']]");

        //список решений
        private static CSSDescription decisionItem = new CSSDescription("span[id='questionForm:resolutionsTable']>div.ui-g");//сколко штук
        private static CSSDescription decisionItemNumber = new CSSDescription("span[id='questionForm:resolutionsTable']>div.ui-g:nth-child(1)>div.table-results__number");//номер решения
        private static CSSDescription decisionItemDescriptions = new CSSDescription("span[id='questionForm:resolutionsTable']>div.ui-g:nth-child(1)>div.table-results__description");//_description решения
        private static CSSDescription decisionItemToggle = new CSSDescription("span[id='questionForm:resolutionsTable']>div.ui-g:nth-child(1)>div.toggle-row-icon>div");//toggle решения
        private static CSSDescription decisionItemDelete = new CSSDescription("span[id='questionForm:resolutionsTable']>div.ui-g:nth-child(1)>div>a");//delete решения
                                                                                                                                                      //private static CSSDescription decisionItemDelete = new CSSDescription("span[id='questionForm:resolutionsTable']>div.ui-g:nth-child(1)>div>a");

        private static XPathDescription decisionNumber = new XPathDescription(".//span[@id='questionForm:resolutionsTable']/div[@style='display: block;'][1]/div/div/input");//Номер 1go решения
        private static XPathDescription decisionText = new XPathDescription(".//span[@id='questionForm:resolutionsTable']/div[@style='display: block;'][1]/div/div/textarea");//Текст решения



        private static XPathDescription questionSave = new XPathDescription(".//form[@id='questionForm'] //button[span[text()='Сохранить']]");//
        private static XPathDescription questionCancel = new XPathDescription(".//form[@id='questionForm'] //a[text()='Отменить']");//

        private static XPathDescription editCompleteQuestions = new XPathDescription(".//div[@id='questions'] //div[span[text()='Редактирование раздела завершено']]");//checkBox Редактирование завершено - ui-state-active
        //енд бюллетень

        //список к собранию
        private static CSSDescription divParticipants = new CSSDescription("div#participants-page");
        private static XPathDescription loadListParticipants = new XPathDescription(".//button[span[text()='Загрузить список участников']]");
        private static CSSDescription findListParticipants = new CSSDescription("input[id='tabView:participantsForm:searchText']");//Поиск по списку участников

        //form load list participants
        private static XPathDescription formLoadListParticipants = new XPathDescription(".//div[div[span[text()='Загрузка списка участников собрания']]]");
        private static XPathDescription formLoadListParticipantsClose = new XPathDescription(".//div[div[span[text()='Загрузка списка участников собрания']]]/div/a");//close
        private static CSSDescription selectFileParticipants = new CSSDescription("div#dialog-upload-e-voting>div>div>span>input[type='file']");// Выбрать файл
        private static XPathDescription loadFileParticipants = new XPathDescription(".//button[span[text()='Загрузить файлы']]");//загрузить файлы
        private static XPathDescription loadFileParticipantsCancel = new XPathDescription(".//button[span[text()='Отменить']]");//cancel загрузить файлы
                                                                                                                                //end 

        private static CSSDescription listParticipants = new CSSDescription("tbody[id='tabView:participantsForm:ownersList_data']>tr");//кол-во участников

        private static CSSDescription participantName = new CSSDescription("tbody[id='tabView:participantsForm:ownersList_data']>tr:nth-child(1)>td:nth-child(1)");//1 участкник - имя
        private static CSSDescription participantId = new CSSDescription("tbody[id='tabView:participantsForm:ownersList_data']>tr:nth-child(1)>td:nth-child(2)");//1 участкник - имя
        private static CSSDescription participantTypeId = new CSSDescription("tbody[id='tabView:participantsForm:ownersList_data']>tr:nth-child(1)>td:nth-child(3)");//1 участкник - имя
        private static CSSDescription participantSert = new CSSDescription("tbody[id='tabView:participantsForm:ownersList_data']>tr:nth-child(1)>td:nth-child(4)");//1 участкник - имя
                                                                                                                                                                   //end list4PArticipants

        //НАБЛЮДЖАТЕЛИ 
        private static CSSDescription divObservers = new CSSDescription("div#observers-page");
        private static CSSDescription observersLabel = new CSSDescription("div#observers-page>div>div>label");
        private static CSSDescription observersSave = new CSSDescription("div#observers-page>div>div>div>button[type='submit']");//SAVE
        private static CSSDescription observersSearchName = new CSSDescription("input[id='tabView:observersForm:searchName']");//Поиск по ФИО

        //НОВЫЙ НАБЛЮДАТЕЛь
        private static CSSDescription observerForm = new CSSDescription("form#observerForm");
        private static CSSDescription observerFormLastName = new CSSDescription("input[id='observerForm:lastName']");//имя
        private static CSSDescription observerFormFirstName = new CSSDescription("input[id='observerForm:firstName']");//фамилия
        private static CSSDescription observerFormOtherName = new CSSDescription("input[id='observerForm:otherName']");//отчество
        private static XPathDescription observerFormRefresh = new XPathDescription(".//button[span[text()='Обновить']]");

        private static CSSDescription observerFormLogin = new CSSDescription("input[id='observerForm:login']");//login
        private static CSSDescription observerFormPassw = new CSSDescription("input[id='observerForm:password']");//pass

        private static CSSDescription privilegeesForums = new CSSDescription("table[id='observerForm:privilegees']>tbody>tr:nth-child(1) input[name='observerForm:privilegees']");//привелегии-форум чекбокс
        private static CSSDescription privilegeesQuestion = new CSSDescription("table[id='observerForm:privilegees']>tbody>tr:nth-child(2) input[name='observerForm:privilegees']");//привелегии-форум чекбокс
        private static CSSDescription privilegeesMessages = new CSSDescription("table[id='observerForm:privilegees']>tbody>tr:nth-child(3) input[name='observerForm:privilegees']");//привелегии-форум чекбокс
        private static CSSDescription privilegeesMaterials = new CSSDescription("table[id='observerForm:privilegees']>tbody>tr:nth-child(4) input[name='observerForm:privilegees']");//привелегии-форум чекбокс
        private static CSSDescription privilegeesReports = new CSSDescription("table[id='observerForm:privilegees']>tbody>tr:nth-child(5) input[name='observerForm:privilegees']");//привелегии-форум чекбокс



        //form autorise new observers
        private static XPathDescription autorizeTitle = new XPathDescription(".//div[div/span[text()='Данные авторизации']]");
        private static XPathDescription autorizeTitleDetailFIO = new XPathDescription(".//div[@id='observerForm:authorizationDetail']/div[1]");//данные авторизации-фио
        private static XPathDescription autorizeTitleDetailLogin = new XPathDescription(".//div[@id='observerForm:authorizationDetail']/div[2]");//данные авторизации-login
        private static XPathDescription autorizeTitleDetailPass = new XPathDescription(".//div[@id='observerForm:authorizationDetail']/div[3]");//данные авторизации-pass

        private static XPathDescription closeAutorize = new XPathDescription(".//button[span[text()='Закрыть']]");
        private static XPathDescription copyAutorizeData = new XPathDescription(".//a[text()='Скопировать данные авторизации']");
        //END НОВЫЙ НАБЛЮДАТЕЛь
        //private string error = "<span class='ui-messages-warn-summary'>Внимание</span><span class='ui-messages-warn-detail'>
        //NSD-000000 - InvalidOperation(code:0, message:The given id must not be null!; nested exception is java.lang.IllegalArgumentException: 
        //The given id must not be null!)</span>";
        //end form autorize

        //Табл с наблюдателями
        private static CSSDescription observersTableData = new CSSDescription(
           "tbody[id='tabView:observersForm:observersTable_data'] tr");//сколькео наблюдателей
        private static CSSDescription observersName = new CSSDescription(
            "tbody[id='tabView:observersForm:observersTable_data'] tr:nth-child(1)>td:nth-child(1)");//первый наблюдатель-name
        private static CSSDescription observersAccess = new CSSDescription(
            "tbody[id='tabView:observersForm:observersTable_data'] tr:nth-child(1)>td:nth-child(2)>span:not(.disable)");//первый наблюдатель-доступы
        private static XPathDescription observersEdit = new XPathDescription(
            ".//tbody[@id='tabView:observersForm:observersTable_data']/tr[1] //a[text()='Редактировать']");//первый наблюдатель-edit
        private static XPathDescription observersDataAutorize = new XPathDescription(
             ".//tbody[@id='tabView:observersForm:observersTable_data']/tr[1] //a[text()='Данные авторизации']");//первый наблюдатель-данные авторизации
        private static XPathDescription observersDelete = new XPathDescription(
             ".//tbody[@id='tabView:observersForm:observersTable_data']/tr[1] //a[text()='Удалить']");//первый наблюдатель-удалить


        private static XPathDescription createObserv = new XPathDescription(".//button[span[text()='Создать']]");
        private static XPathDescription CancelObserv = new XPathDescription(".//button[span[text()='Отменить']]");
        //END НАБЛЮДАТЕЛИ 



        //НАСТРОЙКИ
        private static CSSDescription divSettingsVoting = new CSSDescription("div#setting-voting");
        private static XPathDescription settingsSave = new XPathDescription(".//div[@id='setting-voting'] //button[span[text()='Сохранить']]");

        private static CSSDescription publishingTimeManualCb = new CSSDescription("div[id='tabView:settingsForm:publishingTimeManual']>div>span.ui-chkbox-icon");//Публикация собрания вручную чекбокс
        private static CSSDescription publishingTimeManualDate = new CSSDescription("input[id='tabView:settingsForm:publishingTimeDate_input']");//date
        private static CSSDescription publishingTimeManualTime = new CSSDescription("input[id='tabView:settingsForm:publishingTimeTime_input'");//time

        private static XPathDescription dateCreateList = new XPathDescription(".//div[div[label[text()='Дата составления списка лиц,имеющих право на участие в собрании']]]/div/span/input");

        private static CSSDescription bulletinTimeEndManualCb = new CSSDescription(
            "div[id='tabView:settingsForm:bulletinTimeEndManual']>div>span.ui-chkbox-icon");//Публикация собрания вручную чекбокс
        private static CSSDescription bulletinTimeEndManualDate = new CSSDescription(
            "input[id='tabView:settingsForm:bulletinTimeEndDate_input']");//Date
        private static CSSDescription bulletinTimeEndManualTime = new CSSDescription(
            "input[id='tabView:settingsForm:bulletinTimeEndTime_input']");//Time

        private static CSSDescription meetingStartDate = new CSSDescription("input[id='tabView:settingsForm:meetingStartDate_input']");//date
        private static CSSDescription meetingStartTime = new CSSDescription("input[id='tabView:settingsForm:meetingStartTime_input']");//time

        private static CSSDescription participantsRegisterStartManualCb = new CSSDescription(
            "div[id='tabView:settingsForm:participantsRegisterStartManual']>div>span.ui-chkbox-icon");//Начало регистрации участников чекбокс
        private static CSSDescription participantsRegisterStartDate = new CSSDescription(
            "input[id='tabView:settingsForm:participantsRegisterStartDate_input']");//date
        private static CSSDescription participantsRegisterStartTime = new CSSDescription(
            "input[id='tabView:settingsForm:participantsRegisterStartTime_input']");//date

        private static CSSDescription participantsRegisterEndManualCb = new CSSDescription(
            "div[id='tabView:settingsForm:participantsRegisterEndManual']>div>span.ui-chkbox-icon");//Окончание регистрации участников чекбокс
        private static CSSDescription participantsRegisterEndTime = new CSSDescription(
            "input[id='tabView:settingsForm:participantsRegisterEndTime_input']");//time

        private static CSSDescription voteMktDdlnManualCb = new CSSDescription(
           "div[id='tabView:settingsForm:voteMktDdlnManual']>div>span.ui-chkbox-icon");//Окончание голосования на собрании чекбокс
        private static CSSDescription voteMktDdlnTime = new CSSDescription(
            "input[id='tabView:settingsForm:voteMktDdlnTime_input']");//time

        private static CSSDescription meetingEndManualCb = new CSSDescription(
          "div[id='tabView:settingsForm:meetingEndManual']>div>span.ui-chkbox-icon");//Окончание проведения собрания
        private static CSSDescription meetingEndTime = new CSSDescription(
            "input[id='tabView:settingsForm:meetingEndTime_input']");

        private static CSSDescription archivingTimeManualCb = new CSSDescription(
          "div[id='tabView:settingsForm:archivingTimeManual']>div>span.ui-chkbox-icon");//Перенос собрания в архив
        private static CSSDescription archivingTimeDate = new CSSDescription(
            "input[id='tabView:settingsForm:archivingTimeDate_input']");//date
        private static CSSDescription archivingTimeTime = new CSSDescription(
            "input[id='tabView:settingsForm:archivingTimeTime_input']");//time

        //Форум
        private static XPathDescription forumServiceOn = new XPathDescription(
            ".//div[@id='meeting-status']/div[7] //div[span[text()='Включить сервис']]/div/div/input");//вкл сервис
        private static CSSDescription forumServiceOnInDate = new CSSDescription(
            "div#meeting-status>div:nth-child(7)>div>div:nth-child(2)>div>span.clndr>input");//c date
        private static CSSDescription forumServiceOnInTime = new CSSDescription(
            "div#meeting-status>div:nth-child(7)>div>div:nth-child(2)>div>span.tm>input");//c time
        private static CSSDescription forumServiceOnOutDate = new CSSDescription(
            "div#meeting-status>div:nth-child(7)>div>div:nth-child(3)>div>span.clndr>input");//c date
        private static CSSDescription forumServiceOnOutTime = new CSSDescription(
            "div#meeting-status>div:nth-child(7)>div>div:nth-child(3)>div>span.tm>input");//c time
        //end Форум

        //ВОПРОС_ОТВЕТ
        private static XPathDescription questionServiceOn = new XPathDescription(
            ".//div[@id='meeting-status']/div[9] //div[span[text()='Включить сервис']]/div/div/input");//вкл сервис
        private static CSSDescription questionServiceOnInDate = new CSSDescription(
            "div#meeting-status>div:nth-child(9)>div>div:nth-child(2)>div>span.clndr>input");//c date
        private static CSSDescription questionServiceOnInTime = new CSSDescription(
            "div#meeting-status>div:nth-child(9)>div>div:nth-child(2)>div>span.tm>input");//c time
        private static CSSDescription questionServiceOnOutDate = new CSSDescription(
            "div#meeting-status>div:nth-child(9)>div>div:nth-child(3)>div>span.clndr>input");//c date
        private static CSSDescription questionServiceOnOutTime = new CSSDescription(
            "div#meeting-status>div:nth-child(9)>div>div:nth-child(3)>div>span.tm>input");//c time
        //end ВОПРОС_ОТВЕТ

        private static XPathDescription registratorIsAdminUsersOfMeeting = new XPathDescription(
            ".//div[span[text()='Разрешить регистратору администрировать форум участников собрания']]/div/div/input");
        private static XPathDescription addModeVoting = new XPathDescription(
            ".//div[span[text()='Включить вспомогательный режим голосования']]/div/div/input");
        private static XPathDescription allowLoadMaterials = new XPathDescription(
            ".//div[span[text()='Разрешить загружать материалы через E-proxy voting']]/div/div/input");

        //состав счетной комиссии
        private static XPathDescription editListUsers = new XPathDescription(".//button[span[text()='редактировать состав']]");
        private static CSSDescription editListUsersInDate = new CSSDescription(
            "div#meeting-status>div:nth-child(15)>div>div:nth-child(2)>div>span.clndr>input");

        //form sostav s4etnoy komissiy
        private static XPathDescription formCompositionCounting = new XPathDescription(
            ".//div[span[text()='Состав Счетной Комиссии']]");
        private static XPathDescription formCompositionCountingClose = new XPathDescription(
            ".//div[span[text()='Состав Счетной Комиссии']]/a");
        private static CSSDescription filterCompositionCounting = new CSSDescription(
            "input[id='tabView:settingsForm:personForm:globalFilter_input']");
        private static CSSDescription compositionCountingUsers = new CSSDescription(
            "tbody[id='tabView:settingsForm:personForm:comissionTable_data'] tr");//кол-во участников сч комиссии
        private static CSSDescription compositionCountingUserCb = new CSSDescription(
           "tbody[id='tabView:settingsForm:personForm:comissionTable_data']>tr:nth-child(1) input");//чекбокс выбран ли 1 участник
        private static CSSDescription compositionCountingUserName = new CSSDescription(
           "tbody[id='tabView:settingsForm:personForm:comissionTable_data']>tr:nth-child(1)>td:not(.ui-selection-column)");//чекбокс NAME 1 участник

        private static XPathDescription formCompositionCountingSave = new XPathDescription(
            ".//div[@id='tabView:settingsForm:personForm:comissionTable'] //button[span[text()='Сохранить']]");
        private static XPathDescription formCompositionCountingCancel = new XPathDescription(
            ".//div[@id='tabView:settingsForm:personForm:comissionTable'] //button[span[text()='Отменить']]");
        //end form sostav s4etnoy komissiy

        private static XPathDescription editCompleteSettings = new XPathDescription(".//div[@id='meeting-status'] //div[span[text()='Редактирование раздела завершено']]");//checkBox Редактирование завершено - почему-то 2 шт - ui-state-active
        //END НАСТРОЙКИ


        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(nameMeet).Exists()
                && (browser.Describe<IWebElement>(nameMeet).InnerText.Equals(meetingType.years));
        }

        public static bool isTruePage(string orgName)
        {
            browser.Sync();
            Console.WriteLine(browser.Describe<IWebElement>(nameOrg).Exists());
            return browser.Describe<IWebElement>(nameOrg).Exists()
                && browser.Describe<IWebElement>(nameOrg).InnerText.Equals(orgName);
        }

        public static void gotoMenuBullet()
        {
            browser.Describe<ILink>(menuBullet).Click();
        }
        public static void gotoMenuFullInfo()
        {
            browser.Describe<ILink>(menuFullInfo).Click();
        }
        public static void gotoMenuMater()
        {
            browser.Describe<ILink>(menuMater).Click();
        }
        public static void gotoMenuSettings()
        {
            browser.Describe<ILink>(menuSettings).Click();
        }
        public static void gotoMenuViewers()
        {
            browser.Describe<ILink>(menuViewers).Click();
        }
        public static void gotoMenuList()
        {
            browser.Describe<ILink>(menuList).Click();
        }

        /// <summary>
        /// Отменить собрание
        /// </summary>
        public static void clickCancelMeeting()
        {
            browser.Describe<IButton>(cancelMeeting).Click();
        }
        /// <summary>
        /// диалог - Отмены собрания
        /// </summary>
        /// <returns></returns>
        public static bool isCancelMeetingDialogExist()
        {
            return browser.Describe<IWebElement>(cancelDialogTitle).Exists()
                && browser.Describe<IWebElement>(cancelDialogTitle).InnerText.Equals("Отменить собрание");
        }
        /// <summary>
        /// Причина отмены
        /// </summary>
        /// <param name="v"></param>
        public static void setCancelDialogReasson(string v)
        {
            browser.Describe<IEditField>(cancelDialogReasson).SetValue(v);
        }
        /// <summary>
        /// да отмени уже собрание!Ё
        /// </summary>
        public static void clickCancelDialogCancelMeeting()
        {
            browser.Describe<IButton>(cancelDialogCancelMeeting).Click();
        }

        /// <summary>
        /// Код причины отмены
        /// </summary>
        /// <param name="v"></param>
        public static void selectCancelDialogCode(string v)
        {
            browser.Describe<IListBox>(cancelDialogCodeSelect).Select(v);
        }

        public static bool isListOfMeetingExist()
        {
            return browser.Describe<IButton>(loadListParticipants).Exists()
                && browser.Describe<IButton>(loadListParticipants).IsVisible;
        }

        public static void clickLoadListParticipants()
        {
            browser.Describe<IButton>(loadListParticipants).Click();
        }
        public static bool isFormLoadListParticipantsExist()
        {
            return browser.Describe<IWebElement>(loadListParticipants).Exists();
        }
        public static void clickSelectFileParticipants()
        {
            IFileField ff = browser.Describe<IFileField>(selectFileParticipants);

            ff.SetValue(@"D:\temp\test.xml");

            browser.Describe<IWebElement>(selectFileParticipants).Click();
            browser.Describe<IFileField>(selectFileParticipants).Click();
            browser.Describe<IFileField>(selectFileParticipants).FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));
            browser.Describe<IFileField>(selectFileParticipants).FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnClick));
            Console.WriteLine("IFileField = " + browser.Describe<IFileField>(selectFileParticipants).Value);

            Console.WriteLine("IFileField = " + browser.Describe<IFileField>(selectFileParticipants).GetVisibleText());
            browser.Describe<IFileField>(selectFileParticipants).Highlight();

            browser.Describe<IWebElement>(
                new CSSDescription("div#dialog-upload-e-voting>div>div>span>span:nth-child(1)")).Click();

            browser.Describe<IWebElement>(
                 new CSSDescription("div#dialog-upload-e-voting>div>div>span>span:nth-child(2)")).Click();


        }

        /// <summary>
        /// изменить статус
        /// </summary>
        public static void clickEditState()
        {
            browser.Describe<IButton>(editState).Click();
        }

        /// <summary>
        /// Создать общее собрание
        /// </summary>
        public static void clickEditStateCreate()
        {
            browser.Describe<IButton>(editStateCreate).Click();
        }

        /// <summary>
        /// открыть собрание регистратору и эмитенту
        /// </summary>
        public static void clickУditStateOpen()
        {
            browser.Describe<IButton>(editStateOpen).Click();
        }


        /// <summary>
        /// получить статус собрания
        /// </summary>
        /// <returns></returns>
        public static string getState()
        {
            return browser.Describe<IWebElement>(state).InnerText;
        }

        public static void setissuerFullName(string v) { browser.Describe<IEditField>(issuerFullName).SetValue(v); }
        public static void setmeetingId(string v) { browser.Describe<IEditField>(meetingId).SetValue(v); }
        public static void setformTypeLabel(string v) { browser.Describe<IEditField>(formTypeLabel).SetValue(v); }
        public static void setmeetingStartInput(string v) { browser.Describe<IEditField>(meetingStartInput).SetValue(v); }
        public static void setmeetingCountryInput(string v) { browser.Describe<IEditField>(meetingCountryInput).SetValue(v); }
        public static void setmeetingAddress(string v) { browser.Describe<IEditField>(meetingAddress).SetValue(v); }
        public static void setvoteMktDdlnInput(string v) { browser.Describe<IEditField>(voteMktDdlnInput).SetValue(v); }
        public static void setparticipantsRegisterStartInput(string v) { browser.Describe<IEditField>(participantsRegisterStartInput).SetValue(v); }
        public static void setentitlementFixingDate_input(string v) { browser.Describe<IEditField>(entitlementFixingDate_input).SetValue(v); }
        public static void setpostCountry_input(string v) { browser.Describe<IEditField>(postCountry_input).SetValue(v); }
        public static void setpostAddressInput(string v) { browser.Describe<IEditField>(postAddressInput).SetValue(v); }
        public static void setagenda(string v) { browser.Describe<IEditField>(agenda).SetValue(v); }
        public static void setprocOfFamiliarWMaterials(string v) { browser.Describe<IEditField>(procOfFamiliarWMaterials).SetValue(v); }

        public static string getissuerFullName() { return browser.Describe<IEditField>(issuerFullName).Value; }
        public static string getmeetingId() { return browser.Describe<IEditField>(meetingId).Value; }
        public static string getformTypeLabel() { return browser.Describe<IEditField>(formTypeLabel).Value; }
        public static string getmeetingStart() { return browser.Describe<IEditField>(meetingStartInput).Value; }
        public static string getmeetingCountry() { return browser.Describe<IEditField>(meetingCountryInput).Value; }
        public static string getMeetingAddress() { return browser.Describe<IEditField>(meetingAddress).Value; }
        public static string getVoteMktDdln() { return browser.Describe<IEditField>(voteMktDdlnInput).Value; }
        public static string getParticipantsRegisterStart() { return browser.Describe<IEditField>(participantsRegisterStartInput).Value; }
        public static string getentitlementFixingDate() { return browser.Describe<IEditField>(entitlementFixingDate_input).Value; }
        public static string getPostCountry() { return browser.Describe<IEditField>(postCountry_input).Value; }
        public static string getPostAddress() { return browser.Describe<IEditField>(postAddressInput).Value; }
        public static string getAgenda() { return browser.Describe<IEditField>(agenda).Value; }
        public static string getProcOfFamiliarWMaterials() { return browser.Describe<IEditField>(procOfFamiliarWMaterials).Value; }

        public static void save()
        {

            browser.Describe<IButton>(saveb).Click();
        }
    }
}
