using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.Features.Department;
using LaborPro.Automation.Features.LocationMapping;
using LaborPro.Automation.Features.Locations;
using LaborPro.Automation.shared.util;
using TechTalk.SpecFlow.Assist;

namespace LaborPro.Automation.Features.Attribute
{
    [Binding]
    public class AttributeSteps
    {
        [When(@"User navigates to the attribute tab")]
        [Given(@"User navigates to the attribute tab")]
        [Then(@"User navigates to the attribute tab")]
        public void UserNavigatesToAttributeTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the attribute tab");
            AttributePage.CloseAttributeForm();
            AttributePage.ClickOnProfilingTab();
            AttributePage.ClickOnAttributeTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();

        }

        [When(@"User add new attribute using below input")]
        [Given(@"User add new attribute using below input")]
        [Then(@"User add new attribute using below input")]
        public void AddAttributeWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User add new attribute using below input-" + inputData);
            AttributePage.AddAttributeWihGivenInput(inputData);
        }

        [Given(@"Verify Validation Message:""([^""]*)""")]
        [When(@"Verify Validation Message:""([^""]*)""")]
        [Then(@"Verify Validation Message:""([^""]*)""")]
        public void VerifyValidationMessage(string message)
        {
            LogWriter.WriteLog("Executing Step:Verify Validation Message:" + message);
            AttributePage.VerifyAddAttributeErrorMessage(message);
        }

        [When(@"User click cancel Button")]
        [Given(@"User click cancel Button")]
        [Then(@"User click cancel Button")]
        public void UserClickCancelButton()
        {
            LogWriter.WriteLog("Executing Step: User click cancel Button");
            AttributePage.CloseAttributeForm();
        }

        [When(@"User verify created attribute name ""([^""]*)""")]
        [Given(@"User verify created attribute name ""([^""]*)""")]
        [Then(@"User verify created attribute name ""([^""]*)""")]
        public void UserVerifyCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing Step: User verify created attribute name" + attributeName);
            AttributePage.VerifyCreatedAttribute(attributeName);
        }

        [When(@"User delete created attribute:""([^""]*)""")]
        [Given(@"User delete created attribute:""([^""]*)""")]
        [Then(@"User delete created attribute:""([^""]*)""")]
        public void DeleteCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing Step: User delete created attribute:" + attributeName);
            AttributePage.DeleteCreatedAttribute(attributeName);
        }

        [Then(@"User select the Department ""([^""]*)""")]
        public void SelectDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing Step: User select the Department" + departmentName);
            AttributePage.SelectTheDepartment(departmentName);
        }

        [Then(@"Verify selected Department ""([^""]*)""")]
        public void VerifySelectedDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing Step: Verify selected Department" + departmentName);
            AttributePage.VerifyTheDepartment(departmentName);
        }

        [Given(@"User delete attribute ""([^""]*)"" if exist")]
        [When(@"User delete attribute ""([^""]*)"" if exist")]
        [Then(@"User delete attribute ""([^""]*)"" if exist")]
        public void UserDeleteAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing Step: User delete created attribute by name" + attributeName);
            AttributePage.DeleteAttributeIfExist(attributeName);
        }
        [Then(@"User verify add button is not present in attribute module")]
        public void ThenUserVerifyAddButtonIsNotPresentInAttributeModule()
        {
            LogWriter.WriteLog("Executing Step: User verify add button is not present in attribute module");
            AttributePage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify click on export icon verify all options displayed in attribute module")]
        public void ThenUserVerifyClickOnExportIconVerifyAllOptionsDisplayedInAttributeModule()
        {
            LogWriter.WriteLog("Executing Step: User verify click on export icon verify all options displayed in attribute module");
            AttributePage.VerifyClickOnExportIcon();
        }

        [When(@"User click on export icon in attribute module")]
        public void WhenUserClickOnExportIconInAttributeModule()
        {
            LogWriter.WriteLog("Executing Step:User click on export icon in attribute module");
            AttributePage.ClickOnExportIcon();
        }

        [Then(@"User verify the dialog box asking for file name for attribute module")]
        public void ThenUserVerifyTheDialogBoxAskingForFileNameForAttributeModule()
        {
            LogWriter.WriteLog("Executing Step: User verify the dialog box asking for file name for attribute module");
            AttributePage.VerifyExportAttributeDialogueBox();

        }

        [Then(@"User select download attribute import template in attribute module")]
        public void ThenUserSelectDownloadAttributeImportTemplateInAttributeModule()
        {
            LogWriter.WriteLog("Executing Step: User select download attribute import template in attribute module ");
            AttributePage.ClickOnDownloadAttributeImportTemplate();
        }

        [Then(@"User verify attribute downloaded file ""([^""]*)""")]
        public void ThenUserVerifyAttributeDownloadedFile(string fileName)
        {
            LogWriter.WriteLog("Executing Step: User verify attribute downloaded file " + fileName);
            AttributePage.VerifyFileDownloadInAttribute(fileName);
        }

        [Then(@"User select download all locations attribute import template in attribute module")]
        public void ThenUserSelectDownloadAllLocationsAttributeImportTemplateInAttributeModule()
        {
            LogWriter.WriteLog("Executing Step: User select download all locations attribute import template in attribute module ");
            AttributePage.ClickOnDownloadLocationAttributeImportTemplate();
        }

        [Then(@"user verify edit button is not present in attribute module")]
        public void ThenUserVerifyEditButtonIsNotPresentInAttributeModule()
        {
            LogWriter.WriteLog("Executing Step: user verify edit button is not present in attribute module");
            AttributePage.VerifyEditButtonIsNotPresent();
        }
        [Then(@"User select export attribute import template in attribute template")]
        public void ThenUserSelectExportAttributeImportTemplateInAttributeTemplate()
        {
            LogWriter.WriteLog("Executing Step: User select export attribute import template in attribute template");
            AttributePage.ClickOnExportAttributeIcon();
        }

        
        [When(@"User setup prerequisites for attribute")]
        [Then(@"User setup prerequisites for attribute")]
        [Given(@"User setup prerequisites for attribute")]
        public void SetupPrerequisitesForAttribute(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User setup prerequisites for attribute " + inputData);
            var prerequisites = inputData.CreateInstance<AttributeValuesRecord>();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            DepartmentsPage.ClickOnDepartment();
            AttributePage.AddNewDepartmentWithGivenInput(prerequisites.Department);
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            AttributePage.AddNewLocationWithGivenInput(prerequisites.Location);
            LocationMappingPage.MapsCreatedDepartmentAndLocation(DataCache.Read(prerequisites.Location), DataCache.Read(prerequisites.Department));
            UserNavigatesToAttributeTab();
            AttributePage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            AttributePage.CreateAttribute(prerequisites.Attribute);
        }
        [When(@"User delete prerequisite records for attribute")]
        [Given(@"User delete prerequisite records for attribute")]
        [Then(@"User delete prerequisite records for attribute")]
        public void DeletePrerequisiteRecordsForAttribute(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User delete prerequisite records for attribute " + inputData);
            var prerequisites = inputData.CreateInstance<AttributeValuesRecord>();
            LocationPage.ClickOnProfilingTab();
            LocationPage.ClickOnLocationsTab();
            LocationPage.ClearAllFilter();
            LocationPage.KeepRecordUnSort();
            LocationPage.DeleteCreatedLocation(DataCache.Read(prerequisites.Location));
            UserNavigatesToAttributeTab();
            AttributePage.SelectTheDepartment(DataCache.Read(prerequisites.Department));
            AttributePage.DeleteAttributeIfExist(DataCache.Read(prerequisites.Attribute));
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            DepartmentsPage.ClickOnDepartment();
            DepartmentsPage.DeleteDepartmentIfExist(DataCache.Read(prerequisites.Department));
        }
        [Then(@"User verify add button is not available on attribute page")]
        [When(@"User verify add button is not available on attribute page")]
        [Given(@"User verify add button is not available on attribute page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step: User verify add button is not available on attribute page");
            UserNavigatesToAttributeTab();
            AttributePage.VerifyAddButtonIsNotAvailable();
        }
        [Then(@"User verify attribute listing is available on attribute page")]
        [When(@"User verify attribute listing is available on attribute page")]
        [Given(@"User verify attribute listing is available on attribute page")]
        public void VerifyAttributeListingIsAvailable()
        {
            LogWriter.WriteLog("Executing Step: User verify attribute listing is available on attribute page");
            UserNavigatesToAttributeTab();
            AttributePage.VerifyAttributeListingIsAvailable();
        }
        [Then(@"User verify edit button is not available in ""([^""]*)"" on attribute page")]
        [When(@"User verify edit button is not available in ""([^""]*)"" on attribute page")]
        [Given(@"User verify edit button is not available in ""([^""]*)"" on attribute page")]
        public void VerifyEditButtonIsNotAvailable(string department)
        {
            LogWriter.WriteLog("Executing Step: User verify edit button is not available in " + department + " on attribute page");
            UserNavigatesToAttributeTab();
            AttributePage.SelectTheDepartment(DataCache.Read(department));
            AttributePage.VerifyEditButtonIsNotAvailable();
        }
        [Then(@"User verify checkboxes are disabled in ""([^""]*)"" on attribute page")]
        [When(@"User verify checkboxes are disabled in ""([^""]*)"" on attribute page")]
        [Given(@"User verify checkboxes are disabled in ""([^""]*)"" on attribute page")]
        public void VerifyCheckboxesAreDisabledOnAttributePage(string department)
        {
            LogWriter.WriteLog("Executing Step: User verify checkboxes are disabled in " + department + " on attribute page");
            UserNavigatesToAttributeTab();
            AttributePage.SelectTheDepartment(DataCache.Read(department));
            AttributePage.VerifyCheckboxesAreDisabled();
        }

        [Then(@"User verify added location ""([^""]*)"" is available on attribute page")]
        [When(@"User verify added location ""([^""]*)"" is available on attribute page")]
        [Given(@"User verify added location ""([^""]*)"" is available on attribute page")]
        public void VerifyAddedLocationIsAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing Step: User verify added location " + locationName + " is available on attribute page");
            UserNavigatesToAttributeTab();
            AttributePage.VerifyAddedLocationIsAvailable(DataCache.Read(locationName));

        }
    }
}



