using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVotingProject.Pages
{
    class LoginLocalPage : Helpers.PageHelper
    {
        //поля логин-пароль
        private static CSSDescription login = new CSSDescription("input#inputLogin");
        private static CSSDescription password = new CSSDescription("input#inputPassword");

        //buttons
        private static CSSDescription sumbit = new CSSDescription("button[type='submit']");//войти
        private static CSSDescription forgotPassw = new CSSDescription("div.forgot-password a");

        public static bool isLoginLocalPage()
        {
            return browser.Describe<IEditField>(login).Exists();
        }

        public static void runLogin(string lgn, string pswrd)
        {

            IEditField loginF = browser.Describe<IEditField>(login);
            IEditField passwordF = browser.Describe<IEditField>(password);

            loginF.SetValue(lgn);
            passwordF.SetValue(pswrd);

            IButton sumbitB = browser.Describe<IButton>(sumbit);//войти

            sumbitB.Click();
        }

        public void forgotRass() {
            ILink forgotPasswB = browser.Describe<ILink>(forgotPassw);
            forgotPasswB.Click();
        }
    }
}
