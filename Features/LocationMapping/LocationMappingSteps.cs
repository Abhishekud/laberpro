using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.Features.Characteristic;
using LaborPro.Automation.Features.Department;
using LaborPro.Automation.Features.Locations;
using LaborPro.Automation.Features.VolumeDriverMapping;
using LaborPro.Automation.shared.util;
using TechTalk.SpecFlow.Assist;

namespace LaborPro.Automation.Features.LocationMapping
{
    [Binding]
    public class LocationMappingSteps
    {
        [When(@"User navigates to the LocationMapping tab")]
        [Given(@"User navigates to the LocationMapping tab")]
        [Then(@"User navigates to the LocationMapping tab")]
        public void NavigatesToTheLocationMappingTab()
        {
            LogWriter.WriteLog("Executing step: User navigates to the  LocationMapping tab");
            LocationMappingPage.CloseLocationDriverMappingForm();
            LocationMappingPage.ClickOnProfilingTab();
            LocationMappingPage.ClickOnLocationMappingTab();
        }

        [Given(@"User click on LocationMapping")]
        [When(@"User click on LocationMapping")]
        [Then(@"User click on LocationMapping")]
        public void UserClickOnVolumeDriver()
        {
            LogWriter.WriteLog("Executing VolumeDriversPage UserClickOnVolumeDriver ");
            LocationMappingPage.ClickOnLocationMappingTab();
        }

        [Given(@"User Maps created Department and location with ""(.*)"" and ""(.*)""")]
        [When(@"User Maps created Department and location with ""(.*)"" and ""(.*)""")]
        [Then(@"User Maps created Department and location with ""(.*)"" and ""(.*)""")]
        public void ThenUserMapsCreatedDepartmentAndLocation(string location, string department)
        {
            LocationMappingPage.MapsCreatedDepartmentAndLocation(location, department);
        }

        [Given(@"User create new LocationMapping with below input")]
        [When(@"User create new LocationMapping with below input")]
        [Then(@"User create new LocationMapping with below input")]
        public void AddNewLocationMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new LocationMapping with below input " + inputData);
            LocationMappingPage.AddNewLocationMappingWithGivenInput(inputData);
        }

        [Given(@"User select the Location ""([^""]*)""")]
        [Then(@"User select the Location ""([^""]*)""")]
        [When(@"User select the Location ""([^""]*)""")]
        public void SelectLocation(string locationName)
        {
            LogWriter.WriteLog("Executing Step:User select the Location" + locationName);
            LocationMappingPage.SelectTheLocation(locationName);
        }

        [Then(@"User refresh the page")]
        [Given(@"User refresh the page")]
        [When(@"User refresh the page")]
        public void RefreshPage()
        {
            LogWriter.WriteLog("Executing Step:User refresh the page");
            LocationMappingPage.Refresh();
        }

        [Given(@"User verify created LocationMapping ""([^""]*)""")]
        [When(@"User verify created LocationMapping ""([^""]*)""")]
        [Then(@"User verify created LocationMapping ""([^""]*)""")]
        public void UserVerifyCreatedLocationMapping(string locationMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify created LocationMapping by name" + locationMappingName);
            LocationMappingPage.VerifyCreatedLocationMapping(locationMappingName);
        }
        [Given(@"User select the department ""([^""]*)"" on location mapping page")]
        [When(@"User select the department ""([^""]*)"" on location mapping page")]
        [Then(@"User select the department ""([^""]*)"" on location mapping page")]
        public void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("User select the department " + departmentName + "on location mapping page");
            LocationMappingPage.SelectTheDepartment(departmentName);
        }

        [Given(@"User verify add button is not available on location mapping page")]
        [When(@"User verify add button is not available on location mapping page")]
        [Then(@"User verify add button is not available on location mapping page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on location mapping page");
            LocationMappingPage.VerifyAddButtonIsNotPresent();
        }
        [Given(@"User verify export option is available on location mapping page")]
        [When(@"User verify export option is available on location mapping page")]
        [Then(@"User verify export option is available on location mapping page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on location mapping page");
            LocationMappingPage.VerifyExportOptionIsPresent();
        }

        [Given(@"User verify save button is not available on location mapping page in  ""([^""]*)""")]
        [When(@"User verify save button is not available on location mapping page in  ""([^""]*)""")]
        [Then(@"User verify save button is not available on location mapping page in  ""([^""]*)""")]
        public void SaveButtonIsNotAvailable(string locationMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify save Button is not available on location mapping page in " + locationMappingName);
            LocationMappingPage.VerifySaveButtonIsNotPresent(DataCache.Read(locationMappingName));
        }

        [Given(@"User verify details are not editable on location mapping page in ""([^""]*)""")]
        [When(@"User verify details are not editable on location mapping page in ""([^""]*)""")]
        [Then(@"User verify details are not editable on location mapping page in ""([^""]*)""")]
        public void VerifyDetailsAreNotEditable(string locationMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify details are not editable on location mapping page in " + locationMappingName);
            LocationMappingPage.CloseLocationDriverMappingForm();
            LocationMappingPage.ClickOnProfilingTab();
            LocationMappingPage.ClickOnLocationMappingTab();
            LocationMappingPage.VerifyDetailsAreNotEditable(DataCache.Read(locationMappingName));
        }

        [Then(@"User verify add button is not available in ""([^""]*)"" on location mapping page")]
        [When(@"User verify add button is not available in ""([^""]*)"" on location mapping page")]
        [Given(@"User verify add button is not available in ""([^""]*)"" on location mapping page")]
        public void VerifyAddButtonIsNotAvailableInLocationMappingPage(string departmentName)
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available in " + departmentName + " on location mapping page");
            NavigatesToTheLocationMappingTab();
            LocationMappingPage.SelectTheDepartment(DataCache.Read(departmentName));
            LocationMappingPage.VerifyAddButtonIsNotAvailable();
        }
        [Then(@"User verify edit location mapping sidebar is available in ""([^""]*)""")]
        [When(@"User verify edit location mapping sidebar is available in ""([^""]*)""")]
        [Given(@"User verify edit location mapping sidebar is available in ""([^""]*)""")]
        public void VerifyEditLocationMappingSidebarIsAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing Step User verify edit location mapping sidebar is available in " + locationName);
            NavigatesToTheLocationMappingTab();
            LocationMappingPage.VerifyEditLocationMappingSidebarIsAvailable(DataCache.Read(locationName));
        }
        [Then(@"User verify edit detail options are not available in ""([^""]*)"" on location mapping page")]
        [When(@"User verify edit detail options are not available in ""([^""]*)"" on location mapping page")]
        [Given(@"User verify edit detail options are not available in ""([^""]*)"" on location mapping page")]
        public void VerifyEditDetailOptionsAreNotAvailableInOnLocationMappingPage(string locationName)
        {
            LogWriter.WriteLog("Executing Step User verify edit detail options are not available in " + locationName + " on location mapping page");
            NavigatesToTheLocationMappingTab();
            LocationMappingPage.VerifyEditDetailOptionsAreNotAvailable(DataCache.Read(locationName));
        } 

        [Then(@"User verify save button is not available in ""([^""]*)"" on location mapping page")]
        [When(@"User verify save button is not available in ""([^""]*)"" on location mapping page")]
        [Given(@"User verify save button is not available in ""([^""]*)"" on location mapping page")]
        public void VerifySaveButtonIsNotAvailableInOnLocationMappingPage(string locationName)
        {
            LogWriter.WriteLog("Executing Step User verify save button is not available in " + locationName + "on location mapping page");
            NavigatesToTheLocationMappingTab();
            LocationMappingPage.VerifySaveButtonIsNotAvailable(DataCache.Read(locationName));
        }
        [Given(@"User create prerequisites record for location mapping")]
        [When(@"User create prerequisites record for location mapping")]
        [Then(@"User create prerequisites record for location mapping")]
        public void CreatePrerequisitesRecordForLocationMapping(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create prerequisites record for location mapping " + inputData);
            var prerequisites = inputData.CreateInstance<LocationMapping>();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.AddNewDepartmentWithGivenInput(prerequisites.Department);
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationPage.CreateNewLocation(prerequisites.Location);
            CharacteristicsPage.CloseCharacteristicForm();
            CharacteristicsPage.ClickOnStandardTab();
            CharacteristicsPage.ClickOnCharacteristicTab();
            CharacteristicsPage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            CharacteristicsPage.ClickOnCharacteristicSet();
            CharacteristicsPage.AddNewCharacteristicSet(prerequisites.CharacteristicSet);
            VolumeDriverMappingPage.CloseVolumeDriverMappingForm();
            VolumeDriverMappingPage.ClickOnProfilingTab();
            VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab();
            VolumeDriverMappingPage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            VolumeDriverMappingPage.ClickOnVolumeDriverSet();
            VolumeDriverMappingPage.AddNewVolumeDriverMappingSet(prerequisites.VolumeDriverMappingSet);

        }

        [Given(@"User verify department ""([^""]*)"" and location ""([^""]*)"" are mapped on location mapping page")]
        [When(@"User verify department ""([^""]*)"" and location ""([^""]*)"" are mapped on location mapping page")]
        [Then(@"User verify department ""([^""]*)"" and location ""([^""]*)"" are mapped on location mapping page")]
        public void VerifyDepartmentAndLocationAreMapped(string department, string location)
        {
            LogWriter.WriteLog("Executing Step User verify department " + department + " and location " + location + " are mapped on location mapping page");
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationMappingPage.MapsCreatedDepartmentAndLocation(DataCache.Read(location), DataCache.Read(department));
            LocationMappingPage.ClickOnLocationMappingTab();
            LocationMappingPage.SelectTheDepartment(DataCache.Read(department));
            LocationMappingPage.VerifyCreatedLocationMapping(DataCache.Read(location));
        }

        [Given(@"User verify location mapping")]
        [When(@"User verify location mapping")]
        [Then(@"User verify location mapping")]
        public void VerifyLocationMapping(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User verify location mapping " + inputData);
            var prerequisites = inputData.CreateInstance<LocationMapping>();
            LocationMappingPage.Refresh();
            LocationMappingPage.ClickOnProfilingTab();
            LocationMappingPage.ClickOnLocationMappingTab();
            LocationMappingPage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            LocationMappingPage.SelectTheLocation(DataCache.Read(prerequisites.Location));
            LocationMappingPage.AddNewLocationMappingWithGivenInput(DataCache.Read(prerequisites.VolumeDriverMappingSet), DataCache.Read(prerequisites.CharacteristicSet));
            LocationMappingPage.VerifyCreatedLocationMapping(DataCache.Read(prerequisites.Location));

        }

        [Given(@"User verify department ""([^""]*)"" and record is ""([^""]*)"" on location mapping page")]
        [When(@"User verify department ""([^""]*)"" and record is ""([^""]*)"" on location mapping page")]
        [Then(@"User verify department ""([^""]*)"" and record is ""([^""]*)"" on location mapping page")]
        public void VerifyDepartmentAndRecordIsAvailable(string department, string record)
        {
            LogWriter.WriteLog("Executing Step User verify " + department + "is available in department dropdown and record is" + record + " on location mapping page");
            LocationMappingPage.CloseLocationDriverMappingForm();
            LocationMappingPage.ClickOnProfilingTab();
            LocationMappingPage.ClickOnLocationMappingTab();
            LocationMappingPage.SelectTheDepartment(DataCache.Read(department));
            LocationMappingPage.VerifyRecordOfSelectedDept(record);
        }

        [Given(@"User delete prerequisites department ""([^""]*)"" and location ""([^""]*)"" for location mapping")]
        [When(@"User delete prerequisites department ""([^""]*)"" and location ""([^""]*)"" for location mapping")]
        [Then(@"User delete prerequisites department ""([^""]*)"" and location ""([^""]*)"" for location mapping")]
        public void DeletePrerequisitesRecord(string department, string location)
        {
            LogWriter.WriteLog("Executing Step User delete prerequisites department " + department + " and location " + location + " for location mapping");
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationPage.DeleteCreatedLocation(DataCache.Read(location));
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.DeleteCreatedDepartment(DataCache.Read(department));
        }
        [Given(@"User setup prerequisites with department ""([^""]*)"" and location ""([^""]*)"" for location mapping")]
        [When(@"User setup prerequisites with department ""([^""]*)"" and location ""([^""]*)"" for location mapping")]
        [Then(@"User setup prerequisites with department ""([^""]*)"" and location ""([^""]*)"" for location mapping")]
        public void SetupPrerequisitesForLocationMapping(string department, string location)
        {
            LogWriter.WriteLog("Executing Step User setup prerequisites with department " + department + " and location " + location + " for location mapping");
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.AddNewDepartmentWithGivenInput(department);
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationPage.CreateNewLocation(location);
            LocationMappingPage.MapsCreatedDepartmentAndLocation(DataCache.Read(location), DataCache.Read(department));
        }

        [Given(@"User verify add button is not available for department ""([^""]*)"" on location mapping page")]
        [When(@"User verify add button is not available for department ""([^""]*)"" on location mapping page")]
        [Then(@"User verify add button is not available for department ""([^""]*)"" on location mapping page")]
        public void VerifyAddButtonIsNotAvailable(string department)
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available for department " + department + " on location mapping page");
            LocationMappingPage.ClickOnProfilingTab();
            LocationMappingPage.ClickOnLocationMappingTab();
            LocationMappingPage.SelectTheDepartment(DataCache.Read(department));
            LocationMappingPage.VerifyAddButtonIsNotAvailable();
        }

    }
}