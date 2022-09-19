@Regression @VolumeDriverValue_ViewOnly
Feature: Verify VolumeDriverValue_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application
	Given User launched "$browser"
	When User go to application "$url"
	Then User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
	And Verify Login message: "success"

Scenario: 02. Verify_add_button_is_not_available
	When User navigates to volume driver values tab
	Then User verify add button is not available on volume driver values page

Scenario: 03. Verify_export_option_is_available
	When User navigates to volume driver values tab
	Then User verify export option is available on volume driver values page

@Cleanup
Scenario: 04. Logout and Close Browser
	When User logout from the application
	Then User close browser