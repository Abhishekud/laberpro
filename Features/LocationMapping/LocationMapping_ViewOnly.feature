@Regression @LocationMapping_ViewOnly
Feature: Verify LocationMapping_ViewOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	When User setup prerequisites with department "DAIRYFOOD" and location "ATLANTA" for location mapping
	And User logout from the application

Scenario: 02. Verify add button is not available
	When User "viewonly" is authenticated with application
	Then User verify add button is not available for department "DAIRYFOOD" on location mapping page
  
Scenario: 03. Verify export options is available
	Then User verify export option is available on location mapping page
 
Scenario: 04. Verify save button is not available
	Then User verify save button is not available on location mapping page in  "ATLANTA"
  
Scenario: 05. Verify details are not editable
	Then User verify details are not editable on location mapping page in "ATLANTA"
	And User logout from the application

@Cleanup
Scenario: 06. Logout and Close Browser
	When User "superadmin" is authenticated with application
	And User delete prerequisites department "DAIRYFOOD" and location "ATLANTA" for location mapping
	And User logout from the application
	And User close browser
