using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.VolumeDriver
{
    [Binding]
    public class VolumeDriverSteps
    {

        [When(@"User navigates to the VolumeDriver tab")]
        [Given(@"User navigates to the VolumeDriver tab")]
        [Then(@"User navigates to the VolumeDriver tab")]
        public void UserNavigatesToTheListManagementsTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.UserNavigatesToTheListManagementTab ");
            VolumeDriverPage.CloseVolumeDriverForm();
            VolumeDriverPage.ClickOnStandardTab();
            VolumeDriverPage.ClickOnListManagementTab();
            VolumeDriverPage.ClickOnVolumeDriver();
        }

        [Given(@"User create new VolumeDriver with below input")]
        [When(@"User create new VolumeDriver with below input")]
        [Then(@"User create new VolumeDriver with below input")]
        public void AddNewVolumeDriverWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new VolumeDriver with below input " + inputData);
            VolumeDriverPage.AddNewVolumeDriverWithGivenInput(inputData);
        }

        [Given(@"User create new VolumeDriver with below input if not exist")]
        [When(@"User create new VolumeDriver with below input if not exist")]
        [Then(@"User create new VolumeDriver with below input if not exist")]
        public void AddNewVolumeDriverWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new VolumeDriver with below input " + inputData);
            VolumeDriverPage.AddNewVolumeDriverWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created VolumeDriver by name ""([^""]*)""")]
        [When(@"User verify created VolumeDriver by name ""([^""]*)""")]
        [Then(@"User verify created VolumeDriver by name ""([^""]*)""")]
        public void UserVerifyCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing User verify created VolumeDriver by name" + volumeDriverName);
            VolumeDriverPage.VerifyCreatedVolumeDriver(volumeDriverName);
        }

        [Given(@"User delete created VolumeDriver by name ""([^""]*)""")]
        [When(@"User delete created VolumeDriver by name ""([^""]*)""")]
        [Then(@"User delete created VolumeDriver by name ""([^""]*)""")]
        public void UserDeleteCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing User delete created VolumeDriver by name" + volumeDriverName);
            VolumeDriverPage.DeleteCreatedVolumeDriver(volumeDriverName);
        }

        [When(@"User search VolumeDriver ""([^""]*)""")]
        public void WhenUserSearchVolumeDriver(string volumeDriver)
        {
            LogWriter.WriteLog("Executing step User search VolumeDriver ");
            VolumeDriverPage.ClearAllFilter();
            VolumeDriverPage.SearchVolumeDriver(volumeDriver);
        }

        [Given(@"User delete VolumeDriver ""([^""]*)"" if exist")]
        [When(@"User delete VolumeDriver ""([^""]*)"" if exist")]
        [Then(@"User delete VolumeDriver ""([^""]*)"" if exist")]
        public void UserDeleteVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriver by name" + volumeDriverName);
            VolumeDriverPage.DeleteVolumeDriverIfExist(volumeDriverName);
        }
        [Given(@"User verify add button is not present")]
        [When(@"User verify add button is not present")]
        [Then(@"User verify add button is not present")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not present");
            VolumeDriverPage.VerifyAddButtonIsNotPresent();
        }
        [Given(@"User verify Export option is not present")]
        [When(@"User verify Export option is not present")]
        [Then(@"User verify Export option is not present")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Export button is not present");
            VolumeDriverPage.VerifyExportOptionIsNotPresent();
        }
        [Given(@"User verify Delete button is not present ""([^""]*)""")]
        [When(@"User verify Delete button is not present ""([^""]*)""")]
        [Then(@"User verify Delete button is not present ""([^""]*)""")]
        public void VerifyDeleteButtonIsNotPresent(string volumeDriver)
        {
            LogWriter.WriteLog("Executing Step User verify Delete button is not present");
            VolumeDriverPage.VerifyDeleteButtonIsNotPresent(volumeDriver);
        }
    }
}
