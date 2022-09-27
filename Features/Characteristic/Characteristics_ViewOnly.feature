@Regression @Characteristic_ViewOnly
Feature: Verify Characteristic_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User launched "$browser"
	When User go to application "$url"
	Then User enter email: "$username_4" and password: "$password_4"
	And User navigates to the List Management tab
	And User selects Department
	And User create new Department with below input if not exist
		| Key  | Value                                        |
		| Name | Department to verify Characteristic_ViewOnly |
	And User navigates to the Characteristic tab
	And User select the Department "Department to verify Characteristic_ViewOnly"
	And User create new Characteristic with below input if not exist
		| Key  | Value                                 |
		| Name | Characteristic_created_via_automation |
	And User click on Characteristic set
	And User create new Characteristic with below input
		| Key  | Value                                    |
		| Name | Characteristicset_created_via_automation |
	And User refresh the page
	Then User logout from the application

Scenario: 02. Verify_add_button_is_not_available
	Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
	When User navigates to the Characteristic tab
	Then User select the Department "Department to verify Characteristic_ViewOnly"
	Then User verify add button is not available on characteristic page
  
Scenario: 03. Verify_export_options_are_available
	When User navigates to the Characteristic tab
	Then User verify export option is available on characteristic page
  
Scenario: 04. Verify_delete_button_is_not_available
	When User navigates to the Characteristic tab 
	Then User verify delete button is not available on characteristic page in "Characteristic_created_via_automation"
  
Scenario: 05. Verify_edit_option_is_not_available
	When User navigates to the Characteristic tab 
	Then User verify edit option is not available on characteristic page
	 
  
@Cleanup
Scenario: 06. Logout and Close Browser
	Given User logout from the application
	When User enter email: "$username_4" and password: "$password_4"
	Then User navigates to the Characteristic tab
	And User select the Department "Department to verify Characteristic_ViewOnly"
	And User delete Characteristic "Characteristic_created_via_automation" if exist
	And User navigates to the List Management tab
	And User selects Department
	And User delete created Department "Department to verify Characteristic_ViewOnly"
	And User logout from the application
	Then User close browser
  
