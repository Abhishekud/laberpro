@LaborPro @Regression @Standards
Feature: Verify Standards Module

A short summary of the feature


 @Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_4" and password: "$password_4"
    And Verify Login message: "success"

    @Smoke 
    Scenario: 02. verify_add_new_standards_name_is_required
    Given User navigates to the standards tab
    Then User add new standards using below input
    | Key     | Value |
    |  Name   |       |
    And Verify Validation Message:"Name is required"
    Then User click cancel Button


    @Smoke 
    Scenario: 03. verify_add_new_standards_Department_is_required
    Given User navigates to the standards tab
    Then User add new standards using below input
    | Key           | Value                                 |
    | Name          | name to verify department is required |
    | Department    |                                       |
    And Verify Validation message :"is required"
    Then User click cancel Button

    @Smoke
    Scenario: 04. verify_add_new_standards_name_by_adding_correct_record_of_name
    Given User navigates to the List Management tab
    And User selects Department
    Then User create new Department with below input if not exist
    | Key     | Value                     |
    | Name    | department for standards  |
    Then User verify created Department "department for standards"
    Then User navigates to the standards tab
    And User delete Standard "name to verify add record" if exist
    When User add new standards using below input
    | Key            | Value                    |
    | Name           | name to verify add record|
    | Department     | department for standards |
    Then User verify created standards name "name to verify add record"
    And User Delete created Standards 
 
     
     @Smoke
     Scenario: 05. verify_add_new_element_to_created_standard_select_standard_element_pop_up_is_open
     Given User navigates to the standards tab
     And User delete Standard "name to verify" if exist
     When User add new standards using below input
    | Key            | Value                    |
    | Name           | name to verify           |
    | Department     | department for standards |
    Then User verify created standards name "name to verify"
    When User clicks New Standard Element
    Then User Verify standard element popup by name "Select Standard Element Type"
    And User Selects Standard Element type "Estimate" 
    Then User click on cancel Button
    And User click on previous link

    @Smoke
    Scenario: 06. verify_add_new_element_to_created_standard_name_is_empty
    Given User navigates to the List Management tab
    When User selects UnitOfMeasure
    Then User Selects Created Department "department for standards"
    When User create new UnitOfMeasure with below input if not exist
    | Key     | Value      |
    | Name    |  Demo Uom  |
    Then User verify Added Unit of Measure "Demo Uom"
    Given User navigates to the standards tab
    When User search standard by name "name to verify"
    Then User selects standard by name "name to verify"
    Then User clicks New Standard Element
    And User Selects Standard Element type "Estimate" 
    When User adds new Standard Element Using Below input
    | Key            | Value         |
    | Name           |               |
    Then Verify validation Message: "Name is required"
    And User click on cancel button
    Then User click on previous link

    @Smoke
    Scenario: 07. verify_add_new_element_to_created_standard_unit_of_measure_is_empty
    Given User navigates to the standards tab
    When User search standard by name "name to verify"
    Then User selects standard by name "name to verify"
    Then User clicks New Standard Element
    And User Selects Standard Element type "Estimate" 
    When User adds new Standard Element Using Below input
    | Key           | Value |
    | Name          | dummy |
    | Frequency     |  4    |
    Then Verify validation Message: "Unit of Measure is required"
    And User click on cancel button
    Then User click on previous link

    @Smoke
    Scenario: 08. verify_add_new_element_to_created_standard_frequency_is_empty
     Given User navigates to the standards tab
    When User search standard by name "name to verify"
    Then User selects standard by name "name to verify"
    Then User clicks New Standard Element
    And User Selects Standard Element type "Estimate" 
    When User adds new Standard Element Using Below input
    | Key             | Value    |
    | Name            | dummy    |
    | Frequency       |          |
    | Unit of Measure | Demo Uom |
    Then User Verify Frequency is empty
    And User click on cancel button
    Then User click on previous link

    @Smoke
    Scenario: 09. verify_add_new_element_to_created_standard_Units_of_measure_dropdown_showing_available_Units_of_measure
     Given User navigates to the standards tab
    When User search standard by name "name to verify"
    Then User selects standard by name "name to verify"
    Then User clicks New Standard Element
    When User Selects Standard Element type "Estimate" 
    Then User Verify Unit Of measure in DropDown "Demo Uom"
    And User click on cancel button
    Then User click on previous link

    @Smoke 
    Scenario: 10.verify_add_new_element_to_created_standard_time_must_be_greater_than_or_equal_to_zero
     Given User navigates to the standards tab
    When User search standard by name "name to verify"
    Then User selects standard by name "name to verify"
    Then User clicks New Standard Element
    When User Selects Standard Element type "Estimate" 
    Then User adds new Standard Element Using Below input
    | Key             | Value    |
    | Name            | dummy    |
    | Frequency       |   4      |
    | Unit of Measure | Demo Uom |
    | Time (Seconds)  |   -1     |
    And Verify validation Message: "Measured Time must be greater than or equal to 0"
    Then User click on cancel button
    And User click on previous link


    @Smoke
    Scenario: 11. verify_add_new_element_to_created_standard_by_adding_correct_record
    Given User navigates to the standards tab
    When User search standard by name "name to verify"
    Then User selects standard by name "name to verify"
    Then User clicks New Standard Element
    And User Selects Standard Element type "Estimate" 
    When User adds new Standard Element Using Below input
    | Key             | Value    |
    | Name            | Dummy    |
    | Frequency       | 16       |
    | Unit of Measure | Demo Uom |
     Then User verify standard element by name "Dummy"
     And User delete standard element 
     Then User Delete created Standards
     Given User navigates to the List Management tab
     When User selects UnitOfMeasure
     Then User Selects Created Department "department for standards"
     And User delete UOM by name "Demo Uom"
     When User selects Department
     Then User delete created Department "department for standards"

   @Cleanup @Smoke
  Scenario: 12. Logout and Close Browser
    When User logout from the application
    Then User close browser  
