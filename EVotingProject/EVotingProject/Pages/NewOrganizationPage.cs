using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK.Web;
using HP.LFT.SDK;
using HP.LFT.SDK.StdWin;


namespace EVotingProject.Pages
{
    class NewOrganizationPage : Helpers.PageHelper
    {
        private static CSSDescription orgProfileTitle = new CSSDescription("div#org-profile>label.main-header-page");//"Сбербанк России ОАО"

        //MENU
        private static XPathDescription menuMeeting = new XPathDescription(".//a[text()='Собрания']");
        private static XPathDescription menuUsers = new XPathDescription(".//a[text()='Пользователи']");
        private static XPathDescription menuDocuments = new XPathDescription(".//a[text()='Договоры']");
        private static XPathDescription menuProfileOrg = new XPathDescription(".//a[text()='Профиль организации']");

        private static CSSDescription titlePanel = new CSSDescription("div#branding-block-info label.main-header-page");

        private static CSSDescription divBranding = new CSSDescription("div#branding-block");

        //делегировано регистратору
        private static XPathDescription createNewMeeting = new XPathDescription(
            ".//div[@id='branding-block-delegating'] //tbody/tr[1]/td[1]/div/div/input");//Создание (инициация) новых собраний
        private static XPathDescription manageSettingsMeeting = new XPathDescription(
            ".//div[@id='branding-block-delegating'] //tbody/tr[1]/td[3]/div/div/input");
        private static XPathDescription adminForums = new XPathDescription(
            ".//div[@id='branding-block-delegating'] //tbody/tr[2]/td[1]/div/div/input");

        private static XPathDescription loadLogo = new XPathDescription(
            ".//button[span[text()='Загрузить логотип']]");
        private static XPathDescription loadLogoHeader = new XPathDescription(
            ".//a[span[contains(text(),'ЗАГРУЗИТЬ ЛОГОТИП ШАПКИ')]]");
        private static XPathDescription loadLogoList = new XPathDescription(
            ".//a[span[contains(text(),'ЗАГРУЗИТЬ ЛОГОТИП СПИСКА')]]");

        private static XPathDescription colorHeader = new XPathDescription(
            ".//div[@id='branding-block-edit']/div[2]/div[3]/div/input");//цвет шапки
        private static XPathDescription colorButton = new XPathDescription(
            ".//div[@id='branding-block-edit']/div[2]/div[5]/div/input");//цвет шапки

        private static CSSDescription divPrev = new CSSDescription("div#divPrev");//style="background:#009900;"
        private static XPathDescription samplesButton = new XPathDescription(
            ".//button[span[text()='Пример кнопки']]");//background:#edff21"

        private static XPathDescription saveB = new XPathDescription(
            ".//button[span[text()='Сохранить']]");


        public static bool? isOpenFileDialog()
        {
            string browserTitle = string.Empty;

            switch (browser.Version.Type)
            {
                case "Chrome":
                    browserTitle = @"Открыть";
                    break;
                case "Mozilla Firefox":
                    browserTitle = @"Выгрузка файла";
                    break;
                case "internet explorer":
                    browserTitle = @"Выбор выкладываемого файла";
                    break;
            }

            var openFileDialog = Desktop.Describe<IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                Text = @"НРД - Google Chrome",
                WindowClassRegExp = @"Chrome_WidgetWin_1",
                NativeClass = @"Chrome_WidgetWin_1",
                WindowTitleRegExp = @" Google Chrome"
            }).Describe<IDialog>(new DialogDescription
            {
                IsOwnedWindow = true,
                IsChildWindow = false,
                Text = @"Открыть",
                WindowTitleRegExp = @"Открыть"
            });

            Console.WriteLine(openFileDialog.Exists());
            return openFileDialog.Exists();
        }

        public static void clickOkOfOpenFileDialog()
        {
            //openFileDialog.clickOk();
        }
        public static void clickCancelOfOpenFileDialog()
        {
            //openFileDialog.clickCancel();
        }

        public static void selectLogoFileOfDialog(string filePathHeader)
        {


            if (System.IO.File.Exists(filePathHeader))
            {
                Console.WriteLine(browser.Version.Type);

                // openFileDialog.select(filePathHeader);



            }
        }



        public static bool isTruePage(string org)
        {
            browser.Sync();
            return browser.Describe<IWebElement>(orgProfileTitle).Exists() && browser.Describe<IWebElement>(orgProfileTitle).InnerText.Equals(org);
        }

        public static bool isTitlePanelExist(string text)
        {
            browser.Sync();
            return browser.Describe<IWebElement>(titlePanel).Exists() && browser.Describe<IWebElement>(titlePanel).InnerText.Equals(text);
        }

        public static void save()
        {
            browser.Describe<HP.LFT.SDK.Web.IButton>(saveB).Click();
        }

        public static bool isSaveExist()
        {
            return browser.Describe<HP.LFT.SDK.Web.IButton>(saveB).Exists() && browser.Describe<HP.LFT.SDK.Web.IButton>(saveB).IsEnabled;
        }

        public static void gotoMenuMeeting()
        {
            browser.Describe<ILink>(menuMeeting).Click();
        }
        public static void gotoMenuUsers()
        {
            browser.Describe<ILink>(menuUsers).Click();
        }



        public static void gotoMenuDocuments()
        {
            browser.Describe<ILink>(menuDocuments).Click();
        }
        public static void gotoMenuProfileOrg()
        {
            browser.Describe<ILink>(menuProfileOrg).Click();
        }

        public static void clickLoadLogo()
        {

            browser.Describe<HP.LFT.SDK.Web.IButton>(loadLogo).Click();
        }

        public static void clickLoadLogoHeader()
        {
            // browser.getPage().runJavaScript("window.scrollTo(120,100);");
            browser.Page.RunJavaScript("window.scrollTo(120,1000);");

            /*
                        CSSDescription scriptCss = new CSSDescription("#uploaderHeaderLogo>script");
                        var script = browser.Describe<IWebElement>(scriptCss);
                        // Console.WriteLine(script.InnerText);
                        Console.WriteLine(script);


                        //browser.Page.RunJavaScript("$('#uploaderHeaderLogo input[type=file]').click(); PrimeFaces.ab({ s: 'j_idt56:brandInfo:j_idt99',f: 'j_idt56:brandInfo'});");// ("$('#uploaderHeaderLogo input[type=file]');");

                        browser.Page.RunJavaScript(
                            "document.getElementById('uploaderHeaderLogo').getElementsByTagName('input').click();");
            */
            //contentDiv.WaitUntil(c => c.Exists() && c.IsVisible);

            // CSSDescription loadLogoHeader2 = new CSSDescription("#uploaderListLogo input[type=file]");

            /*
                        var bt = browser.Describe<HP.LFT.SDK.Web.IButton>(new CSSDescription("#uploaderHeaderLogo input[type=file]"));
                        bt.FireEvent(EventInfoFactory.CreateEventInfo("onclick"));
                        Console.WriteLine(bt.Exists() + " " + bt.IsVisible + " " + bt.DisplayName);
                        bt.Click();
            */
            
            //browser.EmbedScript("document.getElementById('uploaderHeaderLogo').getElementsByTagName('input').click();");
            var loadLogoHeaderBt = browser.Describe<HP.LFT.SDK.Web.IFileField>(new CSSDescription("#uploaderListLogo input[type=file]"));
 //           loadLogoHeaderBt.WaitUntil(logo => logo.Exists() && logo.IsVisible);

            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateEventInfo("click"));
            //            Console.WriteLine(loadLogoHeaderBt.Location.X + " " + loadLogoHeaderBt.Location.Y + " " + loadLogoHeaderBt.Size.Height + " " + loadLogoHeaderBt.Size.Width);
            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnMouseOver));
           // loadLogoHeaderBt.Highlight();
            loadLogoHeaderBt.HoverTap();
            loadLogoHeaderBt.Click();
            // browser.Page.RunJavaScript("var el = document.elementFromPoint(" + loadLogoHeaderBt.Location.X + 10 + ", " + loadLogoHeaderBt.Location.Y + 10 + ");el.click();");

            Console.WriteLine(loadLogoHeaderBt.Exists() + " " + loadLogoHeaderBt.IsVisible + " " + loadLogoHeaderBt.DisplayName);


            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateEventInfo("click()"));
            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnClick));
            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnMouseDown));
            loadLogoHeaderBt.LongPress();
            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateEventInfo("click"));
            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateEventInfo("onclick"));
            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateEventInfo("onclick()"));
            loadLogoHeaderBt.Click();
            loadLogoHeaderBt.Click(MouseButton.Left);




            /*
            var loadLogoHeaderBt = browser.Describe<ILink>(loadLogoHeader);
            Console.WriteLine("(loadLogoHeader).Exists=" + loadLogoHeaderBt.Exists());
            //loadLogoHeaderBt.Highlight();

            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateEventInfo("keydown"));
             loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnMouseOver));
            loadLogoHeaderBt.FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnClick));

              loadLogoHeaderBt.Click();
             loadLogoHeaderBt.DoubleClick();


            // ////////////

          //  clickLoadLogo();
          /

            XPathDescription loadLogoHeader2 = new XPathDescription(
               ".//a/span[contains(text(),'ЗАГРУЗИТЬ ЛОГОТИП ШАПКИ')]");
            var loadLogoHeaderBt2 = browser.Describe<IWebElement>(loadLogoHeader2);
            // loadLogoHeaderBt2.Highlight();

            loadLogoHeaderBt2.FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnMouseOver));
            loadLogoHeaderBt2.FireEvent(EventInfoFactory.CreateMouseEventInfo(MouseEventTypes.OnClick));

            loadLogoHeaderBt2.Click();
            // ////////////////////////////
            clickLoadLogo();
            CSSDescription x = new CSSDescription("div[role='menu']>ul>li[role='menuitem']:nth-child(1)");
            var loadLogoHeaderBt3 = browser.Describe<IWebElement>(x);
            Console.WriteLine("(loadLogoHeaderBt3).Exists=" + loadLogoHeaderBt3.Exists());
            loadLogoHeaderBt3.Click();
            // ///////////////////
            clickLoadLogo();
            CSSDescription y = new CSSDescription("#uploaderListLogo input[type=file]");
            var loadLogoHeaderBt4 = browser.Describe<IWebElement>(y);
            Console.WriteLine("(loadLogoHeaderBt4).Exists=" + loadLogoHeaderBt4.Exists());
            loadLogoHeaderBt4.Click();
            */
        }

        public static void clickLoadLogoList()
        {
            browser.Describe<ILink>(loadLogoList).Click();
        }

        public static void setColorHeader(string color)
        {
            browser.Describe<HP.LFT.SDK.Web.IEditField>(colorHeader).SetValue(color);
        }

        public static void setColorButton(string color)
        {
            browser.Describe<HP.LFT.SDK.Web.IEditField>(colorButton).SetValue(color);
        }
    }
}
