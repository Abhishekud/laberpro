@Regression @TaskGroups_ViewOnly
Feature: Verify TaskGroups_ViewOnly Module

	@Setup
	Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
		Given User launched "$browser"
		When User go to application "$url"
		Then User enter email: "$username_1" and password: "$password_1"
		And User navigates to the TaskGroups tab
		And User create new TaskGroups with below input if not exist
			| Key                   | Value                             |
			| Name                  | TaskGroups created via automation |
			| Generic Department    | Generic Department                |
			| Combined Distribution | Combined Distribution             |
			| Allocate Labor Hours  | Start Day                         |
			| Job Name              | Job Name                          |
		Then User logout from the application
	  
	   
	Scenario: 02. Verify_add_button_is_not_available
		Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
		When User navigates to the TaskGroups tab
		Then User verify add button is not available on task group page
	 
	Scenario: 03. Verify_export_options_are_available
		When User navigates to the TaskGroups tab
		Then User verify export option is available on task groups page
	  
	Scenario: 04. Verify_delete_button_is_not_available
		When User navigates to the TaskGroups tab
		Then User verify delete button is not available on task groups page in  "TaskGroups created via automation"

	@Cleanup
	Scenario: 05. Logout and Close Browser
		Given User logout from the application
		When User enter email: "$username_1" and password: "$password_1"
		Then User navigates to the TaskGroups tab
		And User delete TaskGroups "TaskGroups created via automation" if exist
		And User logout from the application
		Then User close browser
  
  
