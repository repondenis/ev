using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using EVotingProject.Helpers;

namespace EVotingProject.Pages
{
    class LoginSertPage : PageHelper
    {

        private static CSSDescription textAutoris = new CSSDescription("h3.ng-binding");//наджпись - Авторизация через ЭП

        private static CSSDescription buttonLoadFile = new CSSDescription("button[click-target='#inputFile']");
        private static XPathDescription buttonSubmit = new XPathDescription(".//button[text()=' Войти']");//внопка войти

        private static CSSDescription labelFile = new CSSDescription("div[ng-if='ctrl.filename']");//после загрузки файла,
        private static CSSDescription labelNameFile = new CSSDescription("div[ng-if='ctrl.filename'] span");//после загрузки файла,

        private static CSSDescription pass = new CSSDescription("input#passwd");

        public static bool isLoginSertPage()
        {
            return browser.Describe<IWebElement>(textAutoris).Exists();
        }

        public static void loadFileClick(string filefath)
        {
            IButton loadFile = browser.Describe<IButton>(buttonLoadFile);
            loadFile.Click();
            // писать обработку опенфайлдиалога

        }

        public static string getFileNameLoad()
        {
            return browser.Describe<IWebElement>(labelNameFile).InnerText;
        }

        public static void setPassword(string psw)
        {
            IEditField password = browser.Describe<IEditField>(pass);
            password.SetValue(psw);
        }

        public static void submit()
        {
            IButton submitB = browser.Describe<IButton>(buttonSubmit);
            submitB.Click();
        }


    }
}
