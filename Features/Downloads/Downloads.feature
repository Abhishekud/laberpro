@Regression @Downloads
Feature: Verify Downloads Module

@Setup
Scenario: 01. Launch Browser and Login to the Application
  Given User "superadmin" is authenticated with application

Scenario: 02. Verify_export_file_exists
  Given User has requested a export
  When User navigates to Downloads tab
  Then User has export record on downloads page

@Cleanup
Scenario: 03. Logout and Close Browser
  When User logout from the application
  Then User close browser
