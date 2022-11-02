@Regression @VolumeDriverValueSet
Feature: Verify VolumeDriverValueSet Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with "url"
	When User setup prerequisites for volume driver value set
		| Department | Location     | UnitsOfMeasure | VolumeDriver   |
		| ATM DPT    | ATM LOCATION | ATM UOM        | ATM VOL DRIVER |

Scenario: 02. Verify popup when click on new volume driver value set
	Then User verify new volume driver value set popup

Scenario: 03. Verify create new volume driver value set
	When User add new volume driver value set
		| VolumeDriverValueSet | Location     | Department | VolumeDriver   | Value | LocationDescription |
		| ATM VDVS             | ATM LOCATION | ATM DPT    | ATM VOL DRIVER | 2     | ATM LOCATION        |
	Then User verify created volume driver value set "ATM VDVS"
   
Scenario: 04. Verify name input required validation message
	When User add volume driver value set without name
	Then User verify validation message "Name is required" on volume driver value set popup

Scenario: 05. Verify Volume Driver Value file is required
	When User add new volume driver value set without file "ATM VDV"
	Then User verify validation message "Volume Driver Value file is required" on volume driver value set popup

Scenario: 06. Verify duplicate message name already exist
	When User add new volume driver value set for duplication "ATM VDVS"
	Then User verify validation message "Name already exists" on volume driver value set popup

Scenario: 07. Verify delete volume driver value set
	When User delete volume driver value set "ATM VDVS"
	Then User verify volume driver value set "ATM VDVS" not available

Scenario: 08. Verify delete button disabled for default volume driver value set
	Then User verify delete button is disabled in default volume driver value set "Default VDV Set"

Scenario: 09. Verify volume driver values export option is available
	Then User verify export option on volume driver values page

@Cleanup
Scenario: 10. Logout and Close Browser
	When User delete prerequisite records for volume driver value set
		| Department | Location     | UnitsOfMeasure | VolumeDriver   |
		| ATM DPT    | ATM LOCATION | ATM UOM        | ATM VOL DRIVER |
	And User logout from the application
	And User close browser
