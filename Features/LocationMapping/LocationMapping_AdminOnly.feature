@Regression @LocationMapping_AdminOnly
Feature: Verify LocationMapping_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "user1" is authenticated with "url"
	When Location "BITS LOCATION" and Department "BITS DEPARTMENT" mapping exists
	And User logout from the application
  
Scenario: 02.verify add button is not available
	When User "admin" is authenticated with "url"
	Then User verify add button is not available in "BITS DEPARTMENT" on location mapping page
  
Scenario: 03.verify edit locationmapping sidebar is available
	Then User verify edit location mapping sidebar is available in "BITS LOCATION"
     
Scenario: 04.verify edit detail options are not available
	Then User verify edit detail options are not available in "BITS LOCATION" on location mapping page
   
Scenario: 05.verify save button is not available
	Then User verify save button is not available in "BITS LOCATION" on location mapping page
	And User logout from the application
  
@Cleanup
Scenario: 06. Logout and Close Browser
	Given User "user1" is authenticated with "url"
	When User delete records "BITS LOCATION" and "BITS DEPARTMENT" on location mapping page
	And User logout from the application
	And User close browser