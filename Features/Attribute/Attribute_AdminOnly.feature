@Regression @Attribute_AdminOnly
Feature: Verify Attribute_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with "url"
	When User setup prerequisites for attribute
		| Department | Location | Attribute |
		| GROCERY    | DUNLOP   | SAFETY    |
	And User logout from the application
  
Scenario: 02.verify add button is not available
	When User "admin" is authenticated with "url"
	Then User verify add button is not available on attribute page
	  
Scenario: 03.verify edit button is not available
	Then User verify edit button is not available in "GROCERY" on attribute page
	
Scenario: 04.verify attribute listing is available
	Then User verify attribute listing is available on attribute page
  
Scenario: 05.verify checkboxes are disabled
	Then User verify checkboxes are disabled in "GROCERY" on attribute page

Scenario: 06.verify added location is available
	Then User verify added location "DUNLOP" is available on attribute page
	And User logout from the application
 
@Cleanup
Scenario: 07. Logout and Close Browser
	Given User "superadmin" is authenticated with "url"
	When User delete prerequisite records for attribute
		| Department | Location | Attribute |
		| GROCERY    | DUNLOP   | SAFETY    |
	And User logout from the application
	And User close browser
