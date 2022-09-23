using Figgle;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Framework.Support
{
    public class TestBase
    {
        private readonly IScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly string _screenShotDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\Screenshots\\"));

        public TestBase(ScenarioContext scenarioContext, SpecflowWebDriver specflowWebDriver)
        {          
            _scenarioContext = scenarioContext;
            _webDriver = specflowWebDriver.WebDriver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                string fileName = _screenShotDirectory + Regex.Replace(TestContext.CurrentContext.Test.FullName, "[^a-z0-9\\-_]+", "_", RegexOptions.IgnoreCase) + ".png";
                ((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);
                OutputTestFailureContext(_scenarioContext.TestError);
            }
            _webDriver.Quit();
        }

        public void OutputTestFailureContext(Exception exception)
        {
            Console.WriteLine(
                FiggleFonts.Broadway.Render("Context:") + "\n \n" +
                $"Failing Test: {TestContext.CurrentContext.Test.FullName} \n \n" +
                $"Screenshot: {_screenShotDirectory + TestContext.CurrentContext.Test.FullName} \n \n" +
                $"Url: {_webDriver.Url} \n \n" +
                
                FiggleFonts.Broadway.Render("\n \n Exception: \n \n") + "\n \n" +
                exception.ToString() +
                
                FiggleFonts.Broadway.Render("\n \n Stack Trace: \n \n") +
                Environment.StackTrace);
        }
    }
}