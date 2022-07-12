@laborPro @Regression @Activity_ViewOnly
Feature: Verify Activity_ViewOnly Module

@Setup 
  Scenario: 01. Launch Browser
    Given User launched "$browser"
  
  Scenario: 02. Verify_that_User_should_not_have_access_for_Add_button_in_Activity
    When User go to application "$url"
    Then User enter email: "$viewonly_username" and password: "$viewonly_password"
    And User navigates to the Activity tab
    And User verify Add Button is not Present in Activity
    Then User logout from the application

  Scenario: 03. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_Activity_details_must_not_be_editable
    Given User go to application "$url"
    When User enter email: "$username_2" and password: "$password_2"
    And User navigates to the Activity tab
    Then User create new Activity with below input if not exist
      | Key  | Value                           | 
      | Name | Activity_created_via_automation |
    And User logout from the application
    When User enter email: "$viewonly_username" and password: "$viewonly_password"
    Then User navigates to the Activity tab
    And User find Activity by name "Activity_created_via_automation"
    Then User verify Activity Delete Button is not Present
    And User logout from the application
    Then User enter email: "$username_2" and password: "$password_2"
    And User navigates to the Activity tab
    Then User delete created Activity by name "Activity_created_via_automation"
    And User logout from the application
  
  @Cleanup 
  Scenario: 04. Close Browser
     Given User close browser
  
