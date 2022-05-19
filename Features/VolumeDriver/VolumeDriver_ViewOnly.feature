 @laborPro @Regression @VolumeDriver_ViewOnly
Feature: Verify VolumeDriver_ViewOnly Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  Scenario: 02. Verify_that_user_should_not_have_access_for_add_button  
    Given User navigates to the VolumeDriver tab
     Then User selects Department
     When User create new Department with below input if not exist
      | Key  | Value                                      | 
      | Name | Department to verify VolumeDriver_ViewOnly | 
     Then User verify created Department "Department to verify VolumeDriver_ViewOnly"
    Given User navigates to the VolumeDriver tab
     Then User delete VolumeDriver "VolumeDriver via Automation" if exist
     When User create new VolumeDriver with below input
      | Key        | Value                                      | 
      | Name       | VolumeDriver via Automation                | 
      | Department | Department to verify VolumeDriver_ViewOnly | 
     Then User verify created VolumeDriver by name "VolumeDriver via Automation"
     When User logout from the application
     Then User enter email: "$username_6" and password: "$password_6"
      And User navigates to the VolumeDriver tab
     Then User verify add button is not present
  
  @Smoke
  Scenario: 03. Verify_that_export_options_are_not_available_for_the_User 
    Given User navigates to the VolumeDriver tab
      And User verify Export option is not present
  
  @Smoke
  Scenario: 04. Verify_that_Delete_buttons_are_not_available_when_clicked_on_any_record_Also_VolumeDriver_details_must_not_be_editable 
    Given User navigates to the VolumeDriver tab
      And User verify Delete button is not present "VolumeDriver via Automation"
     When User logout from the application
     Then User enter email: "$username_2" and password: "$password_2"
    Given User navigates to the VolumeDriver tab
     Then User delete VolumeDriver "VolumeDriver via Automation" if exist
     Then User selects Department
      And User delete created Department "Department to verify VolumeDriver_ViewOnly"
  
  @Cleanup @Smoke
  Scenario: 05. Logout and Close Browser
     When User logout from the application
     Then User close browser
  
