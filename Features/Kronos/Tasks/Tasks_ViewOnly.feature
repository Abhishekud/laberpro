@Regression @Tasks_ViewOnly
Feature: Verify Tasks_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	When User navigates to the Tasks tab
	Then User create new Tasks with below input if not exist
		| Key                   | Value                        |
		| Name                  | Tasks created via automation |
		| Generic Department    | Generic Department           |
		| Combined Distribution | Combined Distribution        |
		| Time Dependency       | Time Dependent               |
	And User logout from the application
  
   
Scenario: 02. Verify_add_button_is_not_available
	Given User "viewonly" is authenticated with application
	When User navigates to the Tasks tab
	Then User verify add button is not available on tasks page
  
Scenario: 03. Verify_export_options_are_available
	When User navigates to the Tasks tab
	Then User verify export option is available on tasks page
     
Scenario: 04. Verify_delete_button_is_not_available
	When User navigates to the Tasks tab
	Then User verify delete button is not available on tasks page on record "Tasks created via automation"
     
@Cleanup
Scenario: 05. Logout and Close Browser
	Given User logout from the application
	When User "superadmin" is authenticated with application
	Then User navigates to the Tasks tab
	And User delete Tasks "Tasks created via automation" if exist
	When User logout from the application
	Then User close browser
  
  
