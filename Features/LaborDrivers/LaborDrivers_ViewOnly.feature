 @laborPro @Regression @LaborDrivers_ViewOnly
Feature: Verify LaborDrivers_ViewOnly Module

  @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_3" and password: "$password_3"
    And Verify Login message: "success"
    When User navigates to the LaborDrivers tab 
    Then User create new LaborDrivers with below input if not exist  
      | Key                                             | Value                               | 
      | Name                                            | LaborDrivers created via automation | 
      | Driver Type                                     | Volume Driver                       | 
      | Number                                          | 2                                   | 
      | Number of business days to look back for volume | 2                                   | 
      | Driver                                          | Drivers                             | 
      | Generic Category                                | Generic Category                    |  
    And User logout from the application
  
   
  Scenario: 02. Verify_that_user_should_not_have_access_for_add_button
    Given User enter email: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the LaborDrivers tab
    Then Verify add button is not present 
     
 
  Scenario: 03. Verify_that_export_options_are_available_for_the_user 
    When User navigates to the LaborDrivers tab
    Then Verify export option is present  
  
   
  Scenario: 04. Verify_delete_button_is_not_available_also_details_must_not_be_editable
    When User navigates to the LaborDrivers tab
    Then Verify delete button is not present in  "LaborDrivers created via automation" 
   
   @Cleanup  
  Scenario: 05. Logout and Close Browser
   Given User logout from the application
   When User enter email: "$username_3" and password: "$password_3"
   Then User navigates to the LaborDrivers tab
   And User delete LaborDrivers "LaborDrivers created via automation" if exist
   When User logout from the application
   Then User close browser
  
  
  
