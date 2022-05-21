 @laborPro @Regression @Characteristic_ViewOnly
Feature: Verify Characteristic_ViewOnly Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. Verify_that_User_should_not_have_access_for_Add_button_in_Characteristic
    Given User navigates to the List Management tab
     Then  User selects Department
     When User create new Department with below input if not exist
      | Key  | Value                                        | 
      | Name | Department to verify Characteristic_ViewOnly | 
     Then User verify created Department "Department to verify Characteristic_ViewOnly"
     When User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic_ViewOnly"
      And User delete Characteristic "Characteristic" if exist
     Then User click on Characteristic
     When User create new Characteristic with below input
      | Key  | Value          | 
      | Name | Characteristic | 
     Then User verify created Characteristic by name "Characteristic"
     When User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic"
     Then User click on Characteristic set
     When User create new Characteristic with below input 
      | Key  | Value                   | 
      | Name | Characteristic_ViewOnly | 
     Then User verify created CharacteristicSet by name "Characteristic_ViewOnly"
      And User refresh the page
     When User logout from the application
     Then User enter email: "$viewonly_username" and password: "$viewonly_password"
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic_ViewOnly"
      And User verify Add Button is not Present
  
  Scenario: 03. Verify_that_Export_options_are_available_for_the_User_in_Characteristic 
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic_ViewOnly"
      And User verify Export option is Present  
  
  @Smoke
  Scenario: 04. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_Characteristic_details_must_not_be_editable 
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic_ViewOnly"
     Then User verify Delete Button is not Present "Characteristic"
  
  Scenario: 05. Verify_edit_option_is_not_available_when_clicked_on_the_Hamburger_icon_in_the_Characteritics_page 
    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic_ViewOnly"
      And User verify Edit option is not Present
     When User logout from the application
     Then User enter email: "$username_2" and password: "$password_2"
     Then User navigates to the Characteristic tab
     Then User select the Department "Department to verify Characteristic_ViewOnly"
      And User delete Characteristic "Characteristic" if exist
     When User navigates to the List Management tab
     When User selects Department
     Then User delete created Department "Department to verify Characteristic_ViewOnly" 
  
  @Cleanup @Smoke
  Scenario: 06. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
