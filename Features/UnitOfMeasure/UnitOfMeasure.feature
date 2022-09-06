@Laberpro @Regression @UnitsOfMeasure
Feature: Verify UnitOfMeasure Module

A short summary of the feature
 @Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_2" and password: "$password_2"
    And Verify Login message: "success"

    @Smoke
    Scenario: 02. verify_add_Units_Of_Measure_name_empty_tag
    Given User navigates to the List Management tab
    When User selects Department
    Then User create new Department with below input if not exist
    | Key               | Value |
    | Name              | Department To verify Units of Measure |
    And User verify created Department "Department To verify Units of Measure"

    When User selects UnitOfMeasure
    Then User Selects Created Department "Department To verify Units of Measure"
    And User adds Unit Of Measure using below input
    | Key                           | Value |
   	| Name                          |       |
    Then Verify validation Message: "Name is required"
    And User click cancel Button

    @Smoke
    Scenario: 03. verify_add_Units_Of_Measure_By_adding_correct_record_of_name
    Given User navigates to the List Management tab
    When User selects UnitOfMeasure
    Then User Selects Created Department "Department To verify Units of Measure"
    Then User delete UnitOfMeasure "UOM" if exist
    When User adds Unit Of Measure using below input
    | Key     | Value |
    | Name    |  UOM  |
    Then User verify Added Unit of Measure "UOM"
    And User delete created Unit Of Measure

    @Smoke
    Scenario: 04. verify_add_units_of_measure_By_selecting_the_respective_Department
     Given User navigates to the List Management tab
    When User selects UnitOfMeasure
    Then User Selects Created Department "Department To verify Units of Measure"
    Then User verify the Department record "No records available"

    @Smoke
    Scenario: 05. verify_add_Units_Of_Measure_name_already_exists
      Given User navigates to the List Management tab
      Then User selects UnitOfMeasure
       Then User Selects Created Department "Department To verify Units of Measure"
       Then User delete UnitOfMeasure "UOM" if exist
       When User adds Unit Of Measure using below input
       | Key     | Value |
       | Name    |  UOM  |
     Then User verify Added Unit of Measure "UOM"
     When User adds Unit Of Measure using below input
       | Key     | Value |
       | Name    |  UOM  |
 
     Then Verify validation Message: "Name already exists"
     Then User click cancel Button
     And User delete created Unit Of Measure
     Then User selects Department
     And User delete created Department "Department To verify Units of Measure"

    @Cleanup @Smoke
    Scenario: 06. Logout and Close Browser
    When User logout from the application
    Then User close browser  






