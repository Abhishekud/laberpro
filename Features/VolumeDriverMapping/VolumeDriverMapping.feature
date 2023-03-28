@Regression @VolumeDriverMapping
Feature: Verify VolumeDriverMapping Module
@Setup @Smoke
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	When User setup prerequisites for volume driver mapping
		| Department        | UnitsOfMeasure | VolumeDriver                  | VolumeDriverMappingSet  |
		| FRESH CONVENIENCE | MILK PALLET    | CHILLED CONVENIENCE ITEM SOLD | FILL TWO THIRDS PALLETS |
@Smoke
Scenario: 02.Verify created department is available in dropdown
	Then User verify department "FRESH CONVENIENCE" is available on volume driver mapping page
  
@Smoke
Scenario: 03.Verify name input required validation message
	When User add volume driver mapping set without name
	Then User verify validation message "Name is required" on volume driver mapping set popup

@Smoke
Scenario: 04.Verify create new volume driver mapping set
	Then User verify created volume driver mapping set "FILL TWO THIRDS PALLETS"

@Smoke
Scenario: 05.Verify created volume driver and units of measure are available in dropdown
	Then User verify created volume driver and units of measure are available in "CHILLED CONVENIENCE ITEM SOLD"
  
@Cleanup @Smoke
Scenario: 06.Cleanup and Logout
	When User delete prerequisite records for volume driver mapping
		| Department        | UnitsOfMeasure | VolumeDriver                  | VolumeDriverMappingSet  |
		| FRESH CONVENIENCE | MILK PALLET    | CHILLED CONVENIENCE ITEM SOLD | FILL TWO THIRDS PALLETS |
	And User logout from the application
	And User close browser
