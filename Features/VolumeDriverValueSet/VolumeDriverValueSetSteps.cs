using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.Features.Department;
using LaborPro.Automation.Features.LocationMapping;
using LaborPro.Automation.Features.Locations;
using LaborPro.Automation.Features.UnitOfMeasure;
using LaborPro.Automation.Features.VolumeDriver;
using LaborPro.Automation.Features.VolumeDriverValue;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.util;
using TechTalk.SpecFlow.Assist;

namespace LaborPro.Automation.Features.VolumeDriverValueSet
{
    [Binding]
    public class VolumeDriverValueSetSteps
    {
        [Given(@"User verify new volume driver value set popup")]
        [When(@"User verify new volume driver value set popup")]
        [Then(@"User verify new volume driver value set popup")]
        public void VerifyNewVolumeDriverValueSetPopup()
        {
            LogWriter.WriteLog("Executing Step User verify new volume driver value set popup");
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.ClickOnNewVolumeDriverValueSet();
            VolumeDriverValueSetPage.VerifyVolumeDriverValueSetPopup();
        }
        [Given(@"User verify validation message ""([^""]*)"" on volume driver value set popup")]
        [When(@"User verify validation message ""([^""]*)"" on volume driver value set popup")]
        [Then(@"User verify validation message ""([^""]*)"" on volume driver value set popup")]
        public void VerifyValidationMessage(string message)
        {
            LogWriter.WriteLog("Executing Step User verify validation message: " + message + " on volume driver value set popup");
            VolumeDriverValueSetPage.VerifyAddVolumeDriverValueSetErrorMessage(message);
        }
        [Given(@"User verify created volume driver value set ""([^""]*)""")]
        [When(@"User verify created volume driver value set ""([^""]*)""")]
        [Then(@"User verify created volume driver value set ""([^""]*)""")]
        public void VerifyVolumeDriverValueSet(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing Step User verify volume driver value set by name" + volumeDriverValueSet);
            VolumeDriverValueSetPage.IgnoreImportErrorMessage();
            VolumeDriverValueSetPage.VerifyVolumeDriverValueSet(DataCache.Read(volumeDriverValueSet));
        }
  
        [Given(@"User delete volume driver value set ""([^""]*)""")]
        [When(@"User delete volume driver value set ""([^""]*)""")]
        [Then(@"User delete volume driver value set ""([^""]*)""")]
        public void DeleteVolumeDriverValueSetByName(string volumeDriverValueSetRecord)
        {
            LogWriter.WriteLog("Executing Step User delete volume driver value set by name" + volumeDriverValueSetRecord);
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.DeleteCreatedVolumeDriverValueSet(DataCache.Read(volumeDriverValueSetRecord));
        }
        [Given(@"User verify export option on volume driver values page")]
        [When(@"User verify export option on volume driver values page")]
        [Then(@"User verify export option on volume driver values page")]
        public void SelectExportOptionOnVolumeDriverValuesPage()
        {
            LogWriter.WriteLog("Executing Step User select export option on volume driver values page");
            VolumeDriverValueSetPage.SelectExportOption();
        }
        [Given(@"User verify created volume driver values")]
        [When(@"User verify created volume driver values")]
        [Then(@"User verify created volume driver values")]
        public void VerifyLocationDepartmentVolumeDriver(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User verify location department volume driver in volume driver value page " + inputData);
            var VolumeDriverValuesRecord = inputData.CreateInstance<VolumeDriverValuesRecord>();
            LocationPage.ClickOnProfilingTab();
            VolumeDriverValuePage.ClickOnVolumeDriverValueTab();
            VolumeDriverValueSetPage.SelectTheVolumeDriverValueSet(DataCache.Read(VolumeDriverValuesRecord.VolumeDriverValueSet));
            VolumeDriverValueSetPage.VerifyLocationDepartmentVolumeDriverInVolumeDriverValue(VolumeDriverValuesRecord);
        }
        [Given(@"User add volume driver value set without name")]
        [When(@"User add volume driver value set without name")]
        [Then(@"User add volume driver value set without name")]
        public void AddVolumeDriverValueSetWithoutName()
        {
            LogWriter.WriteLog("Executing User add volume driver value set without name");
            VolumeDriverValueSetPage.WaitForLoadingSpinnerInvisible();
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.ClickOnNewVolumeDriverValueSet();
            VolumeDriverValueSetPage.ClickOnSaveButton(); 
        }
        [Given(@"User add new volume driver value set")]
        [When(@"User add new volume driver value set")]
        [Then(@"User add new volume driver value set")]
        public void AddNewVolumeDriverValueSet(Table inputData)
        {
            LogWriter.WriteLog("Executing User User add new volume driver value set " + inputData);
            var volumeDriverValuesRecord = inputData.CreateInstance<VolumeDriverValuesRecord>();
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.DownloadVolumeDriverValueTemplate();
            VolumeDriverValueSetPage.AddRecordToCsv(volumeDriverValuesRecord, SeleniumDriver.CsvFile);
            VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInput(volumeDriverValuesRecord.VolumeDriverValueSet);
            VolumeDriverValueSetPage.ImportTheVolumeDriverValueUpdatedFile();
            VolumeDriverValueSetPage.ClickOnSaveButton();
        }
        [Given(@"User verify delete button is disabled in default volume driver value set ""([^""]*)""")]
        [When(@"User verify delete button is disabled in default volume driver value set ""([^""]*)""")]
        [Then(@"User verify delete button is disabled in default volume driver value set ""([^""]*)""")]
        public void VerifyDeleteButtonIsDisabled(string record)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is disabled in default volume driver value set " + record);
            VolumeDriverValueSetPage.WaitForLoadingSpinnerInvisible();
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.SelectDefaultVolumeDriverValueSet(record);
            VolumeDriverValueSetPage.VerifyDeleteButtonIsDisabledForDefault();
        }
        [Given(@"User add new volume driver value set for duplication ""([^""]*)""")]
        [When(@"User add new volume driver value set for duplication ""([^""]*)""")]
        [Then(@"User add new volume driver value set for duplication ""([^""]*)""")]
        public void AddVolumeDriverValueSetForDuplication(string duplicateRecord)
        {
            LogWriter.WriteLog("Executing Step User add new volume driver value set for duplication ");
            VolumeDriverValueSetPage.WaitForLoadingSpinnerInvisible();
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.AddVolumeDriverValueSetDuplicateRecord(DataCache.Read(duplicateRecord));
            VolumeDriverValueSetPage.ImportTheVolumeDriverValueUpdatedFile();
            VolumeDriverValueSetPage.ClickOnSaveButton();
        }
        [Given(@"User add new volume driver value set without file ""([^""]*)""")]
        [When(@"User add new volume driver value set without file ""([^""]*)""")]
        [Then(@"User add new volume driver value set without file ""([^""]*)""")]
        public void AddNewVolumeDriverValueSetWithoutFile(string record)
        {
            LogWriter.WriteLog("Executing Step User add new volume driver value set without file " + record);
            VolumeDriverValueSetPage.WaitForLoadingSpinnerInvisible();
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInput(record);
            VolumeDriverValueSetPage.ClickOnSaveButton();
        }

        [Given(@"User setup prerequisites for volume driver value set")]
        [When(@"User setup prerequisites for volume driver value set")]
        [Then(@"User setup prerequisites for volume driver value set")]
        public void CreatePrerequisitesForVolumeDriverValueSet(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User setup prerequisites for volume driver value set " + inputData);
            var prerequisites = inputData.CreateInstance<VolumeDriverValueSetPrerequisites>();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            DepartmentsPage.ClickOnDepartment();
            VolumeDriverValueSetPage.AddNewDepartmentWithGivenInput(prerequisites.Department);
            UnitsOfMeasurePage.ClickOnUnitOfMeasure();
            UnitsOfMeasurePage.SelectCreatedDepartment(DataCache.Read(prerequisites.Department));
            VolumeDriverValueSetPage.AddUnitOfMeasureWihGivenInput(prerequisites);
            VolumeDriverPage.ClickOnVolumeDriver();
            VolumeDriverValueSetPage.AddNewVolumeDriverWithGivenInput(prerequisites.VolumeDriver, prerequisites.Department);
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            VolumeDriverValueSetPage.AddNewLocationWithGivenInput(prerequisites.Location);
            LocationMappingPage.MapsCreatedDepartmentAndLocation(DataCache.Read(prerequisites.Location), DataCache.Read(prerequisites.Department));
        }

        [Given(@"User verify volume driver value set ""([^""]*)"" not available")]
        [When(@"User verify volume driver value set ""([^""]*)"" not available")]
        [Then(@"User verify volume driver value set ""([^""]*)"" not available")]
        public void VerifyVolumeDriverValueSetNotAvailable(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing Step User verify volume driver value set " + volumeDriverValueSet + " not available ");
            VolumeDriverValueSetPage.VerifyVolumeDriverValueSetNotAvailable(volumeDriverValueSet);
        }

        [When(@"User delete prerequisite records for volume driver value set")]
        public void DeletePrerequisiteForVolumeDriverValueSet(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User delete prerequisite records for volume driver value set " + inputData);
            var prerequisites = inputData.CreateInstance<VolumeDriverValueSetPrerequisites>();
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationPage.DeleteCreatedLocation(DataCache.Read(prerequisites.Location));
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            UnitsOfMeasurePage.ClickOnUnitOfMeasure();
            UnitsOfMeasurePage.SelectCreatedDepartment(DataCache.Read(prerequisites.Department));
            UnitsOfMeasurePage.DeleteCreatedUnitOfMeasureByName(DataCache.Read(prerequisites.UnitsOfMeasure));
            VolumeDriverPage.ClickOnVolumeDriver();
            VolumeDriverPage.DeleteCreatedVolumeDriver(DataCache.Read(prerequisites.VolumeDriver));
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.DeleteDepartmentIfExist(DataCache.Read(prerequisites.Department));
        }

    }
}
