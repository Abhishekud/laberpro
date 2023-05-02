@Regression @Activity_ViewOnly
Feature: Verify Activity_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	And User create new activity "ATM_ACT - BITS"
	And User logout from the application
   
Scenario: 02. Verify add button is not available
	When User "viewonly" is authenticated with application
	Then User verify add button is not available in activity
	 
Scenario: 03. Verify delete button and edit option is not available
	Then User verify delete and edit option is not available for activity "ATM_ACT - BITS"
	And User logout from the application
	
@Cleanup
Scenario: 04. Cleanup and Logout
	When User "superadmin" is authenticated with application
	And User delete activity "ATM_ACT - BITS"
	And User logout from the application
	And User close browser
