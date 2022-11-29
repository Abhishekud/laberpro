@Regression @Classifications_ViewOnly
Feature: Verify Classifications_ViewOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	When User create classifications "COVERAGE"
	And User logout from the application
  
Scenario: 02. Verify add button is not available
	When User "viewonly" is authenticated with application
	Then User verify add classification button is not available
  
Scenario: 03. Verify delete button and edit option is not available
	Then User verify delete classification button is not available in "COVERAGE"
	And User logout from the application
	
@Cleanup
Scenario: 04. Cleanup and Logout
	Given User "superadmin" is authenticated with application
	When User delete classifications "COVERAGE"
	And User logout from the application
	And User close browser
