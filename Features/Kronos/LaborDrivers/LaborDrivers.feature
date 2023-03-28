@Regression @LaborDrivers
Feature: Verify LaborDrivers Module

@Setup @Smoke
Scenario: 01. Launch Browser and Login to the Application
	Given User "superadmin" is authenticated with application
  
@Smoke
Scenario: 02. Verify_that_Click_on_New_Labor_Driver_Opens_Add_popup.
	Given User navigates to the LaborDrivers tab
	When User clicks Add LaborDrivers Button
	Then User verify Add Menu Popup
	And User clicks cancel Button
  
@Smoke
Scenario: 03. verify_add_LaborDrivers_when_enter_blank_details
	Given User navigates to the LaborDrivers tab
	When User create new LaborDrivers with below input
		| Key  | Value |
		| Name |       |
	Then Verify validation Message: "Labor Driver Name is required."
	And User clicks cancel Button
  
@Smoke
Scenario: 04. Verify_that_if_VolumeDriver_is_selected_fields_get_populated
	Given User navigates to the LaborDrivers tab
	When User create new LaborDrivers with below input
		| Key         | Value                       |
		| Name        | LaborDrivers Exist Scenario |
		| Driver Type | Volume Driver               |
	Then User verify Add Menu Popup
	And User clicks cancel Button
  
@Smoke
Scenario: 05. verify_add_LaborDrivers_when_enter_existing_details
	Given User navigates to the LaborDrivers tab
	Then User delete LaborDrivers "LaborDrivers Exist Scenario" if exist
	When User create new LaborDrivers with below input
		| Key                                             | Value                       |
		| Name                                            | LaborDrivers Exist Scenario |
		| Driver Type                                     | Volume Driver               |
		| Number                                          | 2                           |
		| Number of business days to look back for volume | 2                           |
		| Driver                                          | Drivers                     |
		| Generic Category                                | Generic Category            |
	And User verify created LaborDrivers "LaborDrivers Exist Scenario"
	When User create new LaborDrivers with below input
		| Key                                             | Value                       |
		| Name                                            | LaborDrivers Exist Scenario |
		| Driver Type                                     | Volume Driver               |
		| Number                                          | 2                           |
		| Number of business days to look back for volume | 2                           |
		| Driver                                          | Drivers                     |
		| Generic Category                                | Generic Category            |
	Then Verify validation Message: "Labor Driver Name must be unique."
	And User clicks cancel Button
	And User delete created LaborDrivers "LaborDrivers Exist Scenario"
  
@Cleanup @Smoke
Scenario: 06. Logout and Close Browser
	When User logout from the application
	Then User close browser
  
  
