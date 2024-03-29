@Regression @Classifications_ViewOnly
Feature: Verify Classifications_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User launched "$browser"
	When User go to application "$url"
	Then User enter email: "$username_1" and password: "$password_1"
	And User navigates to the Classifications tab
	And User create new Classifications with below input if not exist
		| Key  | Value                                 |
		| Name | Classification_created_via_automation |
	Then User logout from the application
  
Scenario: 02. Verify_add_button_is_not_available
	Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
	When User navigates to the Classifications tab
	Then User verify add classification button is not Present
  
Scenario: 03. Verify_delete_button_and_edit_option_is_not_avaiable
	Given User navigates to the Classifications tab
	When User find Classification by name "Classification_created_via_automation"
	Then User verify delete classification button is not Present
	
@Cleanup
Scenario: 04. Logout and Close Browser
	Given User logout from the application
	When User enter email: "$username_1" and password: "$password_1"
	Then User navigates to the Classifications tab
	And User delete Classifications "Classification_created_via_automation" if exist
	And User logout from the application
	Then User close browser
