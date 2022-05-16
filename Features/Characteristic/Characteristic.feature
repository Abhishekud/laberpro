 @laborPro @Regression @Characteristics
Feature: Verify Characteristics Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. verify_that_created_department_is_available_in_department_dropdown
    Given User navigates to the List Management tab
     Then  User selects Department
     When User create new Department with below input if not exist
      | Key  | Value                               | 
      | Name | Department to verify Characteristic | 
     Then User verify created Department "Department to verify Characteristic"
     Then User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User delete Characteristic "Characteristic" if exist
      And User delete Characteristic "CharacteristicTest" if exist
      And Verify Record Of Selected Dept "No records available"
  
  Scenario: 03. verify_add_Characteristic_when_enter_blank_details 
  
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User click on Characteristic 
     When User create new Characteristic with below input
      | Key  | Value | 
      | Name |       | 
     Then Verify validation Message: "Name is required"
      And User click on cancel button 
  
  @Smoke
  Scenario: 04. verify_add_Characteristic_when_enter_correct_details 
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User delete Characteristic "Characteristic" if exist
     Then User click on Characteristic
     When User create new Characteristic with below input
      | Key  | Value          | 
      | Name | Characteristic | 
     Then User verify created Characteristic by name "Characteristic"
      And User delete created Characteristic by name "Characteristic"
  
  Scenario: 05. verify_that_Characteristic_may_only_contain_letters_numbers_underscores 
  
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User click on Characteristic 
     When User create new Characteristic with below input
      | Key  | Value                  | 
      | Name | CharacteristicTest 123 | 
     Then Verify validation Message: "Name may only contain letters, numbers and underscores"
      And User click on cancel button
  
  Scenario: 06. verify_add_Characteristic_when_enter_existing_details
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User delete Characteristic "CharacteristicTest" if exist
     Then User click on Characteristic
     When User create new Characteristic with below input
      | Key  | Value              | 
      | Name | CharacteristicTest | 
     Then User verify created Characteristic by name "CharacteristicTest"
     Then User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User click on Characteristic
     When User create new Characteristic with below input
      | Key  | Value              | 
      | Name | CharacteristicTest | 
     Then Verify validation Message: "Name already exists in the specified Department"
      And User click on cancel button 
      And User delete created Characteristic by name "CharacteristicTest" 
  
  Scenario: 07. verify_add_Characteristic_set_when_enter_blank_details 
  
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User click on Characteristic set
     When User create new Characteristic with below input
      | Key  | Value | 
      | Name |       | 
     Then Verify validation Message: "Name is required"
      And User click on cancel button 
  
  Scenario: 08. verify_add_Characteristic_set_when_enter_correct_details 
  
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
     Then User click on Characteristic set
     When User create new Characteristic with below input 
      | Key  | Value | 
      | Name | ATest | 
     Then User verify created CharacteristicSet by name "ATest"
  
  Scenario: 09. verify_add_Characteristic_set_when_enter_existing_details 
  
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User delete Characteristic set "Characteristicset" if exist 
     Then User click on Characteristic set 
     When User create new Characteristic with below input
      | Key  | Value             | 
      | Name | Characteristicset | 
     Then User verify created CharacteristicSet by name "Characteristicset"
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
      And User click on Characteristic set
     When User create new Characteristic with below input
      | Key  | Value             | 
      | Name | Characteristicset | 
     Then Verify validation Message: "Name already exists"
      And User click on cancel button
      And User delete created Characteristic set by name "Characteristicset"
     When User navigates to the List Management tab
     When User selects Department
     Then User delete created Department "Department to verify Characteristic" 
  
  @Cleanup @Smoke
  Scenario: 10. Logout and Close Browser
     When User logout from the application
     Then User close browser
