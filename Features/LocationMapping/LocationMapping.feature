@Regression @LocationMapping
Feature: Verify LocationMapping Module
@Setup
Scenario: 01. Launch Browser and Login to the Application
	Given User "superadmin" is authenticated with application
	And User create prerequisites record for location mapping
		| Department | Location | CharacteristicSet | VolumeDriverMappingSet |
		| MEAT       | MASCOT   | STORE SERVICES    | MEAT REDESIGN          |

Scenario: 02. Verify created department is available in dropdown
	Then User verify department "MEAT" and record is "No records available" on location mapping page
 
Scenario: 03. Verify mapping of department with location
	Then User verify department "MEAT" and location "MASCOT" are mapped on location mapping page

Scenario: 04. Verify created volume driver mapping set and characterstics set are available in dropdown
	Then User verify location mapping 
		| Department | Location | CharacteristicSet | VolumeDriverMappingSet |
		| MEAT       | MASCOT   | STORE SERVICES    | MEAT REDESIGN          |

@Cleanup
Scenario: 05. Logout and Close Browser
	When User delete prerequisites department "MEAT" and location "MASCOT" for location mapping
	And User logout from the application
	And User close browser