@Regression @Attribute
Feature: Verify Attribute Module

A short summary of the feature

@Setup @Smoke
Scenario: 01. Launch Browser and Login to the Application
	Given User "superadmin" is authenticated with application

@Smoke
Scenario: 02. verify_that_new_department_is_available_in_department_dropdown
	Given User navigates to the List Management tab
	And User selects Department
	And User create new Department with below input if not exist
		| Key  | Value            |
		| Name | ATM_DEPT - SALES |
	Then User verify created Department "ATM_DEPT - SALES"
	Then User navigates to the attribute tab
	And User select the Department "ATM_DEPT - SALES"
	Then Verify selected Department "ATM_DEPT - SALES"

@Smoke
Scenario: 03. verify_add_new_attribute_name_is_required
	Given User navigates to the attribute tab
	When User add new attribute using below input
		| Key  | Value |
		| Name |       |
	Then Verify Validation Message:"Name is required"
	And User click cancel Button

@Smoke
Scenario: 04. verify_add_new_attribute_name_already_exist
	Given User navigates to the attribute tab
	Then User delete attribute "ATM_ATTR - BIKE REPAIR" if exist
	When User add new attribute using below input
		| Key  | Value                  |
		| Name | ATM_ATTR - BIKE REPAIR |
	Then User select the Department "ATM_DEPT - SALES"
	Then User verify created attribute name "ATM_ATTR - BIKE REPAIR"
	When User add new attribute using below input
		| Key  | Value                  |
		| Name | ATM_ATTR - BIKE REPAIR |
	Then Verify Validation message :"Name already exists"
	And User click cancel Button
	Then User delete created attribute:"ATM_ATTR - BIKE REPAIR"

@Smoke
Scenario: 05. verify_add_new_attribute_by_adding_correct_record_of_name
	Given User navigates to the attribute tab
	Then User delete attribute "ATM_ATTR - BIKE" if exist
	When User add new attribute using below input
		| Key  | Value           |
		| Name | ATM_ATTR - BIKE |
	Then User select the Department "ATM_DEPT - SALES"
	Then User verify created attribute name "ATM_ATTR - BIKE"
	And User delete created attribute:"ATM_ATTR - BIKE"
	Then User navigates to the List Management tab
	And User selects Department
	Then User delete created Department "ATM_DEPT - SALES"
  
@Cleanup @Smoke
Scenario: 06. Logout and Close Browser
	When User logout from the application
	Then User close browser
