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
            LocationPage.KeepRecordUnsort();
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

    }
}
