@Regression @Allowance_ViewOnly
Feature: Verify Allowance_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with "url"
	Then User add allowance with name "MEAT ALLOWANCE" and paid time "300" for view only
	Then User logout from the application

Scenario: 02. Verify add button is not available
	When User "viewonly" is authenticated with "url"
	Then User verify add button is not available on allowance page

Scenario: 03. Verify user is able to download allowance report
	Then User verify download allowance details report for allowance: "MEAT ALLOWANCE"

Scenario: 04. Verify copy option is not available
	Then User verify copy option is not available on allowance page
	And User logout from the application

@Cleanup
Scenario: 05. Logout and Close Browser
	When User "superadmin" is authenticated with "url"
	And User delete record of allowance "MEAT ALLOWANCE"
	And User logout from the application
	And User close browser