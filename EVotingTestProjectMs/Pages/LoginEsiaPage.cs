using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingTestProjectMs.Pages
{
    class LoginEsiaPage : Helpers.PageHelper
    {
        private static CSSDescription slogan = new CSSDescription("div.slogan");//надпись

        private static CSSDescription mobileMailI = new CSSDescription("input#mobileOrEmail");//Мобильный телефон или почта
        private static CSSDescription passI = new CSSDescription("input#password");
        private static CSSDescription submitB = new CSSDescription("button[data-bind='click: loginByPwd']");//Войти

        private static XPathDescription menuLoginSnils = new XPathDescription(".//a[text=' СНИЛС']");
        private static XPathDescription menuLoginPhoneMail = new XPathDescription(".//a[text=' Телефона/почты']");
        private static XPathDescription menuLoginSert = new XPathDescription(".//a[text=' Электронных средств']");

        public static bool isLoginEsiaPage()
        {
            return browser.Describe<IWebElement>(slogan).Exists();
        }

        public static void setMobileMail(string mobileOrMail)
        {
            IEditField mobileMail = browser.Describe<IEditField>(mobileMailI);
            mobileMail.SetValue(mobileOrMail);
        }

        public static void setPassword(string psw)
        {
            IEditField pass = browser.Describe<IEditField>(passI);
            pass.SetValue(psw);
        }

        public static void submit()
        {
            IButton subm = browser.Describe<IButton>(submitB);
            subm.Click();
        }

    }
}


