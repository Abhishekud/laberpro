using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Locations
{
    [Binding]
    public class LocationSteps
    {

        [When(@"User navigates to the Locations tab")]
        [Given(@"User navigates to the Locations tab")]
        [Then(@"User navigates to the Locations tab")]
        public void NavigatesToTheLocationsTab()
        {
            LogWriter.WriteLog("Executing step: User navigates to the Locations tab");
            LocationPage.CloseLocationForm();
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
        }

        [Given(@"User create new location with below input")]
        [When(@"User create new location with below input")]
        [Then(@"User create new location with below input")]
        public void AddNewLocationWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new location with below input");
            LocationPage.AddNewLocationWithGivenInput(inputData);
        }

        [Given(@"User create new location with below input if not exist")]
        [When(@"User create new location with below input if not exist")]
        [Then(@"User create new location with below input if not exist")]
        public void AddNewLocationWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new location with below input if not exist - " + inputData);
            LocationPage.AddNewLocationWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User edit location ""([^""]*)"" with below input")]
        [When(@"User edit location ""([^""]*)"" with below input")]
        [Then(@"User edit location ""([^""]*)"" with below input")]
        public void EditLocationWithGivenInput(string locationName, Table inputData)
        {
            LogWriter.WriteLog("Executing step: User edit location "+ locationName+" with below input - " + inputData);
            LocationPage.EditLocationWithGivenInput(locationName, inputData);
        }

        [Given(@"User verify created location by name ""([^""]*)""")]
        [When(@"User verify created location by name ""([^""]*)""")]
        [Then(@"User verify created location by name ""([^""]*)""")]
        public void VerifyCreatedLocation(String locationName)
        {
            LogWriter.WriteLog("Executing step: User verify created location by name " + locationName);
            LocationPage.VerifyCreatedLocation(locationName);
        }

        [Given(@"User delete created location by name ""([^""]*)""")]
        [When(@"User delete created location by name ""([^""]*)""")]
        [Then(@"User delete created location by name ""([^""]*)""")]
        public void DeleteCreatedLocation(String locationName)
        {
            LogWriter.WriteLog("Executing step: User delete created location by name " + locationName);
            LocationPage.DeleteCreatedLocation(locationName);
        }

        [Given(@"User delete location by name ""([^""]*)"" if exist")]
        [When(@"User delete location by name ""([^""]*)"" if exist")]
        [Then(@"User delete location by name ""([^""]*)"" if exist")]
        public void DeleteLocationIfExist(String locationName)
        {
            LogWriter.WriteLog("Executing step: User delete created location by name " + locationName +" if exist");
            LocationPage.DeleteLocationIfExist(locationName);
        }
        [Given(@"User verify add button is not available on location page")]
        [When(@"User verify add button is not available on location page")]
        [Then(@"User verify add button is not available on location page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step: User verify add button is not available on location page");
            LocationPage.VerifyAddButtonIsNotAvailable();
        }

        [Given(@"User verify export option is available on location page")]
        [When(@"User verify export option is available on location page")]
        [Then(@"User verify export option is available on location page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing step: User verify export option is available on location page");
            LocationPage.VerifyExportOptionIsPresent();
        }

        [Given(@"User verify export option is available for location profile")]
        [When(@"User verify export option is available for location profile")]
        [Then(@"User verify export option is available for location profile")]
        public void ExportOptionIsAvailableForLocationProfile()
        {
            LogWriter.WriteLog("Executing step: User verify export option is available for location profile");
            LocationPage.VerifyExportOptionIsPresent();
        }

        [Given(@"User selects location by name ""([^""]*)""")]
        [When(@"User selects location by name ""([^""]*)""")]
        [Then(@"User selects location by name ""([^""]*)""")]
        public void UserSelectsLocationByName(string locationName)
        {
            LogWriter.WriteLog("Executing step: User selects location by name " + locationName);
            LocationPage.SelectLocationRecord(locationName);
        }

        [Given(@"User verify edit option is not available on location page")]
        [When(@"User verify edit option is not available on location page")]
        [Then(@"User verify edit option is not available on location page")]
        public void VerifyEditOptionIsNotAvailable()
        {
            LogWriter.WriteLog("Executing step: User verify edit option is not available on location page");
            LocationPage.VerifyEditOptionIsNotAvailable();
        }

        [Given(@"User verify delete button is not available on location page")]
        [When(@"User verify delete button is not available on location page")]
        [Then(@"User verify delete button is not available on location page")]
        public void VerifyDeleteButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing step: User verify delete button is not available on location page");
            LocationPage.VerifyDeleteButtonIsNotAvailable();
        }

        [Given(@"User verify location record ""([^""]*)"" and department record ""([^""]*)"" cannot be mapped")]
        [Then(@"User verify location record ""([^""]*)"" and department record ""([^""]*)"" cannot be mapped")]
        [Then(@"User verify location record ""([^""]*)"" and department record ""([^""]*)"" cannot be mapped")]
        public void VerifyLocationRecordAndDepartmentRecordCannotBeMapped(string locationRecord, string departmentRecord)
        {
            LogWriter.WriteLog("User verify location record" + locationRecord + "and department record" + departmentRecord + "cannot be mapped");
            LocationPage.MapsCreatedDepartmentAndLocationNotAvailable(locationRecord, departmentRecord);

        }
    }
}
