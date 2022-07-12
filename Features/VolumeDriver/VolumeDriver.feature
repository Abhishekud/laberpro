@Regression @VolumeDrivers
Feature: Verify VolumeDrivers Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  Scenario: 02. verify_add_VolumeDriver_when_enter_blank_details  
    Given User navigates to the VolumeDriver tab
     When User create new VolumeDriver with below input
      | Key  | Value | 
      | Name |       | 
     Then Verify validation Message: "Name is required"
      And User click on cancel Button
  
  @Smoke
  Scenario: 03. verify_add_VolumeDriver_when_if_Department_is_empty 
    Given User navigates to the VolumeDriver tab
     When User create new VolumeDriver with below input 
      | Key  | Value                       | 
      | Name | VolumeDriver via Automation | 
      And Verify Validation message :"is required."
      And User click on cancel Button
  
  @Smoke
  Scenario: 04. verify_add_VolumeDriver_when_enter_correct_details 
    Given User navigates to the VolumeDriver tab
     Then User selects Department
     When User create new Department with below input if not exist
      | Key  | Value                             | 
      | Name | Department to verify VolumeDriver | 
     Then User verify created Department "Department to verify VolumeDriver"
    Given User navigates to the VolumeDriver tab
     Then User delete VolumeDriver "VolumeDriver via Automation" if exist
     When User create new VolumeDriver with below input
      | Key        | Value                             | 
      | Name       | VolumeDriver via Automation       | 
      | Department | Department to verify VolumeDriver | 
     Then User verify created VolumeDriver by name "VolumeDriver via Automation"
      And User delete created VolumeDriver by name "VolumeDriver via Automation" 
  
  Scenario: 05. verify_add_VolumeDriver_if_Name_already_exist_for_respective_department
    Given User navigates to the VolumeDriver tab
     Then User delete VolumeDriver "VolumeDriver Exist Scenario" if exist
     When User create new VolumeDriver with below input
      | Key        | Value                             | 
      | Name       | VolumeDriver Exist Scenario       | 
      | Department | Department to verify VolumeDriver | 
     Then User verify created VolumeDriver by name "VolumeDriver Exist Scenario"
    Given User navigates to the VolumeDriver tab
     When User create new VolumeDriver with below input
      | Key        | Value                             | 
      | Name       | VolumeDriver Exist Scenario       | 
      | Department | Department to verify VolumeDriver | 
      And Verify Validation message :"Name already exists"
      And User click on cancel Button
      And User delete created VolumeDriver by name "VolumeDriver Exist Scenario"
     Then User selects Department
      And User delete created Department "Department to verify VolumeDriver"
  
  @Cleanup @Smoke
  Scenario: 06. Logout and Close Browser
     When User logout from the application
     Then User close browser
