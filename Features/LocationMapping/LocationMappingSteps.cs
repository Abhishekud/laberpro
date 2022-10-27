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

    }
}
