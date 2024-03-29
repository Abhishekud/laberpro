@Regression @JobClasses_ViewOnly
Feature: Verify JobClasses_ViewOnly Module

  @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_4" and password: "$password_4"
    And Verify Login message: "success"
    When User navigates to the job classes page
    Then User create new job classes with below input if not exist
      | Key  | Value                             | 
      | Name | JobClasses_created_via_automation | 
    And User logout from the application
    
  Scenario: 02. Verify_add_button_is_not_available
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the job classes page
    Then User verify add button is not available on job classes page

  Scenario: 03. Verify_export_options_is_not_available
    When User navigates to the job classes page
    Then User verify export option is not available on job classes page 
  
  Scenario: 04. Verify_delete_button_and_edit_option_is_not_available
    Given User navigates to the job classes page
    When User find job class by name "JobClasses_created_via_automation"
    Then User verify delete button and edit option is not available on job classes page
  
  @Cleanup 
  Scenario: 05. Logout and Close Browser
    Given User logout from the application
    When User enter email: "$username_4" and password: "$password_4"
    Then User navigates to the job classes page
    And User delete job class "JobClasses_created_via_automation" if exist
    Then User logout from the application
    And User close browser
