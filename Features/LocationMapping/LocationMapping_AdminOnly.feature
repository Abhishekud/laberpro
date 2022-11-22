@Regression @LocationMapping_AdminOnly
Feature: Verify LocationMapping_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	When User setup prerequisites with department "CAFE" and location "MAWSON" for location mapping
	And User logout from the application
  
Scenario: 02.verify add button is not available
	When User "admin" is authenticated with application
	Then User verify add button is not available in "CAFE" on location mapping page
  
Scenario: 03.verify edit locationmapping sidebar is available
	Then User verify edit location mapping sidebar is available in "MAWSON"
     
Scenario: 04.verify edit detail options are not available
	Then User verify edit detail options are not available in "MAWSON" on location mapping page
   
Scenario: 05.verify save button is not available
	Then User verify save button is not available in "MAWSON" on location mapping page
	And User logout from the application
  
@Cleanup
Scenario: 06. Cleanup and Logout
	When User "superadmin" is authenticated with application
	And User delete prerequisites department "CAFE" and location "MAWSON" for location mapping
	And User logout from the application
	And User close browser