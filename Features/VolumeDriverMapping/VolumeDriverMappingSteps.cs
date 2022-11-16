using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.Features.Department;
using LaborPro.Automation.Features.UnitOfMeasure;
using LaborPro.Automation.Features.VolumeDriver;
using LaborPro.Automation.shared.util;
using TechTalk.SpecFlow.Assist;

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
        [Then(@"User verify add button is not available in department ""([^""]*)"" on volume driver mapping page")]
        [When(@"User verify add button is not available in department ""([^""]*)"" on volume driver mapping page")]
        [Given(@"User verify add button is not available in department ""([^""]*)"" on volume driver mapping page")]
        public void VerifyAddButtonIsNotAvailable(string departmentName)
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available in department " + departmentName + " on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.SelectTheDepartment(DataCache.Read(departmentName));
            VolumeDriverMappingPage.VerifyAddButtonIsNotAvailable();
        }

        [Given(@"User verify export option is available on volume driver mapping page")]
        [When(@"User verify export option is available on volume driver mapping page")]
        [Then(@"User verify export option is available on volume driver mapping page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyExportOptionIsAvailable();
        }

        [Given(@"User verify delete button is not available on volume driver mapping page in  ""([^""]*)""")]
        [When(@"User verify delete button is not available on volume driver mapping page in  ""([^""]*)""")]
        [Then(@"User verify delete button is not available on volume driver mapping page in  ""([^""]*)""")]
        public void VerifyDeleteButtonIsNotAvailable(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on volume driver mapping page in " + volumeDriverMappingName);
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyDeleteButtonIsNotAvailable(DataCache.Read(volumeDriverMappingName));
        }
        [Given(@"User verify details are not editable on volume driver mapping page")]
        [When(@"User verify details are not editable on volume driver mapping page")]
        [Then(@"User verify details are not editable on volume driver mapping page")]
        public void VerifyDetailsAreNotEditable()
        {
            LogWriter.WriteLog("Executing Step User verify details are not editable on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
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
        public void CreateNewVolumeDriverMappingWithBelowInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new VolumeDriverMapping with below input" + inputData);
            VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput(inputData);
        }
        [When(@"User setup prerequisites for volume driver mapping")]
        [Then(@"User setup prerequisites for volume driver mapping")]
        [Given(@"User setup prerequisites for volume driver mapping")]
        public void SetupPrerequisitesForVolumeDriverMapping(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User setup prerequisites for volume driver mapping" + inputData);
            var prerequisites = inputData.CreateInstance<VolumeDriverMapping>();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.AddNewDepartmentWithGivenInput(prerequisites.Department);
            UnitsOfMeasurePage.ClickOnUnitOfMeasure();
            UnitsOfMeasurePage.SelectCreatedDepartment(DataCache.Read(prerequisites.Department));
            UnitsOfMeasurePage.AddUnitOfMeasureWihGivenInput(prerequisites.UnitsOfMeasure);
            VolumeDriverPage.ClickOnVolumeDriver();
            VolumeDriverPage.AddNewVolumeDriverWithGivenInput(prerequisites.VolumeDriver, DataCache.Read(prerequisites.Department));
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput(DataCache.Read(prerequisites.VolumeDriver), DataCache.Read(prerequisites.UnitsOfMeasure));
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            VolumeDriverMappingPage.ClickOnVolumeDriverSet();
            VolumeDriverMappingPage.AddNewVolumeDriverMappingSet(prerequisites.VolumeDriverMappingSet);
        }
        [When(@"User delete prerequisite records for volume driver mapping")]
        [Then(@"User delete prerequisite records for volume driver mapping")]
        [Given(@"User delete prerequisite records for volume driver mapping")]
        public void DeletePrerequisiteRecordsForVolumeDriverMapping(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User delete prerequisite records for volume driver mapping " + inputData);
            var prerequisites = inputData.CreateInstance<VolumeDriverMapping>();
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            VolumeDriverMappingPage.DeleteVolumeDriverMappingSetIfExist(DataCache.Read(prerequisites.VolumeDriverMappingSet));
            VolumeDriverMappingPage.DeleteVolumeDriverMappingIfExist(DataCache.Read(prerequisites.VolumeDriver));
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            UnitsOfMeasurePage.ClickOnUnitOfMeasure();
            UnitsOfMeasurePage.SelectCreatedDepartment(DataCache.Read(prerequisites.Department));
            UnitsOfMeasurePage.DeleteUnitOfMeasureIfExist(DataCache.Read(prerequisites.UnitsOfMeasure));
            VolumeDriverPage.ClickOnVolumeDriver();
            VolumeDriverPage.DeleteVolumeDriverIfExist(DataCache.Read(prerequisites.VolumeDriver));
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.DeleteDepartmentIfExist(DataCache.Read(prerequisites.Department));
        }
        [Then(@"User verify add button is not available in ""([^""]*)"" on volume driver mappings page")]
        [When(@"User verify add button is not available in ""([^""]*)"" on volume driver mappings page")]
        [Given(@"User verify add button is not available in ""([^""]*)"" on volume driver mappings page")]
        public void VerifyAddButtonIsNotAvailableOnVolumeDriverMappingsPage(string department)
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available in " + department + " on volume driver mappings page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.SelectTheDepartment(DataCache.Read(department));
            VolumeDriverMappingPage.VerifyAddButtonIsNotPresent();
        }
        [Then(@"User verify edit volume driver mapping sidebar is available in ""([^""]*)""")]
        [When(@"User verify edit volume driver mapping sidebar is available in ""([^""]*)""")]
        [Given(@"User verify edit volume driver mapping sidebar is available in ""([^""]*)""")]
        public void VerifyEditVolumeDriverMappingSidebarIsAvailable(string volumeDriverMapping)
        {
            LogWriter.WriteLog("Executing Step User verify edit volume driver mapping sidebar is available in " + volumeDriverMapping);
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyEditVolumeDriverMappingSidebarIsAvailable(DataCache.Read(volumeDriverMapping));
        }
        [Then(@"User verify save button is not available in ""([^""]*)"" on volume driver mapping page")]
        [When(@"User verify save button is not available in ""([^""]*)"" on volume driver mapping page")]
        [Given(@"User verify save button is not available in ""([^""]*)"" on volume driver mapping page")]
        public void VerifySaveButtonIsNotAvailableInOnVolumeDriverMappingPage(string volumeDriverMapping)
        {
            LogWriter.WriteLog("Executing Step User verify save button is not available in " + volumeDriverMapping + " on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifySaveButtonIsNotAvailable(DataCache.Read(volumeDriverMapping));
        }
        [Then(@"User verify delete button and edit option is not available in ""([^""]*)"" on volume driver mapping page")]
        [When(@"User verify delete button and edit option is not available in ""([^""]*)"" on volume driver mapping page")]
        [Given(@"User verify delete button and edit option is not available in ""([^""]*)"" on volume driver mapping page")]
        public void VerifyDeleteButtonAndEditOptionIsNotAvailableInOnVolumeDriverMappingPage(string volumeDriverMapping)
        {
            LogWriter.WriteLog("Executing Step User verify delete button and edit option is not available in " + volumeDriverMapping + " on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyDeleteButtonAndEditOptionIsNotAvailable(DataCache.Read(volumeDriverMapping));
        }
        [Then(@"User verify volume driver mapping listing is available on volume driver mapping page")]
        [When(@"User verify volume driver mapping listing is available on volume driver mapping page")]
        [Given(@"User verify volume driver mapping listing is available on volume driver mapping page")]
        public void VerifyVolumeDriverMappingListingIsAvailableOnVolumeDriverMappingPage()
        {
            LogWriter.WriteLog("Executing Step User verify volume driver mapping listing is available on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyVolumeDriverMappingListingIsAvailable();
        }
        [Then(@"User verify volume driver mapping listing edit option is not available on volume driver mapping page")]
        [When(@"User verify volume driver mapping listing edit option is not available on volume driver mapping page")]
        [Given(@"User verify volume driver mapping listing edit option is not available on volume driver mapping page")]
        public void VerifyVolumeDriverMappingListingEditOptionIsNotAvailableOnVolumeDriverMappingPage()
        {
            LogWriter.WriteLog("Executing Step User verify volume driver mapping listing edit option is not available on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyVolumeDriverMappingListingEditOptionIsNotAvailable();
        }
        [Then(@"User verify department ""([^""]*)"" is available on volume driver mapping page")]
        [When(@"User verify department ""([^""]*)"" is available on volume driver mapping page")]
        [Given(@"User verify department ""([^""]*)"" is available on volume driver mapping page")]
        public void VerifyDepartmentIsAvailableOnVolumeDriverMappingPage(string departmentName)
        {
            LogWriter.WriteLog("Executing Step User verify department " + departmentName + " is available on volume driver mapping page");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyDepartmentIsAvailable(DataCache.Read(departmentName));
        }

        [When(@"User add volume driver mapping set without name")]
        [Then(@"User add volume driver mapping set without name")]
        [Given(@"User add volume driver mapping set without name")]
        public void AddVolumeDriverMappingSetWithoutName()
        {
            LogWriter.WriteLog("Executing Step User add volume driver mapping set without name");
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.ClickOnVolumeDriverSet();
            VolumeDriverMappingPage.ClickOnSaveButton();
        }

        [Then(@"User verify validation message ""([^""]*)"" on volume driver mapping set popup")]
        [Given(@"User verify validation message ""([^""]*)"" on volume driver mapping set popup")]
        [When(@"User verify validation message ""([^""]*)"" on volume driver mapping set popup")]
        public void VerifyValidationMessageOnVolumeDriverMappingSetPopup(string message)
        {
            LogWriter.WriteLog("Executing Step User verify validation message " + message + " on volume driver mapping set popup");
            AllowancePage.VerifyAddAllowanceErrorMessage(message);
        }

        [Then(@"User verify created volume driver mapping set ""([^""]*)""")]
        [Given(@"User verify created volume driver mapping set ""([^""]*)""")]
        [When(@"User verify created volume driver mapping set ""([^""]*)""")]
        public void VerifyCreatedVolumeDriverMappingSet(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing Step User verify created volume driver mapping set " + volumeDriverMappingName);
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMappingSet(DataCache.Read(volumeDriverMappingName));
        }

        [Then(@"User verify created volume driver and units of measure are available in ""([^""]*)""")]
        [Given(@"User verify created volume driver and units of measure are available in ""([^""]*)""")]
        [When(@"User verify created volume driver and units of measure are available in ""([^""]*)""")]
        public void VerifyCreatedVolumeDriverAndUnitsOfMeasureAreAvailable(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing Step User verify created volume driver and units of measure are available in " + volumeDriverName);
            NavigatesToTheVolumeDriverMappingTab();
            VolumeDriverMappingPage.VerifyCreatedVolumeDriverMapping(DataCache.Read(volumeDriverName));
        }


    }
}
