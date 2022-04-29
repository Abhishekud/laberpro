using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.VolumeDriverMapping
{
    [Binding]
    public class VolumeDriverMappingSteps
    {


        [Given(@"User Selected Created Department by name ""(.*)""")]
        [When(@"User Selected Created Department by name ""(.*)""")]
        [Then(@"User Selected Created Department by name ""(.*)""")]
        public void ThenUserSelectedCreatedDepartmentByName(string DeptName)
        {
            LogWriter.WriteLog("Executing Step User Selects Created Department " + DeptName);
            VolumeDriverMappingPage.SelectCreatedDepartment(DeptName);
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
            LogWriter.WriteLog("Executing VolumeDriversPage UserClickOnVolumeDriver ");
            VolumeDriverMappingPage.ClickOnVolumeDriverMapping();
        }

        [Given(@"User click on VolumeDriverMapping set")]
        [When(@"User click on VolumeDriverMapping set")]
        [Then(@"User click on VolumeDriverMapping set")]
        public void UserClickOnVolumeDriverset()
        {
            LogWriter.WriteLog("Executing VolumeDriversPage UserClickOnVolumeDriverset ");

            VolumeDriverMappingPage.ClickOnVolumeDriverset();
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
        public void UserVerifyCreatedVolumeDriver(String VolumeDriverName)
        {
            LogWriter.WriteLog("Executing  VolumeDriverMappingPage UserVerifyCreatedVolumeDriver");
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMapping(VolumeDriverName);
        }

        [Given(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        [When(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        [Then(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        public void UserDeleteCreatedVolumeDriver(String VolumeDriverName)
        {
            LogWriter.WriteLog("Executing  VolumeDriverMappingPage UserDeleteCreatedVolumeDriver");
            VolumeDriverMappingPage.DeleteCreatedVolumeDriverMapping(VolumeDriverName);
        }
        [Given(@"User delete created UOM by ""([^""]*)""")]
        [When(@"User delete created UOM by ""([^""]*)""")]
        [Then(@"User delete created UOM by ""([^""]*)""")]
        public void UserDeleteCreatedUOM(String UomName)
        {
            LogWriter.WriteLog("Executing  VolumeDriverMappingPage UserDeleteCreatedVolumeDriver");
            VolumeDriverMappingPage.DeleteCreatedUOM(UomName);
        }

        [Given(@"User verify created VolumeDriverMappingset by name ""([^""]*)""")]
        [When(@"User verify created VolumeDriverMappingset by name ""([^""]*)""")]
        [Then(@"User verify created VolumeDriverMappingset by name ""([^""]*)""")]
        public void VerifyCreatedVolumeDriverMapping(String VolumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing step: User verify created VolumeDriverMapping by name " + VolumeDriverMappingName);
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMappingset(VolumeDriverMappingName);
        }

        [Given(@"User delete created VolumeDriverMappingset by name ""([^""]*)""")]
        [When(@"User delete created VolumeDriverMappingset by name ""([^""]*)""")]
        [Then(@"User delete created VolumeDriverMappingset by name ""([^""]*)""")]
        public void DeleteCreatedVolumeDriverMapping(String VolumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing step: User delete created VolumeDriverMapping by name " + VolumeDriverMappingName);
            VolumeDriverMappingPage.DeleteCreatedVolumeDriverMappingset(VolumeDriverMappingName);
        }

        [Given(@"User delete VolumeDriverMappingset ""([^""]*)"" if exist")]
        [When(@"User delete VolumeDriverMappingset ""([^""]*)"" if exist")]
        [Then(@"User delete VolumeDriverMappingset ""([^""]*)"" if exist")]
        public void UserDeleteVolumeDriverMappingset(String VolumeDriverMappingsetName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriverMappingset by name" + VolumeDriverMappingsetName);
            VolumeDriverMappingPage.DeleteVolumeDriverMappingsetifexist(VolumeDriverMappingsetName);
        }
        [Given(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        [When(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        [Then(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        public void UserDeleteVolumeDriverMapping(String VolumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriverMapping by name" + VolumeDriverMappingName);
            VolumeDriverMappingPage.DeleteVolumeDriverMappingifexist(VolumeDriverMappingName);
        }

    }
}
