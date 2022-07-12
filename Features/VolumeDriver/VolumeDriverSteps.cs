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
            LogWriter.WriteLog("Executing Step User navigates to the VolumeDriver tab");
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
            LogWriter.WriteLog("Executing Step User create new VolumeDriver with below input " + inputData);
            VolumeDriverPage.AddNewVolumeDriverWithGivenInput(inputData);
        }

        [Given(@"User create new VolumeDriver with below input if not exist")]
        [When(@"User create new VolumeDriver with below input if not exist")]
        [Then(@"User create new VolumeDriver with below input if not exist")]
        public void AddNewVolumeDriverWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new VolumeDriver with below input if not exist" + inputData);
            VolumeDriverPage.AddNewVolumeDriverWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created VolumeDriver by name ""([^""]*)""")]
        [When(@"User verify created VolumeDriver by name ""([^""]*)""")]
        [Then(@"User verify created VolumeDriver by name ""([^""]*)""")]
        public void UserVerifyCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing Step User verify created VolumeDriver by name" + volumeDriverName);
            VolumeDriverPage.VerifyCreatedVolumeDriver(volumeDriverName);
        }

        [Given(@"User delete created VolumeDriver by name ""([^""]*)""")]
        [When(@"User delete created VolumeDriver by name ""([^""]*)""")]
        [Then(@"User delete created VolumeDriver by name ""([^""]*)""")]
        public void UserDeleteCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriver by name" + volumeDriverName);
            VolumeDriverPage.DeleteCreatedVolumeDriver(volumeDriverName);
        }

        [When(@"User search VolumeDriver ""([^""]*)""")]
        public void WhenUserSearchVolumeDriver(string volumeDriver)
        {
            LogWriter.WriteLog("Executing Step User search VolumeDriver" +volumeDriver);
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
        [Then(@"User verify add button is not available on volume driver page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on volume driver page");
            VolumeDriverPage.VerifyAddButtonIsNotPresent();
        } 
        [Then(@"User verify export option is not available on volume driver page")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export button is not available on volume driver page");
            VolumeDriverPage.VerifyExportOptionIsNotPresent();
        } 
        [Then(@"User verify delete button is not available on volume driver page ""([^""]*)""")]
        public void VerifyDeleteButtonIsNotPresent(string volumeDriver)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on volume driver page"+ volumeDriver);
            VolumeDriverPage.VerifyDeleteButtonIsNotPresent(volumeDriver);
        }
    }
}
