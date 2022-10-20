using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.Features.Department;
using LaborPro.Automation.Features.Locations;
using LaborPro.Automation.shared.util;

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
        public void UserVerifyCreatedLocationMapping(String locationMappingName)
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
            LocationMappingPage.VerifySaveButtonIsNotPresent(locationMappingName);
        }

        [Given(@"User verify details are not editable on location mapping page in  ""([^""]*)""")]
        [When(@"User verify details are not editable on location mapping page in  ""([^""]*)""")]
        [Then(@"User verify details are not editable on location mapping page in  ""([^""]*)""")]
        public void VerifyDetailsAreNotEditable(string locationMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify details are not editable on location mapping page in " + locationMappingName);
            LocationMappingPage.VerifyDetailsAreNotEditable(locationMappingName);
        }











        [When(@"User create location ""([^""]*)"" and department ""([^""]*)"" and map them")]
        [Then(@"User create location ""([^""]*)"" and department ""([^""]*)"" and map them")]
        [Given(@"User create location ""([^""]*)"" and department ""([^""]*)"" and map them")]
        public void LocationAndDepartmentMappingExists(string locationName, string departmentName)
        {
            LogWriter.WriteLog("Executing Step User create location " + locationName + " and department " + departmentName + " and map them");
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            DepartmentsPage.ClickOnDepartment();
            LocationMappingPage.AddNewDepartmentWithGivenInput(departmentName);
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationMappingPage.AddNewLocationWithGivenInput(locationName);
            LocationMappingPage.MapsCreatedDepartmentAndLocation(DataCache.Read(locationName), DataCache.Read(departmentName));
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

        [Given(@"User delete records ""([^""]*)"" and ""([^""]*)"" on location mapping page")]
        [Then(@"User delete records ""([^""]*)"" and ""([^""]*)"" on location mapping page")]
        [When(@"User delete records ""([^""]*)"" and ""([^""]*)"" on location mapping page")]
        public void DeleteRecordsAndOnLocationMappingPage(string locationName, string departmentName)
        {
            LogWriter.WriteLog("Executing Step User delete records " + locationName + " and " + departmentName + " on location mapping page");
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationPage.DeleteCreatedLocation(DataCache.Read(locationName));
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.DeleteDepartmentIfExist(DataCache.Read(departmentName));
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


    }
}
