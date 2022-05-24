 @Laberpro @Regression @UnitOfMeasure_ViewOnly
Feature: Verify UnitOfMeasure_ViewOnly Module

A short summary of the feature
@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. Verify_that_user_should_not_have_access_for_Add_button
    Given User navigates to the List Management tab
     When User selects Department
     Then User create new Department with below input if not exist
      | Key  | Value                                       | 
      | Name | Department To verify UnitOfMeasure_ViewOnly | 
      And User verify created Department "Department To verify UnitOfMeasure_ViewOnly"
  
     When User selects UnitOfMeasure
     Then User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
     Then User delete UnitOfMeasure "UOM" if exist
     When User adds Unit Of Measure using below input
      | Key  | Value | 
      | Name | UOM   | 
     Then User verify Added Unit of Measure "UOM"
     When User logout from the application
     Then User enter email: "$viewonly_username" and password: "$viewonly_password"
    Given User navigates to the List Management tab
     When User selects UnitOfMeasure
     Then User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
     When User verify Add button is not present
  
  @Smoke
  Scenario: 03. Verify_that_export_options_are_not_available_for_the_user
    Given User navigates to the List Management tab
     When User selects UnitOfMeasure
     Then User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
      And User verify export option is not present
  
  @Smoke
  Scenario: 04. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_UOM_details_must_not_be_editable
    Given User navigates to the List Management tab
     When User selects UnitOfMeasure
     Then User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
      And User verify delete button is not present "UOM"
     When User logout from the application
     Then User enter email: "$username_2" and password: "$password_2"
    Given User navigates to the List Management tab
     Then User selects UnitOfMeasure
     Then User Selects Created Department "Department To verify UnitOfMeasure_ViewOnly"
     Then User delete UnitOfMeasure "UOM" if exist
     Then User selects Department
      And User delete created Department "Department To verify UnitOfMeasure_ViewOnly"
  
  @Cleanup @Smoke
  Scenario: 05. Logout and Close Browser
     When User logout from the application
     Then User close browser  
  
  
