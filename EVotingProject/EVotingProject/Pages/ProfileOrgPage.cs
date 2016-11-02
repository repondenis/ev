using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Pages
{
    class ProfileOrgPage : Helpers.PageHelper
    {
        private static CSSDescription orgProfileTitle = new CSSDescription("div#org-profile>label.main-header-page");//"Сбербанк России ОАО"

        //MENU
        private static XPathDescription menuMeeting = new XPathDescription(".//a[text()='Собрания']");
        private static XPathDescription menuUsers = new XPathDescription(".//a[text()='Пользователи']");
        private static XPathDescription menuDocuments = new XPathDescription(".//a[text()='Договоры']");
        private static XPathDescription menuProfileOrg = new XPathDescription(".//a[text()='Профиль организации']");

        private static CSSDescription divBranding = new CSSDescription("div#branding-block");

        //делегировано регистратору
        private static XPathDescription createNewMeeting = new XPathDescription(
            ".//div[@id='branding-block-delegating'] //tbody/tr[1]/td[1]/div/div/input");//Создание (инициация) новых собраний
        private static XPathDescription manageSettingsMeeting = new XPathDescription(
            ".//div[@id='branding-block-delegating'] //tbody/tr[1]/td[3]/div/div/input");
        private static XPathDescription adminForums = new XPathDescription(
            ".//div[@id='branding-block-delegating'] //tbody/tr[2]/td[1]/div/div/input");

        private static CSSDescription loadLogo = new CSSDescription(".//button[span[text()='Загрузить логотип']]");
        private static CSSDescription loadLogoHeader = new CSSDescription(".//a[span[contains(text(),'ЗАГРУЗИТЬ ЛОГОТИП ШАПКИ')]]");
        private static CSSDescription loadLogoList = new CSSDescription(".//a[span[contains(text(),'ЗАГРУЗИТЬ ЛОГОТИП СПИСКА')]]");

        private static CSSDescription colorHeader = new CSSDescription(".//div[@id='branding-block-edit']/div[2]/div[3]/div/input");//цвет шапки
        private static CSSDescription colorButton = new CSSDescription(".//div[@id='branding-block-edit']/div[2]/div[5]/div/input");//цвет шапки

        private static CSSDescription divPrev = new CSSDescription("div#divPrev");//style="background:#009900;"
        private static XPathDescription samplesButton = new XPathDescription(".//button[span[text()='Пример кнопки']]");//background:#edff21"

        private static XPathDescription save = new XPathDescription(".//button[span[text()='Сохранить']]");

        public static bool isProfileOrgPage(string org)
        {
            return browser.Describe<IWebElement>(orgProfileTitle).Exists() && browser.Describe<IWebElement>(orgProfileTitle).InnerText.Equals(org);
        }

    }
}
