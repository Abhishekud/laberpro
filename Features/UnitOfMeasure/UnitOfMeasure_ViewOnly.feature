@Regression @UnitOfMeasure_ViewOnly
Feature: Verify UnitOfMeasure_ViewOnly Module

A short summary of the feature
@Setup
Scenario: 01. Launch Browser and Login to the Application
	Given User "superadmin" is authenticated with application
	Then User navigates to the List Management tab
	And User selects Department
	And User create new Department with below input if not exist
		| Key  | Value                                       |
		| Name | Department To verify UnitOfMeasure_ViewOnly |
	And User selects UnitOfMeasure
	And User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
	And User delete UnitOfMeasure "UOM" if exist
	And User adds Unit Of Measure using below input
		| Key  | Value |
		| Name | UOM   |
	And User verify Added Unit of Measure "UOM"
	Then User logout from the application
  
Scenario: 02. Verify_add_button_is_not_available
	Given User "viewonly" is authenticated with application
	When User navigates to the List Management tab
	Then User selects UnitOfMeasure
	And User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
	Then User verify add button is not present on units of measure page
  
Scenario: 03. Verify_export_options_is_not_available
	Given User navigates to the List Management tab
	When User selects UnitOfMeasure
	And User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
	Then User verify export option is not present on units of measure page
  
Scenario: 04. Verify_delete_button_and_edit_option_is_not_available
	Given User navigates to the List Management tab
	When User selects UnitOfMeasure
	And User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
	Then User verify delete button and edit option is not present for record "UOM" on units of measure page
    
  
@Cleanup
Scenario: 05. Logout and Close Browser
	Given User logout from the application
	When User "superadmin" is authenticated with application
	Then User navigates to the List Management tab
	And User selects UnitOfMeasure
	And User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
	And User delete UnitOfMeasure "UOM" if exist
	And User selects Department
	And User delete created Department "Department To verify UnitOfMeasure_ViewOnly"
	And User logout from the application
	Then User close browser
  
  
