@Regression @Location_AdminOnly
Feature: Verify Location_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application
	Given User "admin" is authenticated with application

Scenario: 02. verify add button is available
	Then User verify add button is available on location page
  
Scenario: 03. verify add button options are available
	Then User verify add button options are available on location page
 
Scenario: 04. verify new locations add popup
	Then User verify new location popup is available on location page
   
Scenario: 05. verify added location is available
	When User create new location "BITS LOCATION"
	Then User verify created location "BITS LOCATION"

Scenario: 06. verify new locations profile add popup
	Then User verify new location profile popup is available on location page

Scenario: 07. verify import locations popup
	Then User verify import locations popup is available on location page

Scenario: 08. verify import locations profile popup
	Then User verify import locations profile popup is available on location page
	
Scenario: 09. verify added location profile is available
	When User create new location profile "BITS LOCATION PROFILE"
	Then User verify created location profile by name "BITS LOCATION PROFILE"
	
Scenario: 10. verify location profile listing is available
	Then User verify location profile listing is available
	
Scenario: 11. verify location profile edit options are available
	Then User verify location profile edit options are available in "BITS LOCATION PROFILE"

Scenario: 12. verify checkboxes are available
	Then User verify checkboxes are available on location page

Scenario: 13. verify bulk edit option is available
	Then User verify bulk edit option is available on location page
	
Scenario: 14. verify edit location options are available
	Then User verify edit location options are available on location page

Scenario: 15. verify edit location sidebar is available
	Then User verify edit location sidebar is available on location page

@Cleanup
Scenario: 16. Logout and Close Browser
	Given User delete records "BITS LOCATION" and "BITS LOCATION PROFILE" on location page
	When User logout from the application
	Then User close browser
