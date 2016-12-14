using EVotingProject.Helpers;
using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace EVotingProject.Pages
{
    class LoginLocalPage : Helpers.PageHelper
    {



        //поля логин-пароль
        private static CSSDescription logini = new CSSDescription("input#login-username");//28112016("input[name='inputLogin']");
        private static CSSDescription passwordi = new CSSDescription("input#login-password");//28112016("input[name='inputPassword']");

        //buttons
        private static CSSDescription sumbit = new CSSDescription("button[type='submit']");//войти
        private static CSSDescription forgotPassw = new CSSDescription("div.forgot-password a");

        public static bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IEditField>(logini).Exists();
        }

        /// <summary>
        /// авторизация
        /// </summary>
        /// <param name="lgn"></param>
        /// <param name="pswrd"></param>
        public static void runLogin(string lgn, string pswrd)
        {
            setLogin(lgn);
            setPassword(pswrd);
            clickSubmit();
        }

        public static void setLogin(string v)
        {
            var login = browser.Describe<IEditField>(logini);

            /*
            Point p = login.AbsoluteLocation;
            var toX = 65535 * (p.X + 10) / Screen.PrimaryScreen.Bounds.Width;
            var toY = 65535 * (p.Y + 10) / Screen.PrimaryScreen.Bounds.Height;

            InputSimulator keyb = new InputSimulator();
            keyb.Mouse.MoveMouseTo(toX, toY);
            keyb.Mouse.LeftButtonClick();
            keyb.Keyboard.TextEntry(v);
            */
            click2Object(login);
            sendText2Object(v);

        }

        public static void setLoginOld(string v)
        {
            var login = browser.Describe<IEditField>(logini);
            login.SetValue(string.Empty);
            login.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));
            login.SetValue(v);
        }

        public static void setPassword(string v)
        {
            var password = browser.Describe<IEditField>(passwordi);
            /*
            Point p = password.AbsoluteLocation;
            var toX = 65535 * (p.X + 10) / Screen.PrimaryScreen.Bounds.Width;
            var toY = 65535 * (p.Y + 10) / Screen.PrimaryScreen.Bounds.Height;

            InputSimulator keyb = new InputSimulator();
            keyb.Mouse.MoveMouseTo(toX, toY);
            keyb.Mouse.LeftButtonClick();
            keyb.Keyboard.TextEntry(v);
            */

            click2Object(password);
            sendText2Object(v);
        }

        public static void setPasswordOld(string v)
        {
            var password = browser.Describe<IEditField>(passwordi);
            password.SetValue(string.Empty);
            password.SetSecure(v);
            password.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));
        }

        public static void clickSubmit()
        {
            browser.Describe<IButton>(sumbit).Click();//войти
        }

        public void forgotRass()
        {
            ILink forgotPasswB = browser.Describe<ILink>(forgotPassw);
            forgotPasswB.Click();
        }
    }
}
