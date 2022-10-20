@laborPro @Regression @Elements_ViewOnly
Feature: Verify Elements_ViewOnly Module

@Setup
  Scenario: 01. Launch browser and login to the application and perform prerequisite
    Given User launched "$browser"
    When User go to application "$url"
    And User enter email: "$username_3" and password: "$password_3"
    Then Verify Login message: "success"
    When User navigates to the Activity tab
    Then User create new Activity with below input if not exist
      | Key  | Value                              |
      | Name | Activities created via automations |
    When User navigates to the UoM page
    Then User create new UoM with below input if not exist
      | Key  | Value                       |
      | Name | UOM created via automations |
    When User navigates to the elements page
    Then User create new elements with below input if not exist
      | Key      | Value                             |
      | Name     | Elements created via automations  |
      | UOM      | UOM created via automations       |
      | Activity | Activities created via automations|
    And User click on previous link
    Then User logout from the application
 
  Scenario: 02. Verify_add_button_is_not_available
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the elements page
    Then User verify add button is not present
 
  Scenario: 03.Verify_select_multiple_elements_checkbox_is_not_available
    When User navigates to the elements page
    Then User verify that select multiple elements checkbox is not available
 
  Scenario: 04. Verify_export_options_is_available
    When User navigates to the elements page
    Then User verify export option is present  
 
  Scenario: 05.Verify_user_is_able_to_download_element_report
    When User navigates to the elements page
    Then User verify download element report for element: "Elements created via automations"
 
  Scenario: 06.Verify_select_checkboxes_are_not_available_for_multi_select
    When User navigates to the elements page
    Then User verify select checkboxes are not available for multi select
 
  Scenario: 07.Verify_edit_element_details_page_is_not_editable
    When User navigates to the elements page
    Then User verify edit option for the element page is not available
 
  Scenario: 08. Verify_more_options_menu_is_not_available
    When User navigates to the elements page
    Then User verify more options menu is not available
 
  Scenario: 09. Verify_simo_toggle_is_not_available
    When User navigates to the elements page
    Then User verify simo toggle is not available
 
  Scenario: 10. Verify_edit_element_step_details_is_not_available
    When User navigates to the elements page
    Then User verify edit option for the element step is not available
 
  Scenario: 11. Verify_delete_button_is_not_available
    When User navigates to the elements page
    Then User verify delete button is not present on elements page

  @Cleanup
  Scenario: 12. Logout and Close Browser
    Given User logout from the application
    And User enter email: "$username_3" and password: "$password_3"
    When User navigates to the elements page
    Then User delete elements "Elements created via automations" if exist
    When User navigates to the Activity tab
    Then User delete Activity "Activities created via automations" if exist
    When User navigates to the UoM page
    Then User delete UOM "UOM created via automations" if exist
    And User logout from the application
    Then User close browser

  
