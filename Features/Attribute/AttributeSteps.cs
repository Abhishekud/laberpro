using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.shared.util;

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

    }
}
