@laborPro @Regression @JobClasses_ViewOnly
Feature: Verify JobClasses_ViewOnly Module

   @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_4" and password: "$password_4"
    And Verify Login message: "success"
    When User navigates to the JobClasses tab
    Then User create new JobClasses with below input if not exist
      | Key  | Value                                 | 
      | Name | JobClasses_created_via_automation | 
    And User logout from the application
    
  Scenario: 02. Verify_that_user_should_not_have_access_for_add_button  
    Given User enter email: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the JobClasses tab
    Then Verify add Button is not present on JobClasses page

  Scenario: 03. Verify_that_export_options_are_not_available  
    When User navigates to the JobClasses tab
    Then Verify export option is not Present on JobClasses page 
  
 
  Scenario: 04. Verify_that_delete_buttons_are_not_available_when_clicked_on_any_record_Also_JobClasses_details_must_not_be_editable
    Given User navigates to the JobClasses tab
    When User find JobClasses by name "JobClasses_created_via_automation"
    Then Verify delete Button is not present on JobClasses page
  
  
  @Cleanup 
  Scenario: 05. Close Browser
    Given User logout from the application
    When User enter email: "$username_4" and password: "$password_4"
    Then User navigates to the JobClasses tab
    And User delete JobClasses "JobClasses_created_via_automation" if exist
    Then User logout from the application
    And User close browser
