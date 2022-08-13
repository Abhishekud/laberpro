@Regression @ExistingIndustryStandard
Feature: Verify ExistingIndustryStandard Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User launched "$browser"
	When User go to application "$url"
	Then User enter email: "$username_3" and password: "$password_3"
	And User navigates to the List Management tab
	And User selects Department
	And User create new Department with below input if not exist
		| Key  | Value                                           |
		| Name | Department_to_verify_existing_industry_standard |
	And User navigates to the standards tab
	Then User delete the record with department by name "Department_to_verify_existing_industry_standard"

Scenario: 02. Verify_add_button_is_available
	When User navigates to the standards tab
	Then User verify add button is available

Scenario: 03. Verify_existing_industry_standard_and_new_standard_options_are_available
	When User navigates to the standards tab
	Then User verify existing industry standard and new standard options are available

Scenario: 04. Verify_industry_standard_data_is_available
	When User navigates to the existing industry standard tab
	Then User verify industry standard data is available

Scenario: 05. Verify_import_department_sidebar_is_available
	When User navigates to the existing industry standard tab
	Then User verify import department sidebar is available 

Scenario: 06. Verify_alert_message_when_no_industry_standard_is_selected
	Given User navigates to the existing industry standard tab
	When User clicks on add button
	Then User verify industry standard error alert toast message "No industry standards selected"
	
Scenario: 07. Verify_different_industry_typical_department_option_is_available
	When User navigates to the existing industry standard tab
	Then User verify industry typical department option on industry standard page 

Scenario: 08. Verify_add_industry_standard
	Given User navigates to the existing industry standard tab
	When User selects the department by name "Department_to_verify_existing_industry_standard"
	Then User selects the first record
	And User clicks on add button
	Then User verify industry standard alert toast message "1 Industry Standard added."

Scenario: 09. Verify_force_use_of_standard_id
	Given User navigates to the existing industry standard tab
	When User selects the department by name "Department_to_verify_existing_industry_standard"
	Then User selects the second record
	And User clicks on add button
	Then User verify force use of standard id by alert message "1 Industry Standard added."

Scenario: 10. Verify_industry_standard_details_are_available
	When User navigates to the existing industry standard tab
	Then User verify industry standard details are available
	
Scenario: 11. Verify_standard_details_are_available_when_click_on_any_record
	When User navigates to the existing industry standard tab
	Then User verify standard details page is available

Scenario: 12. Verify_industry_standard_details_sidebar_is_available
	When User navigates to the existing industry standard tab
	Then User verify industry standard details sidebar is available

Scenario: 13. Verify_element_detail_page_is_available
	When User navigates to the existing industry standard tab
	Then User verify element detail page is available

@Cleanup
Scenario: 14. Logout and Close Browser
	Given User navigates to the standards tab
	When User delete the record with department by name "Department_to_verify_existing_industry_standard"
	Then User navigates to the List Management tab
	And User selects Department
	And User delete created Department "Department_to_verify_existing_industry_standard"
	And User logout from the application
	Then User close browser