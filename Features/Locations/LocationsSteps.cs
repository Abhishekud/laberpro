using laborpro.pages;
using laborpro.util;

namespace laborpro.glue
{
    [Binding]
    public class LocationsSteps
    {

        [When(@"User navigates to the Locations tab")]
        [Given(@"User navigates to the Locations tab")]
        [Then(@"User navigates to the Locations tab")]
        public void NavigatesToTheLocationsTab()
        {
            LogWriter.WriteLog("Executing step: User navigates to the Locations tab");
            LocationsPage.CloseLocationForm();
            LocationsPage.ClickOnProfilingTab();
            LocationsPage.ClickOnLocationsTab();
            LocationsPage.ClearAllFilter();
            LocationsPage.KeepRecordUnsort();
        }

        [Given(@"User create new location with below input")]
        [When(@"User create new location with below input")]
        [Then(@"User create new location with below input")]
        public void AddNewLocationWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new location with below input");
            LocationsPage.AddNewLocationWithGivenInput(inputData);
        }

        [Given(@"User create new location with below input if not exist")]
        [When(@"User create new location with below input if not exist")]
        [Then(@"User create new location with below input if not exist")]
        public void AddNewLocationWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new location with below input if not exist - " + inputData);
            LocationsPage.AddNewLocationWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User edit location ""([^""]*)"" with below input")]
        [When(@"User edit location ""([^""]*)"" with below input")]
        [Then(@"User edit location ""([^""]*)"" with below input")]
        public void EditLocationWithGivenInput(string locationName, Table inputData)
        {
            LogWriter.WriteLog("Executing step: User edit location "+ locationName+" with below input - " + inputData);
            LocationsPage.EditLocationWithGivenInput(locationName, inputData);
        }

        [Given(@"User verify created location by name ""([^""]*)""")]
        [When(@"User verify created location by name ""([^""]*)""")]
        [Then(@"User verify created location by name ""([^""]*)""")]
        public void VerifyCreatedLocation(String locationName)
        {
            LogWriter.WriteLog("Executing step: User verify created location by name " + locationName);
            LocationsPage.VerifyCreatedLocation(locationName);
        }

        [Given(@"User delete created location by name ""([^""]*)""")]
        [When(@"User delete created location by name ""([^""]*)""")]
        [Then(@"User delete created location by name ""([^""]*)""")]
        public void DeleteCreatedLocation(String locationName)
        {
            LogWriter.WriteLog("Executing step: User delete created location by name " + locationName);
            LocationsPage.DeleteCreatedLocation(locationName);
        }

        [Given(@"User delete location by name ""([^""]*)"" if exist")]
        [When(@"User delete location by name ""([^""]*)"" if exist")]
        [Then(@"User delete location by name ""([^""]*)"" if exist")]
        public void DeleteLocationIfExist(String locationName)
        {
            LogWriter.WriteLog("Executing step: User delete created location by name " + locationName +" if exist");
            LocationsPage.DeleteLocationIfExist(locationName);
        }

    }
}
