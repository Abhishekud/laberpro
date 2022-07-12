@Regression @Rest_ViewOnly
Feature: Verify Rest_ViewOnly Module

  @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_1" and password: "$password_1" 
    And User navigates to the Rest tab 
    And User create new Rest with below input if not exist
    | Key                                          | Value                       |
	| Name                                         | Rest_created_via_automation |
	| Effective Net Weight Pounds Handled          | 01 - 10                     |
    | Percent Time Under Load                      | 01 - 12                     | 
    Then User logout from the application
  
   
  Scenario: 02. Verify_add_button_is_not_available
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the Rest tab
    Then User verify add button is not available on rest page
     
 
  Scenario: 03. Verify_delete_button_and_edit_option_is_not_available
    Given User navigates to the Rest tab
    When User find rest by name "Rest_created_via_automation"
    Then User verify delete button and edit option is not available on rest page 
    
  @Cleanup  
  Scenario: 04. Logout and Close Browser
   Given User logout from the application
   When User enter email: "$username_1" and password: "$password_1"
   Then User navigates to the Rest tab
   And User delete Rest "Rest_created_via_automation" if exist
   And User logout from the application
   Then User close browser
   