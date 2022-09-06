@laborPro @Regression @Downloads
Feature: Verify Downloads Module

@Setup
Scenario: 01. Launch Browser and Login to the Application
  Given User launched "$browser"
  When User go to application "$url"
  Then User enter email: "$username_1" and password: "$password_1"
    And Verify Login message: "success"

Scenario: 02. Verify_wim_file_exists
  Given Kronos is enabled and User has requested a WIM export
  When User navigates to Downloads tab
  Then User has WIM record on Downloads page

@Cleanup
Scenario: 03. Logout and Close Browser
  When User logout from the application
  Then User close browser
