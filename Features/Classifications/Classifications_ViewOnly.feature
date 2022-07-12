@laborPro @Regression @Classifications_ViewOnly
Feature: Verify Classifications_ViewOnly Module

  @Setup 
  Scenario: 01. Launch Browser
    Given User launched "$browser"  
  
  Scenario: 02. Verify_that_User_should_not_have_access_for_Add_button_in_Classifications
   When User go to application "$url"
   Then User enter email: "$viewonly_username" and password: "$viewonly_password"
   And User navigates to the Classifications tab
   And User verify add classification button is not Present
   Then User logout from the application
  
 
  Scenario: 03. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_Classifications_details_must_not_be_editable
   Given User go to application "$url"
   When User enter email: "$username_2" and password: "$password_2"
   And User navigates to the Classifications tab
   Then User create new Classifications with below input if not exist
      | Key  | Value                                 | 
      | Name | Classification_created_via_automation | 
   And User logout from the application
   Then User enter email: "$viewonly_username" and password: "$viewonly_password"
   When User navigates to the Classifications tab
   And User find Classification by name "Classification_created_via_automation"
   Then User verify delete classification button is not Present
   When User logout from the application
   Then User enter email: "$username_2" and password: "$password_2"
   Given User navigates to the Classifications tab
   And User delete Classifications "Classification_created_via_automation" if exist
   Then User logout from the application
  
  @Cleanup 
  Scenario: 06. Close Browser
     Given User close browser
