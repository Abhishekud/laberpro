@laborPro @Regression @LocationMapping
Feature: Verify LocationMapping Module

@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_2" and password: "$password_2"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. verify_that_create_Department_is_available_in_department_dropdown
    Given User navigates to the List Management tab
     Then  User selects Department
     When User create new Department with below input if not exist
      | Key  | Value                                | 
      | Name | Department to verify LocationMapping | 
     Then User verify created Department "Department to verify LocationMapping"
     Then User navigates to the Locations tab
      And User delete location by name "Location via LocationMapping" if exist
     Then User navigates to the LocationMapping tab
      And User select the Department "Department to verify LocationMapping"
     Then Verify Record Of Selected Dept "No records available"
  
  @Smoke
  Scenario: 03.Verify_that_Click_on_Location_record_shows_Mapping.
    Given User navigates to the Locations tab
      And User delete location by name "Location via LocationMapping" if exist
     When User create new location with below input
      | Key  | Value                        | 
      | Name | Location via LocationMapping | 
      And User verify created location by name "Location via LocationMapping"
     When User Maps created Department and location with "Location via LocationMapping" and "Department to verify LocationMapping"
     Then User click on LocationMapping
      And User select the Department "Department to verify LocationMapping"
      And User verify created LocationMapping "Location via LocationMapping"
  
  @Smoke
  Scenario: 04.Verify_that_Respective_Volume_Driver_Mapping_Set_&_Characteristic_Set_are_available_in_dropdown
    Given User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify LocationMapping"
     Then User delete VolumeDriverMappingset "VolumeDriverMappingset via LocationMapping" if exist
      And User click on VolumeDriverMapping set
     When User create new VolumeDriverMappingset with below input
      | Key  | Value                                      | 
      | Name | VolumeDriverMappingset via LocationMapping | 
      And User verify created VolumeDriverMappingset by name "VolumeDriverMappingset via LocationMapping"
  
     Then User navigates to the VolumeDriver tab
     When User create new VolumeDriver with below input if not exist
      | Key        | Value                                | 
      | Name       | VolumeDriver via LocationMapping     | 
      | Department | Department to verify LocationMapping | 
     And User verify created VolumeDriver by name "VolumeDriver via LocationMapping"
     When User selects "Units of Measure"
     Then User Selects Created Department "Department to verify LocationMapping"
     When User create new UnitOfMeasure with below input if not exist
      | Key  | Value | 
      | Name | UOM   | 
     And User verify Added Unit of Measure "UOM"
     Then User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify LocationMapping"
     Then User delete VolumeDriverMapping "VolumeDriver via LocationMapping" if exist
      And User click on VolumeDriverMapping
     When User create new VolumeDriverMappingset with below input
      | Key                    | Value                            | 
      | VolumeDriver           | VolumeDriver via LocationMapping | 
      | UOM                    | UOM                              | 
      | VolumeDriverMappingSet | 2                                | 
      And User verify created VolumeDriverMapping by "VolumeDriver via LocationMapping"
     When User navigates to the Characteristic tab
     Then User select the Department "Department to verify LocationMapping"
      And User click on Characteristic set
     When User create new Characteristic with below input
      | Key  | Value             | 
      | Name | Characteristicset | 
     Then User verify created Characteristic by name "Characteristicset"
      And User refresh the page
     Then User navigates to the LocationMapping tab
      And User select the Department "Department to verify LocationMapping"
     Then User select the Location "Location via LocationMapping"
     When User create new LocationMapping with below input  
      | Key                    | Value                                      | 
      | VolumeDriverMappingSet | VolumeDriverMappingset via LocationMapping | 
      | CharacteristicSet      | Characteristicset                          | 
     Then User verify created LocationMapping "Location via LocationMapping"
  
  @Smoke
  Scenario: 05.Verify_that_Respective_records_is_deleted.
    Given User navigates to the Locations tab
      And User delete created location by name "Location via LocationMapping"
     Then User navigates to the VolumeDriverMapping tab
      And User select the Department "Department to verify LocationMapping"
      And User delete created VolumeDriverMapping by "VolumeDriver via LocationMapping"
  
     Then User navigates to the VolumeDriver tab
      And User delete created VolumeDriver by name "VolumeDriver via LocationMapping"
  
     When User selects Department
     Then User delete created Department "Department to verify LocationMapping"
  
  @Cleanup @Smoke
  Scenario: 06. Logout and Close Browser
     When User logout from the application
     Then User close browser
