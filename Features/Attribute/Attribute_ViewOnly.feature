 @LaberPro @Regression @Attribute
Feature:Verify Attribute_ViewOnly Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
    When User go to application "$url"
    Then User enter email: "$username_2" and password: "$password_2"
    And Verify Login message: "success"
    Given User navigates to the List Management tab
    And  User selects Department
    And User create new Department with below input if not exist
    | Key               | Value                                   |
    | Name              | Department to verify attribute_viewonly |
    Then User verify created Department "Department to verify attribute_viewonly"
    Given User navigates to the attribute tab
    Then  User select the Department "Department to verify attribute_viewonly"
    Then User delete attribute "AJT_viewonly" if exist
    When User add new attribute using below input
    | Key     | Value           |
    | Name    |  AJT_viewonly   |
    Then User refresh the page
    Given User logout from the application
    Then User enter email: "$viewonly_username" and password: "$viewonly_password"

    Scenario: 02. Verify_that_user_should_not_have_access_for_Add_button
    Given User navigates to the attribute tab
    Then  User select the Department "Department to verify attribute_viewonly"
    Then User verify add button is not present in attribute module

    Scenario: 03. Verify_if_user_when_clicked_on_upper_right_corner_with_export_icon_following_options_displayed_Export_Attributes_Download_Attribute_Import_Template_Download_All_Locations_Attributes_Import_Template
    Given User navigates to the attribute tab
    Then  User select the Department "Department to verify attribute_viewonly"
    Then  User verify click on export icon verify all options displayed in attribute module

    Scenario: 04. Verify_if_user_clicked_on_Export_Attributes_a_popup_with_textbox_for_name_of_file_to_user
    Given User navigates to the attribute tab
    Then  User select the Department "Department to verify attribute_viewonly"
    When  User click on export icon in attribute module 
    Then User select export attribute import template in attribute template
    Then User verify the dialog box asking for file name for attribute module

    Scenario: 05. Verify_if_user_can_download_import_template_when_clicked_on_Download_Attribute_Import_Template
     Given User navigates to the attribute tab
     Then  User select the Department "Department to verify attribute_viewonly"
     When  User click on export icon in attribute module 
     Then User select download attribute import template in attribute module
     And User verify attribute downloaded file "Attributes-import-template"

     Scenario: 06. Verify_if_user_can_download_locations_attributes_template_when_clicked_on_Download_Locations_Attribute_Import_Template 
     Given User navigates to the attribute tab
     Then  User select the Department "Department to verify attribute_viewonly"
     When  User click on export icon in attribute module 
     Then User select download all locations attribute import template in attribute module
     And User verify attribute downloaded file "All-location-attributes-import-template"

     Scenario: 07. Verify_edit_option_is_invisible_aside_of_the_attributes_name_in_the_Attributes_listing
     Given User navigates to the attribute tab
     Then  User select the Department "Department to verify attribute_viewonly"
     Then user verify edit button is not present in attribute module

    @Cleanup @Smoke
    Scenario: 08. Logout and Close Browser
    When User logout from the application
    Then User enter email: "$username_2" and password: "$password_2"
    Given User navigates to the attribute tab
    Then  User select the Department "Department to verify attribute_viewonly"
    And User delete created attribute:"AJT_viewonly"
    Given User navigates to the List Management tab
    When User selects Department
    Then User delete created Department "Department to verify attribute_viewonly"
    When User logout from the application
    Then User close browser



