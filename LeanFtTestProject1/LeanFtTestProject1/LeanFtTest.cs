using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK;
using HP.LFT.UnitTesting;
using HP.LFT.Common;
using HP.LFT.SDK.Web;
using HP.LFT.Report;
using HP.LFT.SDK.StdWin;
using System.Diagnostics;

namespace LeanFtTestProject1
{
    [TestFixture]
    public class LeanFtTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [Test]
        public void Test()
        {
            Console.WriteLine("Test");
        }

        [Test]
        public void TestCalculator()
        {
            SDK.Init(new SdkConfiguration());
            Reporter.Init(new ReportConfiguration());
            Process.Start(@"C:\Windows\System32\calc.exe");
            IWindow win = Desktop.Describe<IWindow>(new WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"CalcFrame",
                WindowTitleRegExp = @"Calculator"
            });

            Console.WriteLine("Calculator window title is " + win.WindowTitleRegExp);
            Trace.WriteLine("Calculator window title is " + win.WindowTitleRegExp);


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

            //  var calculatorModel = new CalculatorModel();
            //  calculatorModel.CalculatorWindow.ButtonPlus.Click();
            //  calculatorModel.CalculatorWindow.Button3.Click();
            //  calculatorModel.CalculatorWindow.ButtonEquals.Click();
            Trace.WriteLine("Result of addition is " + result.Text);
            Assert.AreEqual("11", result.Text, "Addition of 8 and 3");
            win.Close();
            Reporter.GenerateReport();
            SDK.Cleanup();

        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
