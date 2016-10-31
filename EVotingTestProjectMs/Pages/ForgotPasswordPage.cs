using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingTestProjectMs.Pages
{
    class ForgotPasswordPage : Helpers.PageHelper
    {
        private static CSSDescription description = new CSSDescription("div.wrapper>div>div>div.ng-scope");

        public static bool isForgotPasswordPage()
        {
            return browser.Describe<IWebElement>(description).Exists() && browser.Describe<IWebElement>(description).GetVisibleText().Equals("Восстановление пароля");
        }
    }
}
