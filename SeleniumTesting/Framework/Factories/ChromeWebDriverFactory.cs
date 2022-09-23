using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Framework.Factories
{
    public static class ChromeWebDriverFactory
    {
        public static IWebDriver Create(TimeSpan commandTimeout, TimeSpan searchTimeout, bool incognito = false)
        {
            IWebDriver webDriver = new ChromeDriver(Service(), Options(incognito), commandTimeout);
            webDriver.Manage().Timeouts().ImplicitWait = searchTimeout;
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }

        private static ChromeOptions Options(bool incognito)
        {
            var options = new ChromeOptions();
            options.AddArgument("-no-sandbox");
            options.AddArgument("ignore-certificate-errors");
            options.AddUserProfilePreference("download.default_directory", "%temp%");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            options.AddUserProfilePreference("profile.content_settings.exceptions.automatic_downloads.*.setting", 1);
            if (incognito)
            {
                options.AddArgument("--incognito");
            }
            options.AddUserProfilePreference("download.prompt_for_download", false);
            return options;
        }

        private static ChromeDriverService Service()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            return service;
        }
    }
}