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
            LogWriter.WriteLog("Executing Step User Selected Created Department by name" + deptName);
            VolumeDriverMappingPage.SelectCreatedDepartment(deptName);
        }

        [Given(@"User navigates to the VolumeDriverMapping tab")]
        [When(@"User navigates to the VolumeDriverMapping tab")]
        [Then(@"User navigates to the VolumeDriverMapping tab")]
        public void NavigatesToTheVolumeDriverMappingTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the VolumeDriverMapping tab");
            VolumeDriverMappingPage.CloseVolumeDriverMappingForm();
            VolumeDriverMappingPage.ClickOnProfilingTab();
            VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab();
        }

        [Given(@"User click on VolumeDriverMapping")]
        [When(@"User click on VolumeDriverMapping")]
        [Then(@"User click on VolumeDriverMapping")]
        public void UserClickOnVolumeDriver()
        {
            LogWriter.WriteLog("Executing Step User click on VolumeDriverMapping");
            VolumeDriverMappingPage.ClickOnVolumeDriverMapping();
        }

        [Given(@"User click on VolumeDriverMapping set")]
        [When(@"User click on VolumeDriverMapping set")]
        [Then(@"User click on VolumeDriverMapping set")]
        public void UserClickOnVolumeDriverSet()
        {
            LogWriter.WriteLog("Executing Step User click on VolumeDriverMapping set");

            VolumeDriverMappingPage.ClickOnVolumeDriverSet();
        }

        [Given(@"User create new VolumeDriverMappingSet with below input")]
        [When(@"User create new VolumeDriverMappingSet with below input")]
        [Then(@"User create new VolumeDriverMappingSet with below input")]
        public void AddNewVolumeDriverMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step:  User create new VolumeDriverMappingSet with below input" + inputData);
            VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput(inputData);
        }

        [Given(@"User create new VolumeDriverMapping with below input if not exist")]
        [When(@"User create new VolumeDriverMapping with below input if not exist")]
        [Then(@"User create new VolumeDriverMapping with below input if not exist")]
        public void AddNewVolumeDriverMappingWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User create new VolumeDriverMapping with below input if not exist - " + inputData);
            VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created VolumeDriverMapping by ""([^""]*)""")]
        [When(@"User verify created VolumeDriverMapping by ""([^""]*)""")]
        [Then(@"User verify created VolumeDriverMapping by ""([^""]*)""")]
        public void UserVerifyCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing Step User verify created VolumeDriverMapping by - " + volumeDriverName);
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMapping(volumeDriverName);
        }

        [Given(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        [When(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        [Then(@"User delete created VolumeDriverMapping by ""([^""]*)""")]
        public void UserDeleteCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriverMapping by - " + volumeDriverName);
            VolumeDriverMappingPage.DeleteCreatedVolumeDriverMapping(volumeDriverName);
        }

        [Given(@"User delete created UOM by ""([^""]*)""")]
        [When(@"User delete created UOM by ""([^""]*)""")]
        [Then(@"User delete created UOM by ""([^""]*)""")]
        public void UserDeleteCreatedUom(string uomName)
        {
            LogWriter.WriteLog("Executing Step User delete created UOM by - " + uomName);
            VolumeDriverMappingPage.DeleteCreatedUom(uomName);
        }

        [Given(@"User verify created VolumeDriverMappingSet by name ""([^""]*)""")]
        [When(@"User verify created VolumeDriverMappingSet by name ""([^""]*)""")]
        [Then(@"User verify created VolumeDriverMappingSet by name ""([^""]*)""")]
        public void VerifyCreatedVolumeDriverMapping(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step: User verify created VolumeDriverMapping set by name " + volumeDriverMappingName);
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMappingSet(volumeDriverMappingName);
        }

        [Given(@"User delete created VolumeDriverMappingSet by name ""([^""]*)""")]
        [When(@"User delete created VolumeDriverMappingSet by name ""([^""]*)""")]
        [Then(@"User delete created VolumeDriverMappingSet by name ""([^""]*)""")]
        public void DeleteCreatedVolumeDriverMapping(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step: User delete created VolumeDriverMapping set by name " + volumeDriverMappingName);
            VolumeDriverMappingPage.DeleteCreatedVolumeDriverMappingSet(volumeDriverMappingName);
        }

        [Given(@"User delete VolumeDriverMappingSet ""([^""]*)"" if exist")]
        [When(@"User delete VolumeDriverMappingSet ""([^""]*)"" if exist")]
        [Then(@"User delete VolumeDriverMappingSet ""([^""]*)"" if exist")]
        public void UserDeleteVolumeDriverMappingSet(string volumeDriverMappingSetName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriverMapping set by name" + volumeDriverMappingSetName);
            VolumeDriverMappingPage.DeleteVolumeDriverMappingSetIfExist(volumeDriverMappingSetName);
        }

        [Given(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        [When(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        [Then(@"User delete VolumeDriverMapping ""([^""]*)"" if exist")]
        public void UserDeleteVolumeDriverMapping(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step User delete created VolumeDriverMapping by name" + volumeDriverMappingName);
            VolumeDriverMappingPage.DeleteVolumeDriverMappingIfExist(volumeDriverMappingName);
        }
        [Given(@"User verify add button is not available on volume driver mapping page")]
        [When(@"User verify add button is not available on volume driver mapping page")]
        [Then(@"User verify add button is not available on volume driver mapping page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on volume driver mapping page");
            VolumeDriverMappingPage.VerifyAddButtonIsNotAvailable();
        }
        [Given(@"User verify export option is available on volume driver mapping page")]
        [When(@"User verify export option is available on volume driver mapping page")]
        [Then(@"User verify export option is available on volume driver mapping page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on volume driver mapping page");
            VolumeDriverMappingPage.VerifyExportOptionIsAvailable();
        }

        [Given(@"User verify delete button is not available on volume driver mapping page in  ""([^""]*)""")]
        [When(@"User verify delete button is not available on volume driver mapping page in  ""([^""]*)""")]
        [Then(@"User verify delete button is not available on volume driver mapping page in  ""([^""]*)""")]
        public void VerifyDeleteButtonIsNotAvailable(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on volume driver mapping page in " + volumeDriverMappingName);
            VolumeDriverMappingPage.VerifyDeleteButtonIsNotAvailable(volumeDriverMappingName);
        }
        [Given(@"User verify details are not editable on volume driver mapping page")]
        [When(@"User verify details are not editable on volume driver mapping page")]
        [Then(@"User verify details are not editable on volume driver mapping page")]
        public void VerifyDetailsAreNotEditable()
        {
            LogWriter.WriteLog("Executing Step User verify details are not editable on volume driver mapping page");
            VolumeDriverMappingPage.VerifyDetailsAreNotEditable();
        }
        [Given(@"User select the department ""([^""]*)"" on volume driver mapping page")]
        [When(@"User select the department ""([^""]*)"" on volume driver mapping page")]
        [Then(@"User select the department ""([^""]*)"" on volume driver mapping page")]
        public void UserSelectTheDepartment(string departmentValue)
        {
            LogWriter.WriteLog("Executing Step User select the department " + departmentValue + "on volume driver mapping page");
            VolumeDriverMappingPage.SelectTheDepartment(departmentValue);
        }

        [Given(@"User create new VolumeDriverMapping with below input")]
        [When(@"User create new VolumeDriverMapping with below input")]
        [Then(@"User create new VolumeDriverMapping with below input")]
        public void ThenUserCreateNewVolumeDriverMappingWithBelowInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new VolumeDriverMapping with below input" + inputData);
            VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput(inputData);
        }


    }
}
