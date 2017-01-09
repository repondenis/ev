using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.SDK.Web;
using HP.LFT.Verifications;
using EVotingProject.Pages;
using HP.LFT.Report;
using System.Diagnostics;

namespace EVotingProject
{
    [TestFixture]
    [Description("Old Tests")]
    public class LeanFtTest : UnitTestClassBase
    {


        private string url = "http://yandex.ru";

        [OneTimeSetUp]// [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
        }

        [SetUp]
        public void SetUp()
        {
            browser = BrowserFactory.Launch(BrowserType.Chrome);
            //browser.Navigate(this.url);
        }

        [Test]
        [Description("TestInputFile")]
        public void TestInputFile()
        {
            /*
            var urlUni = "http://саратов.окна.рф/%D0%9A%D0%BE%D0%BC%D0%BF%D0%B0%D0%BD%D0%B8%D0%B8/f2221-%D0%9A%D0%BE%D1%80%D0%BE%D0%BB%D0%B5%D0%B2%20%D0%94%D0%9D";
            CSSDescription uniPin = new CSSDescription("input[name='pincode']");
            CSSDescription uniSubm = new CSSDescription("input[type='submit']");
            browser.Navigate(urlUni);
            browser.Sync();
            var input = browser.Describe<IEditField>(uniPin);
            var submit = browser.Describe<IWebElement>(uniSubm);

            // browser.Page.RunJavaScript("document.querySelector('div.popup').style.display='none';");
            for (int i = 0370; i <= 9999; i++) {
                input.SetValue(i.ToString().PadLeft(4,'0'));
                submit.Click();
            }
            */


            var urlTrue = "http://www.softpost.org/selenium-test-page/";
            var cssTrue = "input[type='file']";



            string filePath = @"D:\temp\str2.jpg";

            var url2 = "http://www.uniplast-kbe.ru/test/1.php";
            var css1 = "input#upload_hidden";
            var css2 = "input#upload_hidden_2";
            var css3 = "input#upload_hidden_3";
            var css4 = "input#upload_hidden_4";
            var css5 = "input.upload_hidden_5";

            browser.Navigate(url2);
            browser.Sync();


            // Console.WriteLine(browser.Page.RunJavaScript("document.querySelector('#upload_hidden_4').style.position"));


            //    Console.WriteLine("className is " + browser.Page.RunJavaScript("document.getElementById('upload_hidden').style.overflow;"));

            //string query2 = browser.Page.RunJavaScript("document.getElementById('upload_hidden').style.overflow='visible';");


            string query4 = browser.Page.RunJavaScript(
                 "document.getElementById('upload_hidden').style.overflow='visible'; " +
                 "document.getElementById('upload_hidden').style.display='inline-block'; " +
                 "document.getElementById('upload_hidden').style.opacity=1; " +
                 "document.getElementById('upload_hidden').style.top=0; " +
                 "document.getElementById('upload_hidden').style.left=0; " +
                 "document.getElementById('upload_hidden').style.width=100; " +
                 "document.getElementById('upload_hidden').style.height=20; " +
                 "document.getElementById('upload_hidden').style.filter=''; " +
                 "document.getElementById('upload_hidden').style.position='relative'; " +
                 "document.getElementById('upload_hidden_2').style.overflow='visible'; " +
                 "document.getElementById('upload_hidden_2').style.display='inline-block'; " +
                 "document.getElementById('upload_hidden_2').style.opacity=1; " +
                 "document.getElementById('upload_hidden_2').style.top=0; " +
                 "document.getElementById('upload_hidden_2').style.left=0; " +
                 "document.getElementById('upload_hidden_2').style.width=100; " +
                 "document.getElementById('upload_hidden_2').style.height=20; " +
                 "document.getElementById('upload_hidden_2').style.filter=''; " +
                 "document.getElementById('upload_hidden_2').onchange=''; " +
                 "document.getElementById('upload_hidden_2').style.position='relative'; " +
                 "document.getElementById('upload_hidden_3').style.overflow='visible'; " +
                 "document.getElementById('upload_hidden_3').style.display='inline-block'; " +
                 "document.getElementById('upload_hidden_3').style.opacity=1; " +
                 "document.getElementById('upload_hidden_3').style.top=0; " +
                 "document.getElementById('upload_hidden_3').style.left=0; " +
                 "document.getElementById('upload_hidden_3').style.width=100; " +
                 "document.getElementById('upload_hidden_3').style.height=20; " +
                 "document.getElementById('upload_hidden_3').style.filter=''; " +
                 "document.getElementById('upload_hidden_3').style.position='relative'; " +

                                 /*             "document.querySelector('input.upload_hidden_5').style.overflow='visible'; " +
                                            "document.querySelector('input.upload_hidden_5').style.display='inline-block'; " +
                                            "document.querySelector('input.upload_hidden_5').style.opacity=1; " +
                                            "document.querySelector('input.upload_hidden_5').style.top=0; " +
                                            "document.querySelector('input.upload_hidden_5').style.left=0; " +
                                            "document.querySelector('input.upload_hidden_5').style.width=100; " +
                                            "document.querySelector('input.upload_hidden_5').style.height=20; " +
                                            "document.querySelector('input.upload_hidden_5').style.filter=''; " +
                                            "document.querySelector('input.upload_hidden_5').style.position='relative'; " +
                 */
                                 "document.getElementById('form:j_idt52').style.overflow='visible'; " +
                                   "document.getElementById('form:j_idt52').style.display='inline-block'; " +
                                   "document.getElementById('form:j_idt52').style.opacity=1; " +
                                   "document.getElementById('form:j_idt52').style.top=0; " +
                                   "document.getElementById('form:j_idt52').style.left=0; " +
                                   "document.getElementById('form:j_idt52').style.width=100; " +
                                   "document.getElementById('form:j_idt52').style.height=20; " +
                                   "document.getElementById('form:j_idt52').style.filter=''; " +
                                   "document.getElementById('form:j_idt52').style.position='relative'; " +

                 "document.getElementById('upload_hidden_4').style.overflow='visible'; " +
                 "document.getElementById('upload_hidden_4').style.opacity=1; " +
                 "document.getElementById('upload_hidden_4').style.top=0; " +
                 "document.getElementById('upload_hidden_4').style.left=0; " +
                 "document.getElementById('upload_hidden_4').style.width=100; " +
                 "document.getElementById('upload_hidden_4').style.height=20; " +
                 "document.getElementById('upload_hidden_4').style.filter=''; " +
                 "document.getElementById('upload_hidden_4').style.position='relative'; " +
                 "document.getElementById('upload_hidden_4').style.display='inline-block'; "
                 );

            // Console.WriteLine("className_2 is " + query4);

            //  Console.WriteLine(browser.Page.RunJavaScript("document.querySelector('#upload_hidden_4').style.position"));
            //  browser.Page.RunJavaScript("document.getElementsByTagName('input').style.display='inline-block';");



            //browser.Page.RunJavaScript("for (el of document.getElementsByTagName('input')){el.style.display='inline-block';}");
            //   browser.Describe<IFileField>(new CSSDescription(css1)).Click();
            //  browser.Describe<IFileField>(new CSSDescription(css2)).Click();
            //   browser.Describe<IFileField>(new CSSDescription(css3)).Click();
            //   browser.Describe<IFileField>(new CSSDescription(css4)).Click();
            //   browser.Describe<IFileField>(new CSSDescription(css5)).Click();



            /*          try
                      {
                          browser.Describe<IFileField>(new CSSDescription(css1)).SetValue(filePath);//ok
                      }
                      catch (Exception e)
                      {

                          Console.WriteLine(e.Message + " " + e.Source + " " + e.StackTrace);
                      }
                      try
                      {
                          browser.Describe<IFileField>(new CSSDescription(css2)).SetValue(filePath);//ok
                      }
                      catch (Exception e)
                      {
                          Console.WriteLine(e.Message + " " + e.Source + " " + e.StackTrace);
                      }
                      try
                      {
                          browser.Describe<IFileField>(new CSSDescription(css3)).SetValue(filePath);//ok
                      }
                      catch (Exception e)
                      {
                          Console.WriteLine(e.Message + " " + e.Source + " " + e.StackTrace);
                      }
                      try
                      {
                          browser.Describe<IFileField>(new CSSDescription(css4)).SetValue(filePath);//ok
                      }
                      catch (Exception e)
                      {
                          Console.WriteLine(e.Message + " " + e.Source + " " + e.StackTrace);
                      }
          */
            try
            {
                browser.Describe<IFileField>(new CSSDescription(css5)).SetValue(filePath);//ok
                Reporter.ReportEvent("TestYandex", "Failed during validation", Status.Passed, browser.GetSnapshot());
            }
            catch (Exception e)
            {
                Console.WriteLine("css5 - " + e.Message + " " + e.Source + " " + e.StackTrace);
                Reporter.ReportEvent("TestYandex", "Failed during validation", Status.Failed, e);
            }


            /*
            IFileField inpfil = browser.Describe<IFileField>(new CSSDescription(css1));

            if (inpfil.Exists())
            {
                inpfil.SetValue(@"D:\temp\str2.jpg");
                Console.WriteLine(inpfil.Value);
            }
            */





        }

     //   [TestCase(true, TestName = "Tест пройден, №503770", Description = "тест пройден")]
      //  [TestCase(false, TestName = "Tест не пройден, №503723", Description = "тест не пройден")]
     //   [Ignore("тестовый яндекс тест")]
        public void Test1(bool state)
        {
            Assert.True(state);
        }

     //   [Test]
     //   [Ignore("тестовый яндекс тест")]
        public void TestYandex()
        {
            try
            {
                browser.Navigate(this.url);
                YandexPage.setBrowser(browser);
                YandexPage.sendText("бензин");
                Assert.True(YandexPage.isSearhElementsExist());
                YandexPage.clickSearh();
                Assert.GreaterOrEqual(YandexPage.getCountContent(), 0);
                //Assert.True(browser.URL.Contains("text=%D0%B1%D0%B5%D0%BD%D0%B7%D0%B8%D0%BD"));
            }
            catch (AssertionException e)
            {
                Reporter.ReportEvent("TestYandex", "Failed during validation", Status.Failed, e);
                throw;
            }
        }




      //  [Test]
     //   [Ignore("тестовый тест")]
        public void Verify_SearchSuggestionsArePresentedAndMoreThan0()
        {

            browser.Navigate("http://www.google.com");

            // Use try-catch to add a warning to the run report if the assert validation fails.          
            try
            {
                // Enter the value "LeanFT" in the search box.
                var search = browser.Describe<IEditField>(new EditFieldDescription
                {
                    Name = "q"
                });
                search.SetValue("LeanFT");

                // Simulate a single key down event to trigger the opening of the suggestion box.
                search.FireEvent(EventInfoFactory.CreateEventInfo("onkeydown"));



                // Identify the suggestion box using a CSS selector and wait until the suggestion box opens.
                /*var suggestions = browser.Describe<IWebElement>(new WebElementDescription
                {
                    CSSSelector = @".sbsb_a",
                });*/
                var sbsb = new CSSDescription(".sbsb_a");
                var suggestions = browser.Describe<IWebElement>(sbsb);
                suggestions.WaitUntil(s => s.Exists() && s.IsVisible);

                var suggestionList = suggestions.FindChildren<IWebElement>(new WebElementDescription
                {
                    TagName = "LI"
                });


                // Enclosing the Assert method in a try-catch statement ensures the application 
                // does not throw a runtime error if the Assert returns false. 

                // Verify that the suggestion box exists and contains content.
                Assert.IsTrue(suggestions.IsVisible);
                Assert.Greater(suggestionList.Length, 0);

            }
            catch (AssertionException e)
            // Adds a step to the run report on failure.
            {
                Reporter.ReportEvent("Verify_SearchSuggestionsAreOpenUponUserInput", "Failed during validation", HP.LFT.Report.Status.Failed, e);
                browser.Close();
                throw;
            }

        }


        [TearDown]
        public void TearDown()
        {
            browser.Close();
        }

        [OneTimeTearDown]//[TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }



        public void TestCalculator()
        {
            //  SDK.Init(new SdkConfiguration());

            Reporter.Init(new ReportConfiguration());
            Process.Start(@"C:\Windows\System32\calc.exe");



            var win = Desktop.Describe<HP.LFT.SDK.StdWin.IWindow>(new HP.LFT.SDK.StdWin.WindowDescription
            {
                IsOwnedWindow = false,
                IsChildWindow = false,
                WindowClassRegExp = @"CalcFrame",
                WindowTitleRegExp = @"Калькулятор"
            });

            var bt8 = win.Describe<HP.LFT.SDK.StdWin.IButton>(new HP.LFT.SDK.StdWin.ButtonDescription
            {
                Text = @"8",
                NativeClass = @"Button"
            });

            Console.WriteLine(win.Text + " " + win.WindowTitleRegExp);
            Console.WriteLine(bt8.WindowTitleRegExp);

            bt8.Click();


            var result = win.Describe<HP.LFT.SDK.StdWin.IStatic>(new HP.LFT.SDK.StdWin.StaticDescription
            {
                WindowId = 150,
                NativeClass = @"Static"
            });
            Trace.WriteLine("Result text contains " + result.Text);


            Trace.WriteLine("Result of addition is " + result.Text);
            Assert.AreEqual("8", result.Text, "Addition of 8");
            win.Close();
            Reporter.GenerateReport();
            //  SDK.Cleanup();

        }





    }
}
