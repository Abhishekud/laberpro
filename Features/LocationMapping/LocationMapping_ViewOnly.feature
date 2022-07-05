﻿@Regression @LocationMapping_ViewOnly
Feature: Verify LocationMapping_ViewOnly Module

@Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    And User enter email: "$username_3" and password: "$password_3"
    And User navigates to the List Management tab
    And User selects Department
    And User delete Department "Department_for_LocationMapping_via_automation" if exist
    And User create new Department with below input
      | Key  | Value                                         | 
      | Name | Department_for_LocationMapping_via_automation |  
    Then User navigates to the Locations tab
    And User create new location with below input if not exist
      | Key  | Value                        | 
      | Name | Location_created_via_autoamtion |  
    And User Maps created Department and location with "Location_created_via_autoamtion" and "Department_for_LocationMapping_via_automation"
    And User click on LocationMapping
    And User select the department "Department_for_LocationMapping_via_automation" on location mapping page
    Then User logout from the application 

  Scenario: 02. Verify_add_button_is_not_available
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the LocationMapping tab
    And User select the department "Department_for_LocationMapping_via_automation" on location mapping page
    Then User verify add button is not available on location mapping page   

  Scenario: 03. Verify_export_options_is_available 
    When User navigates to the LocationMapping tab
    Then User verify export option is available on location mapping page 

  Scenario: 04. Verify_save_button_is_not_available
    When User navigates to the LocationMapping tab  
    Then User verify save button is not available on location mapping page in  "Location_created_via_autoamtion"   

  Scenario: 05. Verify_details_are_not_editable 
   When User navigates to the LocationMapping tab 
   Then User verify details are not editable on location mapping page in  "Location_created_via_autoamtion"    

  @Cleanup  
  Scenario: 06. Logout and Close Browser
     Given User logout from the application
     When User enter email: "$username_3" and password: "$password_3"
     Then User navigates to the List Management tab
     And User selects Department
     And User delete Department "Department_for_LocationMapping_via_automation" if exist
     And User navigates to the Locations tab
     And User delete location by name "Location_created_via_autoamtion" if exist
     And User logout from the application
     Then User close browser