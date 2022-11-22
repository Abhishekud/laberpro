@Regression @LaborPeriods_ViewOnly
Feature: Verify LaborPeriods_ViewOnly Module

@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User "superadmin" is authenticated with application
	And User navigates to LaborPeriod Tab
	When User Add New LaborPeriod Using Below Input if not exist
		| Key               | Value                                     |
		| Name              | laborperiodviewonly created by automation |
		| LaborPeriodType   | Hours of Operation                        |
		| TrafficPattern    | Distribute Evenly and Apply Rounding      |
		| LaborDistribution | Same As Selected Labor Period             |
	Then User logout from the application

Scenario: 02. Verify_add_button_is_not_available
	Given User "viewonly" is authenticated with application
	When User navigates to LaborPeriod Tab
	Then User verify add button is not available on labor period page
 
Scenario: 03. Verify_export_options_is_available
	When User navigates to LaborPeriod Tab
	Then User verify export option is available on labor period page
 
Scenario: 04. Verify_delete_button_and_edit_option_is_not_available
	When User navigates to LaborPeriod Tab
	Then User search LaborPeriod "laborperiodviewonly created by automation"
	When User selects LaborPeriod By Name "laborperiodviewonly created by automation"
	Then User verify delete button and edit option is not available on labor period page

@Cleanup
Scenario: 05. Logout and Close Browser
	Given User logout from the application
	When User "superadmin" is authenticated with application
	Then User navigates to LaborPeriod Tab
	When User search LaborPeriod "laborperiodviewonly created by automation"
	Then User selects LaborPeriod By Name "laborperiodviewonly created by automation"
	And User delete created LaborPeriod
	Then User logout from the application
