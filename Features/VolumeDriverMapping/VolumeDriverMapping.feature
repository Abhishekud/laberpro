@laborPro @Regression @VolumeDriverMapping
Feature: Verify VolumeDriverMapping Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "chrome"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. verify_that_new_department_is_available_in_department_dropdown
    Given User navigates to the List Management tab
     Then  User selects Department
     When User create new Department with below input
      | Key  | Value                                    | 
      | Name | Department to verify VolumeDriverMapping | 
      And  User verify created Department "Department to verify VolumeDriverMapping"
     Then User navigates to the VolumeDriverMapping tab
      And User select the Department "Department to verify VolumeDriverMapping"
     Then Verify Record Of Selected Dept "No records available"
  
  @Smoke
  Scenario: 03.Verify_that_if_Name_is_empty 
    Given User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify VolumeDriverMapping"
      And User click on VolumeDriverMapping set
     When User create new VolumeDriverMappingset with below input
      | Key  | Value | 
      | Name |       | 
     Then Verify validation Message: "Name is required"
      And User click on cancel Button
  
  @Smoke
  Scenario: 04.verify_add_VolumeDriverMappingset_when_enter_correct_details 
    Given User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify VolumeDriverMapping"
      And User click on VolumeDriverMapping set
     When User create new VolumeDriverMappingset with below input
      | Key  | Value                                 | 
      | Name | VolumeDriverMappingset via Automation | 
     Then User verify created VolumeDriverMappingset by name "VolumeDriverMappingset via Automation"
  
  Scenario: 05. Verify_that_respective_'VolumeDriver'_& _UOM""_available_in_dropdown 
  
    Given User navigates to the VolumeDriver tab
     When User create new VolumeDriver with below input
      | Key        | Value                                    | 
      | Name       | VolumeDriver via Automation              | 
      | Department | Department to verify VolumeDriverMapping | 
     Then User verify created VolumeDriver by name "VolumeDriver via Automation"
     When User selects "Units of Measure"
     Then User Selects Created Department "Department to verify VolumeDriverMapping"
     When User adds Unit Of Measure using below input
      | Key  | Value | 
      | Name | UOM   | 
     Then User verify Added Unit of Measure "UOM"
    Given User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify VolumeDriverMapping"
      And User click on VolumeDriverMapping
      And User create new VolumeDriverMapping with below input if not exist
      | Key                    | Value                       | 
      | VolumeDriver           | VolumeDriver via Automation | 
      | UOM                    | UOM                         | 
      | VolumeDriverMappingSet | 2                           | 
     Then User verify created VolumeDriverMapping by "VolumeDriver via Automation"
      And User delete created VolumeDriverMapping by "VolumeDriver via Automation"
  
  @Smoke
  Scenario: 06. Verify_that_respective_'VolumeDriver'_& _UOM""_available_in_dropdown_is_deleted
    Given User navigates to the List Management tab
    Given User navigates to the VolumeDriver tab
      And User delete created VolumeDriver by name "VolumeDriver via Automation"
     When User selects "Units of Measure"
     Then User Selects Created Department "Department to verify VolumeDriverMapping"
     Then User delete created UOM by "UOM"
     When User selects Department
     Then User delete created Department "Department to verify VolumeDriverMapping"
  
  @Cleanup @Smoke
  Scenario: 07. Logout and Close Browser
     When User logout from the application
     Then User close browser
