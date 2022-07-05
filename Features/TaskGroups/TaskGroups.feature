 @laborPro @Regression @TaskGroups
Feature: Verify TaskGroups Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_4" and password: "$password_4"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. Verify_that_Click_on_New_Task_Groups_Opens_Add_popup.
    Given User navigates to the TaskGroups tab
     When User clicks Add TaskGroups Button
     Then User verify Add Menu TaskGroups Popup
      And User clicks cancel Button
  
  @Smoke
  Scenario: 03. verify_add_TaskGroups_when_enter_blank_details  
    Given User navigates to the TaskGroups tab
     When User create new TaskGroups with below input
      | Key  | Value | 
      | Name |       | 
     Then Verify validation Message: "Task Group Name is required."
      And User clicks cancel Button
  
  @Smoke
  Scenario: 04. verify_add_TaskGroups_when_enter_correct_details
    Given User navigates to the TaskGroups tab
     Then User delete TaskGroups "TaskGroups Scenario" if exist
     When User create new TaskGroups with below input
      | Key                   | Value                 | 
      | Name                  | TaskGroups Scenario   | 
      | Generic Department    | Generic Department    | 
      | Combined Distribution | Combined Distribution | 
      | Allocate Labor Hours  | Start Day             | 
      | Job Name              | Job                   | 
     Then User verify created TaskGroups "TaskGroups Scenario"
      And User delete created TaskGroups "TaskGroups Scenario" 
  
  @Smoke
  Scenario: 05. verify_add_TaskGroups_when_enter_existing_details
    Given User navigates to the TaskGroups tab
     Then User delete TaskGroups "TaskGroups Exist Scenario" if exist
     When User create new TaskGroups with below input
      | Key                   | Value                     | 
      | Name                  | TaskGroups Exist Scenario | 
      | Generic Department    | Generic Department        | 
      | Combined Distribution | Combined Distribution     | 
      | Allocate Labor Hours  | Start Day                 | 
      | Job Name              | TaskGroups Test Job Name  | 
  
      And User verify created TaskGroups "TaskGroups Exist Scenario"
     When User create new TaskGroups with below input 
      | Key                   | Value                     | 
      | Name                  | TaskGroups Exist Scenario | 
      | Generic Department    | Generic Department        | 
      | Combined Distribution | Combined Distribution     | 
      | Allocate Labor Hours  | Start Day                 | 
      | Job Name              | TaskGroups Test Job Name  | 
  
     Then Verify validation Message: "Task Group Name must be unique."
      And User clicks cancel Button
      And User delete created TaskGroups "TaskGroups Exist Scenario" 
  
  @Cleanup @Smoke
  Scenario: 06. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
  
