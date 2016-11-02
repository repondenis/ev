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


    class YandexPage : Helpers.PageHelper
    {
        //private static IBrowser browser;

        private static CSSDescription searhTextInp = new CSSDescription("input#text");
        private static XPathDescription searhBt = new XPathDescription(".//button[span[text()='Найти']]");
        private static CSSDescription contentList = new CSSDescription("ul.serp-list>li");
        private static CSSDescription contDiv = new CSSDescription("div.content__left");



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

            //Console.WriteLine(DateTime.Now+ ":clickSearh");
        }

        public static bool isSearhElementsExist()
        {
            return browser.Describe<IButton>(searhBt).Exists() && browser.Describe<IEditField>(searhTextInp).Exists();
        }

        public static int getCountContent()
        {
            var contentDiv = browser.Describe<IWebElement>(contDiv);
            contentDiv.WaitUntil(c => c.Exists() && c.IsVisible);

            //var content = browser.FindChildren<IWebElement>(contentList);
            var content = contentDiv.FindChildren<IWebElement>(contentList);
            Console.WriteLine("content lenght=" + content.Length);

            return content.Length;
        }

    }
}
