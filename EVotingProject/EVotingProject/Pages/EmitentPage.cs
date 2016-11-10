using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;

namespace EVotingProject.Pages
{
    class EmitentPage : OrganizationPage
    {
        private static CSSDescription organizationTitle = new CSSDescription("div#organization-block>label");//эмитенты
        private static CSSDescription organizationSearhInput = new CSSDescription("div#organization-block>div>div>input");
        private static CSSDescription organizationDateTabl = new CSSDescription("table[role='grid']");

        public static new bool isTruePage()
        {
            browser.Sync();
            return browser.Describe<IWebElement>(organizationTitle).Exists() &&
                browser.Describe<IWebElement>(organizationTitle).InnerText.Equals("эмитенты");
        }

    }



}
