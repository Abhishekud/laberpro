 @laborPro @Regression @Classifications_ViewOnly
Feature: Verify Classifications_ViewOnly Module

@Setup 
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_2" and password: "$password_2"
    And Verify Login message: "success"
  
  
  Scenario: 02. Verify_that_User_should_not_have_access_for_Add_button_in_Classifications
   Given User navigates to the Classifications tab
   Then User delete Classifications "Classifications_ViewOnly" if exist
   When User create new Classifications with below input
      | Key  | Value                    | 
      | Name | Classifications_ViewOnly | 
       Then User verify created Classifications by name "Classifications_ViewOnly"
   When User logout from the application
   Then User enter email: "$viewonly_username" and password: "$viewonly_password"
   Given User navigates to the Classifications tab
   And User verify Add Button is not Present in Classifications
  
 
  Scenario: 03. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_Classifications_details_must_not_be_editable 
   Given User navigates to the Classifications tab
   Then User verify Delete Button is not Present in Classifications "Classifications_ViewOnly"
   When User logout from the application
   Then User enter email: "$username_2" and password: "$password_2"
   Given User navigates to the Classifications tab
   Then User delete Classifications "Classifications_ViewOnly" if exist 
  
  @Cleanup 
  Scenario: 04. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
