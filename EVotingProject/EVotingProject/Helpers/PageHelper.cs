using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Helpers
{
    class PageHelper
    {
        public static IBrowser browser;

        private static CSSDescription errorMsg = new CSSDescription("span.ui-messages-error-detail");//? как закрыть?
        private static CSSDescription errorAlert = new CSSDescription("div.alert-danger");//http://clip2net.com/s/3DsxmiR
        private static CSSDescription errorAlertClose = new CSSDescription("div.alert-danger a.close");

        private static CSSDescription message = new CSSDescription("span.ui-growl-title");
        private static CSSDescription messageWidget = new CSSDescription("div.ui-messages-info span.ui-messages-info-summary");
        private static CSSDescription messageWidgetClose = new CSSDescription("div.ui-messages-info a.ui-messages-close");


        public static void setBrowser(IBrowser bro)
        {
            browser = bro;
        }

        /**
         * <span class="ui-messages-info-summary">Успешно сохранено!</span>
         */
        public static bool isMessageWidget(string str)
        {
            return browser.Describe<IWebElement>(message).Exists() && browser.Describe<IWebElement>(message).GetVisibleText().Equals(str);
        }

        /**
         * <span class="ui-growl-title">Успешно сохранено!</span>
         */
        public static bool isMessage(string str)
        {
            return browser.Describe<IWebElement>(messageWidget).Exists() && browser.Describe<IWebElement>(messageWidget).GetVisibleText().Equals(str);
        }


        public static bool isErrorMsg()
        {
            IWebElement msg = browser.Describe<IWebElement>(errorMsg);
            if (msg.Exists())
            {
                Console.WriteLine(msg.GetVisibleText());
                return true;
            }
            else
                return false;
        }

        public static bool isErrorAlert()
        {
            IWebElement msg = browser.Describe<IWebElement>(errorAlert);
            if (msg.Exists())
            {
                Console.WriteLine(msg.GetVisibleText());
                return true;
            }
            else
                return false;
        }

    }
}
