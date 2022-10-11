@Regression @Location_AdminOnly
Feature: Verify Location_AdminOnly Module
@Setup
Scenario: 01. Launch Browser and Login to the Application
	Given User "$adminonly" is authenticated with "$url"

Scenario: 02. verify_add_button_is_available
	Then User verify add button is available on location page
  
Scenario: 03. verify_add_button_options_are_available
	Then User verify add button options are available on location page
 
Scenario: 04. verify_new_locations_add_popup
	Then User verify new location popup is available on location page
   
Scenario: 05. verify_added_location_is_available
	When Locations "BITS LOCATION" exists
	Then User verify created location "BITS LOCATION"

Scenario: 06. verify_new_locations_profile_add_popup
	Then User verify new location profile popup is available on location page

Scenario: 07. verify_import_locations_popup
	Then User verify import locations popup is available on location page

Scenario: 08. verify_import_locations_profile_popup
	Then User verify import locations profile popup is available on location page
	
Scenario: 09. verify_added_location_profile_is_available
	When Location profile "BITS LOCATION PROFILE" exist
	Then User verify created location profile by name "BITS LOCATION PROFILE"
	
Scenario: 10. verify_location_profile_listing_is_available
	Then User verify location profile listing is available
	
Scenario: 11. verify_location_profile_edit_options_are_available
	Then User verify location profile edit options are available in "BITS LOCATION PROFILE"

Scenario: 12. verify_checkboxes_are_available
	Then User verify checkboxes are available on location page

Scenario: 13. verify_bulk_edit_option_is_available
	Then User verify bulk edit option is available on location page
	
Scenario: 14. verify_edit_location_options_are_available
	Then User verify edit location options are available on location page

Scenario: 15. verify_edit_location_sidebar_is_available
	Then User verify edit location sidebar is available on location page

@Cleanup
Scenario: 16. Logout and Close Browser
	Given User delete records "BITS LOCATION" and "BITS LOCATION PROFILE" on location page
	When User logout from the application
	Then User close browser
