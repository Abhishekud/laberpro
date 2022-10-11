 @LaborPro @Regression @Attribute
Feature:Verify Attribute Module

A short summary of the feature

  @Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_2" and password: "$password_2"
    And Verify Login message: "success"


    @Smoke
    Scenario: 02. verify_that_new_department_is_available_in_department_dropdown
    Given User navigates to the List Management tab
     And  User selects Department
    And User create new Department with below input if not exist
    | Key               | Value |
    | Name              | Department to verify attribute|
    Then User verify created Department "Department to verify attribute"
    Then User navigates to the attribute tab
    And  User select the Department "Department to verify attribute"
    Then Verify selected Department "Department to verify attribute"


    @Smoke
    Scenario:03. verify_add_new_attribute_name_is_required
    Given User navigates to the attribute tab
    When User add new attribute using below input
    | Key     | Value |
    |  Name   |       |
    Then Verify Validation Message:"Name is required"
    And User click cancel Button 

    @Smoke
    Scenario:04. verify_add_new_attribute_name_already_exist
    Given User navigates to the attribute tab
    Then User delete attribute "AJT" if exist
    When User add new attribute using below input
    | Key     | Value  |
    | Name    |  AJT   |
    And User refresh the page
    Then User select the Department "Department to verify attribute"
    Then User verify created attribute name "AJT"
    When User add new attribute using below input 
    | Key     | Value  |
    | Name    |  AJT   |
    Then Verify Validation Message:"Name already exists in department"
    And User click cancel Button
    Then User delete created attribute:"AJT"

    @Smoke
    Scenario:05. verify_add_new_attribute_by_adding_correct_record_of_name
    Given User navigates to the attribute tab
    Then User delete attribute "AJP" if exist
    When User add new attribute using below input 
    | Key     | Value  |
    | Name    |  AJP   |
    And User refresh the page
    Then User select the Department "Department to verify attribute"
    Then User verify created attribute name "AJP"
    And  User delete created attribute:"AJP"
    Then User navigates to the List Management tab
    And  User selects Department
    Then User delete created Department "Department to verify attribute" 
  
    @Cleanup @Smoke
    Scenario: 06. Logout and Close Browser
    When User logout from the application
    Then User close browser
