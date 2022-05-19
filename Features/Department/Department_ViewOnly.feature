 @laborPro @Regression @Department_ViewOnly
Feature: Verify Department_ViewOnly Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_4" and password: "$password_4"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. Verify_that_User_should_not_have_access_for_Add_button  
    Given User navigates to the List Management tab
     When User selects Department
     Then User delete Department "Department to verify Department_ViewOnly" if exist
     When User create new Department with below input
      | Key  | Value                                    | 
      | Name | Department to verify Department_ViewOnly | 
      And User verify created Department "Department to verify Department_ViewOnly"
     When User logout from the application
     Then User enter email: "$username_6" and password: "$password_6"
    Given User navigates to the List Management tab
     When User selects Department
     Then User verify Add button is not Present
  
  @Smoke
  Scenario: 03. Verify_that_Export_options_are_not_available_for_the_User 
    Given User navigates to the List Management tab
     When User selects Department
      And User verify export option is not Present 
  
  @Smoke
  Scenario: 04. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_Department_details_must_not_be_editable
    Given User navigates to the List Management tab
      And User selects Department
      And User verify delete button is not Present "Department to verify Department_ViewOnly"
     When User logout from the application
     Then User enter email: "$username_2" and password: "$password_2"
    Given User navigates to the List Management tab
     When User selects Department
     Then User delete Department "Department to verify Department_ViewOnly" if exist
  
  @Cleanup @Smoke
  Scenario: 05. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
