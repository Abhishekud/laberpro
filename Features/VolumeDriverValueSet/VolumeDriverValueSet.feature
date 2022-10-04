@Regression @VolumeDriverValueSet
Feature: Verify VolumeDriverValueSet Module
@Setup
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
  Given User "$superadmin" is authenticated with "$url"
  Then Department "Test Department" exists
  And Attribute with below input exists
    | Department | Test Department |
    | Standard   | Test Standard   |
    | Attribute  | Test Attribute  |
  And Standard with below input exists
    | Name       | Test Standard   |
    | Department | Test Department |
    | Attribute  | Test Attribute  |
  And Units Of Measure with below input exists
    | Department     | Test Department   |
    | VolumeDriver   | Test VolumeDriver |
    | UnitsOfMeasure | Test UOM          |
  And Standard Element with below input exists
    | Standard            | Test Standard |
    | StandardElementType | Estimate      |
    | Name                | Dummy         |
    | Frequency           | 16            |
    | Unit of Measure     | Test UOM      |
  And Location "Test Location" exists
  And Mapping with "Test Location" and "Test Department" exists
  And VolumeDriverMappingSet "Test VolumeDriverMappingSet" in department "Test Department" exists
  And Volume Driver "Test VolumeDriver" in department "Test Department" exists
  And Volume Driver Mapping with below input exists
    | VolumeDriver           | Test VolumeDriver |
    | UOM                    | Test UOM          |
    | VolumeDriverMappingSet | 2                 |
  And Characterstics set "Test CharactersticsSet" in department "Test Department" exists
  And Location Mapping "Test VolumeDriverMappingSet" and "Test CharactersticsSet" exists

Scenario: 02. Verify_new_volume_driver_value_set_popup
  Given User verify new volume driver value set popup

Scenario: 03. Verify_add_volume_driver_value_set_module_for_super_admin_user
  When User add new volume driver value set "Test VolumeDriverValueSet"
  Then User verify volume driver value set by name "Test VolumeDriverValueSet"
  #Then User verify location department volume driver in volume driver value page
  #  | Location     | Test Location     |
  #  | Department   | Test Department   |
  #  | VolumeDriver | Test VolumeDriver |

Scenario: 04. Verify_name_is_empty
  When User add volume driver value set without name
  Then User verify validation message "Name is required" on volume driver value set popup

Scenario: 05. Verify_volume_driver_value_file_not_selected
  When User add new volume driver value set without file "Demo"
  Then User verify validation message "Volume Driver Value file is required" on volume driver value set popup

Scenario: 06. Verify_name_is_duplicate
  When User add new volume driver value set for duplication "Test VolumeDriverValueSet"
  Then User verify validation message "Name already exists" on volume driver value set popup

Scenario: 07. Verify_delete_volume_driver_value_set
  Given User delete volume driver value set by name "Test VolumeDriverValueSet"

Scenario: 08. Verify_delete_button_is_disabled_in_default_volume_driver_value_set
  Given User verify delete button is disabled in default volume driver value set "Default VDV Set"

Scenario: 09. Verify_volume_driver_value_export_option
  Given User verify export option on volume driver values page

@Cleanup
Scenario: 10. Logout and Close Browser
  When User delete created records with below input
    | Department     | Test Department   |
    | Standard       | Test Standard     |
    | Location       | Test Location     |
    | VolumeDriver   | Test VolumeDriver |
    | UnitsOfMeasure | Test UOM          |
    | Attribute      | Test Attribute    |
  Then User logout from the application
  Then User close browser
	






