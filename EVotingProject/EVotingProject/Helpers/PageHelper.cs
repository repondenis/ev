using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using System.Drawing;
using WindowsInput;
using System.Windows.Forms;

namespace EVotingProject.Helpers
{
    class PageHelper
    {
        public static IBrowser browser;
        //
        private static CSSDescription errorMsg = new CSSDescription("span.ui-messages-error-detail");//
        private static CSSDescription infoMsg = new CSSDescription("span.ui-messages-info-detail");//Собрание уже опубликовано и не может быть изменено
        private static CSSDescription errorMsgClose = new CSSDescription("ui-icon ui-icon-close");//закрыть

        //Ошибки авторизации
        private static CSSDescription errorAlert = new CSSDescription("div.alert-danger");//http://clip2net.com/s/3DsxmiR  //общий div Ошибки авторизации
        private static CSSDescription errorAlertClose = new CSSDescription("div.alert-danger a.close");
        private static CSSDescription errorAlertState = new CSSDescription("strong.ng-binding");//"Ошибка!"

        //
        private static CSSDescription message = new CSSDescription("span.ui-growl-title");
        private static CSSDescription messageWidget = new CSSDescription("div.ui-messages-info span.ui-messages-info-summary");
        private static CSSDescription messageWidgetClose = new CSSDescription("div.ui-messages-info a.ui-messages-close");

        //
        private static CSSDescription messageGrowle = new CSSDescription("div.ui-growl-item");//сам див с содержимым сообщения
        private static CSSDescription messageGrowleError = new CSSDescription("div.ui-growl-item>span.ui-growl-image-error");//
        private static CSSDescription messageGrowleInfo = new CSSDescription("div.ui-growl-item>span.ui-growl-image-info");
        private static CSSDescription messageGrowleText = new CSSDescription("div.ui-growl-item>div>span.ui-growl-title");

        //
        private static CSSDescription errorAutoris = new CSSDescription("div.swal2-modal");
        private static CSSDescription errorAutorisDescr = new CSSDescription("div.swal2-modal>h2");
        private static CSSDescription errorAutorisClose = new CSSDescription("div.swal2-modal>button.swal2-confirm");

        private static CSSDescription logoMain = new CSSDescription("a[href='#/']");

        public static void clickLogoMain()
        {
            browser.Describe<ILink>(logoMain).Click();
        }

        public static void setBrowser(IBrowser bro)
        {
            browser = bro;
        }

        /// <summary>
        /// есть ли ошибка при авторизации?
        /// </summary>
        /// <returns></returns>
        public static bool isErrorAutorisExist()
        {
            var errorAutorisat = browser.Describe<IWebElement>(errorAutoris);
            if (errorAutorisat.Exists() && errorAutorisat.IsVisible)
            {
                var errorAutorisDescript = browser.Describe<IWebElement>(errorAutorisDescr);
                var errorAutorisCloseBt = browser.Describe<IButton>(errorAutorisClose);
                if (errorAutorisDescript.Exists() && errorAutorisDescript.IsVisible && errorAutorisCloseBt.Exists() && errorAutorisCloseBt.IsVisible)
                {
                    Console.WriteLine(errorAutorisDescript.InnerText);
                    errorAutorisCloseBt.Click();
                    return true;
                }
            }
            return false;
        }

        public static bool isMessageGrowleOk()
        {
            var msg = browser.Describe<IWebElement>(messageGrowle);
            if (msg.Exists())
            {
                Console.WriteLine("MSG: " + msg.Describe<IWebElement>(messageGrowleText).InnerHTML + ", " + DateTime.Now);
                //return browser.Describe<IWebElement>(messageGrowleError).Exists();
                return browser.Describe<IWebElement>(messageGrowleInfo).Exists();
            }
            return false;
        }

        public static bool isMessageGrowleOk(string str)
        {
            var msg = browser.FindChildren<IWebElement>(messageGrowle);
            if (msg.Length > 0)
            {
                Console.WriteLine("MSG: " + msg[0].Describe<IWebElement>(messageGrowleText).InnerHTML + ", " + DateTime.Now);
                //return browser.Describe<IWebElement>(messageGrowleError).Exists();
                return msg[0].Describe<IWebElement>(messageGrowleInfo).Exists() && msg[0].Describe<IWebElement>(messageGrowleText).InnerHTML.Contains(str);
            }
            return false;
        }

        /// <summary>
        /// получить все ошибки скопом)
        /// </summary>
        /// <returns></returns>
        public static List<string> getMessagesGrowleOk()
        {
            List<string> s = new List<string>();

            var msg = browser.FindChildren<IWebElement>(messageGrowle);

            foreach (IWebElement m in msg)
            {
                s.Add(m.Describe<IWebElement>(messageGrowleText).InnerText);
                Console.WriteLine(m.Describe<IWebElement>(messageGrowleText).InnerText);
            }

            /*
            if (msg != null && msg.Length > 0)
                for (int i = 0; i < msg.Length; i++)
                {
                    msg[i].Describe<IWebElement>(messageGrowleText).InnerHTML;
                }

            if (msg.Exists())
            {
                Console.WriteLine("MSG: " + msg.Describe<IWebElement>(messageGrowleText).InnerHTML + ", " + DateTime.Now);
                //return browser.Describe<IWebElement>(messageGrowleError).Exists();
                return msg.Describe<IWebElement>(messageGrowleInfo).Exists() && msg.Describe<IWebElement>(messageGrowleText).InnerHTML;
            }
            return false;
            */
            return s;
        }

        /**
         * <span class="ui-messages-info-summary">Успешно сохранено!</span>
         */
        public static bool isMessageWidget(string str)
        {
            return browser.Describe<IWebElement>(message).Exists() && browser.Describe<IWebElement>(message).InnerText.Equals(str);
        }

        /**
         * <span class="ui-growl-title">Успешно сохранено!</span>
         */
        public static bool isMessage(string str)
        {
            return browser.Describe<IWebElement>(messageWidget).Exists() && browser.Describe<IWebElement>(messageWidget).InnerText.Equals(str);
        }


        public static bool isInfoMsg()
        {
            IWebElement msg = browser.Describe<IWebElement>(infoMsg);
            if (msg.Exists())
            {
                Console.WriteLine(msg.InnerText);
                return true;
            }
            else
                return false;
        }

        public static bool isErrorMsg()
        {
            IWebElement msg = browser.Describe<IWebElement>(errorMsg);
            if (msg.Exists())
            {
                Console.WriteLine("Текст ошибки: " + msg.InnerText);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// есть ли ошибка авторизации?
        /// красная
        /// </summary>
        /// <returns></returns>
        public static bool isErrorAlert()
        {
            var msg = browser.Describe<IWebElement>(errorAlert);

            if (msg.Exists() & msg.IsVisible)
            {
                Console.WriteLine(msg.InnerText);
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// низкоуровневые действия
        /// клик по элементу
        /// </summary>
        /// <param name="elem"></param>
        public static void click2Object(IWebElement elem)
        {
            try
            {
                Point p = elem.AbsoluteLocation;
                var toX = 65535 * (p.X + 5) / Screen.PrimaryScreen.Bounds.Width;
                var toY = 65535 * (p.Y + 5) / Screen.PrimaryScreen.Bounds.Height;

                InputSimulator keyb = new InputSimulator();
                keyb.Mouse.MoveMouseTo(toX, toY);
                keyb.Mouse.LeftButtonClick();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// низкоуровневые действия
        /// ввод текста в текущее положение под курсором
        /// </summary>
        /// <param name="v"></param>
        public static void sendText2Object(string v)
        {
            InputSimulator keyb = new InputSimulator();
            keyb.Keyboard.TextEntry(v);
        }

    }
}
