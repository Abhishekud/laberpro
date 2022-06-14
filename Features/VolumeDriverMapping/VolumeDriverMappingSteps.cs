using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.VolumeDriverMapping
{
    [Binding]
    public class VolumeDriverMappingSteps
    {


        [Given(@"User Selected Created Department by name ""(.*)""")]
        [When(@"User Selected Created Department by name ""(.*)""")]
        [Then(@"User Selected Created Department by name ""(.*)""")]
        public void ThenUserSelectedCreatedDepartmentByName(string deptName)
        {
            LogWriter.WriteLog("Executing Step User Selects Created Department " + deptName);
            VolumeDriverMappingPage.SelectCreatedDepartment(deptName);
        }

        [Given(@"User navigates to the VolumeDriverMapping tab")]
        [When(@"User navigates to the VolumeDriverMapping tab")]
        [Then(@"User navigates to the VolumeDriverMapping tab")]
        public void NavigatesToTheVolumeDriverMappingTab()
        {
            LogWriter.WriteLog("Executing step: User navigates to the VolumeDriverMapping tab");
            VolumeDriverMappingPage.CloseVolumeDriverMappingForm();
            VolumeDriverMappingPage.ClickOnProfilingTab();
            VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab();
        }

        [Given(@"User click on VolumeDriverMapping")]
        [When(@"User click on VolumeDriverMapping")]
        [Then(@"User click on VolumeDriverMapping")]
        public void UserClickOnVolumeDriver()
        {
            LogWriter.WriteLog("Executing step: User click on VolumeDriverMapping");
            VolumeDriverMappingPage.ClickOnVolumeDriverMapping();
        }

        [Given(@"User click on VolumeDriverMapping set")]
        [When(@"User click on VolumeDriverMapping set")]
        [Then(@"User click on VolumeDriverMapping set")]
        public void UserClickOnVolumeDriverSet()
        {
            LogWriter.WriteLog("Executing step: User click on VolumeDriverMapping set");
            VolumeDriverMappingPage.ClickOnVolumeDriverSet();
        }

        [Given(@"User create new VolumeDriverMappingset with below input")]
        [When(@"User create new VolumeDriverMappingset with below input")]
        [Then(@"User create new VolumeDriverMappingset with below input")]
        public void AddNewVolumeDriverMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new VolumeDriverMapping with below input");
            VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput(inputData);
        }

        [Given(@"User create new VolumeDriverMapping with below input if not exist")]
        [When(@"User create new VolumeDriverMapping with below input if not exist")]
        [Then(@"User create new VolumeDriverMapping with below input if not exist")]
        public void AddNewVolumeDriverMappingWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new VolumeDriverMapping with below input if not exist - " + inputData);
            VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created VolumeDriverMapping by ""([^""]*)""")]
        [When(@"User verify created VolumeDriverMapping by ""([^""]*)""")]
        [Then(@"User verify created VolumeDriverMapping by ""([^""]*)""")]
        public void UserVerifyCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing step: User verify created VolumeDriverMapping by name ");
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMapping(volumeDriverName);
        }

        [Given(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        [When(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        [Then(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        public void UserDeleteCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing step: User delete created VolumeDriverMapping by  name");
            VolumeDriverMappingPage.DeleteCreatedVolumeDriverMapping(volumeDriverName);
        }

        [Given(@"User delete created UOM by ""([^""]*)""")]
        [When(@"User delete created UOM by ""([^""]*)""")]
        [Then(@"User delete created UOM by ""([^""]*)""")]
        public void DeleteCreatedUom(string uomName)
        {
            LogWriter.WriteLog("Executing step: User delete created UOM by name ");
            VolumeDriverMappingPage.DeleteCreatedUom(uomName);
        }

        [Given(@"User verify created VolumeDriverMappingset by name ""([^""]*)""")]
        [When(@"User verify created VolumeDriverMappingset by name ""([^""]*)""")]
        [Then(@"User verify created VolumeDriverMappingset by name ""([^""]*)""")]
        public void VerifyCreatedVolumeDriverMapping(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing step: User verify created VolumeDriverMapping by name " + volumeDriverMappingName);
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMappingSet(volumeDriverMappingName);
        }

        [Given(@"User delete created VolumeDriverMappingset by name ""([^""]*)""")]
        [When(@"User delete created VolumeDriverMappingset by name ""([^""]*)""")]
        [Then(@"User delete created VolumeDriverMappingset by name ""([^""]*)""")]
        public void DeleteCreatedVolumeDriverMapping(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing step: User delete created VolumeDriverMapping by name " + volumeDriverMappingName);
            VolumeDriverMappingPage.DeleteCreatedVolumeDriverMappingSet(volumeDriverMappingName);
        }

        [Given(@"User delete VolumeDriverMappingset ""([^""]*)"" if exist")]
        [When(@"User delete VolumeDriverMappingset ""([^""]*)"" if exist")]
        [Then(@"User delete VolumeDriverMappingset ""([^""]*)"" if exist")]
        public void UserDeleteVolumeDriverMappingSet(string volumeDriverMappingsetName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriverMappingset by name" + volumeDriverMappingsetName);
            VolumeDriverMappingPage.DeleteVolumeDriverMappingsetIfExist(volumeDriverMappingsetName);
        }

        [Given(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        [When(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        [Then(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        public void UserDeleteVolumeDriverMapping(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriverMapping by name" + volumeDriverMappingName);
            VolumeDriverMappingPage.DeleteVolumeDriverMappingIfExist(volumeDriverMappingName);
        }

    }
}
