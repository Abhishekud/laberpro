@Regression @Departments
Feature: Verify Departments Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_4" and password: "$password_4"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. verify_add_Department_when_enter_blank_details  
    Given User navigates to the List Management tab
      And User selects Department 
     When User create new Department with below input
      | Key  | Value | 
      | Name |       | 
     Then Verify validation Message: "Name is required"
      And User clicks cancel Button
  
  @Smoke
  Scenario: 03. verify_add_Department_when_enter_correct_details 
    Given User navigates to the List Management tab
     When User selects Department
     Then User delete Department "Department to verify Department" if exist
     When User create new Department with below input
      | Key  | Value                           | 
      | Name | Department to verify Department | 
      And User verify created Department "Department to verify Department"
     Then User delete created Department "Department to verify Department" 
  
  @Smoke
  Scenario: 04. verify_add_Department_when_enter_existing_details
    Given User navigates to the List Management tab
      And User selects Department
     Then User delete Department "Department Exist Scenario" if exist
     When User create new Department with below input
      | Key  | Value                     | 
      | Name | Department Exist Scenario | 
     Then User verify created Department "Department Exist Scenario"
     Then User create new Department with below input 
      | Key  | Value                     | 
      | Name | Department Exist Scenario | 
     Then Verify validation Message: "Name already exists"
      And User clicks cancel Button
      And User delete created Department "Department Exist Scenario" 
  
  @Cleanup @Smoke
  Scenario: 05. Logout and Close Browser
     When User logout from the application
     Then User close browser
