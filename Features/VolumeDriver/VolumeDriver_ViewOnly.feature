@Regression @VolumeDriver_ViewOnly
Feature: Verify VolumeDriver_ViewOnly Module

 @Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_1" and password: "$password_1" 
    And User navigates to the VolumeDriver tab
    And User selects Department
    And User create new Department with below input if not exist
      | Key  | Value                                      | 
      | Name | Department to verify VolumeDriver_ViewOnly |  
    And User navigates to the VolumeDriver tab 
    And User create new VolumeDriver with below input if not exist
      | Key        | Value                                      | 
      | Name       | VolumeDriver via VolumeDriver_ViewOnly     | 
      | Department | Department to verify VolumeDriver_ViewOnly |  
    Then User logout from the application
  
  Scenario: 02. Verify_add_button_is_not_available  
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the VolumeDriver tab
    Then User verify add button is not available on volume driver page
  
  Scenario: 03. Verify_export_option_is_not_available 
    When User navigates to the VolumeDriver tab
    Then User verify export option is not available on volume driver page
  
  Scenario: 04. Verify_delete_button_and_edit_option_is_not_available 
    When User navigates to the VolumeDriver tab
    Then User verify delete button is not available on volume driver page in "VolumeDriver via VolumeDriver_ViewOnly"
 
   @Cleanup 
  Scenario: 05. Logout and Close Browser
    Given User logout from the application
    When User enter email: "$username_2" and password: "$password_2"
    Then User navigates to the VolumeDriver tab
    And User delete VolumeDriver "VolumeDriver via VolumeDriver_ViewOnly" if exist
    And User selects Department
    And User delete created Department "Department to verify VolumeDriver_ViewOnly"
    And User logout from the application
    Then User close browser
  
