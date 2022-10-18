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
            LogWriter.WriteLog("Executing step: User edit location " + locationName + " with below input - " + inputData);
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
            LogWriter.WriteLog("Executing step: User delete created location by name " + locationName + " if exist");
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

        [Then(@"User verify add button is available on location page")]
        [Given(@"User verify add button is available on location page")]
        [When(@"User verify add button is available on location page")]
        public void VerifyAddButtonIsAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing Step: User verify add button is available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyAddButtonIsAvailable();
        }
        [Then(@"User verify add button options are available on location page")]
        [Given(@"User verify add button options are available on location page")]
        [When(@"User verify add button options are available on location page")]
        public void VerifyAddButtonOptionsAreAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing Step: User verify add button options are available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyAddButtonOptionsAreAvailable();
        }

        [Then(@"User verify new location popup is available on location page")]
        [When(@"User verify new location popup is available on location page")]
        [Given(@"User verify new location popup is available on location page")]
        public void VerifyNewLocationPopupIsAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing Step: User verify new location popup is available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyNewLocationPopupIsAvailable();

        }
        [Then(@"User verify created location ""([^""]*)""")]
        [When(@"User verify created location ""([^""]*)""")]
        [Given(@"User verify created location ""([^""]*)""")]
        public void UserVerifyCreatedLocation(string locationName)
        {
            LogWriter.WriteLog("Executing step: User verify created location " + locationName);
            LocationPage.VerifyCreatedLocation(DataCache.Read(locationName));
        }
        [When(@"User verify new location profile popup is available on location page")]
        [Then(@"User verify new location profile popup is available on location page")]
        [Given(@"User verify new location profile popup is available on location page")]
        public void VerifyNewLocationProfilePopupIsAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing Step: User verify new location profile popup is available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyNewLocationProfilePopupIsAvailable();

        }
        [When(@"User verify import locations popup is available on location page")]
        [Then(@"User verify import locations popup is available on location page")]
        [Given(@"User verify import locations popup is available on location page")]
        public void VerifyImportLocationsPopupIsAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing Step: User verify import locations popup is available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyImportLocationsPopupIsAvailable();
        }
        [When(@"User verify import locations profile popup is available on location page")]
        [Then(@"User verify import locations profile popup is available on location page")]
        [Given(@"User verify import locations profile popup is available on location page")]
        public void VerifyImportLocationsProfilePopupIsAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing Step: User verify import locations profile popup is available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyImportLocationsProfilePopupIsAvailable();
        }
        [Then(@"User verify created location profile by name ""([^""]*)""")]
        [When(@"User verify created location profile by name ""([^""]*)""")]
        [Given(@"User verify created location profile by name ""([^""]*)""")]
        public void VerifyCreatedLocationProfile(string locationProfile)
        {
            LogWriter.WriteLog("Executing step: User verify created location profile by name " + locationProfile);
            LocationPage.VerifyCreatedLocationProfile(locationProfile);
        }

        [Then(@"User verify location profile listing is available")]
        [When(@"User verify location profile listing is available")]
        [Given(@"User verify location profile listing is available")]
        public void VerifyLocationProfileListingIsAvailable()
        {
            LogWriter.WriteLog("Executing step: User verify location profile listing is available");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyLocationProfileListingIsAvailable();
        }
        [Given(@"User verify location profile edit options are available in ""([^""]*)""")]
        [When(@"User verify location profile edit options are available in ""([^""]*)""")]
        [Then(@"User verify location profile edit options are available in ""([^""]*)""")]
        public void VerifyLocationProfileEditOptionsAreAvailable(string locationProfile)
        {
            LogWriter.WriteLog("Executing step: User verify location profile edit options are available in " + locationProfile);
            NavigatesToTheLocationsTab();
            LocationPage.VerifyLocationProfileEditOptionsAreAvailable(locationProfile);
        }
        [Given(@"User verify checkboxes are available on location page")]
        [When(@"User verify checkboxes are available on location page")]
        [Then(@"User verify checkboxes are available on location page")]
        public void GivenUserVerifyCheckboxesAreAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing step: User verify checkboxes are available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.CloseLocationDetailSideBar();
            LocationPage.VerifyCheckboxesAreAvailable();
        }
        [Given(@"User verify bulk edit option is available on location page")]
        [When(@"User verify bulk edit option is available on location page")]
        [Then(@"User verify bulk edit option is available on location page")]
        public void VerifyBulkEditOptionIsAvailableInOnLocationPage()
        {
            LogWriter.WriteLog("Executing step: User verify bulk edit option is available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyBulkEditOptionIsAvailable();
        }
        [Given(@"User verify edit location options are available on location page")]
        [When(@"User verify edit location options are available on location page")]
        [Then(@"User verify edit location options are available on location page")]
        public void VerifyEditLocationOptionsAreAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing step: User verify edit location options are available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyEditLocationOptionsAreAvailable();
        }
        [Given(@"User verify edit location sidebar is available on location page")]
        [When(@"User verify edit location sidebar is available on location page")]
        [Then(@"User verify edit location sidebar is available on location page")]
        public void VerifyEditLocationSidebarIsAvailableOnLocationPage()
        {
            LogWriter.WriteLog("Executing step: User verify edit location sidebar is available on location page");
            NavigatesToTheLocationsTab();
            LocationPage.VerifyEditLocationSidebarIsAvailable();
        }
        [Given(@"User delete records ""([^""]*)"" and ""([^""]*)"" on location page")]
        [Then(@"User delete records ""([^""]*)"" and ""([^""]*)"" on location page")]
        [When(@"User delete records ""([^""]*)"" and ""([^""]*)"" on location page")]
        public void DeleteRecords(string locationName, string locationProfile)
        {
            LogWriter.WriteLog("Executing step: User delete records " + locationName + " and " + locationProfile + " on location page");
            NavigatesToTheLocationsTab();
            LocationPage.DeleteCreatedLocation(DataCache.Read(locationName));
            LocationPage.DeleteCreatedLocationProfile(DataCache.Read(locationProfile));
        }
        [When(@"User create new location ""([^""]*)""")]
        [Then(@"User create new location ""([^""]*)""")]
        [Given(@"User create new location ""([^""]*)""")]
        public void UserCreateNewLocation(string locationName)
        {
            LogWriter.WriteLog("Executing step: User create new location " + locationName);
            NavigatesToTheLocationsTab();
            LocationPage.CreateNewLocation(locationName);
        }
        [When(@"User create new location profile ""([^""]*)""")]
        [Then(@"User create new location profile ""([^""]*)""")]
        [Given(@"User create new location profile ""([^""]*)""")]
        public void WhenUserCreateNewLocationProfile(string locationProfile)
        {
            LogWriter.WriteLog("Executing step: User create new location profile " + locationProfile);
            NavigatesToTheLocationsTab();
            LocationPage.AddNewLocationProfileWithGivenInput(locationProfile);
        }

    }
}
