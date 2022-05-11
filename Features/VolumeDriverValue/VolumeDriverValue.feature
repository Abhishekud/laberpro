@LaberPro @Regression @VolumeDriverValue
Feature: Verify VolumeDriverValue Module

A short summary of the feature
@Setup @Smoke
  Scenario: 01. Launch Browser and Login to the Application
    Given User launched "$browser"
     When User go to application "$url"
     Then User enter email: "$username_1" and password: "$password_1"
      And Verify Login message: "success"
  
  @Smoke
  Scenario: 02. verify_volume_driver_value_scenario_and_standardsuombylocation_scenarios
  
    Given User navigates to the List Management tab
     When User selects Department
     Then User create new Department with below input if not exist
      | Key  | Value                                  | 
      | Name | Department to verify VolumeDriverValue | 
      And User verify created Department "Department to verify VolumeDriverValue"

    Given User navigates to the standards tab
      And User delete Standard "standardforvolumedrivervalue" if exist
     Then User navigates to the attribute tab
      And User select the Department "Department to verify VolumeDriverValue"
     Then Verify selected Department "Department to verify VolumeDriverValue"
     Then User delete attribute "attributeforvolumedrivervalue" if exist
     When User add new attribute using below input
      | Key  | Value                         | 
      | Name | attributeforvolumedrivervalue | 
     Then User verify created attribute name "attributeforvolumedrivervalue"

    Given User navigates to the Characteristic tab
     Then User select the Department "Department to verify VolumeDriverValue"
      And User click on Characteristic set
     When User create new Characteristic with below input  
      | Key  | Value                       | 
      | Name | charsetforvolumedrivervalue | 
     Then User verify created Characteristic by name "charsetforvolumedrivervalue"
      And User refresh the page
  
    Given User navigates to the standards tab
      And User delete Standard "standardforvolumedrivervalue" if exist
     When User add new standards using below input
      | Key        | Value                                  | 
      | Name       | standardforvolumedrivervalue           | 
      | Department | Department to verify VolumeDriverValue | 
      | Attribute  | attributeforvolumedrivervalue          | 
     Then User verify created standards name "standardforvolumedrivervalue"
     Then User click on previous link

    Given User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify VolumeDriverValue"
     Then User delete VolumeDriverMapping "VolumeDriver_automations" if exist
    Given User navigates to the List Management tab
     When User selects UnitOfMeasure
     Then User Selects Created Department "Department to verify VolumeDriverValue"
     Then User delete UnitOfMeasure "UOMforvolumedrivervalue" if exist
     When User adds Unit Of Measure using below input
      | Key  | Value                   | 
      | Name | UOMforvolumedrivervalue | 
     Then User verify Added Unit of Measure "UOMforvolumedrivervalue"
  
    Given User navigates to the standards tab
     When User search standard by name "standardforvolumedrivervalue"
     Then User selects standard by name "standardforvolumedrivervalue"
     Then User clicks New Standard Element
      And User Selects Standard Element type "Estimate" 
     When User adds new Standard Element Using Below input
      | Key             | Value                   | 
      | Name            | Dummy                   | 
      | Frequency       | 16                      | 
      | Unit of Measure | UOMforvolumedrivervalue | 
     Then User verify standard element by name "Dummy"
      And User click on previous link
  
    Given User navigates to the Locations tab
      And User delete location by name "Locationforvolumedrivervalue" if exist
     When User create new location with below input
      | Key  | Value                        | 
      | Name | Locationforvolumedrivervalue | 
      And User verify created location by name "Locationforvolumedrivervalue"
     When User Maps created Department and location with "Locationforvolumedrivervalue" and "Department to verify VolumeDriverValue"
     Then User click on LocationMapping
      And User select the Department "Department to verify VolumeDriverValue"
      And User verify created LocationMapping "Locationforvolumedrivervalue"
  
    Given User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify VolumeDriverValue"
     Then User delete VolumeDriverMappingset "VolumeDriverMappingset_automations" if exist
      And User click on VolumeDriverMapping set
     When User create new VolumeDriverMappingset with below input
      | Key  | Value                              | 
      | Name | VolumeDriverMappingset_automations | 
      And User verify created VolumeDriverMappingset by name "VolumeDriverMappingset_automations"
  
     Then User navigates to the VolumeDriver tab
     Then User delete VolumeDriver "VolumeDriver_automations" if exist
     When User create new VolumeDriver with below input
      | Key        | Value                                  | 
      | Name       | VolumeDriver_automations               | 
      | Department | Department to verify VolumeDriverValue | 
      And User verify created VolumeDriver by name "VolumeDriver_automations"
  
     Then User navigates to the VolumeDriverMapping tab
     Then User select the Department "Department to verify VolumeDriverValue"
     Then User delete VolumeDriverMapping "VolumeDriver_automations" if exist
      And User click on VolumeDriverMapping
     When User create new VolumeDriverMappingset with below input
      | Key                    | Value                    | 
      | VolumeDriver           | VolumeDriver_automations | 
      | UOM                    | UOMforvolumedrivervalue  | 
      | VolumeDriverMappingSet | 2                        | 
      And User verify created VolumeDriverMapping by "VolumeDriver_automations"
  
     Then User navigates to the LocationMapping tab
      And User select the Department "Department to verify VolumeDriverValue"
     Then User select the Location "Locationforvolumedrivervalue"
      And User refresh the page
     Then User navigates to the LocationMapping tab
      And User select the Department "Department to verify VolumeDriverValue"
     Then User select the Location "Locationforvolumedrivervalue"
     When User create new LocationMapping with below input  
      | Key                    | Value                              | 
      | VolumeDriverMappingSet | VolumeDriverMappingset_automations | 
      | CharacteristicSet      | charsetforvolumedrivervalue        | 
     Then User verify created LocationMapping "Locationforvolumedrivervalue"
  
    Given User navigates to volume driver values tab
     When User click download template
     Then User verify volume driver value downloaded file "Volume-Driver-import-template"
     When User Access the downloaded file and update volume driver value in location "Locationforvolumedrivervalue" "Department to verify VolumeDriverValue" "VolumeDriver_automations" "10"
     Then User import value in volume driver value
      And User verify location department volumedriver in volume driver value page "Locationforvolumedrivervalue" "Department to verify VolumeDriverValue" "VolumeDriver_automations"
  
    Given User navigates to standardsanduomsbylocation tab
      And User refresh the page
     When User search record by name "Locationforvolumedrivervalue"
     Then User verify standardsanduombylocation "Locationforvolumedrivervalue"
  
    Given User navigates to the Locations tab
      And User delete created location by name "Locationforvolumedrivervalue"
     Then User navigates to the VolumeDriverMapping tab
      And User select the Department "Department to verify VolumeDriverValue"
      And User delete created VolumeDriverMapping by "VolumeDriver_automations"
     Then User navigates to the VolumeDriver tab
      And User delete created VolumeDriver by name "VolumeDriver_automations"
  
    Given User navigates to the standards tab
     When User search standard by name "standardforvolumedrivervalue"
     Then User selects standard by name "standardforvolumedrivervalue"
     Then User Delete created Standards
  
    Given User navigates to the List Management tab
     When User selects UnitOfMeasure
     Then User Selects Created Department "Department to verify VolumeDriverValue"
      And User delete UOM by name "UOMforvolumedrivervalue"
  
    Given User navigates to the attribute tab
     Then  User select the Department "Department to verify VolumeDriverValue"
      And  User delete created attribute:"attributeforvolumedrivervalue"
  
     Then User navigates to the List Management tab
      And  User selects Department
     Then User delete created Department "Department to verify VolumeDriverValue" 
  
  @Cleanup @Smoke
  Scenario: 03. Logout and Close Browser
     When User logout from the application
     Then User close browser
