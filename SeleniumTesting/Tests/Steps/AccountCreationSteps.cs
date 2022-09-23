using NUnit.Framework;
using Framework.Pages;
using Framework.Support;
using TechTalk.SpecFlow;
using System;
using Framework.Models;

namespace SpecflowTests.Steps
{
    [Binding]
    public sealed class AccountCreationSteps : TestBase
    {
        private readonly User _user;
        private readonly LoginPage _loginPage;
        private readonly RegistrationPage _registrationPage;
        private readonly DataGenerator _dataGenerator;

        public AccountCreationSteps(
            LoginPage loginPage,
            RegistrationPage registrationPage,
            ScenarioContext scenarioContext,
            SpecflowWebDriver specflowWebDriver ) : base(scenarioContext, specflowWebDriver)
        {
            _loginPage = loginPage;
            _registrationPage = registrationPage;
            _dataGenerator = new();
            _user = new();
        }

        [Given(@"I am on the Login page")]
        public void NavigateToLoginPage()
        {
            _loginPage.GoTo();
        }

        [Given(@"I provide valid registration details")]
        public void PopulateValidAccountRegistrationDetails()
        {
            //Assert.True(1 == 2); Uncomment this to cause a failure which will take a screenshot. 
            _loginPage.NewEmailField.SendKeys(_user.Email);
            _loginPage.CreateAccountBtn.Click();
            _registrationPage.SelectTitle(new Random().Next(0,1) < 1? Title.Mr : Title.Mrs);
            _registrationPage.CustomerFirstNameField.SendKeys(_user.FirstName);
            _registrationPage.CustomerLastNameField.SendKeys(_user.LastName);
            _registrationPage.PasswordField.SendKeys(_user.Password);
            _registrationPage.DateOfBirth(Faker.RandomNumber.Next(1, 28), Faker.RandomNumber.Next(1, 12), Faker.RandomNumber.Next(1950, 2010));
            _registrationPage.AddressLineOneField.SendKeys(Faker.Address.StreetName());
            _registrationPage.CityField.SendKeys(Faker.Address.City());
            _registrationPage.StateField.SendKeys(Faker.Address.UsState());
            _registrationPage.ZipPostCodeField.SendKeys(_dataGenerator.GenerateRandomString(5, CharacterSet.Numeric));
            _registrationPage.MobilePhoneField.SendKeys(_dataGenerator.GenerateRandomString(11, CharacterSet.Numeric));
        }

        [When(@"I create the account")]
        public void ClickRegister()
        {
            _registrationPage.RegisterBtn.Click();
        }

        [When(@"I logout")]
        public void Logout()
        {
            _registrationPage.SignOutBtn.Click();
        }

        [Then(@"I am now able to login with the new credentials")]
        public void SignIn()
        {
            _loginPage.CurrentEmailField.SendKeys(_user.Email);
            _loginPage.CurrentPasswordField.SendKeys(_user.Password);
            _loginPage.SignInBtn.Click();
            Assert.That(_loginPage.NavigationBarContainsName($"{_user.FirstName} {_user.LastName}"), Is.True);
        }
    }
}