@laborPro @Regression @Departments
Feature: Verify Departments Module

  @Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "edge"
    When User go to application "$url"
    Then User enter email: "$username_4" and password: "$password_4"
    And Verify Login message: "success"

  Scenario: 02. verify_add_Department_when_enter_blank_details  
    Given User navigates to the List Management tab
    And User selects Department 
    Then User create new Department with below input
    | Key               | Value |
    | Name              |       |
    Then Verify validation Message: "Name is required"
    And User clicks cancel Button
  
  @Smoke
  Scenario: 03. verify_add_Department_when_enter_correct_details 
  Given User navigates to the List Management tab
   When User selects Department
   Then User create new Department with below input
    | Key               | Value |
    | Name              | ACreated via Automation |
    And User verify created Department "ACreated via Automation"
    Then User delete created Department "ACreated via Automation" 
  
  Scenario: 04. verify_add_Department_when_enter_existing_details
    Given User navigates to the List Management tab
   And User selects Department
    And User create new Department with below input
    | Key               | Value |
    | Name              | AATest Department Exist Scenario |
    Then User verify created Department "AATest Department Exist Scenario"
    Then User create new Department with below input
    | Key               | Value |
    | Name              | AATest Department Exist Scenario |
    Then Verify validation Message: "Name already exists"
    And User clicks cancel Button
    And User delete created Department "AATest Department Exist Scenario" 
  
  @Cleanup @Smoke
  Scenario: 05. Logout and Close Browser
    When User logout from the application
    Then User close browser