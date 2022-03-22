@laborPro @Regression @Locations
Feature: Verify Locations Module

  @Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_3" and password: "$password_3"
    And Verify Login message: "success"

   
  Scenario: 02. verify_add_location_when_enter_blank_details  
    Given User navigates to the Locations tab
    When User create new location with below input
    | Key               | Value |
    | Name              |       |
    Then Verify validation Message: "Name is required"
    And User click on cancel Button
  
  @Smoke
  Scenario: 03. verify_add_location_when_enter_correct_details 
    Given User navigates to the Locations tab
    And User delete location by name "Location Created via Automation" if exist
    When User create new location with below input
    | Key               | Value |
    | Name              | Location Created via Automation |
    Then User verify created location by name "Location Created via Automation"
  
 
  Scenario: 04. verify_add_location_when_enter_existing_details
    Given User navigates to the Locations tab
    When User create new location with below input if not exist
    | Key               | Value |
    | Name              | Test Location Exist Scenario |
    Then User verify created location by name "Test Location Exist Scenario"
    When User create new location with below input
    | Key               | Value |
    | Name              | Test Location Exist Scenario |
    Then Verify validation Message: "Name already exists"
    And User click on cancel Button
    Then User delete created location by name "Test Location Exist Scenario" 
 
 
  Scenario: 05. verify_edit_location_blank_Details
    Given User navigates to the Locations tab
    When User create new location with below input if not exist
    | Key               | Value |
    | Name              | Location Created via Automation |
    Then User verify created location by name "Location Created via Automation"
    And User edit location "Location Created via Automation" with below input
    | Key               | Value |
    | Name              |       |
    Then Verify validation Message: "Name is required"

  Scenario: 06. verify_edit_location_existing_Details
    Given User navigates to the Locations tab
    And User create new location with below input if not exist
    | Key               | Value |
    | Name              | Created Location via Automation |
    Then User verify created location by name "Created Location via Automation"
    And User edit location "Created Location via Automation" with below input
    | Key               | Value |
    | Name              | Location Created via Automation |
    Then Verify validation Message: "Name already exists"
    And User delete created location by name "Created Location via Automation"

  @Smoke
  Scenario: 07. verify_edit_location_correct_Details
    Given User navigates to the Locations tab
    When User verify created location by name "Location Created via Automation"
    And User edit location "Location Created via Automation" with below input
    | Key               | Value |
    | Name              | Updated Location Created via Automation |
   Then User delete created location by name "Updated Location Created via Automation"  

  @Smoke
  Scenario: 08. verify_delete_location
    Given User navigates to the Locations tab
    And User create new location with below input if not exist
    | Key               | Value |
    | Name              | Created Location via Automation for deletion |
    Then User verify created location by name "Created Location via Automation for deletion"
    And User delete created location by name "Created Location via Automation for deletion"  
    
    
  @Cleanup @Smoke
  Scenario: 09. Logout and Close Browser
    When User logout from the application
    Then User close browser
