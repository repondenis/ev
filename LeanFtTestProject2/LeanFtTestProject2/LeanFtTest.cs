using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Report;
using HP.LFT.SDK.StdWin;
using System.Diagnostics;

namespace LeanFtTestProject2
{
    [TestFixture]
    public class LeanFtTest : UnitTestClassBase
    {



        [TestCase]
        public void TestCalculator()
        {
            SDK.Init(new SdkConfiguration());

            Reporter.Init(new ReportConfiguration());
            Process.Start(@"C:\Windows\System32\calc.exe");



            var calcWin = Desktop.Describe<HP.LFT.SDK.StdWin.IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"CalcFrame",
                WindowTitleRegExp = @"Калькулятор"
            });

            var bt8 = calcWin.Describe<HP.LFT.SDK.StdWin.IButton>(new ButtonDescription
            {
                Text = @"8",
                NativeClass = @"Button"
            });

            Console.WriteLine(calcWin.Text);
            Console.WriteLine(bt8.WindowTitleRegExp);

            IWindow win = Desktop.Describe<HP.LFT.SDK.StdWin.IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"CalcFrame",
                WindowTitleRegExp = @"Калькулятор"
            });

            Console.WriteLine("Calculator window title is " + win.WindowTitleRegExp);


            var button8 = win.Describe<HP.LFT.SDK.StdWin.IButton>(new HP.LFT.SDK.StdWin.ButtonDescription
            {
                Text = string.Empty,
                WindowId = 138,
                NativeClass = @"Button"
            });
            button8.Click();

            var result = win.Describe<IStatic>(new StaticDescription
            {
                WindowId = 150,
                NativeClass = @"Static"
            });
            Trace.WriteLine("Result text contains " + result.Text);


            Trace.WriteLine("Result of addition is " + result.Text);
            Assert.AreEqual("11", result.Text, "Addition of 8 and 3");
            win.Close();
            Reporter.GenerateReport();
            SDK.Cleanup();

        }


    }
}
