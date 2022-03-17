using laborpro.drivers;
using laborpro.pages;
using laborpro.util;

namespace laborpro.glue
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
        public void ThenUserMapsCreatedDepartmentAndLocationWithAnd(string Location, string Department)
        {
            LocationMappingPage.MapscreatedDepartmentandlocation(Location, Department);
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
        public void SelectLocation(string LocationName)
        {
            LogWriter.WriteLog("Executing Step:User select the Location" + LocationName);
            LocationMappingPage.SelectTheLocation(LocationName);
        }

        [Then(@"User refresh the page")]
        [Given(@"User refresh the page")]
        [When(@"User refresh the page")]
        public void refreshpage()
        {
            LogWriter.WriteLog("Executing Step:User refresh the page");
            LocationMappingPage.refresh();
        }


        [Given(@"User verify created LocationMapping ""([^""]*)""")]
        [When(@"User verify created LocationMapping ""([^""]*)""")]
        [Then(@"User verify created LocationMapping ""([^""]*)""")]
        public void UserVerifyCreatedLocationMapping(String LocationMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify created LocationMapping by name" + LocationMappingName);
            LocationMappingPage.VerifyCreatedLocationMapping(LocationMappingName);
        }



    }
}
