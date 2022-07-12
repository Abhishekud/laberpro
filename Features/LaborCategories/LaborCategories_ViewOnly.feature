@Regression @LaborCategories_ViewOnly
Feature: Verify LaborCategories_ViewOnly Module

  @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_1" and password: "$password_1"
    And Verify Login message: "success"
    When User navigates to the labor categories page
    Then User create new labor category with below input if not exist
      | Key  | Value                                  | 
      | Name | LaborCategories_created_via_automation | 
    And User logout from the application
    
  Scenario: 02. Verify_add_button_is_not_available  
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the labor categories page
    Then User verify add button is not available on labor categories page

  Scenario: 03. Verify_export_options_is_not_available 
    When User navigates to the labor categories page
    Then User verify export option is not available on labor categories page 
  
 
  Scenario: 04. Verify_delete_button_and_edit_option_is_not_available
    Given User navigates to the labor categories page
    When User find labor category by name "LaborCategories_created_via_automation"
    Then User verify delete button and edit option is not available on labor categories page
  
  
  @Cleanup 
  Scenario: 05. Logout and Close Browser
    Given User logout from the application
    When User enter email: "$username_2" and password: "$password_2"
    Then User navigates to the labor categories page
    And User delete LaborCategories "LaborCategories_created_via_automation" if exist
    Then User logout from the application
    And User close browser
