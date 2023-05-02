@Regression @Attribute_AdminOnly
Feature: Verify Attribute_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	When User setup prerequisites for attribute
		| Department         | Location         | Attribute         |
		| ATM_DEPT - GROCERY | ATM_LOC - DUNLOP | ATM_ATTR - SAFETY |
	And User logout from the application
  
Scenario: 02.verify add button is not available
	When User "admin" is authenticated with application
	Then User verify add button is not available on attribute page
	  
Scenario: 03.verify edit button is not available
	Then User verify edit button is not available in "ATM_DEPT - GROCERY" on attribute page
	
Scenario: 04.verify attribute listing is available
	Then User verify attribute listing is available on attribute page
  
Scenario: 05.verify checkboxes are disabled
	Then User verify checkboxes are disabled in "ATM_DEPT - GROCERY" on attribute page

Scenario: 06.verify added location is available
	Then User verify added location "ATM_LOC - DUNLOP" is available on attribute page
	And User logout from the application
 
@Cleanup
Scenario: 07. Cleanup and Logout
	When User "superadmin" is authenticated with application
	And User delete prerequisite records for attribute
		| Department         | Location         | Attribute         |
		| ATM_DEPT - GROCERY | ATM_LOC - DUNLOP | ATM_ATTR - SAFETY |
	And User logout from the application
	And User close browser
