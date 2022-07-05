@Regression @VolumeDriverMapping_ViewOnly
Feature: Verify VolumeDriverMapping_ViewOnly Module

@Setup
  Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_4" and password: "$password_4"
    And User navigates to the List Management tab
    And User selects Department
    And User create new Department with below input if not exist
      | Key  | Value               | 
      | Name | Department_for_VolumeDriverMapping_created_via_automation | 
    Then User navigates to the VolumeDriver tab
    And User create new VolumeDriver with below input if not exist 
      | Key        | Value                                                     | 
      | Name       | VolumeDriver created via automation                       | 
      | Department | Department_for_VolumeDriverMapping_created_via_automation | 
    And User selects UnitOfMeasure
    And User Selects Created Department "Department_for_VolumeDriverMapping_created_via_automation"
    Then User create new UnitOfMeasure with below input if not exist
      | Key  | Value | 
      | Name | UOM   | 
    And User navigates to the VolumeDriverMapping tab
    And User select the department "Department_for_VolumeDriverMapping_created_via_automation" on volume driver mapping page 
    And User delete VolumeDriverMapping "VolumeDriver created via automation" if exist
    And User click on VolumeDriverMapping
    And User create new VolumeDriverMapping with below input if not exist
      | Key          | Value                                | 
      | VolumeDriver | VolumeDriver created via automation  | 
      | UOM          | UOM                                  | 
    Then User logout from the application 

  Scenario: 02. Verify_add_button_is_not_available
    Given User logged in with view only access using username: "$viewonly_username" and password: "$viewonly_password"
    When User navigates to the VolumeDriverMapping tab
    Then User verify add button is not available on volume driver mapping page   

  Scenario: 03. Verify_export_option_is_available 
    When User navigates to the VolumeDriverMapping tab
    Then User verify export option is available on volume driver mapping page 

  Scenario: 04. Verify_delete_button_is_not_available
    Given User navigates to the VolumeDriverMapping tab 
    When User select the department "Department_for_VolumeDriverMapping_created_via_automation" on volume driver mapping page 
    Then User verify delete button is not available on volume driver mapping page in  "VolumeDriver created via automation"   

  Scenario: 05. Verify_details_are_not_editable
    When User navigates to the VolumeDriverMapping tab
    Then User verify details are not editable on volume driver mapping page   

  @Cleanup  
  Scenario: 06. Logout and Close Browser
    Given User logout from the application
    When User enter email: "$username_4" and password: "$password_4"
    And User navigates to the VolumeDriverMapping tab
    And User select the department "Department_for_VolumeDriverMapping_created_via_automation" on volume driver mapping page 
    And User delete VolumeDriverMapping "VolumeDriver created via automation" if exist
    And User navigates to the VolumeDriver tab
    And User search VolumeDriver "VolumeDriver created via automation"
    And User delete created VolumeDriver by name "VolumeDriver created via automation"
    And User selects Department
    And User delete created Department "Department_for_VolumeDriverMapping_created_via_automation"
    And User logout from the application
    Then User close browser

  
