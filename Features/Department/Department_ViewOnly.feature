﻿@Regression @Department_ViewOnly
Feature: Verify Department_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application
	Given User "superadmin" is authenticated with application
	And User navigates to the List Management tab
	And User selects Department
	And User delete Department "Department to verify Department_ViewOnly" if exist
	And User create new Department with below input
		| Key  | Value                                    |
		| Name | Department to verify Department_ViewOnly |
	And User verify created Department "Department to verify Department_ViewOnly"
	Then User logout from the application
  
Scenario: 02. Verify_add_button_is_not_available
	Given User "viewonly" is authenticated with application
	When User navigates to the List Management tab
	Then User selects Department
	And User verify add button is not available on department page
  
Scenario: 03. Verify_export_option_is_not_available
	Given User navigates to the List Management tab
	When User selects Department
	Then User verify export option is not available on department page
  
Scenario: 04. Verify_delete_button_and_edit_option_is_not_available
	Given User navigates to the List Management tab
	When User selects Department
	Then User verify delete button and edit option is not available for department record "Department to verify Department_ViewOnly"
     
@Cleanup
Scenario: 05. Logout and Close Browser
	Given User logout from the application
	When User "superadmin" is authenticated with application
	Then User navigates to the List Management tab
	And User selects Department
	And User delete Department "Department to verify Department_ViewOnly" if exist
	And User logout from the application
	Then User close browser
  
