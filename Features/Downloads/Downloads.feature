@laborPro @Regression @Downloads
Feature: Verify Downloads Module

@Setup
Scenario: 01. Launch Browser and Login to the Application
  Given User launched "$browser"
  When User go to application "$url"
  Then User enter email: "$username_1" and password: "$password_1"
    And Verify Login message: "success"

Scenario: 02. Verify_no_downloads_found
  Given User has not requested any exports
  When User navigates to Downloads tab
  Then User has no records on Downloads page

@Cleanup
Scenario: 03. Logout and Close Browser
  When User logout from the application
  Then User close browser
