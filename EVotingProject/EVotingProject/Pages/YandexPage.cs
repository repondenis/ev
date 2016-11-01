using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using HP.LFT.SDK;

namespace EVotingProject.Pages
{


    class YandexPage:Helpers.PageHelper
    {
        //private static IBrowser browser;

        private static CSSDescription searhTextInp = new CSSDescription("input#text");
        private static XPathDescription searhBt = new XPathDescription(".//button[span[text()='Найти']]");
        private static CSSDescription contentList = new CSSDescription("ul.serp-list>li");




        public static void sendText(string text)
        {
            var searhText = browser.Describe<IEditField>(searhTextInp);
            searhText.SetValue(text);

        }

        public static void clickSearh()
        {
            var searh = browser.Describe<IButton>(searhBt);
            searh.Click();
            browser.Sync();
        }

        public static bool isSearhElementsExist()
        {
            return browser.Describe<IButton>(searhBt).Exists() && browser.Describe<IEditField>(searhTextInp).Exists();
        }

        public static int getCountContent()
        {

           // var suggestions = browser.Describe<IWebElement>(contentList);
           // suggestions.WaitUntil(suggestionsBox => suggestionsBox.Exists() && suggestionsBox.IsVisible);
           

            var content = browser.FindChildren<IWebElement>(contentList);
            System.Console.WriteLine("contentList is exists = " + browser.Describe<IWebElement>(contentList).Exists());
            System.Console.WriteLine("content lenght=" + content.Length);

            return content.Length;
        }

    }
}
