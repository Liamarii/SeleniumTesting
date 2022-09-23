@Accounts

Feature: AccountCreation
	As a user
	I want the ability to create an account
	So that I can place orders

Background: 
	Given I am on the Login page

Scenario: Users can create a new account and login
	Given I provide valid registration details
	 When I create the account
	  And I logout
	 Then I am now able to login with the new credentials