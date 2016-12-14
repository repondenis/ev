using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVotingProject.Pages
{
    class PublicPage : PortalPage
    {

        private static CSSDescription manageMeeting = new CSSDescription("ul.hidden-xs a.meeting-link");
        private static CSSDescription meetingsList = new CSSDescription("div.meetings-list>div");

        public static new bool isTruePage()
        {
            return browser.Describe<ILink>(manageMeeting).Exists();
        }

        /// <summary>
        /// перейти к собраниям
        /// </summary>
        public static void gotoPortalPage()
        {
            browser.Describe<ILink>(manageMeeting).Click();
        }

    }
}
