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
        // private static CSSDescription menuOrganizators = new CSSDescription("header.header>div>div:nth-child(2)");
        private static XPathDescription menuRegistrators = new XPathDescription(".//div[text()='Для регистраторов']");
        private static XPathDescription menuObservers = new XPathDescription(".//div[text()='Для наблюдателей']");

        //выбор авториз
        private static CSSDescription autorisESIA = new CSSDescription(".panel-login>a");
        private static XPathDescription autorisLogin = new XPathDescription(".//a[@ui-sref='local']");//Войти с помощью логина и пароля
        private static XPathDescription autorisSert = new XPathDescription(".//a[@ui-sref='cert']");//Войти с помощью неквалифицированной ЭП

        private static CSSDescription header = new CSSDescription("header>div");

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



        public static void caseLoginParam(String param)
        {
            //выбор авториз
            switch (param)
            {
                case LoginParam.esia:
                    ILink autorisatESIA = browser.Describe<ILink>(autorisESIA);
                    autorisatESIA.Click();
                    break;
                case LoginParam.login:
                    ILink autorisatLogin = browser.Describe<ILink>(autorisLogin);//Войти с помощью логина и пароля
                    autorisatLogin.Click();
                    break;
                case LoginParam.sertif:
                    ILink autorisatSert = browser.Describe<ILink>(autorisSert);//Войти с помощью неквалифицированной ЭП
                    autorisatSert.Click();
                    break;
            }
            browser.Sync();
        }

        public static bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<ILink>(autorisESIA).Exists();//ищем только 1 кнопку авторищации в ЕСИА
        }
    }
}
