using OpenQA.Selenium;
using Framework.Constants;
using Framework.Support;
using OpenQA.Selenium.Support.UI;
using System;
using Framework.Pages;

namespace Framework.Pages
{
    public sealed class RegistrationPage : Page
    {
        public RegistrationPage(SpecflowWebDriver specflowWebDriver) : base(specflowWebDriver) { }
        public IWebElement CustomerFirstNameField => WebDriver.FindElement(By.Id(RegistrationPageConstants.CustomerFistNameFieldId));
        public IWebElement CustomerLastNameField => WebDriver.FindElement(By.Id(RegistrationPageConstants.CustomerLastNameFieldId));
        private SelectElement DateOfBirthDay => new(WebDriver.FindElement(By.Id(RegistrationPageConstants.DateOfBirthDayId)));
        private SelectElement DateOfBirthMonth => new(WebDriver.FindElement(By.Id(RegistrationPageConstants.DateOfBirthMonthId)));
        private SelectElement DateOfBirthYear => new(WebDriver.FindElement(By.Id(RegistrationPageConstants.DateOfBirthYearId)));
        public IWebElement AddressFirstNameField => WebDriver.FindElement(By.Id(RegistrationPageConstants.AddressFistNameFieldId));
        public IWebElement AddressLastNameField => WebDriver.FindElement(By.Id(RegistrationPageConstants.AddressLastNameFieldId));
        public IWebElement PasswordField => WebDriver.FindElement(By.Id(RegistrationPageConstants.PasswordFieldId));
        public IWebElement AddressLineOneField => WebDriver.FindElement(By.Id(RegistrationPageConstants.AddressLineOneFieldId));
        public IWebElement CityField => WebDriver.FindElement(By.Id(RegistrationPageConstants.CityFieldId));
        public IWebElement StateField => WebDriver.FindElement(By.Id(RegistrationPageConstants.StateFieldId));
        public IWebElement ZipPostCodeField => WebDriver.FindElement(By.Id(RegistrationPageConstants.ZipPostalCodeFieldId));
        public IWebElement MobilePhoneField => WebDriver.FindElement(By.Id(RegistrationPageConstants.MobilePhoneId));
        public IWebElement RegisterBtn => WebDriver.FindElement(By.Id(RegistrationPageConstants.RegisterBtnId));
        public IWebElement SignOutBtn => WebDriver.FindElement(By.ClassName(RegistrationPageConstants.SignOutBtnClass));

        public void SelectTitle(Title title)
        {
            switch (title)
            {
                case Title.Mr:
                    WebDriver.FindElement(By.Id(RegistrationPageConstants.TitleMrRadioBtnId)).Click();
                    break;
                case Title.Mrs:
                    WebDriver.FindElement(By.Id(RegistrationPageConstants.TitleMrsRadioBtnId)).Click();
                    break;
                default: throw new NotImplementedException($"Unable to select gender {title}");
            }
        }

        public void DateOfBirth(int day, int month, int year)
        {
            DateOfBirthDay.SelectByValue(day.ToString());
            DateOfBirthMonth.SelectByValue(month.ToString());
            DateOfBirthYear.SelectByValue(year.ToString());
        }
    }
}