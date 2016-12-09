using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using EVotingProject.Models;
using HP.LFT.SDK;

namespace EVotingProject.Pages
{
    class LoginPage : Helpers.PageHelper
    {


        //переключатели верхн меню
        private static XPathDescription menuSecurities = new XPathDescription(".//div[text()='Для владельцев ценных бумаг']");
        private static XPathDescription menuOrganizators = new XPathDescription(".//div[text()='Для организаторов']");
        private static XPathDescription menuRegistrators = new XPathDescription(".//div[text()='Для регистраторов']");
        private static XPathDescription menuObservers = new XPathDescription(".//div[text()='Для наблюдателей']");

        //выбор авториз
        private static CSSDescription autorisESIA = new CSSDescription("button.btn-e-voting");//28112016(".panel-login>a");
        private static CSSDescription autorisLogin = new CSSDescription("a.another-login[href='#/local']");//28112016(".//a[@ui-sref='local']");//Войти с помощью логина и пароля
        private static CSSDescription autorisSert = new CSSDescription("a.another-login[href='#/dig']");//28112016(".//a[@ui-sref='cert']");//Войти с помощью неквалифицированной ЭП

        // private static CSSDescription header = new CSSDescription("header>div");



        /// <summary>
        /// выбор нужного пункта меню
        /// под кем авторизоваться
        /// не нужен для АДМИНА Е-Voting
        /// </summary>
        /// <param name="param"></param>
        public static void caseMenuParam(string param)
        {
            try
            {
                //переключатели верхн меню
                switch (param)
                {
                    case MenuParam.securities:
                        browser.Describe<IWebElement>(menuSecurities).Click();
                        break;
                    case MenuParam.registrators:
                        browser.Describe<IWebElement>(menuRegistrators).Click();
                        break;
                    case MenuParam.observers:
                        browser.Describe<IWebElement>(menuObservers).Click();
                        break;
                    case MenuParam.organizators:
                        browser.Describe<IWebElement>(menuOrganizators).Click();
                        break;
                }

            }
            catch (ReplayObjectNotFoundException e)
            {
                Console.WriteLine(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace + "\r\n" + e.TestObject);
            }
        }

        /// <summary>
        /// выбор метода авторизации
        /// </summary>
        /// <param name="param"></param>
        public static void caseLoginParam(String param)
        {
            //выбор авториз
            switch (param)
            {
                case LoginParam.esia:
                    browser.Describe<ILink>(autorisESIA).Click();
                    break;
                case LoginParam.login:
                    browser.Describe<ILink>(autorisLogin).Click();//Войти с помощью логина и пароля
                    break;
                case LoginParam.sertif:
                    browser.Describe<ILink>(autorisSert).Click();//Войти с помощью неквалифицированной ЭП
                    break;
            }
            browser.Sync();
        }

        public static bool isTruePage()
        {
            browser.Sync();
            //Console.WriteLine();
            return browser.Describe<IButton>(autorisESIA).Exists();//ищем только 1 кнопку автори3ации в ЕСИА
        }
    }
}
