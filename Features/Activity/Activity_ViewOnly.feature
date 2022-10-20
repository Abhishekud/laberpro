@Regression @Activity_ViewOnly
Feature: Verify Activity_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User launched "$browser"
	When User go to application "$url"
	Then User enter email: "$username_2" and password: "$password_2"
	And User navigates to the Activity tab
	And User create new Activity with below input if not exist
		| Key  | Value                           |
		| Name | Activity_created_via_automation |
	Then User logout from the application
   
Scenario: 02. Verify_add_button_is_not_available
	Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
	When User navigates to the Activity tab
	Then User verify Add Button is not Present in Activity
	 
Scenario: 03. Verify_delete_button_and_edit_option_is_not_avaiable
	Given User navigates to the Activity tab
	When User find Activity by name "Activity_created_via_automation"
	Then User verify Activity Delete Button is not Present
	  
@Cleanup 
Scenario: 04. Logout and Close Browser 
    Given User logout from the application 
	When User enter email: "$username_2" and password: "$password_2"
	Then User navigates to the Activity tab
	And User delete created Activity by name "Activity_created_via_automation"
	And User logout from the application
	Then User close browser
  
