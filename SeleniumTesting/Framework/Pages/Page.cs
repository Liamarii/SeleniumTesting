using OpenQA.Selenium;
using Framework.Support;

namespace Framework.Pages
{
    public class Page
    {
        public Page(SpecflowWebDriver specflowWebDriver) => WebDriver = specflowWebDriver.WebDriver;
        public IWebDriver WebDriver { get; }
    }
}
