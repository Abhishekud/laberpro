@Regression @Classifications_AdminOnly
Feature: Verify Classifications_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	When User create classifications "CUSTOMER"
	And User logout from the application
  
Scenario: 02. Verify add button is not available
	When User "admin" is authenticated with application
	Then User verify add button is not available on classifications page
  
Scenario: 03. Verify delete button and edit option is not available
	Then User verify delete button and edit option is not available in "CUSTOMER" on classifications page
	And User logout from the application
	
@Cleanup
Scenario: 04. Cleanup and Logout
	Given User "superadmin" is authenticated with application
	When User delete classifications "CUSTOMER"
	And User logout from the application
	And User close browser
