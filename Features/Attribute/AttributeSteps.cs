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
            AllowancesPage.WaitForAllowanceAlertCloseIfAny();
        
        }

        [When(@"User add new attribute using below input")]
        [Given(@"User add new attribute using below input")]
        [Then(@"User add new attribute using below input")]
        public void AddAttributeWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step:User add new attribute using below input-" + inputData);
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
            LogWriter.WriteLog("Exceuting Step: User click cancel Button");
            AttributePage.CloseAttributeForm();
        }

        [When(@"User verify created attribute name ""([^""]*)""")]
        [Given(@"User verify created attribute name ""([^""]*)""")]
        [Then(@"User verify created attribute name ""([^""]*)""")]
        public void UserVerifyCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing Step:User verify created attribute name" + attributeName);
            AttributePage.VerifyCreatedAttribute(attributeName);
        }

        [When(@"User delete created attribute:""([^""]*)""")]
        [Given(@"User delete created attribute:""([^""]*)""")]
        [Then(@"User delete created attribute:""([^""]*)""")]
        public void DeleteCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing Step:User delete created attribute:" + attributeName);
            AttributePage.DeleteCreatedAttribute(attributeName);
        }

        [Then(@"User select the Department ""([^""]*)""")]
        public void SelectDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing Step:User select the Department" + departmentName);
            AttributePage.SelectTheDepartment(departmentName);
        }

        [Then(@"Verify selected Department ""([^""]*)""")]
        public void VerifySelectedDepartment(string departmentName)
        {
            LogWriter.WriteLog("Exceuting Step: Verify selected Department" + departmentName);
            AttributePage.VerifyTheDepartment(departmentName);
        }

        [Given(@"User delete attribute ""([^""]*)"" if exist")]
        [When(@"User delete attribute ""([^""]*)"" if exist")]
        [Then(@"User delete attribute ""([^""]*)"" if exist")]
        public void UserDeleteAttribute(String attributeName)
        {
            LogWriter.WriteLog("Executing Step User delete created attribute by name" + attributeName);
            AttributePage.DeleteAttributeIfExist(attributeName);
        }

    }
}
