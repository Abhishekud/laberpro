@laborPro @Regression @LaborCategories_ViewOnly
Feature: Verify LaborCategories_ViewOnly Module

   @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_1" and password: "$password_1"
    And Verify Login message: "success"
    When User navigates to the LaborCategories tab
    Then User create new LaborCategories with below input if not exist
      | Key  | Value                                 | 
      | Name | LaborCategories_created_via_automation | 
    And User logout from the application
    
  Scenario: 02. Verify_that_user_should_not_have_access_for_add_button  
    Given User enter email: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the LaborCategories tab
    Then Verify add Button is not present on LaborCategories page

  Scenario: 03. Verify_that_export_options_are_not_available_for_the_user 
    When User navigates to the LaborCategories tab
    Then Verify export option is not Present on LaborCategories page 
  
 
  Scenario: 04. Verify_that_delete_buttons_are_not_available_when_clicked_on_any_record_Also_LaborCategories_details_must_not_be_editable
    Given User navigates to the LaborCategories tab
    When User find LaborCategories by name "LaborCategories_created_via_automation"
    Then Verify delete Button is not present on LaborCategories page
  
  
  @Cleanup 
  Scenario: 05. Close Browser
    Given User logout from the application
    When User enter email: "$username_2" and password: "$password_2"
    Then User navigates to the LaborCategories tab
    And User delete LaborCategories "LaborCategories_created_via_automation" if exist
    Then User logout from the application
    And User close browser
