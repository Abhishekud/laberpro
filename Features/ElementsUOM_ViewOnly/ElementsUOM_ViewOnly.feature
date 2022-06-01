 @laborPro @Regression @ElementsUOM_ViewOnly
Feature: Verify ElementsUOM_ViewOnly Module

@Setup 
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_2" and password: "$password_2"
    And Verify Login message: "success"
  
  
  Scenario: 02. Verify_that_User_should_not_have_access_for_Add_button_in_UOM
   Given User navigates to the UOM tab
   Then User delete UOM "Uom_ViewOnly Created via Automation" if exist
   When User create new UOM with below input
      | Key  | Value                    | 
      | Name | Uom_ViewOnly Created via Automation | 
   Then User verify created UOM by name "Uom_ViewOnly Created via Automation"
   When User logout from the application
   Then User enter email: "$viewonly_username" and password: "$viewonly_password"
   Given User navigates to the UOM tab
   And User verify Add Button is not Present in UOM
  
 
  Scenario: 03. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_UOM_details_must_not_be_editable 
   Given User navigates to the UOM tab
   Then User verify Delete Button is not Present in UOM "Uom_ViewOnly Created via Automation"
   When User logout from the application
   Then User enter email: "$username_2" and password: "$password_2"
   Given User navigates to the UOM tab
   Then User delete UOM "Uom_ViewOnly Created via Automation" if exist 
  
  @Cleanup 
  Scenario: 06. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
