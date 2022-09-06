@Regression @LaborStandard_ViewOnly
Feature: Verify LaborStandard_ViewOnly Module

  @Setup 
  Scenario: 01. Launch Browser and Login to the Application
   Given User launched "$browser"
   When User go to application "$url"
   Then User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
   And Verify Login message: "success"
  
  Scenario: 02. Verify_export_option_is_available
   When User navigates to the labor standards page
   Then User verify export option is available on labor standards page
   
  Scenario: 03. Verify_edit_option_is_not_available
   When User navigates to the labor standards page
   Then User verify edit option is not available on labor standards page

  @Cleanup 
  Scenario: 04. Logout and Close Browser
   When User logout from the application
   Then User close browser
