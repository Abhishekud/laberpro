 @laborPro @Regression @ElementsUOM_ViewOnly
Feature: Verify ElementsUoM_ViewOnly Module

@Setup 
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisite
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_4" and password: "$password_4"
    And Verify Login message: "success"
    Given User navigates to the UoM page
   When User create new UoM with below input if not exist
      | Key  | Value                    | 
      | Name | Uom_ViewOnly Created via Automation | 
   Then User logout from the application
  
  Scenario: 02. Verify_add_button_is_not_available
   Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
   When User navigates to the UoM page
   Then User verify add Button is not present 
  
  Scenario: 03. Verify_delete_button_is_not_available
   When User navigates to the UoM page
   Then User verify delete button is not present in UoM "Uom_ViewOnly Created via Automation"
  
  @Cleanup 
  Scenario: 04. Logout and Close Browser
   When User logout from the application
   Then User enter email: "$username_4" and password: "$password_4"
   Given User navigates to the UoM page
   Then User delete UOM "Uom_ViewOnly Created via Automation" if exist 
   When User logout from the application
   Then User close browser
  
