@LaberPro @Regression @LaborPeriods
Feature:Verify LaborPeriods Module

A short summary of the feature

  @Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_1" and password: "$password_1"
    And Verify Login message: "success"

    @Smoke
    Scenario: 02. Verify_that_click_on_New_Labor_Period
    Given User navigates to LaborPeriod Tab
    When User selects New LaborPeriod
    Then User verify page "Create Labor Period"
    And User click cancel button

    @Smoke 
    Scenario: 03. Verify_that_Name_Labor_Period_Type_Traffic_Pattern_Labor_Destribution_are_empty_and_click_on_Save_button
    Given User navigates to LaborPeriod Tab
    When User selects New LaborPeriod
    Then User click save button
    And Verify Validation message :"Name is required"
    And Verify Validation message :"Unknown labor period"
    And Verify Validation message :"Unknown traffic pattern"
    And Verify Validation message :"Unknown distribution type"
    And User click cancel button

    @Smoke
    Scenario: 04. Verify_that_if_we_select_Labor_Period_Type_as_Hours_of_Operation
    Given User navigates to LaborPeriod Tab
    When User selects New LaborPeriod
    And User Add New LaborPeriod Using Below Input
    | Key              |Value               |
    | Name             |                    |
    | LaborPeriodType  | Hours of Operation |
    | TrafficPattern   |                    |
    | LaborDistribution|                    |
    Then User Verify HouseOfOperation by name "Hours of Operation"
    And User click cancel button

    @Smoke
    Scenario: 05. Verify_that_if_we_select_Labor_Period_Type_as_Hours_of_Operation_and_without_selection_any_value_for_Day_click_on_Save_Button
    Given User navigates to LaborPeriod Tab
    Then User Delete record If Exist "automations"
    When User selects New LaborPeriod
    And User Add New LaborPeriod Using Below Input
    | Key                | Value                                |
    | Name               | automations                          |
    | LaborPeriodType    | Hours of Operation                   |
    | TrafficPattern     | Distribute Evenly and Apply Rounding |
    | LaborDistribution  | Same As Selected Labor Period        |
    Then User Verify HouseOfOperation by name "Hours of Operation"
    Then User click save button
    Then Verify Validation Message:"Must have at least one labor period."
    And User click cancel button

    @Smoke
    Scenario: 06. Verify_that_if_provide_all_valid_data_select_Labor_Period_Type_as_Hours_of_Operation_select_any_value_for_Day_Sunday_click_on_Save_Button
    Given User navigates to LaborPeriod Tab
    Then User Delete record If Exist "automations"
    When User selects New LaborPeriod
    And User Add New LaborPeriod Using Below Input
    | Key                | Value                                |
    | Name               | automations                          |
    | LaborPeriodType    | Hours of Operation                   |
    | TrafficPattern     | Distribute Evenly and Apply Rounding |
    | LaborDistribution  | Same As Selected Labor Period        |
   Then User Add HouseOfPeriod
   Then User search LaborPeriod "automations"
   And User Verify LaborPeriod By Name "automations"
   Then User selects LaborPeriod By Name "automations"
   And User delete created LaborPeriod

   @Smoke
   Scenario: 07. Verify_that_if_Labor_Period_Name_already_exist
    Given User navigates to LaborPeriod Tab
    Then User Delete record If Exist "automations"
    When User selects New LaborPeriod
    And User Add New LaborPeriod Using Below Input
    | Key                | Value                                |
    | Name               | automations                          |
    | LaborPeriodType    | Hours of Operation                   |
    | TrafficPattern     | Distribute Evenly and Apply Rounding |
    | LaborDistribution  | Same As Selected Labor Period        |
   Then User Add HouseOfPeriod
   And  User selects New LaborPeriod
   Then User Add New LaborPeriod Using Below Input
    | Key                | Value                                |
    | Name               | automations                          |
    | LaborPeriodType    | Hours of Operation                   |
    | TrafficPattern     | Distribute Evenly and Apply Rounding |
    | LaborDistribution  | Same As Selected Labor Period        |
   Then User Add HouseOfPeriod
    And Verify Validation message :"Name already exists"
   And User click cancel button
   Then User search LaborPeriod "automations"
   Then User selects LaborPeriod By Name "automations"
   Then User delete created LaborPeriod


    @Cleanup @Smoke
    Scenario: 08. Logout and Close Browser
    When User logout from the application
    Then User close browser