@Regression @VolumeDriverMapping_ViewOnly
Feature: Verify VolumeDriverMapping_ViewOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with "url"
	When User setup prerequisites for volume driver mapping
		| Department | UnitsOfMeasure     | VolumeDriver                       | VolumeDriverMappingSet  |
		| BAKERY     | PROPRIETARY CARTON | PROPRIETARY BAKERY CARTON RECEIVED | FILL TWO-THIRDS PALLETS |
	And User logout from the application
  
Scenario: 02. Verify add button is not available
	When User "viewonly" is authenticated with "url"
	Then User verify add button is not available in department "BAKERY" on volume driver mapping page
  
Scenario: 03. Verify export option is available
	Then User verify export option is available on volume driver mapping page
 
Scenario: 04. Verify delete button is not available
	Then User verify delete button is not available on volume driver mapping page in  "PROPRIETARY BAKERY CARTON RECEIVED"
  
Scenario: 05. Verify details are not editable
	Then User verify details are not editable on volume driver mapping page
	And User logout from the application
  
@Cleanup
Scenario: 06. Logout and Close Browser
	Given User "superadmin" is authenticated with "url"
	When User delete prerequisite records for volume driver mapping
		| Department | UnitsOfMeasure     | VolumeDriver                       | VolumeDriverMappingSet  |
		| BAKERY     | PROPRIETARY CARTON | PROPRIETARY BAKERY CARTON RECEIVED | FILL TWO-THIRDS PALLETS |
	And User logout from the application
	And User close browser
  
  
  
