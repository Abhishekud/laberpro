 @laborPro @Regression @Tasks_ViewOnly
Feature: Verify Tasks_ViewOnly Module

   @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_1" and password: "$password_1"
    And Verify Login message: "success"
    When User navigates to the Tasks tab 
    Then User create new Tasks with below input if not exist
      | Key                   | Value                 | 
      | Name                  | Tasks created via automation        | 
      | Generic Department    | Generic Department    | 
      | Combined Distribution | Combined Distribution | 
      | Time Dependency       | Time Dependent        | 
     And User logout from the application  
  
   
  Scenario: 02. Verify_that_user_should_not_have_access_for_add_button
    Given User enter email: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the Tasks tab
    Then Verify add button is not present on Tasks page 
  
  Scenario: 03. Verify_that_export_options_are_available_for_the_user
    When User navigates to the Tasks tab
    Then Verify export option is present on Tasks page
     
  Scenario: 04. Verify_delete_button_is_not_available_also_details_must_not_be_editable  
    When User navigates to the Tasks tab
    Then Verify delete button is not present on Tasks page in  "Tasks created via automation"   
     
   @Cleanup 
  Scenario: 05. Logout and Close Browser
   Given User logout from the application
   When User enter email: "$username_1" and password: "$password_1"
   Then User navigates to the Tasks tab
   And User delete Tasks "Tasks created via automation" if exist
   When User logout from the application
   Then User close browser
  
  
