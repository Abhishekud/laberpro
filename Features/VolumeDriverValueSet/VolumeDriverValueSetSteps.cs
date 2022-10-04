using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.Features.Attribute;
using LaborPro.Automation.Features.Characteristic;
using LaborPro.Automation.Features.Department;
using LaborPro.Automation.Features.LocationMapping;
using LaborPro.Automation.Features.Locations;
using LaborPro.Automation.Features.Standards;
using LaborPro.Automation.Features.UnitOfMeasure;
using LaborPro.Automation.Features.VolumeDriver;
using LaborPro.Automation.Features.VolumeDriverMapping;
using LaborPro.Automation.Features.VolumeDriverValue;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.util;

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
        [Given(@"User verify volume driver value set by name ""([^""]*)""")]
        [When(@"User verify volume driver value set by name ""([^""]*)""")]
        [Then(@"User verify volume driver value set by name ""([^""]*)""")]
        public void VerifyVolumeDriverValueSet(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing Step User verify volume driver value set by name" + volumeDriverValueSet);
            VolumeDriverValueSetPage.IgnoreImportErrorMessage();
            VolumeDriverValueSetPage.VerifyVolumeDriverValueSet(DataCache.Read(volumeDriverValueSet));
        }
  
        [Given(@"User delete volume driver value set by name ""([^""]*)""")]
        [When(@"User delete volume driver value set by name ""([^""]*)""")]
        [Then(@"User delete volume driver value set by name ""([^""]*)""")]
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

        [Given(@"Department ""([^""]*)"" exists")]
        [When(@"Department ""([^""]*)"" exists")]
        [Then(@"Department ""([^""]*)"" exists")]
        public void GivenDepartmentExists(string department)
        {
            LogWriter.WriteLog("Executing Step Department " + department + " exists ");
            DepartmentsPage.CloseDepartmentForm();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            DepartmentsPage.ClickOnDepartment();
            VolumeDriverValueSetPage.AddNewDepartmentWithGivenInputIfNotExist(department);
        }
        [Given(@"Attribute with below input exists")]
        [When(@"Attribute with below input exists")]
        [Then(@"Attribute with below input exists")]
        public void GivenAttributeWithBelowInputExists(Table inputData)
        {
            LogWriter.WriteLog("Executing Step Attribute with below input exists " + inputData);            
            AttributePage.CloseAttributeForm();
            AttributePage.ClickOnProfilingTab();
            AttributePage.ClickOnAttributeTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            AttributePage.SelectTheDepartment(DataCache.Read(dictionary["Department"]));
            VolumeDriverValueSetPage.AddAttributeWihGivenInput(inputData);
        }
        [Given(@"Characterstics set ""([^""]*)"" in department ""([^""]*)"" exists")]
        [When(@"Characterstics set ""([^""]*)"" in department ""([^""]*)"" exists")]
        [Then(@"Characterstics set ""([^""]*)"" in department ""([^""]*)"" exists")]
        public void GivenCharactersticsSetInDepartmentExists(string charactersticSet, string department)
        {
            LogWriter.WriteLog("Executing Step Charactertics set " + charactersticSet + " department " + department + " exists ");
            CharacteristicsPage.CloseCharacteristicForm();
            CharacteristicsPage.ClickOnStandardTab();
            CharacteristicsPage.ClickOnCharacteristicTab();
            AttributePage.SelectTheDepartment(DataCache.Read(department));
            CharacteristicsPage.ClickOnCharacteristicSet();
            VolumeDriverValueSetPage.AddNewCharacteristicWithGivenInput(charactersticSet);
            CharacteristicsPage.CloseCharacteristicDetailSideBar();
            LocationMappingPage.Refresh();
        }
        [Given(@"Standard with below input exists")]
        [When(@"Standard with below input exists")]
        [Then(@"Standard with below input exists")]
        public void GivenStandardWithBelowInputExists(Table inputData)
        {
            LogWriter.WriteLog("Executing Step Standard with below input exists " + inputData);
            var dictionary = Util.ConvertToDictionary(inputData);
            StandardsPage.CloseStandardsForm();
            AllowancePage.ClickOnStandardTab();
            StandardsPage.ClickOnStandardsTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            VolumeDriverValueSetPage.AddStandardsWihGivenInput(inputData);
            AllowancePage.ClickOnPreviousLink();
        }
        [Given(@"Units Of Measure with below input exists")]
        [When(@"Units Of Measure with below input exists")]
        [Then(@"Units Of Measure with below input exists")]
        public void GivenUnitsOfMeasureWithBelowInputExists(Table inputData)
        {
            LogWriter.WriteLog("Executing Step Units Of Measure with below input exists " + inputData);
            var dictionary = Util.ConvertToDictionary(inputData);
            var departmentValue = DataCache.Read(dictionary["Department"]);
            DepartmentsPage.CloseDepartmentForm();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            UnitsOfMeasurePage.ClickOnUnitOfMeasure();
            UnitsOfMeasurePage.SelectCreatedDepartment(departmentValue);
            VolumeDriverValueSetPage.AddUnitOfMeasureWihGivenInput(inputData);
        }
        [Given(@"Standard Element with below input exists")]
        [When(@"Standard Element with below input exists")]
        [Then(@"Standard Element with below input exists")]
        public void GivenStandardElementWithBelowInputExists(Table inputData)
        {
            LogWriter.WriteLog("Executing Step Standard Element with below input exists " + inputData);
            var dictionary = Util.ConvertToDictionary(inputData);
            var standard = DataCache.Read(dictionary["Standard"]);
            var standardElementType = dictionary["StandardElementType"];
            StandardsPage.CloseStandardsForm();
            AllowancePage.ClickOnStandardTab();
            StandardsPage.ClickOnStandardsTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            StandardsPage.ClearAllFilter();
            StandardsPage.SearchStandard(standard);
            StandardsPage.SelectStandard(standard);
            StandardsPage.ClickOnNewStandardElement();
            StandardsPage.SelectElementType(standardElementType);
            VolumeDriverValueSetPage.AddStandardElementWithGivenInput(inputData);
            AllowancePage.ClickOnPreviousLink();
        }
        [Given(@"Location ""([^""]*)"" exists")]
        [When(@"Location ""([^""]*)"" exists")]
        [Then(@"Location ""([^""]*)"" exists")]
        public void GivenLocationExists(string location)
        {
            LogWriter.WriteLog("Executing Step Location " + location + " exists");
            LocationPage.CloseLocationForm();
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            VolumeDriverValueSetPage.AddNewLocationWithGivenInput(location);
        }
        [Given(@"Mapping with ""([^""]*)"" and ""([^""]*)"" exists")]
        [When(@"Mapping with ""([^""]*)"" and ""([^""]*)"" exists")]
        [Then(@"Mapping with ""([^""]*)"" and ""([^""]*)"" exists")]
        public void GivenMappingWithAndExists(string location, string department)
        {
            LogWriter.WriteLog("Executing Step Mapping with " + location +  " and "+ department + " exists ");
            var locationValue = DataCache.Read(location);
            var departmentValue = DataCache.Read(department);
            LocationMappingPage.MapsCreatedDepartmentAndLocation(locationValue, departmentValue);
        }
        [Given(@"VolumeDriverMappingSet ""([^""]*)"" in department ""([^""]*)"" exists")]
        [When(@"VolumeDriverMappingSet ""([^""]*)"" in department ""([^""]*)"" exists")]
        [Then(@"VolumeDriverMappingSet ""([^""]*)"" in department ""([^""]*)"" exists")]
        public void GivenVolumeDriverMappingSetInDepartmentExists(string volumeDriverMappingSet, string department)
        {
            LogWriter.WriteLog("Executing Step VolumeDriverMappingSet " + volumeDriverMappingSet + " in department "+department+ "exists");
            var departmentValue = DataCache.Read(department);
            VolumeDriverMappingPage.CloseVolumeDriverMappingForm();
            VolumeDriverMappingPage.ClickOnProfilingTab();
            VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab();
            AttributePage.SelectTheDepartment(departmentValue);
            VolumeDriverMappingPage.ClickOnVolumeDriverSet();
            VolumeDriverValueSetPage.AddNewVolumeDriverMappingSetWithGivenInput(volumeDriverMappingSet);
        }
        [Given(@"Volume Driver ""([^""]*)"" in department ""([^""]*)"" exists")]
        [When(@"Volume Driver ""([^""]*)"" in department ""([^""]*)"" exists")]
        [Then(@"Volume Driver ""([^""]*)"" in department ""([^""]*)"" exists")]
        public void GivenVolumeDriverInDepartmentExists(string volumeDriver, string department)
        {
            LogWriter.WriteLog("Executing Step Volume Driver "+volumeDriver+ " in department " + department + " exists ");
            var departmentValue = DataCache.Read(department);
            VolumeDriverPage.CloseVolumeDriverForm();
            VolumeDriverPage.ClickOnStandardTab();
            VolumeDriverPage.ClickOnListManagementTab();
            VolumeDriverPage.ClickOnVolumeDriver();
            VolumeDriverValueSetPage.AddNewVolumeDriverWithGivenInput(volumeDriver,departmentValue);
        }
        [Given(@"Volume Driver Mapping with below input exists")]
        [When(@"Volume Driver Mapping with below input exists")]
        [Then(@"Volume Driver Mapping with below input exists")]
        public void GivenVolumeDriverMappingWithBelowInputExists(Table inputData)
        {
            LogWriter.WriteLog("Executing Step Volume Driver Mapping with below input should exist " + inputData);
            VolumeDriverMappingPage.CloseVolumeDriverMappingForm();
            VolumeDriverMappingPage.ClickOnProfilingTab();
            VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab();
            AttributePage.SelectTheDepartment(DataCache.Read("Test Department"));
            VolumeDriverMappingPage.ClickOnVolumeDriverMapping();
            VolumeDriverValueSetPage.AddNewVolumeDriverMappingWithGivenInput(inputData);
        }
        [Given(@"Location Mapping ""([^""]*)"" and ""([^""]*)"" exists")]
        [When(@"Location Mapping ""([^""]*)"" and ""([^""]*)"" exists")]
        [Then(@"Location Mapping ""([^""]*)"" and ""([^""]*)"" exists")]
        public void GivenLocationMappingAndExists(string locationMapping, string charactersticsSet)
        {
            LogWriter.WriteLog("Executing Step Location Mapping " + locationMapping + " and "+ charactersticsSet + " exists ");
            var locationMappingValue = DataCache.Read(locationMapping);
            var charactersticsSetValue = DataCache.Read(charactersticsSet);
            LocationMappingPage.CloseLocationDriverMappingForm();
            LocationMappingPage.ClickOnProfilingTab();
            LocationMappingPage.ClickOnLocationMappingTab();
            AttributePage.SelectTheDepartment(DataCache.Read("Test Department"));
            LocationMappingPage.SelectTheLocation(DataCache.Read("Test Location"));
            LocationMappingPage.Refresh();
            LocationMappingPage.CloseLocationDriverMappingForm();
            LocationMappingPage.ClickOnProfilingTab();
            LocationMappingPage.ClickOnLocationMappingTab();
            AttributePage.SelectTheDepartment(DataCache.Read("Test Department"));
            LocationMappingPage.SelectTheLocation(DataCache.Read("Test Location"));
            VolumeDriverValueSetPage.AddNewLocationMappingWithGivenInput(locationMappingValue, charactersticsSetValue);
        }
        [Given(@"User verify location department volume driver in volume driver value page")]
        [When(@"User verify location department volume driver in volume driver value page")]
        [Then(@"User verify location department volume driver in volume driver value page")]
        public void VerifyLocationDepartmentVolumeDriver(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User verify location department volume driver in volume driver value page " + inputData);
            LocationPage.ClickOnProfilingTab();
            VolumeDriverValuePage.ClickOnVolumeDriverValueTab();
            VolumeDriverValueSetPage.SelectTheVolumeDriverValueSet(DataCache.Read("Test VolumeDriverValueSet"));
            VolumeDriverValueSetPage.VerifyLocationDepartmentVolumeDriverInVolumeDriverValue(inputData);
        }
        [Given(@"User add volume driver value set without name")]
        [When(@"User add volume driver value set without name")]
        [Then(@"User add volume driver value set without name")]
        public void AddVolumeDriverValueSetWithoutName()
        {
            LogWriter.WriteLog("Executing User add volume driver value set without name");
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.ClickOnNewVolumeDriverValueSet();
            VolumeDriverValueSetPage.ClickOnSaveButton(); 
        }
        [Given(@"User add new volume driver value set ""([^""]*)""")]
        [When(@"User add new volume driver value set ""([^""]*)""")]
        [Then(@"User add new volume driver value set ""([^""]*)""")]
        public void AddNewVolumeDriverValueSet(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing User User add new volume driver value set " + volumeDriverValueSet);
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.DownloadVolumeDriverValueTemplate();
            VolumeDriverValueSetPage.AddRecordToCsv(DataCache.Read("Test Location")," ",
                DataCache.Read("Test Department"),DataCache.Read("Test VolumeDriver"),
                "2",SeleniumDriver.CsvFile);
            VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInput(volumeDriverValueSet);
            VolumeDriverValueSetPage.ImportTheVolumeDriverValueUpdatedFile();
            VolumeDriverValueSetPage.ClickOnSaveButton();
        }
        [Given(@"User verify delete button is disabled in default volume driver value set ""([^""]*)""")]
        [When(@"User verify delete button is disabled in default volume driver value set ""([^""]*)""")]
        [Then(@"User verify delete button is disabled in default volume driver value set ""([^""]*)""")]
        public void VerifyDeleteButtonIsDisabled(string record)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is disabled in default volume driver value set " + record);
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.SelectDefaultVolumeDriverValueSet(record);
            VolumeDriverValueSetPage.VerifyDeleteButtonIsDisabledForDefault();
        }
        [Given(@"User delete created records with below input")]
        [When(@"User delete created records with below input")]
        [Then(@"User delete created records with below input")]
        public void DeleteCreatedRecords(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User delete created records with below input " + inputData);
            var dictionary = Util.ConvertToDictionary(inputData);
            LocationPage.CloseLocationForm();
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationPage.DeleteCreatedLocation(DataCache.Read(dictionary["Location"]));
            VolumeDriverMappingPage.CloseVolumeDriverMappingForm();
            VolumeDriverMappingPage.ClickOnProfilingTab();
            VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab();
            AttributePage.SelectTheDepartment(DataCache.Read(dictionary["Department"]));
            VolumeDriverMappingPage.DeleteCreatedVolumeDriverMapping(DataCache.Read(dictionary["VolumeDriver"]));
            VolumeDriverPage.CloseVolumeDriverForm();
            VolumeDriverPage.ClickOnStandardTab();
            VolumeDriverPage.ClickOnListManagementTab();
            VolumeDriverPage.ClickOnVolumeDriver();
            VolumeDriverPage.DeleteCreatedVolumeDriver(DataCache.Read(dictionary["VolumeDriver"]));
            StandardsPage.CloseStandardsForm();
            AllowancePage.ClickOnStandardTab();
            StandardsPage.ClickOnStandardsTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            StandardsPage.ClearAllFilter();
            StandardsPage.SearchStandard(DataCache.Read(dictionary["Standard"]));
            StandardsPage.SelectStandard(DataCache.Read(dictionary["Standard"]));
            StandardsPage.DeleteCreatedStandard();
            DepartmentsPage.CloseDepartmentForm();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            UnitsOfMeasurePage.ClickOnUnitOfMeasure();
            UnitsOfMeasurePage.SelectCreatedDepartment(DataCache.Read(dictionary["Department"]));
            UnitsOfMeasurePage.DeleteUnitOfMeasureIfExist(DataCache.Read(dictionary["UnitsOfMeasure"]));
            AttributePage.CloseAttributeForm();
            AttributePage.ClickOnProfilingTab();
            AttributePage.ClickOnAttributeTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AttributePage.SelectTheDepartment(DataCache.Read(dictionary["Department"]));
            AttributePage.DeleteAttributeIfExist(DataCache.Read(dictionary["Attribute"]));
            DepartmentsPage.CloseDepartmentForm();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.DeleteDepartmentIfExist(DataCache.Read(dictionary["Department"]));

        }
        [Given(@"User add new volume driver value set for duplication ""([^""]*)""")]
        [When(@"User add new volume driver value set for duplication ""([^""]*)""")]
        [Then(@"User add new volume driver value set for duplication ""([^""]*)""")]
        public void AddVolumeDriverValueSetForDuplication(string duplicateRecord)
        {
            LogWriter.WriteLog("Executing Step User add new volume driver value set for duplication ");
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
        public void UserAddNewVolumeDriverValueSetWithoutFile(string record)
        {
            LogWriter.WriteLog("Executing Step User add new volume driver value set without file " + record);
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInput(record);
            VolumeDriverValueSetPage.ClickOnSaveButton();
        }
    }
}
