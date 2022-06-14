 @laborPro @Regression @TaskGroups_ViewOnly
Feature: Verify TaskGroups_ViewOnly Module

 @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_5" and password: "$password_5"
    And Verify Login message: "success"
    When User navigates to the TaskGroups tab 
    Then User create new TaskGroups with below input if not exist
      | Key                   | Value                             | 
      | Name                  | TaskGroups created via automation | 
      | Generic Department    | Generic Department                | 
      | Combined Distribution | Combined Distribution             | 
      | Allocate Labor Hours  | Start Day                         | 
      | Job Name              | Job Name                          |  
    And User logout from the application 
  
   
  Scenario: 02. Verify_that_user_should_not_have_access_for_add_button 
    Given User enter email: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the TaskGroups tab
    Then Verify add button is not present on TaskGroups page      
 
  Scenario: 03. Verify_that_export_options_are_available_for_the_user 
    When User navigates to the TaskGroups tab
    Then Verify export option is present on TaskGroups page 
  
  
  Scenario: 04. Verify_delete_button_is_not_available_also_details_must_not_be_editable 
    When User navigates to the TaskGroups tab
    Then Verify delete button is not present on TaskGroups page in  "TaskGroups created via automation"   

  @Cleanup  
  Scenario: 05. Logout and Close Browser
    Given User logout from the application
    When User enter email: "$username_5" and password: "$password_5"
    Then User navigates to the TaskGroups tab
    And User delete TaskGroups "TaskGroups created via automation" if exist
    When User logout from the application
    Then User close browser
  
  
