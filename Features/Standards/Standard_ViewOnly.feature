@Regression @Standard_ViewOnly
Feature: Verify Standard_ViewOnly Module

@Setup @Smoke
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	And User navigates to the List Management tab
	And User selects Department
	Then User create new Department with below input if not exist
		| Key  | Value                             |
		| Name | department for standards viewonly |
	And User navigates to the List Management tab
	And User selects UnitOfMeasure
	And User Selects Created Department "department for standards viewonly"
	Then User create new UnitOfMeasure with below input if not exist
		| Key  | Value    |
		| Name | Demo Uom |
	And User navigates to the standards tab
	And User delete Standard "name to verify viewonly" if exist
	Then User add new standards using below input
		| Key        | Value                             |
		| Name       | name to verify viewonly           |
		| Department | department for standards viewonly |
	And User click on previous link
	And User search standard by name "name to verify viewonly"
	And User selects standard by name "name to verify viewonly"
	Then User clicks New Standard Element
	And User Selects Standard Element type "Estimate"
	Then User adds new Standard Element Using Below input
		| Key             | Value    |
		| Name            | Dummy    |
		| Frequency       | 16       |
		| Unit of Measure | Demo Uom |
	And User click on previous link
	Then User logout from the application

Scenario: 02. Verify_add_button_is_not_available
	Given User "viewonly" is authenticated with application
	When User navigates to the standards tab
	Then User verify add button is not available on standard page

Scenario: 03. Verify_edit_option_is_not_available
	Given User navigates to the standards tab
	Then User search standard by name "name to verify viewonly"
	And User selects standard by name "name to verify viewonly"
	Then User verify edit button is not available on standard details page

Scenario: 04. Verify_export_option_is_available
	When User navigates to the standards tab
	Then User verify export option is available on standard page
    
Scenario: 05. Verify_download_report_option_is_available
	Given User navigates to the standards tab
	When User search standard by name "name to verify viewonly"
	And User selects standard by name "name to verify viewonly"
	Then User verify download report option is available

Scenario: 06. Verify_add_button_is_not_available_for_standard_element
	Given User navigates to the standards tab
	When User search standard by name "name to verify viewonly"
	And User selects standard by name "name to verify viewonly"
	Then User verify add button is not available for standard element on standard details page

Scenario: 07. Verify_add_option_is_not_available_for_standard_group
	Given User navigates to the standards tab
	When User search standard by name "name to verify viewonly"
	And User selects standard by name "name to verify viewonly"
	Then User verify add option is not available for standard group on standard details page

Scenario: 08. Verify_tick_option_in_existing_standard_element_is_not_available
	Given User navigates to the standards tab
	When User search standard by name "name to verify viewonly"
	And User selects standard by name "name to verify viewonly"
	Then User verify tick option in existing standard element is not available

Scenario: 09. Verify_download_report_option_for_selected_standard_in_standard_listing_is_available
	Given User navigates to the standards tab
	When User search standard by name "name to verify viewonly"
	And User selects standard in standard listing
	Then User verify download report option is available
    
Scenario: 10. Verify_export_option_for_selected_standard_in_standard_listing_is_available
	Given User navigates to the standards tab
	When User search standard by name "name to verify viewonly"
	And User selects standard in standard listing
	Then User verify export option is available on standard page

@Cleanup @Smoke
Scenario: 11. Logout and Close Browser
	Given User logout from the application
	When User "superadmin" is authenticated with application
	Then Verify Login message: "success"
	And User navigates to the standards tab
	And User search standard by name "name to verify viewonly"
	And User selects standard by name "name to verify viewonly"
	Then User Delete created Standards
	And User navigates to the List Management tab
	And User selects Department
	And User delete created Department "department for standards viewonly"
	And User logout from the application
	Then User close browser
