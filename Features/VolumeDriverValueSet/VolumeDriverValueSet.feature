@Regression @VolumeDriverValueSet
Feature: Verify VolumeDriverValueSet Module

@Setup @Smoke
Scenario: 01. Launch Browser and Login to the Application and perform prerequisites
	Given User launched "$browser"
	When User go to application "$url"
	Then User logged in with super admin access using username: "$superadmin_username" and password: "$superadmin_password"
	And Verify Login message: "success"
	Then User navigates to the List Management tab
	And User selects Department
	And User create new Department with below input if not exist
		| Key  | Value                                     |
		| Name | Department to verify VolumeDriverValueSet |
	Then User navigates to the standards tab
	And User delete Standard "standardforvolumedrivervalueset" if exist
	And User navigates to the attribute tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User delete attribute "attributeforvolumedrivervalueset" if exist
	And User add new attribute using below input
		| Key  | Value                            |
		| Name | attributeforvolumedrivervalueset |
	Then User navigates to the Characteristic tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User click on Characteristic set
	And User create new Characteristic with below input
		| Key  | Value                          |
		| Name | charsetforvolumedrivervalueset |
	And User refresh the page
	Then User navigates to the standards tab
	And User delete Standard "standardforvolumedrivervalueset" if exist
	And User add new standards using below input
		| Key        | Value                                     |
		| Name       | standardforvolumedrivervalueset           |
		| Department | Department to verify VolumeDriverValueSet |
		| Attribute  | attributeforvolumedrivervalueset          |
	And User click on previous link
	Then User navigates to the VolumeDriverMapping tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User delete VolumeDriverMapping "VolumeDriver_created via automations" if exist
	Then User navigates to the List Management tab
	And User selects UnitOfMeasure
	And User Selects Created Department "Department to verify VolumeDriverValueSet"
	And User delete UnitOfMeasure "UOMforvolumedrivervalueset" if exist
	And User adds Unit Of Measure using below input
		| Key  | Value                      |
		| Name | UOMforvolumedrivervalueset |
	Then User navigates to the standards tab
	And User search standard by name "standardforvolumedrivervalueset"
	And User selects standard by name "standardforvolumedrivervalueset"
	And User clicks New Standard Element
	And User Selects Standard Element type "Estimate"
	And User adds new Standard Element Using Below input
		| Key             | Value                      |
		| Name            | Dummy                      |
		| Frequency       | 16                         |
		| Unit of Measure | UOMforvolumedrivervalueset |
	And User click on previous link
	Then User navigates to the Locations tab
	And User delete location by name "Locationforvolumedrivervalueset" if exist
	And User create new location with below input
		| Key  | Value                           |
		| Name | Locationforvolumedrivervalueset |
	And User Maps created Department and location with "Locationforvolumedrivervalueset" and "Department to verify VolumeDriverValueSet"
	Then User click on LocationMapping
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User verify created LocationMapping "Locationforvolumedrivervalueset"
	Then User navigates to the VolumeDriverMapping tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User delete VolumeDriverMappingSet "VolumeDriverMappingset_automations" if exist
	And User click on VolumeDriverMapping set
	And User create new VolumeDriverMappingSet with below input
		| Key  | Value                              |
		| Name | VolumeDriverMappingset_automations |
	Then User navigates to the VolumeDriver tab
	And User delete VolumeDriver "VolumeDriver_created via automations" if exist
	And User create new VolumeDriver with below input
		| Key        | Value                                     |
		| Name       | VolumeDriver_created via automations      |
		| Department | Department to verify VolumeDriverValueSet |
	Then User navigates to the VolumeDriverMapping tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User delete VolumeDriverMapping "VolumeDriver_created via automations" if exist
	And User click on VolumeDriverMapping
	Then User create new VolumeDriverMappingSet with below input
		| Key                    | Value                                |
		| VolumeDriver           | VolumeDriver_created via automations |
		| UOM                    | UOMforvolumedrivervalueset           |
		| VolumeDriverMappingSet | 2                                    |
	Then User navigates to the LocationMapping tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User select the Location "Locationforvolumedrivervalueset"
	And User refresh the page
	Then User navigates to the LocationMapping tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User select the Location "Locationforvolumedrivervalueset"
	And User create new LocationMapping with below input
		| Key                    | Value                              |
		| VolumeDriverMappingSet | VolumeDriverMappingset_automations |
		| CharacteristicSet      | charsetforvolumedrivervalueset     |

Scenario: 02. Verify_new_volume_driver_value_set_popup
	When User navigates to volume driver value set page
	Then User verify new volume driver value set popup

Scenario: 03. Verify_add_volume_driver_value_set_module_for_super_admin_user
	Given User navigates to volume driver value set page
	When User download volume driver value import template
	Then User verify volume driver value downloaded file "Volume-Driver-Values-import-template"
	And User access the downloaded file and update volume driver value in location "Locationforvolumedrivervalueset" "Department to verify VolumeDriverValueSet" "VolumeDriver_created via automations" "10"
	Then User navigates to volume driver value set page
	And User add new volume driver value set using below input 
		| Key  | Value                                       |
		| Name | VolumeDriverValueSet created via automation |
	Then User verify volume driver value set by name "VolumeDriverValueSet created via automation"
	Then User navigates to volume driver values tab
	When User selects volume driver value sets by name "VolumeDriverValueSet created via automation"
	Then User verify location department volume driver in volume driver value page "Locationforvolumedrivervalueset" "Department to verify VolumeDriverValueSet" "VolumeDriver_created via automations"

Scenario: 04. Verify_name_is_empty
	Given User navigates to volume driver value set page
	When User add new volume driver value set using below input
		| Key  | Value |
		| Name |       |
	And User click save button on volume driver value set popup
	Then User verify validation message "Name is required" on volume driver value set popup

Scenario: 05. Verify_volume_driver_value_file_not_selected
	Given User navigates to volume driver value set page
	When User add new volume driver value set using below input if not exist
		| Key  | Value |
		| Name | Demo  |
	And User click save button on volume driver value set popup
	Then User verify validation message "Volume Driver Value file is required" on volume driver value set popup

Scenario: 06. Verify_name_is_duplicate
	Given User navigates to volume driver value set page
	When User add new volume driver value set using below input
		| Key  | Value                                       |
		| Name | VolumeDriverValueSet created via automation |
	Then User verify validation message "Name already exists" on volume driver value set popup

Scenario: 07. Verify_delete_volume_driver_value_set
	When User navigates to volume driver value set page
	Then User delete volume driver value set by name "VolumeDriverValueSet created via automation"

Scenario: 08. Verify_delete_button_is_disabled_in_default_volume_driver_value_set
	Given User navigates to volume driver value set page
	When User selects default volume driver value set "Default VDV Set"
	Then User verify delete button is disabled in default volume driver value set

Scenario: 09. Verify_volume_driver_value_export_option
	When User navigates to volume driver values tab
	Then User verify export option on volume driver values page

@Cleanup
Scenario: 10. Logout and Close Browser
	Then User navigates to the Locations tab
	And User delete created location by name "Locationforvolumedrivervalueset"
	Then User navigates to the VolumeDriverMapping tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User delete created VolumeDriverMapping by "VolumeDriver_created via automations"
	Then User navigates to the VolumeDriver tab
	And User delete created VolumeDriver by name "VolumeDriver_created via automations"
	Then User navigates to the standards tab
	And User search standard by name "standardforvolumedrivervalueset"
	And User selects standard by name "standardforvolumedrivervalueset"
	Then User Delete created Standards
	Then User navigates to the List Management tab
	And User selects UnitOfMeasure
	And User Selects Created Department "Department to verify VolumeDriverValueSet"
	And User delete UOM by name "UOMforvolumedrivervalueset"
	Then User navigates to the attribute tab
	And User select the Department "Department to verify VolumeDriverValueSet"
	And User delete created attribute:"attributeforvolumedrivervalueset"
	Then User navigates to the List Management tab
	And User selects Department
	And User delete created Department "Department to verify VolumeDriverValueSet"
	When User logout from the application
	Then User close browser






