@Regression @Attribute
Feature: Verify Attribute_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	And User navigates to the List Management tab
	And User selects Department
	And User create new Department with below input if not exist
		| Key  | Value            |
		| Name | ATM_DEPT - STAFF |
	And User navigates to the attribute tab
	Then User select the Department "ATM_DEPT - STAFF"
	And User delete attribute "ATM_ATTR - DEPOSIT" if exist
	And User add new attribute using below input
		| Key  | Value              |
		| Name | ATM_ATTR - DEPOSIT |
	And User refresh the page
	And User logout from the application

Scenario: 02. Verify_add_button_is_not_available
	Given User "viewonly" is authenticated with application
	When User navigates to the attribute tab
	Then User select the Department "ATM_DEPT - STAFF"
	Then User verify add button is not present in attribute module

Scenario: 03. Verify_export_options_are_available
	Given User navigates to the attribute tab
	Then User select the Department "ATM_DEPT - STAFF"
	Then User verify click on export icon verify all options displayed in attribute module

Scenario: 04. Verify_dialog_box_is_available
	Given User navigates to the attribute tab
	Then User select the Department "ATM_DEPT - STAFF"
	When User click on export icon in attribute module
	Then User select export attribute import template in attribute template
	Then User verify the dialog box asking for file name for attribute module

Scenario: 05. Verify_user_is_able_to_download_attribute_import_template
	Given User navigates to the attribute tab
	Then User select the Department "ATM_DEPT - STAFF"
	When User click on export icon in attribute module
	Then User select download attribute import template in attribute module
	And User verify attribute downloaded file "Attributes-import-template"

Scenario: 06. Verify_user_is_able_to_download_all_locations_attribute_import_template
	Given User navigates to the attribute tab
	Then User select the Department "ATM_DEPT - STAFF"
	When User click on export icon in attribute module
	Then User select download all locations attribute import template in attribute module
	And User verify attribute downloaded file "All-location-attributes-import-template"

Scenario: 07. Verify_edit_button_is_not_available
	Given User navigates to the attribute tab
	Then User select the Department "ATM_DEPT - STAFF"
	Then user verify edit button is not present in attribute module

@Cleanup
Scenario: 08. Logout and Close Browser
	Given User logout from the application
	When User "superadmin" is authenticated with application
	Then User navigates to the attribute tab
	And User select the Department "ATM_DEPT - STAFF"
	And User delete created attribute:"ATM_ATTR - DEPOSIT"
	And User navigates to the List Management tab
	And User selects Department
	And User delete created Department "ATM_DEPT - STAFF"
	And User logout from the application
	Then User close browser
