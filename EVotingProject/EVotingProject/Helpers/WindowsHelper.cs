//using HP.LFT.SDK;
//using HP.LFT.SDK;
using HP.LFT.SDK.StdWin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVotingProject.Helpers
{
    class WindowsHelper
    {

        public static void isWindowExist(string browserType)
        {

            string browserTitle = string.Empty;
            switch (browserType)
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

            Console.WriteLine(browserType);

            var notepadWindow = HP.LFT.SDK.Desktop.Describe<IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"Notepad",
                WindowTitleRegExp = @"Безымянный — Блокнот"
            });

            Console.WriteLine("notepadWindow - " + notepadWindow.Exists());

            HP.LFT.SDK.Desktop.Describe<IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"Chrome_WidgetWin_1",
                WindowTitleRegExp = @" Google Chrome"
            }).Describe<IDialog>(new DialogDescription
            {
                IsOwnedWindow = true,
                IsChildWindow = false,
                IsPopupWindow = true,
                Text = @"Открыть",
                WindowTitleRegExp = @"Открыть",
                IsVisible = true
            }).Exists();

            HP.LFT.SDK.Desktop.Describe<IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"Chrome_WidgetWin_1",
                WindowTitleRegExp = @" Google Chrome"
            }).Describe<IDialog>(new DialogDescription
            {
                IsOwnedWindow = true,
                IsChildWindow = false,
                Text = @"Открыть",
                NativeClass = @"#32770",
                WindowTitleRegExp = @"Открыть"
            }).Describe<IEditField>(new EditFieldDescription
            {
                AttachedText = @"&Имя файла:",
                WindowClassRegExp = @"Edit",
                NativeClass = @"Edit"
            }).Exists();

        }

    }
}
