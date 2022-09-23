using OpenQA.Selenium;
using Framework.Factories;

namespace Framework.Support
{
    public sealed class SpecflowWebDriver
    {
        public IWebDriver WebDriver { get; }

        public SpecflowWebDriver()
        {
            WebDriver = WebDriverFactory.Create();
        }
    }
}
