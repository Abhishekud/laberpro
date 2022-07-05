 @laborPro @Regression @Tasks
Feature: Verify Tasks Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_4" and password: "$password_4"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. Verify_that_Click_on_New_Task_Opens_Add_popup.
    Given User navigates to the Tasks tab
     When User clicks Add Tasks Button
     Then User verify Add Menu Tasks Popup
      And User clicks cancel Button
  
  @Smoke
  Scenario: 03. verify_add_Tasks_when_enter_blank_details  
    Given User navigates to the Tasks tab
     When User create new Tasks with below input
      | Key  | Value | 
      | Name |       | 
     Then Verify validation Message: "Task Name is required."
      And User clicks cancel Button
  
  @Smoke
  Scenario: 04. verify_add_Tasks_when_enter_correct_details
    Given User navigates to the Tasks tab
     Then User delete Tasks "Tasks Scenario" if exist
     When User create new Tasks with below input
      | Key                   | Value                 | 
      | Name                  | Tasks Scenario        | 
      | Generic Department    | Generic Department    | 
      | Combined Distribution | Combined Distribution | 
      | Time Dependency       | Time Dependent        | 
     Then User verify created Tasks "Tasks Scenario"
      And User delete created Tasks "Tasks Scenario" 
  
  @Smoke
  Scenario: 05. Verify_that_Respective_TaskGroup_is_available_in_Task 
    Given User navigates to the TaskGroups tab
     Then User delete TaskGroups "TaskGroups" if exist
     When User create new TaskGroups with below input 
      | Key                   | Value                 | 
      | Name                  | TaskGroups            | 
      | Generic Department    | Generic Department    | 
      | Combined Distribution | Combined Distribution | 
      | Allocate Labor Hours  | Start Day             | 
      | Job Name              | Job1                  | 
      And User verify created TaskGroups "TaskGroups"
     Then User navigates to the Tasks tab
      And User delete Tasks "Tasks Scenario" if exist
     When User create new Tasks with below input
      | Key                   | Value                 | 
      | Name                  | Tasks Scenario        | 
      | Generic Department    | Generic Department    | 
      | Combined Distribution | Combined Distribution | 
      | Time Dependency       | Time Dependent        | 
      | TaskGroups            | TaskGroups            | 
     Then User verify created Tasks "Tasks Scenario"
      And User delete created Tasks "Tasks Scenario" 
     Then User navigates to the TaskGroups tab
      And User delete created TaskGroups by name "TaskGroups" 
  
  @Smoke
  Scenario: 06. verify_add_Tasks_when_enter_existing_details
    Given User navigates to the Tasks tab
      And User delete Tasks "Tasks Exist Scenario" if exist
     When User create new Tasks with below input 
      | Key                   | Value                 | 
      | Name                  | Tasks Exist Scenario  | 
      | Generic Department    | Generic Department    | 
      | Combined Distribution | Combined Distribution | 
      | Time Dependency       | Time Dependent        | 
      And User verify created Tasks "Tasks Exist Scenario"
     When User create new Tasks with below input  
      | Key                   | Value                 | 
      | Name                  | Tasks Exist Scenario  | 
      | Generic Department    | Generic Department    | 
      | Combined Distribution | Combined Distribution | 
      | Time Dependency       | Time Dependent        | 
     Then Verify validation Message: "Task Name must be unique."
      And User clicks cancel Button
      And User delete created Tasks "Tasks Exist Scenario" 
  
  @Cleanup @Smoke
  Scenario: 07. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
  
