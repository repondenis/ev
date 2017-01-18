using HP.LFT.SDK.StdWin;
using System;


namespace EVotingProject.Helpers
{
    class WindowsHelper
    {

        public static void setFilePath2WinDialog(string browserType, string filePath)
        {

            string browserTitle = string.Empty;
            string winClassRegExp = string.Empty;
            string winTitleRegExp = string.Empty;

            switch (browserType)
            {
                case "Chrome":

                    winClassRegExp = @"Chrome_WidgetWin_1";
                    winTitleRegExp = @" Google Chrome";
                    browserTitle = @"Открыть";
                    break;
                case "Mozilla Firefox":
                    winClassRegExp = @"MozillaWindowClass";
                    winTitleRegExp = @" Mozilla Firefox";
                    browserTitle = @"Выгрузка файла";
                    break;
                case "internet explorer":
                    //  winClassRegExp = @"";
                    winTitleRegExp = @" Internet Explorer";
                    browserTitle = @"Выбор выкладываемого файла";
                    break;
            }

           // Console.WriteLine(browserType + ", "+ winClassRegExp + ", " + winTitleRegExp);

            var chromeWind = HP.LFT.SDK.Desktop.Describe<IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = winClassRegExp,
                WindowTitleRegExp = winTitleRegExp
            });
          //  Console.WriteLine("Wind-" + chromeWind.Exists());

            var dialogWind = chromeWind.Describe<IDialog>(new DialogDescription
            {
                IsOwnedWindow = true,
                IsChildWindow = false,
                IsPopupWindow = true,
                Text = browserTitle,
                WindowTitleRegExp = browserTitle,
                IsVisible = true
            });
          //  Console.WriteLine("dialog-" + dialogWind.Exists());

            var editFileLabel = dialogWind.Describe<IEditField>(new EditFieldDescription
            {
                AttachedText = @"&Имя файла:",
                WindowClassRegExp = @"Edit",
                NativeClass = @"Edit"
            });
            editFileLabel.SetText(filePath);

            var btnOk = dialogWind.Describe<IUiObject>(new UiObjectDescription
            {
                WindowClassRegExp = @"Button",
              //  WindowId = 1,
                NativeClass = @"Button",
                WindowTitleRegExp = @"&Открыть"
            });
            btnOk.Click();

        }

    }
}
