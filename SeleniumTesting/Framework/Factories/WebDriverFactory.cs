using OpenQA.Selenium;
using System;

namespace Framework.Factories
{
    internal static class WebDriverFactory
    {
        public static IWebDriver Create(string browser = "Chrome", TimeSpan? commandTimeout = null, TimeSpan? searchTimeout = null, bool incognito = false)
        {
            var webDriverCommandTimeout = commandTimeout ?? TimeSpan.FromSeconds(30);
            var webDriverSearchTimeout = searchTimeout ?? TimeSpan.FromSeconds(30);

            return browser.ToLower() switch
            {
                "chrome" => ChromeWebDriverFactory.Create(webDriverCommandTimeout, webDriverSearchTimeout, incognito),
                _ => throw new NotImplementedException(),
            };
        }
    }
}