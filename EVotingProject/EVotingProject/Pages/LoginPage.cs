using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using EVotingProject.Models;
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
        private static XPathDescription autorisESIA = new XPathDescription(".//buton[@type='button' and text()='Войти с помощью']");
        private static XPathDescription autorisLogin = new XPathDescription(".//a[@ui-sref='local']");//Войти с помощью логина и пароля
        private static XPathDescription autorisSert = new XPathDescription(".//a[@ui-sref='cert']");//Войти с помощью неквалифицированной ЭП


        public static void caseMenuParam(String param)
        {
            //переключатели верхн меню
            switch (param)
            {
                case MenuParam.securities:
                    ILink menuSec = browser.Describe<ILink>(menuSecurities);
                    menuSec.Click();
                    break;
                case MenuParam.registrators:
                    ILink menuReg = browser.Describe<ILink>(menuRegistrators);
                    menuReg.Click();
                    break;
                case MenuParam.observers:
                    ILink menuObs = browser.Describe<ILink>(menuObservers);
                    menuObs.Click();
                    break;
                case MenuParam.organizators:
                    ILink menuOrg = browser.Describe<ILink>(menuOrganizators);
                    menuOrg.Click();
                    break;
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
        }

        public static bool isLoginPage()
        {
            return browser.Describe<ILink>(autorisESIA).Exists();//ищем только 1 кнопку авторищации в ЕСИА
        }
    }
}
