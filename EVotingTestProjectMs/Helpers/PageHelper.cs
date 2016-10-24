using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingTestProjectMs.Helpers
{
    class PageHelper
    {
        public static IBrowser browser;

        private static CSSDescription errorMsg = new CSSDescription("span.ui-messages-error-detail");//? как закрыть?
        private static CSSDescription errorAlert = new CSSDescription("div.alert-danger");//http://clip2net.com/s/3DsxmiR
        private static CSSDescription errorAlertClose = new CSSDescription("div.alert-danger a.close");

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
