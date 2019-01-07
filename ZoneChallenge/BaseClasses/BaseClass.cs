using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using log4net;
using ZoneChallenge.Helpers;

namespace ZoneChallenge.BaseClasses
{
    [TestClass]
    public class BaseClass
    {
        public static IWebDriver Driver;

        // For additional logging with Log4Net
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected BaseClass()
        {
        }

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void InitialiseBrowser()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            // options.AddArgument("--window-size=1280,1024");

            // For mobile uncomment next line
            // options.EnableMobileEmulation("Nexus 5");
            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            Log.Info("Browser initialised with options: " + options);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ScreenshotOnFailure();
            //ext.ReportJsErrors();
            //_driver.Close();
            Driver.Quit();
            Log.Info("Test clean up complete");
        }

        public void ScreenshotOnFailure()
        {
            var date = GeneralHelper.GetTimeStamp(DateTime.Now, "yyyyMMdd");
            var time = GeneralHelper.GetTimeStamp(DateTime.Now, "HHmmss");
            var resultsDir = TestContext.TestResultsDirectory;
            var path = resultsDir + @"\Screenshots\Exceptions\" + date + "-" + time + @"\";
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Failed) return;
            Log.Info("TEST FAILED");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var ss = ((ITakesScreenshot)Driver).GetScreenshot();
            var ssFilename = path + @"\" + TestContext.TestName + "_" + TestContext.CurrentTestOutcome.ToString().ToUpper() + ".png";
            ss.SaveAsFile(ssFilename, ScreenshotImageFormat.Png);
            TestContext.AddResultFile(ssFilename);
            Log.Info("Screenshot saved");
        }
    }

}
