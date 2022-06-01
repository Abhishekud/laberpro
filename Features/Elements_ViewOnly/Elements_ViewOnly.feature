  @laborPro @Regression @Elements_ViewOnly
Feature: Verify Elements_ViewOnly Module

@Setup 
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  Scenario: 02. Verify_that_User_should_not_have_access_for_Add_button_in_Elements
    Given User navigates to the Activity tab
    Then User delete Activity "Activities_ViewOnly" if exist
    When User create new Activity with below input
      | Key  | Value                      | 
      | Name | Activities_ViewOnly | 
    Then User verify created Activity by name "Activities_ViewOnly"
    Given User navigates to the UOM tab
    Then User delete UOM "UOM_ViewOnly" if exist
    When User create new UOM with below input
      | Key  | Value        | 
      | Name | UOM_ViewOnly | 
    Then User verify created UOM by name "UOM_ViewOnly"
    Given User navigates to the Elements tab
    Then User delete Elements "Elements_ViewOnly" if exist
    When User create new Elements with below input
      | Key      | Value             | 
      | Name     | Elements_ViewOnly | 
      | UOM      |  UOM_ViewOnly     | 
      | Activity |Activities_ViewOnly| 
    Then User verify created Elements by name "Elements_ViewOnly"
    And User click on previous link
    When User logout from the application
    Then User enter email: "$viewonly_username" and password: "$viewonly_password"
    Given User navigates to the Elements tab
    And User verify Add Button is not Present in Elements
  
  Scenario: 03.Verify_that_select_multiple_Elements_checkbox_is_unavailable_in_Elements
    Given User navigates to the Elements tab
    And User Verify that select multiple Elements checkbox is unavailable
  
  Scenario: 04. Verify_that_Export_options_are_available_for_the_User_in_Elements 
    Given User navigates to the Elements tab
    And User verify Export option is Present in Elements
  
  Scenario: 05.Verify_if_user_is_able_to_download_Element_Report_when_clicked_on_the_Element_Report_button_in_element_details_page 
    Given User navigates to the Elements tab
    Then User Verify if user is able to download Element Report in "Elements_ViewOnly"
  
  Scenario: 06.Verify_that_if_select_checkboxes_are_available_for_multi_select_in_Element_Details_Page
    Given User navigates to the Elements tab
    Then User Verify that if select checkboxes are unavailable for multi select in Element Details
  
  Scenario: 07.Verify_if_user_is_not_able_to_edit_element_details_page_when_hovered_next_to_element_step_name 
    Given User navigates to the Elements tab
    Then User Verify if user is not able to edit the element steps
  
  Scenario: 08. Verify_if_user_is_unable_to_access_more_options_menu_the_element_steps_page_in_the_element_details_page
    Given User navigates to the Elements tab
    Then User Verify if user is unable to access more options menu
  
  Scenario: 09. Verify_if_the_user_is_unable_to_access_Simo_toggle_in_the_element_step_details
    Given User navigates to the Elements tab
    Then User Verify if the user is unable to access Simo toggle
  
  Scenario: 10. Verify_if_user_does_not_have_access_to_edit_element_step_details_when_clicked_on_the_View_button_next_to_the_title_of_the_element_step
    Given User navigates to the Elements tab
    Then User Verify if user does not have access to edit element step details
  
  Scenario: 11. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_Elements_details_must_not_be_editable 
    Given User navigates to the Elements tab
    Then User verify Delete Button is not Present in Elements
    And User click on previous link
    When User logout from the application
    Then User enter email: "$username_2" and password: "$password_2"
    Given User navigates to the Elements tab
    Then User delete Elements "Elements_ViewOnly" if exist 
    Given User navigates to the Activity tab
    Then User delete Activity "Activities_ViewOnly" if exist 
    Given User navigates to the UOM tab
    Then User delete UOM "UOM_ViewOnly" if exist 
  
  @Cleanup 
  Scenario: 12. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
  
