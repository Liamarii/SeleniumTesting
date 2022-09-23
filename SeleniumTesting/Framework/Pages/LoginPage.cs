using OpenQA.Selenium;
using Framework.Constants;
using Framework.Support;

namespace Framework.Pages
{
    public sealed class LoginPage : Page
    {
        public LoginPage(SpecflowWebDriver specflowWebDriver) : base(specflowWebDriver) { }
        public IWebElement CurrentEmailField => WebDriver.FindElement(By.Id(LoginPageConstants.CurrentEmailFieldId));
        public IWebElement NewEmailField => WebDriver.FindElement(By.Id(LoginPageConstants.NewEmailFieldId));
        public IWebElement CurrentPasswordField => WebDriver.FindElement(By.Id(LoginPageConstants.CurrentPasswordFieldId));
        public IWebElement SignInBtn => WebDriver.FindElement(By.Id(LoginPageConstants.SignInBtnId));
        public IWebElement CreateAccountBtn => WebDriver.FindElement(By.Id(LoginPageConstants.CreateAccountBtnId));
        public IWebElement NavigationBarAccountBtn => WebDriver.FindElement(By.ClassName(LoginPageConstants.NavigationBarAccountBtnClass));
        public void LoginAs(string accountEmail, string accountPassword)
        {
            CurrentEmailField.SendKeys(accountEmail);
            CurrentPasswordField.SendKeys(accountPassword);
            SignInBtn.Click();
        }
        public void GoTo() => WebDriver.Navigate().GoToUrl(LoginPageConstants.Url);
        public bool NavigationBarContainsName(string name) => NavigationBarAccountBtn.GetAttribute("innerHTML").Contains(name);
    }
}