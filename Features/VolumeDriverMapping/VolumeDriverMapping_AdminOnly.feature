@Regression @VolumeDriverMapping_AdminOnly
Feature: Verify VolumeDriverMapping_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with "url"
	When User setup prerequisites for volume driver mapping
		| Department    | UnitsOfMeasure     | VolumeDriver    | VolumeDriverMappingSet |
		| FRUIT AND VEG | BANANAS SETUP ITEM | FRUIT ITEM SOLD | TWO-THIRDS PALLET      |
	And User logout from the application
  
Scenario: 02.verify add button is not available
	When User "admin" is authenticated with "url"
	Then User verify add button is not available in "FRUIT AND VEG" on volume driver mappings page

Scenario: 03.verify edit volume driver mapping sidebar is available
	Then User verify edit volume driver mapping sidebar is available in "FRUIT ITEM SOLD"

Scenario: 04.verify save button is not available
	Then User verify save button is not available in "FRUIT ITEM SOLD" on volume driver mapping page
  
Scenario: 05.verify delete button and edit option is not available
	Then User verify delete button and edit option is not available in "FRUIT ITEM SOLD" on volume driver mapping page

Scenario: 06.verify volume driver mapping listing is available
	Then User verify volume driver mapping listing is available on volume driver mapping page
   
Scenario: 07.verify volume driver mapping listing edit option is not available
	Then User verify volume driver mapping listing edit option is not available on volume driver mapping page
	And User logout from the application
 
@Cleanup
Scenario: 08. Cleanup and Logout
	Given User "superadmin" is authenticated with "url"
	When User delete prerequisite records for volume driver mapping
		| Department    | UnitsOfMeasure     | VolumeDriver    | VolumeDriverMappingSet |
		| FRUIT AND VEG | BANANAS SETUP ITEM | FRUIT ITEM SOLD | TWO-THIRDS PALLET      |
	And User logout from the application
	And User close browser
