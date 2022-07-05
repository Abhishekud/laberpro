@Regression @Locations_ViewOnly
Feature:Verify Locations_ViewOnly module

   @Setup 
   Scenario: 01. Launch Browser and Login to the Application and perform prerequisite
	Given User launched "$browser"
	When User go to application "$url"
	Then User enter email: "$username_1" and password: "$password_1"
	And User navigates to the Locations tab
    And User create new location with below input if not exist
    | Key               | Value                                   |
    | Name              | Location_viewonly created via automation |
	And User navigates to the List Management tab
	And User selects Department
	And User delete Department "Department for location_viewonly" if exist
	And  User create new Department with below input
	| Key  | Value                           | 
    | Name | Department for location_viewonly| 
	Then User logout from the application 
	
   Scenario: 02. Verify_add_button_is_not_available
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
	When User navigates to the Locations tab
	Then User verify add button is not available on location page

   Scenario: 03. Verify_export_option_is_available
    When User navigates to the Locations tab
    Then User verify export option is available on location page

   Scenario: 04. Verify_export_option_is_available_for_location_profile
    When User navigates to the Locations tab
	Then User verify export option is available for location profile

   Scenario: 05. Verify_edit_option_is_not_available
    Given User navigates to the Locations tab
	When User selects location by name "Location_viewonly created via automation"
	Then User verify edit option is not available on location page

   Scenario: 06. Verify_delete_button_is_not_available
    Given User navigates to the Locations tab
	When User selects location by name "Location_viewonly created via automation"
	Then User verify delete button is not available on location page

   Scenario: 07. Verify_mapping_option_between_location_and_department_is_not_available
    When User navigates to the Locations tab
	Then User verify location record "Location_viewonly created via automation" and department record "Department for location_viewonly" cannot be mapped

   @Cleanup
   Scenario: 08. Logout and Close Browser
    Given User logout from the application
	When User enter email: "$username_1" and password: "$password_1"
	Then User navigates to the List Management tab
     And User selects Department
     And User delete Department "Department for location_viewonly" if exist
     And User navigates to the Locations tab
     And User delete location by name "Location_viewonly created via automation" if exist
     And User logout from the application
     Then User close browser
